namespace digirom
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btDisconnect = new System.Windows.Forms.Button();
            this.btConnect = new System.Windows.Forms.Button();
            this.btReload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btConnectWifi = new System.Windows.Forms.Button();
            this.btSaveWifi = new System.Windows.Forms.Button();
            this.tbDevicename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbApikey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btSend = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.btPatse = new System.Windows.Forms.Button();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // cbPort
            // 
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(6, 23);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(117, 21);
            this.cbPort.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(180, 143);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btDisconnect);
            this.tabPage1.Controls.Add(this.btConnect);
            this.tabPage1.Controls.Add(this.btReload);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbPort);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(172, 117);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ACOM USB";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btDisconnect
            // 
            this.btDisconnect.Location = new System.Drawing.Point(6, 88);
            this.btDisconnect.Name = "btDisconnect";
            this.btDisconnect.Size = new System.Drawing.Size(160, 23);
            this.btDisconnect.TabIndex = 4;
            this.btDisconnect.Text = "Disconnect";
            this.btDisconnect.UseVisualStyleBackColor = true;
            this.btDisconnect.Click += new System.EventHandler(this.btDisconnect_Click);
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(6, 59);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(160, 23);
            this.btConnect.TabIndex = 3;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.button2_Click);
            // 
            // btReload
            // 
            this.btReload.Image = global::digirom.Properties.Resources.reload;
            this.btReload.Location = new System.Drawing.Point(129, 14);
            this.btReload.Name = "btReload";
            this.btReload.Size = new System.Drawing.Size(37, 37);
            this.btReload.TabIndex = 2;
            this.btReload.UseVisualStyleBackColor = true;
            this.btReload.Click += new System.EventHandler(this.btReload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial Port";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btConnectWifi);
            this.tabPage2.Controls.Add(this.btSaveWifi);
            this.tabPage2.Controls.Add(this.tbDevicename);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tbApikey);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(172, 117);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "WIFICOM";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btConnectWifi
            // 
            this.btConnectWifi.Location = new System.Drawing.Point(91, 88);
            this.btConnectWifi.Name = "btConnectWifi";
            this.btConnectWifi.Size = new System.Drawing.Size(75, 23);
            this.btConnectWifi.TabIndex = 6;
            this.btConnectWifi.Text = "Connect";
            this.btConnectWifi.UseVisualStyleBackColor = true;
            this.btConnectWifi.Click += new System.EventHandler(this.btConnectWifi_Click);
            // 
            // btSaveWifi
            // 
            this.btSaveWifi.Location = new System.Drawing.Point(7, 88);
            this.btSaveWifi.Name = "btSaveWifi";
            this.btSaveWifi.Size = new System.Drawing.Size(75, 23);
            this.btSaveWifi.TabIndex = 5;
            this.btSaveWifi.Text = "Save";
            this.btSaveWifi.UseVisualStyleBackColor = true;
            this.btSaveWifi.Click += new System.EventHandler(this.button5_Click);
            // 
            // tbDevicename
            // 
            this.tbDevicename.Location = new System.Drawing.Point(6, 62);
            this.tbDevicename.Name = "tbDevicename";
            this.tbDevicename.Size = new System.Drawing.Size(160, 20);
            this.tbDevicename.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Device Name";
            // 
            // tbApikey
            // 
            this.tbApikey.Location = new System.Drawing.Point(6, 23);
            this.tbApikey.Name = "tbApikey";
            this.tbApikey.Size = new System.Drawing.Size(160, 20);
            this.tbApikey.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "API Key";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btSend);
            this.groupBox1.Controls.Add(this.tbOutput);
            this.groupBox1.Controls.Add(this.btPatse);
            this.groupBox1.Controls.Add(this.tbInput);
            this.groupBox1.Location = new System.Drawing.Point(199, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 142);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Digirom";
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(7, 46);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(413, 23);
            this.btSend.TabIndex = 5;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.BackColor = System.Drawing.Color.White;
            this.tbOutput.Location = new System.Drawing.Point(7, 75);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(413, 61);
            this.tbOutput.TabIndex = 6;
            this.tbOutput.TextChanged += new System.EventHandler(this.tbOutput_TextChanged);
            // 
            // btPatse
            // 
            this.btPatse.Location = new System.Drawing.Point(360, 19);
            this.btPatse.Name = "btPatse";
            this.btPatse.Size = new System.Drawing.Size(60, 23);
            this.btPatse.TabIndex = 5;
            this.btPatse.Text = "Patse";
            this.btPatse.UseVisualStyleBackColor = true;
            this.btPatse.Click += new System.EventHandler(this.btPatse_Click);
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(7, 20);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(347, 20);
            this.tbInput.TabIndex = 0;
            this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_input_KeyDown);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(619, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "---------------------------------------------------------------------------------" +
    "-----------------------------------------------------------------------  Version" +
    " 0.2 beta1 [Naynan_TH]";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 174);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DigiROM Sender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btDisconnect;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btReload;
        private System.Windows.Forms.Button btConnectWifi;
        private System.Windows.Forms.Button btSaveWifi;
        private System.Windows.Forms.TextBox tbDevicename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbApikey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btPatse;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label4;
    }
}

