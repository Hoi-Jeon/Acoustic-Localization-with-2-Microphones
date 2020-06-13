using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;
using AForge.Video;
using AForge.Video.DirectShow;

namespace BeamForming
{
    public partial class BeamForming : Form
    {
        private const Int32 NFFT = 128;                     ///< Number of FFT
        private byte[] BufferPhase = new byte[NFFT * 2];    ///< Internal Buffer to buffer FFT signal (1 float = 4 bytes)
        private float[] Phase = new float[NFFT / 2];        ///< Converted a phase between ADC0 and ADC1

        static byte[] CMD_NO_CMD = { 0x00 };                ///< no command was actually send by serial connection
        static byte[] CMD_SEND_ADC = { 0x01 };              ///< Start sending ADC (Time domain) signal
        static byte[] CMD_STOP = { 0x02 };                  ///< Stop sending ADC|FFT signal
        static byte[] CMD_SEND_FFT = { 0x03 };              ///< Start sending FFT signal
        static byte[] CMD_SEND_PHASE = { 0x04 };            ///< Start sending a phase between ADC0 and ADC1 signals
        static byte[] CMD_DISCONNECT = { 0x0D };            ///< Disconnect serail connection to Tiva Board
        private byte[] CMD_CURRENT = CMD_NO_CMD;            ///< Current CMD

        private Int32 MinByte = 2;                          ///< Minimum numer of bytes to read at one time in serial port
        private Int32 idxBuffer = 0;                        ///< index of the last read element
        private Int32 NbytesToRead;                         ///< Numer of bytes to read at one time in serial port

        private Bitmap chartBackImage;                      ///< Backimage of C# chart
        private Int32 Freq;                                 ///< Beamforming frequency
        private Int32 IdxFreq;                              ///< Beamforming frequency index
        private Int32 dFreq = 32;                           ///< fixed in Tiva Launchpad (Fs / Nfft = 2048 / 128)
        private float MicSpacing;                           ///< Microphone spacing between two microphones

        FilterInfoCollection filterInfoCollection;          ///< Filter Info collection for AForge.Video.DirectShow
        VideoCaptureDevice videoCaptureDevice;              ///< Video capture device

        public BeamForming()
        {
            InitializeComponent();
        }

        private void BeamForming_Load(object sender, EventArgs e)
        {

            // Initialize Controls in GUI
            for (int n = -35; n <= 35; n++)
            {
                chartBFM.Series["Series1"].Points.AddXY(n, 1);
            }
            chartBFM.Titles.Add("Acoustic localization with two microphones");
            chartBFM.ChartAreas[0].AxisX.Title = "Angle [degree]";
            chartBFM.ChartAreas[0].AxisX.Minimum = -35;
            chartBFM.ChartAreas[0].AxisX.Maximum = 35;
            chartBFM.ChartAreas[0].AxisX.Interval = 5;
            chartBFM.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartBFM.ChartAreas[0].AxisY.Minimum = 0;
            chartBFM.ChartAreas[0].AxisY.Maximum = 1;
            chartBFM.ChartAreas[0].AxisY.Interval = 2;
            chartBFM.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Solid;
            chartBFM.ChartAreas[0].AxisY.MajorGrid.Interval = 2;
            chartBFM.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
                        
            chartBFM.ChartAreas[0].CursorX.LineColor = Color.Red;
            chartBFM.ChartAreas[0].CursorX.LineWidth = 5;
            chartBFM.ChartAreas[0].CursorX.LineDashStyle = ChartDashStyle.Solid;

            try
            {
                // List available video device
                filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo filterInfo in filterInfoCollection)
                cboVideo.Items.Add(filterInfo.Name);
                cboVideo.SelectedIndex = 0;
                videoCaptureDevice = new VideoCaptureDevice();

                // List available serial port names
                string[] ArrayComPortsNames = SerialPort.GetPortNames();
                int index = -1;
                string ComPortName = null;
                do
                {
                    index += 1;
                    cboPorts.Items.Add(ArrayComPortsNames[index]);
                }
                while (!((ArrayComPortsNames[index] == ComPortName) || (index == ArrayComPortsNames.GetUpperBound(0))));

                // Sort all available COM ports
                Array.Sort(ArrayComPortsNames);

                // Get the first COM port for the text in the ComboBox
                if (index == ArrayComPortsNames.GetUpperBound(0)) 
                    ComPortName = ArrayComPortsNames[0];

                // Select the first port name for the text of combobox
                cboPorts.Text = ArrayComPortsNames[0]; 

                // Set a frequency and Microphone spacing
                Freq = Convert.ToInt32(tbFreq.Text);
                IdxFreq = Freq / dFreq; // unit in Hz
                MicSpacing = Convert.ToSingle(tbMicSpacing.Text)*0.001f; // unit in meter
            }            

