using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PADIBook.Utils;
using PADIBook.Utils.Exceptions;
using PADIBook.Client;

namespace PADIBook.Client
{
    public partial class PADIbookForm : Form
    {
        private List<string> currentInterests;
        private List<FriendRequest> currentRequests;
        private Profile userProfile;
        private string clientAddress;
        private int clientPort;

        public PADIbookForm()
        {
            InitializeComponent();
            ClientConfiguration cc = new ClientConfiguration();
            cc.ShowDialog();
            clientAddress = cc.Address;
            clientPort = cc.Port;
            this.Text = "PADIBook @ " + clientAddress + ":" + clientPort;
            serverAddrComboBox.DataSource = (Config.Instance.ServersConfiguration.Select(p => p.Name)).ToList<string>();
            serverAddrComboBox.SelectedIndex = 0;
            Control.CheckForIllegalCrossThreadCalls = false;
            currentInterests = new List<string>();
            currentRequests = new List<FriendRequest>();
            AddInterests();
            for (int i = 1; i < 101; i++)
            {
                ageComboBox.Items.Add(i);
                ageFromComboBox.Items.Add(i);
                ageToComboBox.Items.Add(i);
            }
            ageComboBox.SelectedIndex = 0;
            ageFromComboBox.SelectedIndex = 0;
            ageToComboBox.SelectedIndex = 0;
        }

        public PADIbookForm(string clientId)
        {
            InitializeComponent();
            Config.Instance.ChooseClientSetOfReplicas(clientId);
            clientAddress = (from addr in Config.Instance.ClientsConfiguration
                       where addr.Name == clientId
                       select addr.Address).First<string>();
            clientPort = (from port in Config.Instance.ClientsConfiguration
                    where port.Name == clientId
                    select port.Port).First<int>();
   
            this.Text = "PADIBook @ " + clientAddress + ":" + clientPort;
            serverAddrComboBox.DataSource = (Config.Instance.ServersConfiguration.Select(p => p.Name)).ToList<string>();
            serverAddrComboBox.SelectedIndex = 0;
            Control.CheckForIllegalCrossThreadCalls = false;
            currentInterests = new List<string>();
            currentRequests = new List<FriendRequest>();
            AddInterests();
            for (int i = 1; i < 101; i++)
            {
                ageComboBox.Items.Add(i);
                ageFromComboBox.Items.Add(i);
                ageToComboBox.Items.Add(i);
            }
            ageComboBox.SelectedIndex = 0;
            ageFromComboBox.SelectedIndex = 0;
            ageToComboBox.SelectedIndex = 0;
        }

        private void PADIbookForm_Load(object sender, EventArgs e)
        {
            Tabs.Enabled = false;
        }

        //Begin inits
        private void AddInterests()
        {
            interestsCheckBoxes.Items.Add("Carros");
            interestComboBox.Items.Add("Carros");
            interestsCheckBoxes.Items.Add("Comics");
            interestComboBox.Items.Add("Comics");
            interestsCheckBoxes.Items.Add("Finanças");
            interestComboBox.Items.Add("Finanças");
            interestsCheckBoxes.Items.Add("Jogos");
            interestComboBox.Items.Add("Jogos");
            interestsCheckBoxes.Items.Add("Hobbies");
            interestComboBox.Items.Add("Hobbies");
            interestsCheckBoxes.Items.Add("Trabalhos");
            interestComboBox.Items.Add("Trabalhos");
            interestsCheckBoxes.Items.Add("Literatura");
            interestComboBox.Items.Add("Literatura");
            interestsCheckBoxes.Items.Add("Vida");
            interestComboBox.Items.Add("Vida");
            interestsCheckBoxes.Items.Add("Medicina");
            interestComboBox.Items.Add("Medicina");
            interestsCheckBoxes.Items.Add("Filmes");
            interestComboBox.Items.Add("Filmes");
            interestsCheckBoxes.Items.Add("Música");
            interestComboBox.Items.Add("Música");
            interestsCheckBoxes.Items.Add("Natureza");
            interestComboBox.Items.Add("Natureza");
            interestsCheckBoxes.Items.Add("Pintura");
            interestComboBox.Items.Add("Pintura");
            interestsCheckBoxes.Items.Add("Personalidades");
            interestComboBox.Items.Add("Personalidades");
            interestsCheckBoxes.Items.Add("Política");
            interestComboBox.Items.Add("Política");
            interestsCheckBoxes.Items.Add("Religião");
            interestComboBox.Items.Add("Religião");
            interestsCheckBoxes.Items.Add("Ciência");
            interestComboBox.Items.Add("Ciência");
            interestsCheckBoxes.Items.Add("Desporto");
            interestComboBox.Items.Add("Desporto");
            interestsCheckBoxes.Items.Add("Viagens");
            interestComboBox.Items.Add("Viagens");
            interestComboBox.SelectedIndex = 0;
        }

