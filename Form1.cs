using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Http;
using System.Security.Principal;
using System.Reflection;
using System.Text.Json.Nodes;
using System.Text.Json;
using digirom.Properties;


namespace digirom
{
    public partial class Form_Main : Form
    {
        private static readonly HttpClient client = new HttpClient();
        int time_c = 0;
        String acom = "";
        String api_key = "";
        String device_name = "";
        String digirom = "";
        public Form_Main()
        {
            InitializeComponent();

            btDisconnect.Enabled = false;
            tbInput.Enabled = false;
            btPatse.Enabled = false;
            btSend.Enabled = false;
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            tbApikey.Text = Settings.Default.apikey;
            tbDevicename.Text = Settings.Default.devicename;

            string[] ports = SerialPort.GetPortNames();
            if(ports.Length > 0 )
            {
                cbPort.Items.AddRange(ports);
                cbPort.SelectedIndex = 0;
            }
            if (ports.Contains(Settings.Default.comport))
            { 
                cbPort.SelectedItem = Settings.Default.comport;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.PortName = cbPort.Text;
                serialPort.BaudRate = 9600;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.Parity = Parity.None;
                serialPort.Open();

                tbOutput.AppendText("Connected on " + cbPort.Text);
                tbOutput.AppendText(Environment.NewLine);

                Settings.Default.comport = cbPort.Text;

                tbInput.Focus();

                cbPort.Enabled = false;
                btConnect.Enabled = false;
                btReload.Enabled = false;

                btConnectWifi.Enabled = false;

                btDisconnect.Enabled = true;
                tbInput.Enabled = true;
                btPatse.Enabled = true;
                btSend.Enabled = true;
                acom = "USB";
                Settings.Default.Save();
            }

            catch (Exception ex)
            {
                cbPort.Enabled = true;
                btConnect.Enabled = true;
                btReload.Enabled = true;

                btConnectWifi.Enabled = true;
                

                btDisconnect.Enabled = false;
                tbInput.Enabled = false;
                btPatse.Enabled = false;
                btSend.Enabled = false;
                acom = "";

                MessageBox.Show("Error :" + ex, "Cannot connect to select com port", MessageBoxButtons.OK);
                return;
            }

        }
        delegate void OutputUpdateDelegate(string data);