            catch (IndexOutOfRangeException err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void btnSTART_Click(object sender, EventArgs e)
        {
            // Start Video Capture
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboVideo.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();

            // Update the current command
            CMD_CURRENT = CMD_SEND_PHASE;
            srPort.Write(CMD_CURRENT, 0, 1);

            // Activate and deactivate buttons
            btnSTART.Enabled = false;
            btnSTOP.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            chartBackImage = (Bitmap)eventArgs.Frame.Clone();
            BeginInvoke(new EventHandler(UpdateVideos));
        }

        private void UpdateVideos(object sender, EventArgs e)
        {
            if (chartBFM.Images.Count != 0)
                chartBFM.Images.RemoveAt(0);

            chartBFM.Images.Add(new NamedImage("DynamicImage", chartBackImage));
            chartBFM.ChartAreas[0].BackImage = chartBFM.Images[0].Name;
            chartBFM.ChartAreas[0].BackImageWrapMode = ChartImageWrapMode.Scaled;
        }


        private void btnSTOP_Click(object sender, EventArgs e)
        {
            // Stop video capture device
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();

            // Update the current command
            CMD_CURRENT = CMD_STOP;
            srPort.Write(CMD_CURRENT, 0, 1);

            // Run out of all remaining received bytess
            while (srPort.BytesToRead > 0) { }

            // Activate and deactivate buttons
            btnSTART.Enabled = true;
            btnSTOP.Enabled = false;
            btnUpdate.Enabled = false;

            // Clean Serial port
            srPort.DiscardInBuffer();
            srPort.DiscardOutBuffer();

            // Reset counter index
            idxBuffer = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Open Serial port
            srPort.PortName = Convert.ToString(cboPorts.Text);
            srPort.ReceivedBytesThreshold = MinByte; // Minumum size of received bytes in Serial port
            srPort.Open();

            // Run out of all remaining received bytess
            while (srPort.BytesToRead > 0) { }

            // Update the current command
            CMD_CURRENT = CMD_STOP;
            srPort.Write(CMD_CURRENT, 0, 1);

            // Activate and deactivate buttons
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
            btnSTART.Enabled = true;
            btnSTOP.Enabled = false;
            btnUpdate.Enabled = false;

            // Change texts in the status bar
            tssLBLstatus.Text = srPort.PortName;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            // Update the current command
            CMD_CURRENT = CMD_STOP;
            srPort.Write(CMD_CURRENT, 0, 1);

            // Suspend 0.1 second, so the last serial command can be sent to TI Launchpad 100% securely
            System.Threading.Thread.Sleep(100); 

            // Close Serial port
            srPort.DiscardInBuffer();
            srPort.DiscardOutBuffer();
            srPort.Close();

            // Stop video capture device
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();

            // Activate and deactivate buttons
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnSTART.Enabled = false;
            btnSTOP.Enabled = false;
            btnUpdate.Enabled = false;

            // Change texts in the status bar
            tssLBLstatus.Text = "Disconnected";
            lbNBytes.Text = "0";
        }

        private void BeamForming_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Stop video capture device
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();

            // Close any thread still running in the background
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void srPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Get a number of read data from serial port
            NbytesToRead = srPort.BytesToRead;

            // Display a number of read data from serial port                
            this.BeginInvoke(new EventHandler(DisplayNbytesToRead));

            // Create a byte array for the data from serial port
            byte[] Buffer = new byte[NbytesToRead];
            srPort.Read(Buffer, 0, NbytesToRead);

            // Get a phase and Calculate an angle at the wished frequency               
            if (CMD_CURRENT == CMD_SEND_PHASE)
            {
                // Copy data in a buffer to the internal buffer
                for (int n = 0; n < NbytesToRead; n++)
                {
                    if (idxBuffer == NFFT * 2)
                    {
                        for (int i = 0; i < (NFFT / 2); i++)
                        {
                            // Convert 4 bytes into 1 floats
                            Phase[i] = BitConverter.ToSingle(BufferPhase, 4 * i);
                        }

                        // Display the read ADC signal to Chart
                        this.BeginInvoke(new EventHandler(DisplayMovingCursor));

                        // Reset the location of the last read element
                        idxBuffer = 0;
                    }

                    // Copy data into a temporary buffer
                    BufferPhase[idxBuffer] = Buffer[n];
                    // Increase the index of the last read element 
                    idxBuffer++;
                }
            }
        }

        private void DisplayMovingCursor(object sender, EventArgs e)
        {
            try
            {
                // Change a red cursor position with the phase input
                Double PhaseInDegree = 180 / (Math.PI) * Math.Asin(Phase[IdxFreq] * 343.1f / MicSpacing / Freq / (2 * Math.PI));
                chartBFM.ChartAreas[0].CursorX.SetCursorPosition(PhaseInDegree);
            }
            catch
            {

            }
        }

        private void DisplayNbytesToRead(object sender, EventArgs e)
        {
            try
            {
                lbNBytes.Text = NbytesToRead.ToString("000");
            }
            catch
            {

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Freq = Convert.ToInt32(tbFreq.Text);
            IdxFreq = Freq / dFreq; // unit in Hz
            MicSpacing = Convert.ToSingle(tbMicSpacing.Text) * 0.001f; // unit in meter
        }
    }
}
