namespace PADIBook.Client
{
    partial class PADIbookForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PADIbookForm));
            this.Tabs = new System.Windows.Forms.TabControl();
            this.MuralTab = new System.Windows.Forms.TabPage();
            this.wall = new System.Windows.Forms.ListBox();
            this.RefrescarButton = new System.Windows.Forms.Button();
            this.PostarButton = new System.Windows.Forms.Button();
            this.insertPostBox = new System.Windows.Forms.TextBox();
            this.PerfilTab = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ageComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.femaleRadio = new System.Windows.Forms.RadioButton();
            this.maleRadio = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.userProfileTextbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.interestsCheckBoxes = new System.Windows.Forms.CheckedListBox();
            this.profileButton = new System.Windows.Forms.Button();
            this.AmigosTab = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.refreshFriendsButton = new System.Windows.Forms.Button();
            this.friendListBox = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.receivedRequestsCheckedList = new System.Windows.Forms.CheckedListBox();
            this.refreshRequestsViewButton = new System.Windows.Forms.Button();
            this.acceptFriendButton = new System.Windows.Forms.Button();
            this.rejectFriendButton = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.refreshSentRequestsButton = new System.Windows.Forms.Button();
            this.sentRequestsListBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.searchUserNameTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.searchSexAndAgeButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ageToComboBox = new System.Windows.Forms.ComboBox();
            this.ageFromComboBox = new System.Windows.Forms.ComboBox();
            this.searchFemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.searchMaleRadioButton = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.searchIneterestButton = new System.Windows.Forms.Button();
            this.interestComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.searchUserNameButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.friendPortTextBox = new System.Windows.Forms.TextBox();
            this.friendsAddrTextBox = new System.Windows.Forms.TextBox();
            this.AdicionarButton = new System.Windows.Forms.Button();
            this.PADIbookLabel = new System.Windows.Forms.Label();
            this.LigarButton = new System.Windows.Forms.Button();
            this.NomeBox = new System.Windows.Forms.TextBox();
            this.UtilizadorLabel = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.registrationButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.serverAddrComboBox = new System.Windows.Forms.ComboBox();
            this.Tabs.SuspendLayout();
            this.MuralTab.SuspendLayout();
            this.PerfilTab.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.AmigosTab.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabs.Controls.Add(this.MuralTab);
            this.Tabs.Controls.Add(this.PerfilTab);
            this.Tabs.Controls.Add(this.AmigosTab);
            this.Tabs.Controls.Add(this.tabPage1);
            this.Tabs.Controls.Add(this.tabPage2);
            this.Tabs.Location = new System.Drawing.Point(12, 67);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(649, 442);
            this.Tabs.TabIndex = 2;
            // 
            // MuralTab
            // 
            this.MuralTab.Controls.Add(this.wall);
            this.MuralTab.Controls.Add(this.RefrescarButton);
            this.MuralTab.Controls.Add(this.PostarButton);
            this.MuralTab.Controls.Add(this.insertPostBox);
            this.MuralTab.Location = new System.Drawing.Point(4, 22);
            this.MuralTab.Name = "MuralTab";
            this.MuralTab.Padding = new System.Windows.Forms.Padding(3);
            this.MuralTab.Size = new System.Drawing.Size(641, 416);
            this.MuralTab.TabIndex = 0;
            this.MuralTab.Text = "Mural";
            this.MuralTab.UseVisualStyleBackColor = true;
            // 
            // wall
            // 
            this.wall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wall.FormattingEnabled = true;
            this.wall.Location = new System.Drawing.Point(16, 124);
            this.wall.Name = "wall";
            this.wall.ScrollAlwaysVisible = true;
            this.wall.Size = new System.Drawing.Size(519, 225);
            this.wall.TabIndex = 6;
            // 
            // RefrescarButton
            // 
            this.RefrescarButton.BackColor = System.Drawing.Color.Lavender;
            this.RefrescarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefrescarButton.Location = new System.Drawing.Point(16, 15);
            this.RefrescarButton.Name = "RefrescarButton";
            this.RefrescarButton.Size = new System.Drawing.Size(108, 23);
            this.RefrescarButton.TabIndex = 5;
            this.RefrescarButton.Text = "Refrescar Mural";
            this.RefrescarButton.UseVisualStyleBackColor = false;
            this.RefrescarButton.Click += new System.EventHandler(this.RefrescarButton_Click);
            // 
            // PostarButton
            // 
            this.PostarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PostarButton.BackColor = System.Drawing.Color.Lavender;
            this.PostarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PostarButton.Location = new System.Drawing.Point(550, 53);
            this.PostarButton.Name = "PostarButton";
            this.PostarButton.Size = new System.Drawing.Size(75, 23);
            this.PostarButton.TabIndex = 4;
            this.PostarButton.Text = "Postar";
            this.PostarButton.UseVisualStyleBackColor = false;
            this.PostarButton.Click += new System.EventHandler(this.PostarButton_Click);
            // 
            // insertPostBox
            // 
            this.insertPostBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.insertPostBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.insertPostBox.Location = new System.Drawing.Point(16, 53);
            this.insertPostBox.Multiline = true;
            this.insertPostBox.Name = "insertPostBox";
            this.insertPostBox.Size = new System.Drawing.Size(519, 56);
            this.insertPostBox.TabIndex = 0;
            this.insertPostBox.Text = " Insira aqui a sua mensagem";
            this.insertPostBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.insertPostBox_MouseClick);
            // 
            // PerfilTab
            // 
            this.PerfilTab.Controls.Add(this.groupBox4);
            this.PerfilTab.Controls.Add(this.groupBox3);
            this.PerfilTab.Controls.Add(this.groupBox2);
            this.PerfilTab.Controls.Add(this.groupBox1);
            this.PerfilTab.Controls.Add(this.profileButton);
            this.PerfilTab.Location = new System.Drawing.Point(4, 22);
            this.PerfilTab.Name = "PerfilTab";
            this.PerfilTab.Padding = new System.Windows.Forms.Padding(3);
            this.PerfilTab.Size = new System.Drawing.Size(641, 416);
            this.PerfilTab.TabIndex = 1;
            this.PerfilTab.Text = "Perfil";
            this.PerfilTab.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ageComboBox);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox4.Location = new System.Drawing.Point(6, 146);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(588, 75);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Idade";
            // 
            // ageComboBox
            // 
            this.ageComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ageComboBox.FormattingEnabled = true;
            this.ageComboBox.Location = new System.Drawing.Point(11, 25);
            this.ageComboBox.Name = "ageComboBox";
            this.ageComboBox.Size = new System.Drawing.Size(167, 23);
            this.ageComboBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.femaleRadio);
            this.groupBox3.Controls.Add(this.maleRadio);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox3.Location = new System.Drawing.Point(6, 87);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(588, 53);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Género";
            // 
            // femaleRadio
            // 
            this.femaleRadio.AutoSize = true;
            this.femaleRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.femaleRadio.Location = new System.Drawing.Point(230, 25);
            this.femaleRadio.Name = "femaleRadio";
            this.femaleRadio.Size = new System.Drawing.Size(77, 19);
            this.femaleRadio.TabIndex = 1;
            this.femaleRadio.TabStop = true;
            this.femaleRadio.Text = "Feminino";
            this.femaleRadio.UseVisualStyleBackColor = true;
            // 
            // maleRadio
            // 
            this.maleRadio.AutoSize = true;
            this.maleRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.maleRadio.Location = new System.Drawing.Point(83, 25);
            this.maleRadio.Name = "maleRadio";
            this.maleRadio.Size = new System.Drawing.Size(82, 19);
            this.maleRadio.TabIndex = 0;
            this.maleRadio.TabStop = true;
            this.maleRadio.Text = "Masculino";
            this.maleRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.userProfileTextbox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(588, 65);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nome de utilizador";
            // 
            // userProfileTextbox
            // 
            this.userProfileTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.userProfileTextbox.Location = new System.Drawing.Point(11, 26);
            this.userProfileTextbox.Name = "userProfileTextbox";
            this.userProfileTextbox.Size = new System.Drawing.Size(354, 21);
            this.userProfileTextbox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.interestsCheckBoxes);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(6, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 128);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de interesses";
            // 
            // interestsCheckBoxes
            // 
            this.interestsCheckBoxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.interestsCheckBoxes.FormattingEnabled = true;
            this.interestsCheckBoxes.Location = new System.Drawing.Point(11, 36);
            this.interestsCheckBoxes.MultiColumn = true;
            this.interestsCheckBoxes.Name = "interestsCheckBoxes";
            this.interestsCheckBoxes.Size = new System.Drawing.Size(566, 84);
            this.interestsCheckBoxes.Sorted = true;
            this.interestsCheckBoxes.TabIndex = 0;
            this.interestsCheckBoxes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.interestsCheckBoxes_ItemCheck);
            // 
            // profileButton
            // 
            this.profileButton.BackColor = System.Drawing.Color.Lavender;
            this.profileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.profileButton.Location = new System.Drawing.Point(486, 375);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(108, 23);
            this.profileButton.TabIndex = 6;
            this.profileButton.Text = "Editar Perfil";
            this.profileButton.UseVisualStyleBackColor = false;
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // AmigosTab
            // 
            this.AmigosTab.Controls.Add(this.groupBox6);
            this.AmigosTab.Location = new System.Drawing.Point(4, 22);
            this.AmigosTab.Name = "AmigosTab";
            this.AmigosTab.Padding = new System.Windows.Forms.Padding(3);
            this.AmigosTab.Size = new System.Drawing.Size(641, 416);
            this.AmigosTab.TabIndex = 2;
            this.AmigosTab.Text = "Amigos";
            this.AmigosTab.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.refreshFriendsButton);
            this.groupBox6.Controls.Add(this.friendListBox);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox6.Location = new System.Drawing.Point(15, 15);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(608, 382);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Amigos";
            // 
            // refreshFriendsButton
            // 
            this.refreshFriendsButton.BackColor = System.Drawing.Color.Lavender;
            this.refreshFriendsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshFriendsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.refreshFriendsButton.Location = new System.Drawing.Point(485, 353);
            this.refreshFriendsButton.Name = "refreshFriendsButton";
            this.refreshFriendsButton.Size = new System.Drawing.Size(108, 23);
            this.refreshFriendsButton.TabIndex = 18;
            this.refreshFriendsButton.Text = "Refrescar lista";
            this.refreshFriendsButton.UseVisualStyleBackColor = false;
            this.refreshFriendsButton.Click += new System.EventHandler(this.refreshFriendsButton_Click);
            // 
            // friendListBox
            // 
            this.friendListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.friendListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.friendListBox.FormattingEnabled = true;
            this.friendListBox.ItemHeight = 15;
            this.friendListBox.Location = new System.Drawing.Point(17, 42);
            this.friendListBox.Name = "friendListBox";
            this.friendListBox.Size = new System.Drawing.Size(576, 300);
            this.friendListBox.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(641, 416);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Pedidos Pendentes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.receivedRequestsCheckedList);
            this.groupBox8.Controls.Add(this.refreshRequestsViewButton);
            this.groupBox8.Controls.Add(this.acceptFriendButton);
            this.groupBox8.Controls.Add(this.rejectFriendButton);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox8.Location = new System.Drawing.Point(320, 24);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(303, 365);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Pedidos Recebidos";
            // 
            // receivedRequestsCheckedList
            // 
            this.receivedRequestsCheckedList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.receivedRequestsCheckedList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.receivedRequestsCheckedList.FormattingEnabled = true;
            this.receivedRequestsCheckedList.Location = new System.Drawing.Point(19, 25);
            this.receivedRequestsCheckedList.Name = "receivedRequestsCheckedList";
            this.receivedRequestsCheckedList.Size = new System.Drawing.Size(267, 272);
            this.receivedRequestsCheckedList.TabIndex = 0;
            this.receivedRequestsCheckedList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.receivedRequests_ItemCheck);
            // 
            // refreshRequestsViewButton
            // 
            this.refreshRequestsViewButton.BackColor = System.Drawing.Color.Lavender;
            this.refreshRequestsViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.refreshRequestsViewButton.Location = new System.Drawing.Point(59, 307);
            this.refreshRequestsViewButton.Name = "refreshRequestsViewButton";
            this.refreshRequestsViewButton.Size = new System.Drawing.Size(119, 23);
            this.refreshRequestsViewButton.TabIndex = 3;
            this.refreshRequestsViewButton.Text = "Refrescar pedidos";
            this.refreshRequestsViewButton.UseVisualStyleBackColor = false;
            this.refreshRequestsViewButton.Click += new System.EventHandler(this.refreshRequestsViewButton_Click);
            // 
            // acceptFriendButton
            // 
            this.acceptFriendButton.BackColor = System.Drawing.Color.Lavender;
            this.acceptFriendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.acceptFriendButton.Location = new System.Drawing.Point(184, 307);
            this.acceptFriendButton.Name = "acceptFriendButton";
            this.acceptFriendButton.Size = new System.Drawing.Size(102, 23);
            this.acceptFriendButton.TabIndex = 2;
            this.acceptFriendButton.Text = "Aceitar pedidos";
            this.acceptFriendButton.UseVisualStyleBackColor = false;
            this.acceptFriendButton.Click += new System.EventHandler(this.acceptFriendButton_Click);
            // 
            // rejectFriendButton
            // 
            this.rejectFriendButton.BackColor = System.Drawing.Color.Lavender;
            this.rejectFriendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.rejectFriendButton.Location = new System.Drawing.Point(175, 336);
            this.rejectFriendButton.Name = "rejectFriendButton";
            this.rejectFriendButton.Size = new System.Drawing.Size(111, 23);
            this.rejectFriendButton.TabIndex = 1;
            this.rejectFriendButton.Text = "Rejeitar pedidos";
            this.rejectFriendButton.UseVisualStyleBackColor = false;
            this.rejectFriendButton.Click += new System.EventHandler(this.rejectFriendButton_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.refreshSentRequestsButton);
            this.groupBox7.Controls.Add(this.sentRequestsListBox);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox7.Location = new System.Drawing.Point(27, 24);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(271, 365);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Pedidos Efectuados";
            // 
            // refreshSentRequestsButton
            // 
            this.refreshSentRequestsButton.BackColor = System.Drawing.Color.Lavender;
            this.refreshSentRequestsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.refreshSentRequestsButton.Location = new System.Drawing.Point(137, 336);
            this.refreshSentRequestsButton.Name = "refreshSentRequestsButton";
            this.refreshSentRequestsButton.Size = new System.Drawing.Size(119, 23);
            this.refreshSentRequestsButton.TabIndex = 4;
            this.refreshSentRequestsButton.Text = "Refrescar pedidos";
            this.refreshSentRequestsButton.UseVisualStyleBackColor = false;
            this.refreshSentRequestsButton.Click += new System.EventHandler(this.refreshSentRequestsButton_Click);
            // 
            // sentRequestsListBox
            // 
            this.sentRequestsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sentRequestsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.sentRequestsListBox.FormattingEnabled = true;
            this.sentRequestsListBox.ItemHeight = 15;
            this.sentRequestsListBox.Location = new System.Drawing.Point(18, 27);
            this.sentRequestsListBox.Name = "sentRequestsListBox";
            this.sentRequestsListBox.Size = new System.Drawing.Size(238, 300);
            this.sentRequestsListBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox9);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(641, 416);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Procurar amigo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.Color.Transparent;
            this.groupBox9.Controls.Add(this.searchUserNameTextBox);
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Controls.Add(this.searchSexAndAgeButton);
            this.groupBox9.Controls.Add(this.label10);
            this.groupBox9.Controls.Add(this.label9);
            this.groupBox9.Controls.Add(this.ageToComboBox);
            this.groupBox9.Controls.Add(this.ageFromComboBox);
            this.groupBox9.Controls.Add(this.searchFemaleRadioButton);
            this.groupBox9.Controls.Add(this.searchMaleRadioButton);
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.searchIneterestButton);
            this.groupBox9.Controls.Add(this.interestComboBox);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.searchUserNameButton);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.resultsTextBox);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox9.Location = new System.Drawing.Point(18, 91);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(617, 315);
            this.groupBox9.TabIndex = 16;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Procura";
            // 
            // searchUserNameTextBox
            // 
            this.searchUserNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.searchUserNameTextBox.Location = new System.Drawing.Point(81, 38);
            this.searchUserNameTextBox.Name = "searchUserNameTextBox";
            this.searchUserNameTextBox.Size = new System.Drawing.Size(294, 21);
            this.searchUserNameTextBox.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label11.Location = new System.Drawing.Point(8, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "Username:";
            // 
            // searchSexAndAgeButton
            // 
            this.searchSexAndAgeButton.BackColor = System.Drawing.Color.Lavender;
            this.searchSexAndAgeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchSexAndAgeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.searchSexAndAgeButton.Location = new System.Drawing.Point(412, 136);
            this.searchSexAndAgeButton.Name = "searchSexAndAgeButton";
            this.searchSexAndAgeButton.Size = new System.Drawing.Size(108, 23);
            this.searchSexAndAgeButton.TabIndex = 31;
            this.searchSexAndAgeButton.Text = "Procurar";
            this.searchSexAndAgeButton.UseVisualStyleBackColor = false;
            this.searchSexAndAgeButton.Click += new System.EventHandler(this.searchSexAndAgeButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label10.Location = new System.Drawing.Point(272, 139);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 15);
            this.label10.TabIndex = 30;
            this.label10.Text = "Aos:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.Location = new System.Drawing.Point(135, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 15);
            this.label9.TabIndex = 29;
            this.label9.Text = "Dos:";
            // 
            // ageToComboBox
            // 
            this.ageToComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ageToComboBox.FormattingEnabled = true;
            this.ageToComboBox.Location = new System.Drawing.Point(309, 136);
            this.ageToComboBox.Name = "ageToComboBox";
            this.ageToComboBox.Size = new System.Drawing.Size(88, 23);
            this.ageToComboBox.TabIndex = 28;
            // 
            // ageFromComboBox
            // 
            this.ageFromComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ageFromComboBox.FormattingEnabled = true;
            this.ageFromComboBox.Location = new System.Drawing.Point(173, 136);
            this.ageFromComboBox.Name = "ageFromComboBox";
            this.ageFromComboBox.Size = new System.Drawing.Size(88, 23);
            this.ageFromComboBox.TabIndex = 27;
            // 
            // searchFemaleRadioButton
            // 
            this.searchFemaleRadioButton.AutoSize = true;
            this.searchFemaleRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.searchFemaleRadioButton.Location = new System.Drawing.Point(20, 167);
            this.searchFemaleRadioButton.Name = "searchFemaleRadioButton";
            this.searchFemaleRadioButton.Size = new System.Drawing.Size(77, 19);
            this.searchFemaleRadioButton.TabIndex = 26;
            this.searchFemaleRadioButton.TabStop = true;
            this.searchFemaleRadioButton.Text = "Feminino";
            this.searchFemaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // searchMaleRadioButton
            // 
            this.searchMaleRadioButton.AutoSize = true;
            this.searchMaleRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.searchMaleRadioButton.Location = new System.Drawing.Point(20, 140);
            this.searchMaleRadioButton.Name = "searchMaleRadioButton";
            this.searchMaleRadioButton.Size = new System.Drawing.Size(82, 19);
            this.searchMaleRadioButton.TabIndex = 25;
            this.searchMaleRadioButton.TabStop = true;
            this.searchMaleRadioButton.Text = "Masculino";
            this.searchMaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.Location = new System.Drawing.Point(131, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "Idade:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(6, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "Género:";
            // 
            // searchIneterestButton
            // 
            this.searchIneterestButton.BackColor = System.Drawing.Color.Lavender;
            this.searchIneterestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchIneterestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.searchIneterestButton.Location = new System.Drawing.Point(382, 77);
            this.searchIneterestButton.Name = "searchIneterestButton";
            this.searchIneterestButton.Size = new System.Drawing.Size(108, 23);
            this.searchIneterestButton.TabIndex = 22;
            this.searchIneterestButton.Text = "Procurar";
            this.searchIneterestButton.UseVisualStyleBackColor = false;
            this.searchIneterestButton.Click += new System.EventHandler(this.searchIneterestButton_Click);
            // 
            // interestComboBox
            // 
            this.interestComboBox.FormattingEnabled = true;
            this.interestComboBox.Location = new System.Drawing.Point(81, 74);
            this.interestComboBox.Name = "interestComboBox";
            this.interestComboBox.Size = new System.Drawing.Size(295, 28);
            this.interestComboBox.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(7, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Interesse:";
            // 
            // searchUserNameButton
            // 
            this.searchUserNameButton.BackColor = System.Drawing.Color.Lavender;
            this.searchUserNameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchUserNameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.searchUserNameButton.Location = new System.Drawing.Point(382, 36);
            this.searchUserNameButton.Name = "searchUserNameButton";
            this.searchUserNameButton.Size = new System.Drawing.Size(108, 23);
            this.searchUserNameButton.TabIndex = 16;
            this.searchUserNameButton.Text = "Procurar";
            this.searchUserNameButton.UseVisualStyleBackColor = false;
            this.searchUserNameButton.Click += new System.EventHandler(this.searchUserNameButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(7, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Resultados:";
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Location = new System.Drawing.Point(10, 224);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsTextBox.Size = new System.Drawing.Size(601, 85);
            this.resultsTextBox.TabIndex = 18;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.friendPortTextBox);
            this.groupBox5.Controls.Add(this.friendsAddrTextBox);
            this.groupBox5.Controls.Add(this.AdicionarButton);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox5.Location = new System.Drawing.Point(18, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(617, 79);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Adicionar amigo através do endereço";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(346, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Porto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Endereço:";
            // 
            // friendPortTextBox
            // 
            this.friendPortTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.friendPortTextBox.Location = new System.Drawing.Point(349, 47);
            this.friendPortTextBox.Name = "friendPortTextBox";
            this.friendPortTextBox.Size = new System.Drawing.Size(141, 21);
            this.friendPortTextBox.TabIndex = 13;
            // 
            // friendsAddrTextBox
            // 
            this.friendsAddrTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.friendsAddrTextBox.Location = new System.Drawing.Point(10, 47);
            this.friendsAddrTextBox.Name = "friendsAddrTextBox";
            this.friendsAddrTextBox.Size = new System.Drawing.Size(324, 21);
            this.friendsAddrTextBox.TabIndex = 12;
            // 
            // AdicionarButton
            // 
            this.AdicionarButton.BackColor = System.Drawing.Color.Lavender;
            this.AdicionarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdicionarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.AdicionarButton.Location = new System.Drawing.Point(503, 45);
            this.AdicionarButton.Name = "AdicionarButton";
            this.AdicionarButton.Size = new System.Drawing.Size(108, 23);
            this.AdicionarButton.TabIndex = 7;
            this.AdicionarButton.Text = "Adicionar Amigo";
            this.AdicionarButton.UseVisualStyleBackColor = false;
            this.AdicionarButton.Click += new System.EventHandler(this.AdicionarButton_Click);
            // 
            // PADIbookLabel
            // 
            this.PADIbookLabel.AutoSize = true;
            this.PADIbookLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.PADIbookLabel.ForeColor = System.Drawing.Color.Navy;
            this.PADIbookLabel.Location = new System.Drawing.Point(5, 13);
            this.PADIbookLabel.Name = "PADIbookLabel";
            this.PADIbookLabel.Size = new System.Drawing.Size(135, 30);
            this.PADIbookLabel.TabIndex = 3;
            this.PADIbookLabel.Text = "PADIbook";
            // 
            // LigarButton
            // 
            this.LigarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LigarButton.BackColor = System.Drawing.Color.Lavender;
            this.LigarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LigarButton.Location = new System.Drawing.Point(586, 11);
            this.LigarButton.Name = "LigarButton";
            this.LigarButton.Size = new System.Drawing.Size(75, 23);
            this.LigarButton.TabIndex = 0;
            this.LigarButton.Text = "Ligar";
            this.LigarButton.UseVisualStyleBackColor = false;
            this.LigarButton.Click += new System.EventHandler(this.LigarButton_Click);
            // 
            // NomeBox
            // 
            this.NomeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NomeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NomeBox.Location = new System.Drawing.Point(417, 11);
            this.NomeBox.Multiline = true;
            this.NomeBox.Name = "NomeBox";
            this.NomeBox.Size = new System.Drawing.Size(163, 23);
            this.NomeBox.TabIndex = 4;
            this.NomeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NomeBox_KeyDown);
            // 
            // UtilizadorLabel
            // 
            this.UtilizadorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UtilizadorLabel.AutoSize = true;
            this.UtilizadorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UtilizadorLabel.Location = new System.Drawing.Point(340, 15);
            this.UtilizadorLabel.Name = "UtilizadorLabel";
            this.UtilizadorLabel.Size = new System.Drawing.Size(71, 17);
            this.UtilizadorLabel.TabIndex = 7;
            this.UtilizadorLabel.Text = "Utilizador:";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // registrationButton
            // 
            this.registrationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.registrationButton.BackColor = System.Drawing.Color.Lavender;
            this.registrationButton.Location = new System.Drawing.Point(586, 40);
            this.registrationButton.Name = "registrationButton";
            this.registrationButton.Size = new System.Drawing.Size(75, 23);
            this.registrationButton.TabIndex = 8;
            this.registrationButton.Text = "Registar";
            this.registrationButton.UseVisualStyleBackColor = false;
            this.registrationButton.Click += new System.EventHandler(this.registrationButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Endereço do servidor:";
            // 
            // serverAddrComboBox
            // 
            this.serverAddrComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.serverAddrComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.serverAddrComboBox.FormattingEnabled = true;
            this.serverAddrComboBox.Location = new System.Drawing.Point(417, 40);
            this.serverAddrComboBox.Name = "serverAddrComboBox";
            this.serverAddrComboBox.Size = new System.Drawing.Size(163, 21);
            this.serverAddrComboBox.TabIndex = 11;
            this.serverAddrComboBox.SelectedIndexChanged += new System.EventHandler(this.serverAddrComboBox_SelectedIndexChanged);
            // 
            // PADIbookForm
            // 
            this.AccessibleName = "PADIForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(673, 521);
            this.Controls.Add(this.serverAddrComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.registrationButton);
            this.Controls.Add(this.UtilizadorLabel);
            this.Controls.Add(this.NomeBox);
            this.Controls.Add(this.PADIbookLabel);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.LigarButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PADIbookForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "PADIbook";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.PADIbookForm_Load);
            this.Tabs.ResumeLayout(false);
            this.MuralTab.ResumeLayout(false);
            this.MuralTab.PerformLayout();
            this.PerfilTab.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.AmigosTab.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage MuralTab;
        private System.Windows.Forms.TabPage PerfilTab;
        private System.Windows.Forms.TabPage AmigosTab;
        private System.Windows.Forms.Label PADIbookLabel;
        private System.Windows.Forms.TextBox insertPostBox;
        private System.Windows.Forms.Button PostarButton;
        private System.Windows.Forms.Button LigarButton;
        private System.Windows.Forms.TextBox NomeBox;
        private System.Windows.Forms.Button RefrescarButton;
        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.Label UtilizadorLabel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox userProfileTextbox;
        private System.Windows.Forms.RadioButton femaleRadio;
        private System.Windows.Forms.RadioButton maleRadio;
        private System.Windows.Forms.ComboBox ageComboBox;
        private System.Windows.Forms.CheckedListBox interestsCheckBoxes;
        private System.Windows.Forms.Button registrationButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox wall;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox friendListBox;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ListBox sentRequestsListBox;
        private System.Windows.Forms.Button acceptFriendButton;
        private System.Windows.Forms.Button rejectFriendButton;
        private System.Windows.Forms.CheckedListBox receivedRequestsCheckedList;
        private System.Windows.Forms.ComboBox serverAddrComboBox;
        private System.Windows.Forms.Button refreshRequestsViewButton;
        private System.Windows.Forms.Button refreshSentRequestsButton;
        private System.Windows.Forms.Button refreshFriendsButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox friendPortTextBox;
        private System.Windows.Forms.TextBox friendsAddrTextBox;
        private System.Windows.Forms.Button AdicionarButton;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox resultsTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button searchUserNameButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button searchIneterestButton;
        private System.Windows.Forms.ComboBox interestComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton searchFemaleRadioButton;
        private System.Windows.Forms.RadioButton searchMaleRadioButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox ageToComboBox;
        private System.Windows.Forms.ComboBox ageFromComboBox;
        private System.Windows.Forms.Button searchSexAndAgeButton;
        private System.Windows.Forms.TextBox searchUserNameTextBox;
        private System.Windows.Forms.Label label11;
    }
}