        private void OutputUpdateCallback(string data)
        {
            string newLog = $"{Environment.NewLine}{DateTime.Now:HH:mm:ss->:}{data}";
            tbOutput.Text += newLog;
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                String RecievedData;
                RecievedData = serialPort.ReadLine();
                if (!(RecievedData == ""))
                {
                    tbOutput.Invoke(new OutputUpdateDelegate(OutputUpdateCallback), RecievedData);
                }

            }
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("V");
                serialPort.Close();
            }

        }

        private void btDisconnect_Click(object sender, EventArgs e)
        {
            serialPort.WriteLine("V");
            serialPort.Close(); 
                
            cbPort.Enabled = true;
            btConnect.Enabled = true;
            btReload.Enabled = true;

            btDisconnect.Enabled = false;
            tbInput.Enabled = false;
            btPatse.Enabled = false;
            btSend.Enabled = false;

            btConnectWifi.Enabled = true;

        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if(acom == "USB")
            {
                tbInput.Text = tbInput.Text.Replace(" ", "");
                serialPort.WriteLine(tbInput.Text);
            } else if( acom == "WIFI")
            {
                if (tbApikey.Text != "" && tbDevicename.Text != "")
                {
                    digirom = tbInput.Text;
                    api_key = tbApikey.Text;
                    device_name = tbDevicename.Text;
                    Send_digirom();
                }

            }
        }

        private void btPatse_Click(object sender, EventArgs e)
        {
            tbInput.Text = Clipboard.GetText();
        }

        private void tb_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbInput.Text.Length > 0)
            {
                if (acom == "USB")
                {
                    tbInput.Text = tbInput.Text.Replace(" ", "");
                    serialPort.WriteLine(tbInput.Text);
                } else if(acom == "WIFI")
                {
                    if (tbApikey.Text != "" && tbDevicename.Text != "")
                    {
                        digirom = tbInput.Text;
                        api_key = tbApikey.Text;
                        device_name = tbDevicename.Text;
                        Send_digirom();
                    }

                }
            }
        }

        private void tbOutput_TextChanged(object sender, EventArgs e)
        {
            tbOutput.SelectionStart = tbOutput.Text.Length;
            tbOutput.ScrollToCaret();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tbApikey.Text != "" && tbDevicename.Text != "")
            {
                Settings.Default.apikey = tbApikey.Text;
                Settings.Default.devicename = tbDevicename.Text;
                Settings.Default.Save();
                MessageBox.Show("Save completed");
            }
        }

        private void btConnectWifi_Click(object sender, EventArgs e)
        {
            if (tbApikey.Text != "" && tbDevicename.Text != "")
            {
                Settings.Default.apikey = tbApikey.Text;
                Settings.Default.devicename = tbDevicename.Text;
                Settings.Default.Save();
                digirom = "V";
                api_key = tbApikey.Text;
                device_name = tbDevicename.Text;
                Send_digirom();
            }
        }

        private async void Send_digirom()
        {
            var values = new Dictionary<string, string>
            {
                { "api_key", api_key },
                { "device_name", device_name },
                { "application_uuid", "1783798759430213" },
                { "comment", "digirom_sender" },
                { "digirom", digirom }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://wificom.dev/api/v2/application/send_digirom", content);

            var responseString = await response.Content.ReadAsStringAsync();

            var output_c = JsonNode.Parse(responseString);

            values = new Dictionary<string, string>
            {
                { "api_key", api_key },
                { "device_name", device_name },
                { "application_uuid", "1783798759430213" }
            };

            content = new FormUrlEncodedContent(values);

            response = await client.PostAsync("https://wificom.dev/api/v2/application/last_output", content);

            responseString = await response.Content.ReadAsStringAsync();

            var output_d = JsonNode.Parse(responseString);
            if (output_d["last_online_ago_seconds"].GetValue<int>() > 5)
            {
                MessageBox.Show("WIFICOM not found\nlast available "+ output_d["last_online_ago_seconds"].ToString() +" sec ago", "Error");
                tbOutput.AppendText("Disconnected");
                tbOutput.AppendText(Environment.NewLine);

                tbInput.Enabled = false;
                btSend.Enabled = false;
                btPatse.Enabled = false;
                btConnectWifi.Text = "Connect";

                btSaveWifi.Enabled = true;
                tbApikey.Enabled = true;
                tbDevicename.Enabled = true;

                btConnect.Enabled = true;

                acom = "";
                timer.Stop();
            } else if (digirom == "V" && (output_c["device"]["last_code_sent_at"].ToString() == output_d["last_code_sent_at"].ToString()))
            {
                if (btConnectWifi.Text == "Connect")
                {
                    tbOutput.AppendText("Connected on WifiCOM");
                    tbOutput.AppendText(Environment.NewLine);

                    tbInput.Enabled = true;
                    btSend.Enabled = true;
                    btPatse.Enabled = true;
                    btConnectWifi.Text = "Disconnect";

                    btSaveWifi.Enabled = false;
                    tbApikey.Enabled = false;
                    tbDevicename.Enabled = false;

                    btConnect.Enabled = false;

                    acom = "WIFI";
                    timer.Start();
                }
                else
                {
                    tbOutput.AppendText("Disconnected");
                    tbOutput.AppendText(Environment.NewLine);

                    tbInput.Enabled = false;
                    btSend.Enabled = false;
                    btPatse.Enabled = false;
                    btConnectWifi.Text = "Connect";

                    btSaveWifi.Enabled = true;
                    tbApikey.Enabled = true;
                    tbDevicename.Enabled = true;

                    btConnect.Enabled = true;

                    acom = "";
                    timer.Stop();

                }
            } else if (output_c["device"]["last_code_sent_at"].ToString() == output_d["last_code_sent_at"].ToString())
            {
                tbOutput.AppendText("Send Digirom :" + digirom);
                tbOutput.AppendText(Environment.NewLine);
            }
        }

        private async void Get_Digirom()
        {
            var values = new Dictionary<string, string>
            {
                { "api_key", api_key },
                { "device_name", device_name },
                { "application_uuid", "1783798759430213" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://wificom.dev/api/v2/application/last_output", content);

            var responseString = await response.Content.ReadAsStringAsync();

            var output_d = JsonNode.Parse(responseString);
            
            try
            {
                if (output_d["last_output"].ToString() != null)
                {
                    string newLog = $"{Environment.NewLine}{DateTime.Now:HH:mm:ss->:}{output_d["last_output"].ToString()}";
                    tbOutput.AppendText(newLog);
                    tbOutput.AppendText(Environment.NewLine);
                }
                if(output_d["last_online_ago_seconds"].GetValue<int>() > 5)
                {
                    string newLog = $"{Environment.NewLine}{DateTime.Now:HH:mm:ss->:}{"WIFICOM not found last available "+ output_d["last_online_ago_seconds"].ToString() +" sec ago"}";
                    tbOutput.AppendText(newLog);
                    tbOutput.AppendText(Environment.NewLine);

                    tbOutput.AppendText("Disconnected");
                    tbOutput.AppendText(Environment.NewLine);

                    tbInput.Enabled = false;
                    btSend.Enabled = false;
                    btPatse.Enabled = false;
                    btConnectWifi.Text = "Connect";

                    btSaveWifi.Enabled = true;
                    tbApikey.Enabled = true;
                    tbDevicename.Enabled = true;

                    btConnect.Enabled = true;

                    acom = "";
                    timer.Stop();
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("NullReferenceException");
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ++time_c;
            if(time_c > 4)
            {
                time_c = 0;
                Get_Digirom();
            }
        }

        private void btReload_Click(object sender, EventArgs e)
        {
            cbPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length > 0)
            {
                cbPort.Items.AddRange(ports);
                cbPort.SelectedIndex = 0;
            }
            if (ports.Contains(Properties.Settings.Default.comport))
            {
                cbPort.SelectedItem = Properties.Settings.Default.comport;
            }
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:naynan.fb@gmail.com");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
