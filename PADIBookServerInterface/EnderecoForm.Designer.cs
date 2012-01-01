namespace Server
{
    partial class EnderecoForm
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
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.startButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.setComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.includeChordNodeCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chordNodeAddressTextBox = new System.Windows.Forms.TextBox();
            this.chordPortTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox
            // 
            this.comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(43, 91);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(340, 21);
            this.comboBox.TabIndex = 0;
            this.comboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Lavender;
            this.startButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startButton.Location = new System.Drawing.Point(206, 215);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(190, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(17, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 52);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server";
            // 
            // setComboBox
            // 
            this.setComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.setComboBox.FormattingEnabled = true;
            this.setComboBox.Location = new System.Drawing.Point(43, 33);
            this.setComboBox.Name = "setComboBox";
            this.setComboBox.Size = new System.Drawing.Size(340, 21);
            this.setComboBox.TabIndex = 7;
            this.setComboBox.SelectedIndexChanged += new System.EventHandler(this.setComboBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(17, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 52);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server set of replicas";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.chordPortTextBox);
            this.groupBox3.Controls.Add(this.chordNodeAddressTextBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.includeChordNodeCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(17, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(379, 82);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Known chord node";
            // 
            // includeChordNodeCheckBox
            // 
            this.includeChordNodeCheckBox.AutoSize = true;
            this.includeChordNodeCheckBox.Location = new System.Drawing.Point(9, 19);
            this.includeChordNodeCheckBox.Name = "includeChordNodeCheckBox";
            this.includeChordNodeCheckBox.Size = new System.Drawing.Size(118, 17);
            this.includeChordNodeCheckBox.TabIndex = 0;
            this.includeChordNodeCheckBox.Text = "Include chord node";
            this.includeChordNodeCheckBox.UseVisualStyleBackColor = true;
            this.includeChordNodeCheckBox.CheckedChanged += new System.EventHandler(this.includeChordNodeCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Address";
            // 
            // chordNodeAddressTextBox
            // 
            this.chordNodeAddressTextBox.Enabled = false;
            this.chordNodeAddressTextBox.Location = new System.Drawing.Point(9, 56);
            this.chordNodeAddressTextBox.Name = "chordNodeAddressTextBox";
            this.chordNodeAddressTextBox.Size = new System.Drawing.Size(262, 20);
            this.chordNodeAddressTextBox.TabIndex = 3;
            // 
            // chordPortTextBox
            // 
            this.chordPortTextBox.Enabled = false;
            this.chordPortTextBox.Location = new System.Drawing.Point(277, 56);
            this.chordPortTextBox.Name = "chordPortTextBox";
            this.chordPortTextBox.Size = new System.Drawing.Size(96, 20);
            this.chordPortTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // EnderecoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 241);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.setComboBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "EnderecoForm";
            this.Text = "Escolha um endereço";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox setComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox includeChordNodeCheckBox;
        private System.Windows.Forms.TextBox chordNodeAddressTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox chordPortTextBox;
    }
}

