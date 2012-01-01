using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PADIBook.Utils;
using PADIBook.Server;
using System.Diagnostics;

namespace Server
{
    public partial class EnderecoForm : Form
    {
        public string AddressPort { set; get; }

        public EnderecoForm()
        {
            try
            {
                InitializeComponent();
                setComboBox.DataSource = (Config.Instance.ClientsConfiguration.Select(p => p.Name)).ToList<string>();
                setComboBox.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\r\n############\r\n#Stack Trace:  #\r\n############\r\n" + e);
                Process.GetCurrentProcess().Kill();
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!comboBox.Text.Equals(""))
            {
                try
                {
                    string serverName = comboBox.Text;
                    Config.Instance.ChooseClientSetOfReplicas(setComboBox.Text);

                    ServerConfig serverConfiguration = (Config.Instance.ServersConfiguration.Where(p => p.Name == comboBox.Text)).ToArray<ServerConfig>()[0];
                    List<string> replicas = new List<string>((from p in Config.Instance.ServersConfiguration
                                                              where p.Name.Equals(comboBox.Text) != true
                                                              select p.Address + ":" + p.Port + "/" + p.Name).ToList<string>());
                    AddressPort = serverConfiguration.Address + ":" + serverConfiguration.Port;

                    PADIBook.Server.Server serv;
                    if (includeChordNodeCheckBox.Checked)
                    {
                        if (chordNodeAddressTextBox.Text == "")
                        {
                            MessageBox.Show("Por favor insira um endereço para o nó do Chord.");
                            return;
                        }
                        serv = new PADIBook.Server.Server(serverConfiguration.Name, serverConfiguration.Address, serverConfiguration.Port, replicas, chordNodeAddressTextBox.Text, Int32.Parse(chordPortTextBox.Text));
                    }
                    else
                    {
                        serv = new PADIBook.Server.Server(serverConfiguration.Name, serverConfiguration.Address, serverConfiguration.Port, replicas);
                    }

                    ServerManager.Instance.RegisterServer(serv);
                    ServerManager.Instance.StartServer();
                    this.Close();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse port number.");
                }
            }
        }

        private void comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                StartButton_Click(sender, e);
            }
        }

        private void setComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox.DataSource = (Config.Instance.ClientsConfiguration[setComboBox.SelectedIndex].ServerConfigs.Select(p => p.Name)).ToList<string>();
            comboBox.SelectedIndex = 0;
        }

        private void includeChordNodeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (includeChordNodeCheckBox.Checked)
            {
                chordNodeAddressTextBox.Enabled = true;
                chordPortTextBox.Enabled = true;
            }
            else
            {
                chordNodeAddressTextBox.Enabled = false;
                chordPortTextBox.Enabled = false;
            }
        }
    }
}
