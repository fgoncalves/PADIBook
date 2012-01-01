namespace PADIBook.Client
{
    partial class ClientConfiguration
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
            this.setComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // setComboBox
            // 
            this.setComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.setComboBox.FormattingEnabled = true;
            this.setComboBox.Location = new System.Drawing.Point(37, 40);
            this.setComboBox.Name = "setComboBox";
            this.setComboBox.Size = new System.Drawing.Size(340, 21);
            this.setComboBox.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(11, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 52);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client configuration";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(327, 90);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Iniciar";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // ClientConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 125);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.setComboBox);
            this.Controls.Add(this.groupBox2);
            this.Name = "ClientConfiguration";
            this.Text = "Client Setup";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox setComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button startButton;
    }
}