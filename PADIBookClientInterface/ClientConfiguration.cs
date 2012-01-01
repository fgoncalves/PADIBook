using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PADIBook.Utils;

namespace PADIBook.Client
{
    public partial class ClientConfiguration : Form
    {
        public string Address
        {
            get;
            set;
        }

        public int Port
        {
            get;
            set;
        }

        public ClientConfiguration()
        {
            InitializeComponent();
            setComboBox.DataSource = (Config.Instance.ClientsConfiguration.Select(p => p.Name)).ToList<string>();
            setComboBox.SelectedIndex = 0;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Config.Instance.ChooseClientSetOfReplicas((string) setComboBox.SelectedItem);
            Address = (from addr in Config.Instance.ClientsConfiguration
                       where addr.Name == ((string)setComboBox.SelectedItem)
                       select addr.Address).First<string>();
            Port = (from port in Config.Instance.ClientsConfiguration
                    where port.Name == ((string)setComboBox.SelectedItem)
                    select port.Port).First<int>();
            this.Close();
        }
    }
}
