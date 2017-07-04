namespace ParkingSensors
{
    partial class Status
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Status));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.errorText = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Button();
            this.start_stop = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Sensor_5 = new System.Windows.Forms.Label();
            this.Sensor_4 = new System.Windows.Forms.Label();
            this.Sensor_3 = new System.Windows.Forms.Label();
            this.Sensor_2 = new System.Windows.Forms.Label();
            this.Sensor_1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort_ErrorReceived);
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // errorText
            // 
            this.errorText.AutoSize = true;
            this.errorText.Location = new System.Drawing.Point(13, 13);
            this.errorText.Name = "errorText";
            this.errorText.Size = new System.Drawing.Size(49, 13);
            this.errorText.TabIndex = 0;
            this.errorText.Text = "errorText";
            // 
            // Back
            // 
            this.Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Back.Location = new System.Drawing.Point(544, 242);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(75, 23);
            this.Back.TabIndex = 6;
            this.Back.Text = "BACK";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // start_stop
            // 
            this.start_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.start_stop.Location = new System.Drawing.Point(12, 242);
            this.start_stop.Name = "start_stop";
            this.start_stop.Size = new System.Drawing.Size(75, 23);
            this.start_stop.TabIndex = 7;
            this.start_stop.Text = "start_stop";
            this.start_stop.UseVisualStyleBackColor = true;
            this.start_stop.Visible = false;
            this.start_stop.Click += new System.EventHandler(this.start_stop_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 206);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Sensor_5
            // 
            this.Sensor_5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Sensor_5.AutoSize = true;
            this.Sensor_5.Location = new System.Drawing.Point(3, 178);
            this.Sensor_5.Name = "Sensor_5";
            this.Sensor_5.Size = new System.Drawing.Size(35, 13);
            this.Sensor_5.TabIndex = 5;
            this.Sensor_5.Text = "label1";
            // 
            // Sensor_4
            // 
            this.Sensor_4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Sensor_4.AutoSize = true;
            this.Sensor_4.Location = new System.Drawing.Point(3, 137);
            this.Sensor_4.Name = "Sensor_4";
            this.Sensor_4.Size = new System.Drawing.Size(35, 13);
            this.Sensor_4.TabIndex = 4;
            this.Sensor_4.Text = "label1";
            // 
            // Sensor_3
            // 
            this.Sensor_3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Sensor_3.AutoSize = true;
            this.Sensor_3.Location = new System.Drawing.Point(3, 96);
            this.Sensor_3.Name = "Sensor_3";
            this.Sensor_3.Size = new System.Drawing.Size(35, 13);
            this.Sensor_3.TabIndex = 3;
            this.Sensor_3.Text = "label1";
            // 
            // Sensor_2
            // 
            this.Sensor_2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Sensor_2.AutoSize = true;
            this.Sensor_2.Location = new System.Drawing.Point(3, 55);
            this.Sensor_2.Name = "Sensor_2";
            this.Sensor_2.Size = new System.Drawing.Size(35, 13);
            this.Sensor_2.TabIndex = 2;
            this.Sensor_2.Text = "label1";
            // 
            // Sensor_1
            // 
            this.Sensor_1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Sensor_1.AutoSize = true;
            this.Sensor_1.Location = new System.Drawing.Point(3, 14);
            this.Sensor_1.Name = "Sensor_1";
            this.Sensor_1.Size = new System.Drawing.Size(35, 13);
            this.Sensor_1.TabIndex = 1;
            this.Sensor_1.Text = "label1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.Sensor_4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Sensor_5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Sensor_2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Sensor_3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Sensor_1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(182, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(42, 206);
            this.tableLayoutPanel1.TabIndex = 6;
            this.tableLayoutPanel1.Visible = false;
            // 
            // Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 277);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.start_stop);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.errorText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Status";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Status_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Connection connectionReference;
        private int state = 0;

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Label errorText;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button start_stop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Sensor_5;
        private System.Windows.Forms.Label Sensor_4;
        private System.Windows.Forms.Label Sensor_3;
        private System.Windows.Forms.Label Sensor_2;
        private System.Windows.Forms.Label Sensor_1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}