        private void RefreshFriends()
        {
            friendListBox.Items.Clear();
            foreach (string friend in ServerServiceInvoker.Instance.GetFriends().FriendsInfo.Keys)
            {
                friendListBox.Items.Add(friend);
                friendListBox.Items.Add("");
            }
        }

        private void RefreshReceivedRequests()
        {
            receivedRequestsCheckedList.Items.Clear();
            currentRequests.Clear();
            foreach (FriendRequest p in ServerServiceInvoker.Instance.GetReceivedRequests().Requests.Values)
            {
                receivedRequestsCheckedList.Items.Add(p);
            }
        }

        private void RefreshSentRequests()
        {
            sentRequestsListBox.Items.Clear();
            foreach (FriendRequest fr in ServerServiceInvoker.Instance.GetSentRequests().Requests.Values)
            {
                sentRequestsListBox.Items.Add("Enviado a " + fr.SendTo + ":" + fr.SendToPort);
            }
        }
        
        private void initProfile(string username)
        {
            try
            {
                Profile user = ServerServiceInvoker.Instance.GetUserProfile(username);
                if (user != null)
                {
                    userProfileTextbox.Text = user.UserName;
                    userProfileTextbox.ReadOnly = true;

                    if (user.Gender == "Masculino")
                        maleRadio.Select();
                    else
                        femaleRadio.Select();

                    ageComboBox.SelectedIndex = user.Age - 1;

                    foreach (string interest in user.Interests)
                    {
                        int index = interestsCheckBoxes.Items.IndexOf(interest);
                        interestsCheckBoxes.SetItemChecked(index, true);
                    }

                    userProfile = user;

                    LigarButton.Enabled = false;
                    registrationButton.Enabled = false;
                    NomeBox.Enabled = false;

                    RefrescarButton_Click(null, null);
                    RefreshFriends();
                    RefreshReceivedRequests();
                    RefreshSentRequests();
                    PADIbookLabel.Text = userProfile.UserName + "'s " + PADIbookLabel.Text;
                    Tabs.Enabled = true;
                }
                else
                {
                    MessageBox.Show("User " + username + " not found.");
                    NomeBox.Text = "";
                }
            }
            catch (ServiceUnavailableException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //End inits

        //Begin event handlers
        private void PostarButton_Click(object sender, EventArgs e)
        {
            if (insertPostBox.Text != "")
            {
                try
                {
                    ServerServiceInvoker.Instance.Post(userProfile, insertPostBox.Text);
                }
                catch (ServiceUnavailableException se)
                {
                    MessageBox.Show(se.Message + "\r\nPor favor tente mais tarde.");
                }
                insertPostBox.Text = " Insira aqui a sua mensagem";
            }
        }

        private void LigarButton_Click(object sender, EventArgs e)
        {
            if (NomeBox.Text != "")
            {
                initProfile(NomeBox.Text);
                NomeBox.Text = "";
            }
        }

        private void NomeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LigarButton_Click(sender, e);
        }
        
        private void registrationButton_Click(object sender, EventArgs e)
        {
            Tabs.Enabled = true;
            Tabs.SelectedIndex = 1;
            profileButton.Text = "Registar";
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            if (profileButton.Text == "Registar")
            {
                string username = userProfileTextbox.Text;
                if (username == null)
                {
                    MessageBox.Show("Por favor insira um nome de utilizador.");
                    return;
                }

                string gender = null;
                if (maleRadio.Checked)
                    gender = "Masculino";
                if (femaleRadio.Checked)
                    gender = "Feminino";
                if (gender == null)
                {
                    MessageBox.Show("Por favor indique o seu género.");
                    return;
                }

                if (currentInterests.Count > 5)
                {
                    MessageBox.Show("Por favor seleccione menos de 5 interesses.");
                    return;
                }

                Tabs.Enabled = false;
                try
                {
                    ServerServiceInvoker.Instance.CreateProfile(username, gender, (int)ageComboBox.SelectedItem, currentInterests, clientAddress, clientPort);
                    MessageBox.Show("Registo efectuado com sucesso\r\n\r\nPode ligar-se agora ao PADIBook.");
                }
                catch (ServiceUnavailableException se)
                {
                    MessageBox.Show(se.Message + "\r\nPor favor tente mais tarde.");
                }
                Tabs.Enabled = false;
                profileButton.Text = "Editar Perfil";
                return;
            }
            if (profileButton.Text == "Editar Perfil")
            {
                string gender = null;
                if (maleRadio.Checked)
                    gender = "Masculino";
                if (femaleRadio.Checked)
                    gender = "Feminino";
                if (gender == null)
                {
                    MessageBox.Show("Por favor indique o seu género.");
                    return;
                }

                if (currentInterests.Count > 5)
                {
                    MessageBox.Show("Por favor seleccione menos de 5 interesses.");
                    return;
                }

                Tabs.Enabled = false;
                try
                {
                    userProfile.Age = (int)ageComboBox.SelectedItem;
                    userProfile.Gender = gender;
                    userProfile.Interests = new List<string>(currentInterests);
                    ServerServiceInvoker.Instance.UpdateUserProfile(userProfile);
                    MessageBox.Show("Actualização efectuada com sucesso");
                }
                catch (ServiceUnavailableException se)
                {
                    MessageBox.Show(se.Message + "\r\nPor favor tente mais tarde.");
                }
                Tabs.Enabled = true;
                return;
            }
        }

        private void interestsCheckBoxes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                currentInterests.Add(interestsCheckBoxes.Items[e.Index].ToString());
            }
            else
                currentInterests.Remove(interestsCheckBoxes.Items[e.Index].ToString());
        }

