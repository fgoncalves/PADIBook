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

namespace Server
{
    public partial class ServerForm : Form
    {

        public ServerForm()
        {
            InitializeComponent();
            statusBox.ReadOnly = true;
            EnderecoForm formEndereco = new EnderecoForm();
            formEndereco.ShowDialog();
            this.Text += " @ " + formEndereco.AddressPort;         
        }

        public ServerForm(string clientId, string serverId)
        {
            InitializeComponent();
            statusBox.ReadOnly = true;
            string serverName = serverId;
            Config.Instance.ChooseClientSetOfReplicas(clientId);

            ServerConfig serverConfiguration = (Config.Instance.ServersConfiguration.Where(p => p.Name == serverId)).ToArray<ServerConfig>()[0];
            List<string> replicas = new List<string>((from p in Config.Instance.ServersConfiguration
                                                      where p.Name.Equals(serverId) != true
                                                      select p.Address + ":" + p.Port + "/" + p.Name).ToList<string>());
            this.Text += " @ " + serverConfiguration.Address + ":" + serverConfiguration.Port;
            PADIBook.Server.Server serv = new PADIBook.Server.Server(serverConfiguration.Name, serverConfiguration.Address, serverConfiguration.Port, replicas);
            ServerManager.Instance.RegisterServer(serv);
            ServerManager.Instance.StartServer();                
        }

        public ServerForm(string clientId, string serverId, string chordAddress, int chordPort)
        {
            InitializeComponent();
            statusBox.ReadOnly = true;
            string serverName = serverId;
            Config.Instance.ChooseClientSetOfReplicas(clientId);

            ServerConfig serverConfiguration = (Config.Instance.ServersConfiguration.Where(p => p.Name == serverId)).ToArray<ServerConfig>()[0];
            List<string> replicas = new List<string>((from p in Config.Instance.ServersConfiguration
                                                      where p.Name.Equals(serverId) != true
                                                      select p.Address + ":" + p.Port + "/" + p.Name).ToList<string>());
            this.Text += " @ " + serverConfiguration.Address + ":" + serverConfiguration.Port;
            PADIBook.Server.Server serv = new PADIBook.Server.Server(serverConfiguration.Name, serverConfiguration.Address, serverConfiguration.Port, replicas, chordAddress, chordPort);
            ServerManager.Instance.RegisterServer(serv);
            ServerManager.Instance.StartServer();
        }

        private void ServerForm_Load_1(object sender, EventArgs e)
        {
            serverLabel.Text += " " + ServerManager.Instance.ServerInstance.ID;         
            currentFreezeTimeLabel.Text = ((int)(Config.Instance.FreezeTime / 1000)) + " seconds";
        }

        private void StatusButton_Click(object sender, EventArgs e)
        {
            string status = ServerManager.Instance.ServerInstance.Status(verboseRadioButton.Checked);
            statusBox.Text = status;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (ServerManager.Instance.ServerInstance != null)
            {
                ServerManager.Instance.ServerInstance.ServerDataBase.Close();
            }            
            this.Close();
            Environment.Exit(0);
            Application.Exit();
        }

        private void FreezeButton_Click(object sender, EventArgs e)
        {
            if(!freezeTimeBox.Text.Equals("")){
                try
                {
                    int freeze = Int32.Parse(freezeTimeBox.Text);
                    if (freeze < 0)
                        throw new FormatException();
                    Config.Instance.FreezeTime = freeze * 1000; //Convert to milliseconds
                    freezeTimeBox.Text = "";
                    currentFreezeTimeLabel.Text = ((int)(Config.Instance.FreezeTime / 1000)) + " seconds";
                }
                catch (FormatException)
                {
                    MessageBox.Show("Freeze time must be a positive integer or 0 representing seconds.");
                }
            }
        }

        private void freezeTimeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                FreezeButton_Click(sender, e);
            }
        }
    }
}
