namespace Server
{
    partial class ServerForm
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
            this.ServerTabs = new System.Windows.Forms.TabControl();
            this.StatusTab = new System.Windows.Forms.TabPage();
            this.verboseRadioButton = new System.Windows.Forms.CheckBox();
            this.FreezeButton = new System.Windows.Forms.Button();
            this.freezeTimeBox = new System.Windows.Forms.TextBox();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.StatusButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.currentFreezeTimeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.serverLabel = new System.Windows.Forms.Label();
            this.ServerTabs.SuspendLayout();
            this.StatusTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServerTabs
            // 
            this.ServerTabs.Controls.Add(this.StatusTab);
            this.ServerTabs.Location = new System.Drawing.Point(13, 54);
            this.ServerTabs.Name = "ServerTabs";
            this.ServerTabs.SelectedIndex = 0;
            this.ServerTabs.Size = new System.Drawing.Size(771, 366);
            this.ServerTabs.TabIndex = 0;
            // 
            // StatusTab
            // 
            this.StatusTab.Controls.Add(this.verboseRadioButton);
            this.StatusTab.Controls.Add(this.freezeTimeBox);
            this.StatusTab.Controls.Add(this.statusBox);
            this.StatusTab.Controls.Add(this.StatusButton);
            this.StatusTab.Controls.Add(this.groupBox1);
            this.StatusTab.Location = new System.Drawing.Point(4, 22);
            this.StatusTab.Name = "StatusTab";
            this.StatusTab.Padding = new System.Windows.Forms.Padding(3);
            this.StatusTab.Size = new System.Drawing.Size(763, 340);
            this.StatusTab.TabIndex = 0;
            this.StatusTab.Text = "Status";
            this.StatusTab.UseVisualStyleBackColor = true;
            // 
            // verboseRadioButton
            // 
            this.verboseRadioButton.AutoSize = true;
            this.verboseRadioButton.Location = new System.Drawing.Point(107, 30);
            this.verboseRadioButton.Name = "verboseRadioButton";
            this.verboseRadioButton.Size = new System.Drawing.Size(65, 17);
            this.verboseRadioButton.TabIndex = 12;
            this.verboseRadioButton.Text = "Verbose";
            this.verboseRadioButton.UseVisualStyleBackColor = true;
            // 
            // FreezeButton
            // 
            this.FreezeButton.BackColor = System.Drawing.Color.Lavender;
            this.FreezeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FreezeButton.Location = new System.Drawing.Point(669, 37);
            this.FreezeButton.Name = "FreezeButton";
            this.FreezeButton.Size = new System.Drawing.Size(67, 23);
            this.FreezeButton.TabIndex = 9;
            this.FreezeButton.Text = "Freeze";
            this.FreezeButton.UseVisualStyleBackColor = false;
            this.FreezeButton.Click += new System.EventHandler(this.FreezeButton_Click);
            // 
            // freezeTimeBox
            // 
            this.freezeTimeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.freezeTimeBox.Location = new System.Drawing.Point(28, 293);
            this.freezeTimeBox.Multiline = true;
            this.freezeTimeBox.Name = "freezeTimeBox";
            this.freezeTimeBox.Size = new System.Drawing.Size(650, 23);
            this.freezeTimeBox.TabIndex = 8;
            this.freezeTimeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.freezeTimeBox_KeyDown);
            // 
            // statusBox
            // 
            this.statusBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusBox.Location = new System.Drawing.Point(28, 54);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusBox.Size = new System.Drawing.Size(723, 190);
            this.statusBox.TabIndex = 7;
            // 
            // StatusButton
            // 
            this.StatusButton.BackColor = System.Drawing.Color.Lavender;
            this.StatusButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StatusButton.Location = new System.Drawing.Point(28, 24);
            this.StatusButton.Name = "StatusButton";
            this.StatusButton.Size = new System.Drawing.Size(67, 23);
            this.StatusButton.TabIndex = 6;
            this.StatusButton.Text = "Status";
            this.StatusButton.UseVisualStyleBackColor = false;
            this.StatusButton.Click += new System.EventHandler(this.StatusButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.currentFreezeTimeLabel);
            this.groupBox1.Controls.Add(this.FreezeButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 256);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(943, 72);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server freeze time in seconds";
            // 
            // currentFreezeTimeLabel
            // 
            this.currentFreezeTimeLabel.AutoSize = true;
            this.currentFreezeTimeLabel.Location = new System.Drawing.Point(114, 21);
            this.currentFreezeTimeLabel.Name = "currentFreezeTimeLabel";
            this.currentFreezeTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.currentFreezeTimeLabel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current freeze time:";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Lavender;
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.Location = new System.Drawing.Point(636, 426);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(148, 23);
            this.ExitButton.TabIndex = 10;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // serverLabel
            // 
            this.serverLabel.AutoSize = true;
            this.serverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.serverLabel.ForeColor = System.Drawing.Color.Navy;
            this.serverLabel.Location = new System.Drawing.Point(12, 9);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(95, 30);
            this.serverLabel.TabIndex = 4;
            this.serverLabel.Text = "Server";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 457);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.serverLabel);
            this.Controls.Add(this.ServerTabs);
            this.Name = "ServerForm";
            this.Text = "Servidor";
            this.Load += new System.EventHandler(this.ServerForm_Load_1);
            this.ServerTabs.ResumeLayout(false);
            this.StatusTab.ResumeLayout(false);
            this.StatusTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl ServerTabs;
        private System.Windows.Forms.TabPage StatusTab;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button FreezeButton;
        private System.Windows.Forms.TextBox freezeTimeBox;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.Button StatusButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentFreezeTimeLabel;
        private System.Windows.Forms.CheckBox verboseRadioButton;
    }
}