using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSensors
{

    public partial class Status : Form
    {
        #region DrawingParameters
        const int width = 15;
        const int height = 30;
        const int heightOff = 4;

        int xPosition = 0;
        int yPosition = 0;

        const int xOffset = 20;
        const int yOffset = 2;
        #endregion
        
        public delegate void SensorUpdate(string[]rd2);
        public Status()
        {
            InitializeComponent();
        }

        public void Connect(string portName)
        {
            try
            {
                this.BackColor = System.Drawing.Color.LightGray;

                serialPort.PortName = portName;
                serialPort.Open();
                errorText.Text = "Port " + portName + " successfully opened.";
                start_stop.Text = "STOP";
                start_stop.Visible = true;
                tableLayoutPanel1.Visible = true;
                Sensor_1.Visible = true;
                Sensor_2.Visible = true;
                Sensor_3.Visible = true;
                Sensor_4.Visible = true;
                Sensor_5.Visible = true;
                pictureBox1.Visible = true;

                xPosition = tableLayoutPanel1.Location.X + Sensor_1.Location.X + tableLayoutPanel1.Size.Width + xOffset;
                yPosition = tableLayoutPanel1.Location.Y + Sensor_1.Location.Y + Sensor_1.Size.Height / 2 - height / 2;

                for (int i = 0; i < 5; i++)
                {
                    DrawIt(xPosition + xOffset * 0, yPosition + yOffset * 0 + 41 * i, width, height - heightOff * 0, Pens.Red);
                    DrawIt(xPosition + xOffset * 1, yPosition + yOffset * 1 + 41 * i, width, height - heightOff * 1, Pens.Red);
                    DrawIt(xPosition + xOffset * 2, yPosition + yOffset * 2 + 41 * i, width, height - heightOff * 2, Pens.Orange);
                    DrawIt(xPosition + xOffset * 3, yPosition + yOffset * 3 + 41 * i, width, height - heightOff * 3, Pens.Orange);
                    DrawIt(xPosition + xOffset * 4, yPosition + yOffset * 4 + 41 * i, width, height - heightOff * 4, Pens.Green);
                    DrawIt(xPosition + xOffset * 5, yPosition + yOffset * 5 + 41 * i, width, height - heightOff * 5, Pens.Green);
                }

            }
            catch
            {
                errorText.Text = "Error. Unable to connect.\nCheck connection";
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.Close();
                connectionReference.Show();
                this.Dispose();
            }
            catch
            {
                errorText.Text = "Error. Unable to close connection";
            }
        }

        private void Status_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch(e.CloseReason)
            {
                case CloseReason.UserClosing:
                    {
                        try
                        {
                            serialPort.Close();
                            connectionReference.Show();
                            this.Dispose();
                        }
                        catch
                        {
                            errorText.Text = "Error. Unable to close connection";
                        }
                        break;
                    }
            }
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string read;
            try
            {
                read = serialPort.ReadLine();
            }
            catch (Exception ex) {
                string filePath = @"..\Error.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
                return;
            }
            switch (state)
            {
                case 0:
                    {
                        if (read.Equals("ACK,\r"))
                        {
                            state += 1;
                            serialPort.Write("ACK,");
                            serialPort.DiscardInBuffer();
                        }
                        break;
                    }
                case 1:
                    {
                        string[] rd2 = read.Split(',');

                        if (rd2[0] == "START" && rd2[6] == "END\r")
                        {
                            setSensorData(rd2);
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }

        private void setSensorData(string[] rd2)
        {
            if (Sensor_1.InvokeRequired)
            {
                SensorUpdate s = new SensorUpdate(setSensorData);
                this.Invoke(s, new object[] { rd2 });
            }
            else
            {

                int[] sensor = new int[5];

                Sensor_1.Text = rd2[1] + " cm";
                Sensor_2.Text = rd2[2] + " cm";
                Sensor_3.Text = rd2[3] + " cm";
                Sensor_4.Text = rd2[4] + " cm";
                Sensor_5.Text = rd2[5] + " cm";

                for(int i = 0; i < 5; i++)
                {
                    Int32.TryParse(rd2[i+1], out sensor[i]);
                }

                #region DrawingSensorData
                for (int i = 0; i < 5; i++)
                {
                    if (sensor[i] <= 60 && sensor[i] >= 50)
                    {
                        FillIt(xPosition + xOffset * 5, yPosition + yOffset * 5 + 41 * i, width, height - heightOff * 5, Color.Green);
                        Unfill(xPosition + xOffset * 4 + 1, yPosition + yOffset * 4 + 41 * i + 1, width - 1, height - heightOff * 4 - 1);
                        Unfill(xPosition + xOffset * 3 + 1, yPosition + yOffset * 3 + 41 * i + 1, width - 1, height - heightOff * 3 - 1);
                        Unfill(xPosition + xOffset * 2 + 1, yPosition + yOffset * 2 + 41 * i + 1, width - 1, height - heightOff * 2 - 1);
                        Unfill(xPosition + xOffset * 1 + 1, yPosition + yOffset * 1 + 41 * i + 1, width - 1, height - heightOff * 1 - 1);
                        Unfill(xPosition + xOffset * 0 + 1, yPosition + yOffset * 0 + 41 * i + 1, width - 1, height - heightOff * 0 - 1);
                    }
                    else if (sensor[i] <= 50 && sensor[i] > 40)
                    {
                        FillIt(xPosition + xOffset * 5, yPosition + yOffset * 5 + 41 * i, width, height - heightOff * 5, Color.Green);
                        FillIt(xPosition + xOffset * 4, yPosition + yOffset * 4 + 41 * i, width, height - heightOff * 4, Color.Green);
                        Unfill(xPosition + xOffset * 3 + 1, yPosition + yOffset * 3 + 41 * i + 1, width - 1, height - heightOff * 3 - 1);
                        Unfill(xPosition + xOffset * 2 + 1, yPosition + yOffset * 2 + 41 * i + 1, width - 1, height - heightOff * 2 - 1);
                        Unfill(xPosition + xOffset * 1 + 1, yPosition + yOffset * 1 + 41 * i + 1, width - 1, height - heightOff * 1 - 1);
                        Unfill(xPosition + xOffset * 0 + 1, yPosition + yOffset * 0 + 41 * i + 1, width - 1, height - heightOff * 0 - 1);
                    }
                    else if (sensor[i] <= 40 && sensor[i] > 30)
                    {
                        FillIt(xPosition + xOffset * 5, yPosition + yOffset * 5 + 41 * i, width, height - heightOff * 5, Color.Green);
                        FillIt(xPosition + xOffset * 4, yPosition + yOffset * 4 + 41 * i, width, height - heightOff * 4, Color.Green);
                        FillIt(xPosition + xOffset * 3, yPosition + yOffset * 3 + 41 * i, width, height - heightOff * 3, Color.Orange);
                        Unfill(xPosition + xOffset * 2 + 1, yPosition + yOffset * 2 + 41 * i + 1, width - 1, height - heightOff * 2 - 1);
                        Unfill(xPosition + xOffset * 1 + 1, yPosition + yOffset * 1 + 41 * i + 1, width - 1, height - heightOff * 1 - 1);
                        Unfill(xPosition + xOffset * 0 + 1, yPosition + yOffset * 0 + 41 * i + 1, width - 1, height - heightOff * 0 - 1);
                    }
                    else if (sensor[i] <= 30 && sensor[i] > 20)
                    {
                        FillIt(xPosition + xOffset * 5, yPosition + yOffset * 5 + 41 * i, width, height - heightOff * 5, Color.Green);
                        FillIt(xPosition + xOffset * 4, yPosition + yOffset * 4 + 41 * i, width, height - heightOff * 4, Color.Green);
                        FillIt(xPosition + xOffset * 3, yPosition + yOffset * 3 + 41 * i, width, height - heightOff * 3, Color.Orange);
                        FillIt(xPosition + xOffset * 2, yPosition + yOffset * 2 + 41 * i, width, height - heightOff * 2, Color.Orange);
                        Unfill(xPosition + xOffset * 1 + 1, yPosition + yOffset * 1 + 41 * i + 1, width - 1, height - heightOff * 1 - 1);
                        Unfill(xPosition + xOffset * 0 + 1, yPosition + yOffset * 0 + 41 * i + 1, width - 1, height - heightOff * 0 - 1);
                    }
                    else if (sensor[i] <= 20 && sensor[i] > 10)
                    {
                        FillIt(xPosition + xOffset * 5, yPosition + yOffset * 5 + 41 * i, width, height - heightOff * 5, Color.Green);
                        FillIt(xPosition + xOffset * 4, yPosition + yOffset * 4 + 41 * i, width, height - heightOff * 4, Color.Green);
                        FillIt(xPosition + xOffset * 3, yPosition + yOffset * 3 + 41 * i, width, height - heightOff * 3, Color.Orange);
                        FillIt(xPosition + xOffset * 2, yPosition + yOffset * 2 + 41 * i, width, height - heightOff * 2, Color.Orange);
                        FillIt(xPosition + xOffset * 1, yPosition + yOffset * 1 + 41 * i, width, height - heightOff * 1, Color.Red);
                        Unfill(xPosition + xOffset * 0 + 1, yPosition + yOffset * 0 + 41 * i + 1, width - 1, height - heightOff * 0 - 1);
                    }
                    else if (sensor[i] <= 10 && sensor[i] >= 0)
                    {
                        FillIt(xPosition + xOffset * 5, yPosition + yOffset * 5 + 41 * i, width, height - heightOff * 5, Color.Green);
                        FillIt(xPosition + xOffset * 4, yPosition + yOffset * 4 + 41 * i, width, height - heightOff * 4, Color.Green);
                        FillIt(xPosition + xOffset * 3, yPosition + yOffset * 3 + 41 * i, width, height - heightOff * 3, Color.Orange);
                        FillIt(xPosition + xOffset * 2, yPosition + yOffset * 2 + 41 * i, width, height - heightOff * 2, Color.Orange);
                        FillIt(xPosition + xOffset * 1, yPosition + yOffset * 1 + 41 * i, width, height - heightOff * 1, Color.Red);
                        FillIt(xPosition + xOffset * 0, yPosition + yOffset * 0 + 41 * i, width, height - heightOff * 0, Color.Red);
                    }
                    else
                    {
                        Unfill(xPosition + xOffset * 5 + 1, yPosition + yOffset * 5 + 41 * i + 1, width - 1, height - heightOff * 5 - 1);
                        Unfill(xPosition + xOffset * 4 + 1, yPosition + yOffset * 4 + 41 * i + 1, width - 1, height - heightOff * 4 - 1);
                        Unfill(xPosition + xOffset * 3 + 1, yPosition + yOffset * 3 + 41 * i + 1, width - 1, height - heightOff * 3 - 1);
                        Unfill(xPosition + xOffset * 2 + 1, yPosition + yOffset * 2 + 41 * i + 1, width - 1, height - heightOff * 2 - 1);
                        Unfill(xPosition + xOffset * 1 + 1, yPosition + yOffset * 1 + 41 * i + 1, width - 1, height - heightOff * 1 - 1);
                        Unfill(xPosition + xOffset * 0 + 1, yPosition + yOffset * 0 + 41 * i + 1, width - 1, height - heightOff * 0 - 1);
                    }
                }
                #endregion
                
            }
        }

        private void serialPort_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
            start_stop.Visible = false;
            tableLayoutPanel1.Visible = false;
            Sensor_1.Visible = false;
            Sensor_2.Visible = false;
            Sensor_3.Visible = false;
            Sensor_4.Visible = false;
            Sensor_5.Visible = false;
            pictureBox1.Visible = false;

            errorText.Text = "Connection Error. Closing Serial Port: "+ serialPort.PortName+"\nERROR:\n";
            errorText.Text += e.ToString();
            try
            {
                serialPort.Close();
            }
            catch { return; }
        }

        private void start_stop_Click(object sender, EventArgs e)
        {
            if (start_stop.Text.Equals("START"))
            {
                start_stop.Text = "STOP";
                serialPort.Write("START,");
            }
            else if (start_stop.Text.Equals("STOP"))
                {
                    start_stop.Text = "START";
                    serialPort.Write("STOP,");
                }
        }

        private void DrawIt(int x, int y, int width, int height, Pen p)
        {
            System.Drawing.Graphics graphics = this.CreateGraphics();
            graphics.DrawRectangle(p, new Rectangle(x, y, width, height));
            graphics.Dispose();
        }

        private void FillIt(int x, int y, int width, int height, Color c)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(c);
            System.Drawing.Graphics graphics = this.CreateGraphics();
            graphics.FillRectangle(myBrush, new Rectangle(x, y, width, height));
            graphics.Dispose();
            myBrush.Dispose();
        }

        private void Unfill(int x, int y, int width, int height)
        { 
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.LightGray);
            System.Drawing.Graphics graphics = this.CreateGraphics();
            graphics.FillRectangle(myBrush, new Rectangle(x, y, width, height));
            graphics.Dispose();
            myBrush.Dispose();
        }
    }
}