        private void RefrescarButton_Click(object sender, EventArgs e)
        {
            List<Post> pl;
            try
            {
                pl = ServerServiceInvoker.Instance.GetPostList();
            }
            catch (ServiceUnavailableException se)
            {
                MessageBox.Show(se.Message + "\r\nPor favor tente mais tarde.");
                return;
            }
            wall.Items.Clear();
            foreach (Post x in pl)
            {
                wall.Items.Add("Messagem de " + x.UserName + " em " + x.TimeStamp);
                wall.Items.Add(x.Message);
                wall.Items.Add("");
            }
        }

        private void insertPostBox_MouseClick(object sender, MouseEventArgs e)
        {
            insertPostBox.Text = "";
        }

        private void receivedRequests_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                currentRequests.Add((FriendRequest) receivedRequestsCheckedList.Items[e.Index]);
            }
            else
                currentRequests.Remove((FriendRequest) receivedRequestsCheckedList.Items[e.Index]);
        }

        private void acceptFriendButton_Click(object sender, EventArgs e)
        {
            receivedRequestsCheckedList.Enabled = false;
            acceptFriendButton.Enabled = false;
            rejectFriendButton.Enabled = false;
            try
            {
                foreach (FriendRequest fr in currentRequests)
                {                    
                    ServerServiceInvoker.Instance.AddFriend(fr);
                }

                RefreshReceivedRequests();
                RefreshFriends();
            }
            catch (ServiceUnavailableException se)
            {
                MessageBox.Show(se.Message + "\r\nPor favor tente mais tarde.");
            }
            receivedRequestsCheckedList.Enabled = true;
            acceptFriendButton.Enabled = true;
            rejectFriendButton.Enabled = true;            
        }

        private void rejectFriendButton_Click(object sender, EventArgs e)
        {
            receivedRequestsCheckedList.Enabled = false;
            acceptFriendButton.Enabled = false;
            rejectFriendButton.Enabled = false;
            try
            {
                foreach (FriendRequest fr in currentRequests)
                    ServerServiceInvoker.Instance.RejectFriend(fr);
                RefreshReceivedRequests();
            }
            catch (ServiceUnavailableException se)
            {
                MessageBox.Show(se.Message + "\r\nPor favor tente mais tarde.");
            }            
            refreshRequestsViewButton_Click(sender, e);
            receivedRequestsCheckedList.Enabled = true;
            acceptFriendButton.Enabled = true;
            rejectFriendButton.Enabled = true;
        }

        private void AdicionarButton_Click(object sender, EventArgs e)
        {
            if (friendsAddrTextBox.Text != "" && friendPortTextBox.Text != "")
            {
                string addr = friendsAddrTextBox.Text;
                int port;
                try
                {
                    port = Int32.Parse(friendPortTextBox.Text);
                }catch(FormatException){
                    MessageBox.Show("Verifique que o porto é um número inteiro.");
                    return;
                }
                FriendRequest fr = new FriendRequest(clientAddress, clientPort, addr, port, userProfile.UserName);
                //fr.RequestedUserName = requestedUserNameTextBox.Text;
                try
                {
                    ServerServiceInvoker.Instance.SendFriendRequest(fr);
                    RefreshSentRequests();
                    MessageBox.Show("Pedido enviado com sucesso.");
                }
                catch (ServiceUnavailableException se)
                {
                    MessageBox.Show(se.Message + "\r\nPor favor tente mais tarde.");
                }                
            }
        }

        private void serverAddrComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerServiceInvoker.Instance.ServerAddressToBeginCallIndex = serverAddrComboBox.SelectedIndex;
        }

        private void refreshRequestsViewButton_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshReceivedRequests();
            }
            catch(ServiceUnavailableException se)
            {
                MessageBox.Show(se.Message);                
            }
        }

        private void refreshSentRequestsButton_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshSentRequests();
            }
            catch (ServiceUnavailableException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void refreshFriendsButton_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshFriends();
            }
            catch (ServiceUnavailableException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void searchUserNameButton_Click(object sender, EventArgs e)
        {
            if (searchUserNameTextBox.Text != "")
            {
                string result = ServerServiceInvoker.Instance.LookupByUserName(searchUserNameTextBox.Text);
                if (result != null)
                    resultsTextBox.Text = result;
                else
                    resultsTextBox.Text = "Não foi encontrado nenhum utilizador com o username " + searchUserNameTextBox.Text;
            }
            else
                MessageBox.Show("Por favor inserira um nome de utilizador.");
        }

        private void searchIneterestButton_Click(object sender, EventArgs e)
        {
            if (interestComboBox.Text != "")
            {
                resultsTextBox.Text = "";
                List<string> result = ServerServiceInvoker.Instance.LookupByInterest(interestComboBox.Text);
                if (result != null && result.Count > 0)
                {
                    foreach (string s in result)
                        resultsTextBox.Text += s + "\r\n";
                }
                else
                    resultsTextBox.Text = "Não foi encontrado nenhum utilizador com o interesse " + interestComboBox.Text;
            }
            else
                MessageBox.Show("Por favor escolha um interesse válido.");
        }

        private void searchSexAndAgeButton_Click(object sender, EventArgs e)
        {
            if ((searchFemaleRadioButton.Checked || searchMaleRadioButton.Checked) 
                && ageFromComboBox.Text != "" && ageToComboBox.Text != "")
            {
                string gender = (searchFemaleRadioButton.Checked) ? "Feminino" : "Masculino";
                int @from;
                int to;

                try
                {
                    @from = Int32.Parse(ageFromComboBox.Text);
                    to = Int32.Parse(ageToComboBox.Text);
                }
                catch (FormatException) {
                    MessageBox.Show("Os valores das idades fornecidas são inválidos.");
                    return;
                }

                if (to < @from)
                {
                    MessageBox.Show("Intervalo de idades não válido.");
                    return;
                }

                resultsTextBox.Text = "";
                List<string> result = ServerServiceInvoker.Instance.LookupByGenderAndAge(gender,from,to);
                if (result != null && result.Count > 0)
                {
                    foreach (string s in result)
                        resultsTextBox.Text += s + "\r\n";
                }
                else
                    resultsTextBox.Text = "Não foi encontrado nenhum utilizador com as especificações fornecidas.";
            }
            else
                MessageBox.Show("Por favor preencha todos os campos necessários.");
        }
        //End event handlers
    }
}
