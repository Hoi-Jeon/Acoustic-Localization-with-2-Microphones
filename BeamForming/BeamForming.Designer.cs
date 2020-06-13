namespace BeamForming
{
    partial class BeamForming
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cboPorts = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnSTOP = new System.Windows.Forms.Button();
            this.btnSTART = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssLBLstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLBLSpacer1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbNBytes = new System.Windows.Forms.ToolStripStatusLabel();
            this.srPort = new System.IO.Ports.SerialPort(this.components);
            this.cboVideo = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblVideoPort = new System.Windows.Forms.Label();
            this.chartBFM = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblSerialPort = new System.Windows.Forms.Label();
            this.tbFreq = new System.Windows.Forms.TextBox();
            this.lblFrq = new System.Windows.Forms.Label();
            this.lblMicSpacing = new System.Windows.Forms.Label();
            this.tbMicSpacing = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBFM)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPorts
            // 
            this.cboPorts.FormattingEnabled = true;
            this.cboPorts.Location = new System.Drawing.Point(5, 28);
            this.cboPorts.Name = "cboPorts";
            this.cboPorts.Size = new System.Drawing.Size(70, 21);
            this.cboPorts.TabIndex = 3;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(5, 53);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(70, 25);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(5, 81);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(70, 25);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnSTOP
            // 
            this.btnSTOP.Enabled = false;
            this.btnSTOP.Location = new System.Drawing.Point(5, 197);
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.Size = new System.Drawing.Size(70, 25);
            this.btnSTOP.TabIndex = 12;
            this.btnSTOP.Text = "STOP";
            this.btnSTOP.UseVisualStyleBackColor = true;
            this.btnSTOP.Click += new System.EventHandler(this.btnSTOP_Click);
            // 
            // btnSTART
            // 
            this.btnSTART.Enabled = false;
            this.btnSTART.Location = new System.Drawing.Point(5, 169);
            this.btnSTART.Name = "btnSTART";
            this.btnSTART.Size = new System.Drawing.Size(70, 25);
            this.btnSTART.TabIndex = 14;
            this.btnSTART.Text = "START";
            this.btnSTART.UseVisualStyleBackColor = true;
            this.btnSTART.Click += new System.EventHandler(this.btnSTART_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLBLstatus,
            this.tsLBLSpacer1,
            this.toolStripStatusLabel1,
            this.lbNBytes});
            this.statusStrip1.Location = new System.Drawing.Point(0, 369);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(617, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLBLstatus
            // 
            this.tssLBLstatus.Name = "tssLBLstatus";
            this.tssLBLstatus.Size = new System.Drawing.Size(79, 17);
            this.tssLBLstatus.Text = "Disconnected";
            // 
            // tsLBLSpacer1
            // 
            this.tsLBLSpacer1.Name = "tsLBLSpacer1";
            this.tsLBLSpacer1.Size = new System.Drawing.Size(356, 17);
            this.tsLBLSpacer1.Spring = true;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(142, 17);
            this.toolStripStatusLabel1.Text = "Number of data in buffer:";
            // 
            // lbNBytes
            // 
            this.lbNBytes.Name = "lbNBytes";
            this.lbNBytes.Size = new System.Drawing.Size(25, 17);
            this.lbNBytes.Text = "000";
            // 
            // srPort
            // 
            this.srPort.BaudRate = 115200;
            this.srPort.PortName = "COM3";
            this.srPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.srPort_DataReceived);
            // 
            // cboVideo
            // 
            this.cboVideo.FormattingEnabled = true;
            this.cboVideo.Location = new System.Drawing.Point(5, 144);
            this.cboVideo.Name = "cboVideo";
            this.cboVideo.Size = new System.Drawing.Size(70, 21);
            this.cboVideo.TabIndex = 16;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(5, 320);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(70, 25);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblVideoPort
            // 
            this.lblVideoPort.Location = new System.Drawing.Point(2, 126);
            this.lblVideoPort.Name = "lblVideoPort";
            this.lblVideoPort.Size = new System.Drawing.Size(70, 18);
            this.lblVideoPort.TabIndex = 18;
            this.lblVideoPort.Text = "Select video:";
            this.lblVideoPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chartBFM
            // 
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chartBFM.ChartAreas.Add(chartArea1);
            this.chartBFM.Location = new System.Drawing.Point(99, 9);
            this.chartBFM.Name = "chartBFM";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chartBFM.Series.Add(series1);
            this.chartBFM.Size = new System.Drawing.Size(506, 352);
            this.chartBFM.TabIndex = 20;
            this.chartBFM.Text = "chart1";
            // 
            // lblSerialPort
            // 
            this.lblSerialPort.Location = new System.Drawing.Point(2, 9);
            this.lblSerialPort.Name = "lblSerialPort";
            this.lblSerialPort.Size = new System.Drawing.Size(64, 18);
            this.lblSerialPort.TabIndex = 21;
            this.lblSerialPort.Text = "Serial port:";
            this.lblSerialPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbFreq
            // 
            this.tbFreq.Location = new System.Drawing.Point(5, 257);
            this.tbFreq.Name = "tbFreq";
            this.tbFreq.Size = new System.Drawing.Size(70, 20);
            this.tbFreq.TabIndex = 22;
            this.tbFreq.Text = "512";
            // 
            // lblFrq
            // 
            this.lblFrq.Location = new System.Drawing.Point(2, 238);
            this.lblFrq.Name = "lblFrq";
            this.lblFrq.Size = new System.Drawing.Size(70, 18);
            this.lblFrq.TabIndex = 23;
            this.lblFrq.Text = "Freq [Hz]:";
            this.lblFrq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMicSpacing
            // 
            this.lblMicSpacing.Location = new System.Drawing.Point(2, 277);
            this.lblMicSpacing.Name = "lblMicSpacing";
            this.lblMicSpacing.Size = new System.Drawing.Size(91, 18);
            this.lblMicSpacing.TabIndex = 24;
            this.lblMicSpacing.Text = "Spacing [mm]:";
            this.lblMicSpacing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbMicSpacing
            // 
            this.tbMicSpacing.Location = new System.Drawing.Point(5, 296);
            this.tbMicSpacing.Name = "tbMicSpacing";
            this.tbMicSpacing.Size = new System.Drawing.Size(70, 20);
            this.tbMicSpacing.TabIndex = 25;
            this.tbMicSpacing.Text = "150";
            // 
            // BeamForming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 391);
            this.Controls.Add(this.tbMicSpacing);
            this.Controls.Add(this.lblMicSpacing);
            this.Controls.Add(this.lblFrq);
            this.Controls.Add(this.tbFreq);
            this.Controls.Add(this.lblSerialPort);
            this.Controls.Add(this.lblVideoPort);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cboVideo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSTART);
            this.Controls.Add(this.btnSTOP);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cboPorts);
            this.Controls.Add(this.chartBFM);
            this.Name = "BeamForming";
            this.Text = "BeamForming -Tiva C series TM4C123GXL";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BeamForming_FormClosed);
            this.Load += new System.EventHandler(this.BeamForming_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBFM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnSTOP;
        private System.Windows.Forms.Button btnSTART;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssLBLstatus;
        private System.Windows.Forms.ToolStripStatusLabel tsLBLSpacer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbNBytes;
        private System.IO.Ports.SerialPort srPort;
        private System.Windows.Forms.ComboBox cboVideo;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblVideoPort;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBFM;
        private System.Windows.Forms.Label lblSerialPort;
        private System.Windows.Forms.TextBox tbFreq;
        private System.Windows.Forms.Label lblFrq;
        private System.Windows.Forms.Label lblMicSpacing;
        private System.Windows.Forms.TextBox tbMicSpacing;
    }
}

