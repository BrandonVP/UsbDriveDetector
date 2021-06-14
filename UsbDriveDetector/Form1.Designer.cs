namespace UsbDriveDetector
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.getUSB = new System.Windows.Forms.Button();
            this.clearlistbox = new System.Windows.Forms.Button();
            this.readComPort = new System.Windows.Forms.Button();
            this.sendSerial = new System.Windows.Forms.Button();
            this.openSerial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(808, 407);
            this.listBox1.TabIndex = 0;
            // 
            // getUSB
            // 
            this.getUSB.Location = new System.Drawing.Point(3, 416);
            this.getUSB.Name = "getUSB";
            this.getUSB.Size = new System.Drawing.Size(75, 23);
            this.getUSB.TabIndex = 1;
            this.getUSB.Text = "Find USB";
            this.getUSB.UseVisualStyleBackColor = true;
            this.getUSB.Click += new System.EventHandler(this.getUSB_Click);
            // 
            // clearlistbox
            // 
            this.clearlistbox.Location = new System.Drawing.Point(722, 416);
            this.clearlistbox.Name = "clearlistbox";
            this.clearlistbox.Size = new System.Drawing.Size(75, 23);
            this.clearlistbox.TabIndex = 2;
            this.clearlistbox.Text = "Clear";
            this.clearlistbox.UseVisualStyleBackColor = true;
            this.clearlistbox.Click += new System.EventHandler(this.clearlistbox_Click);
            // 
            // readComPort
            // 
            this.readComPort.Location = new System.Drawing.Point(84, 416);
            this.readComPort.Name = "readComPort";
            this.readComPort.Size = new System.Drawing.Size(75, 23);
            this.readComPort.TabIndex = 3;
            this.readComPort.Text = "Read Com";
            this.readComPort.UseVisualStyleBackColor = true;
            this.readComPort.Click += new System.EventHandler(this.readComPort_Click);
            // 
            // sendSerial
            // 
            this.sendSerial.Location = new System.Drawing.Point(377, 416);
            this.sendSerial.Name = "sendSerial";
            this.sendSerial.Size = new System.Drawing.Size(75, 23);
            this.sendSerial.TabIndex = 4;
            this.sendSerial.Text = "Run Test";
            this.sendSerial.UseVisualStyleBackColor = true;
            this.sendSerial.Click += new System.EventHandler(this.sendSerial_Click);
            // 
            // openSerial
            // 
            this.openSerial.Location = new System.Drawing.Point(296, 415);
            this.openSerial.Name = "openSerial";
            this.openSerial.Size = new System.Drawing.Size(75, 23);
            this.openSerial.TabIndex = 5;
            this.openSerial.Text = "Open Serial";
            this.openSerial.UseVisualStyleBackColor = true;
            this.openSerial.Click += new System.EventHandler(this.openSerial_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.openSerial);
            this.Controls.Add(this.sendSerial);
            this.Controls.Add(this.readComPort);
            this.Controls.Add(this.clearlistbox);
            this.Controls.Add(this.getUSB);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "USB Tool";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button getUSB;
        private System.Windows.Forms.Button clearlistbox;
        private System.Windows.Forms.Button readComPort;
        private System.Windows.Forms.Button sendSerial;
        private System.Windows.Forms.Button openSerial;
    }
}

