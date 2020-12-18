namespace DHCP_Breaker_app
{
    partial class frmDHCPBreaker
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbNet = new System.Windows.Forms.ComboBox();
            this.lblNet = new System.Windows.Forms.Label();
            this.cmdStart = new System.Windows.Forms.Button();
            this.lstServeurDHCP = new System.Windows.Forms.ListBox();
            this.lblServeurDHCP = new System.Windows.Forms.Label();
            this.cmdStop = new System.Windows.Forms.Button();
            this.rtxtPackets = new System.Windows.Forms.RichTextBox();
            this.cmdNetRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbNet
            // 
            this.cmbNet.FormattingEnabled = true;
            this.cmbNet.Location = new System.Drawing.Point(12, 267);
            this.cmbNet.Name = "cmbNet";
            this.cmbNet.Size = new System.Drawing.Size(355, 23);
            this.cmbNet.TabIndex = 0;
            this.cmbNet.SelectedIndexChanged += new System.EventHandler(this.cmbNet_SelectedIndexChanged);
            // 
            // lblNet
            // 
            this.lblNet.AutoSize = true;
            this.lblNet.Location = new System.Drawing.Point(12, 249);
            this.lblNet.Name = "lblNet";
            this.lblNet.Size = new System.Drawing.Size(180, 15);
            this.lblNet.TabIndex = 1;
            this.lblNet.Text = "Choissez la carte réseau à couvrir";
            this.lblNet.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(404, 267);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(107, 23);
            this.cmdStart.TabIndex = 3;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // lstServeurDHCP
            // 
            this.lstServeurDHCP.FormattingEnabled = true;
            this.lstServeurDHCP.ItemHeight = 15;
            this.lstServeurDHCP.Location = new System.Drawing.Point(12, 67);
            this.lstServeurDHCP.Name = "lstServeurDHCP";
            this.lstServeurDHCP.Size = new System.Drawing.Size(136, 154);
            this.lstServeurDHCP.TabIndex = 4;
            // 
            // lblServeurDHCP
            // 
            this.lblServeurDHCP.AutoSize = true;
            this.lblServeurDHCP.Location = new System.Drawing.Point(12, 49);
            this.lblServeurDHCP.Name = "lblServeurDHCP";
            this.lblServeurDHCP.Size = new System.Drawing.Size(136, 15);
            this.lblServeurDHCP.TabIndex = 1;
            this.lblServeurDHCP.Text = "Serveurs DHCP autorisés";
            this.lblServeurDHCP.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.Location = new System.Drawing.Point(404, 319);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(107, 23);
            this.cmdStop.TabIndex = 6;
            this.cmdStop.Text = "Stop";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // rtxtPackets
            // 
            this.rtxtPackets.Location = new System.Drawing.Point(12, 319);
            this.rtxtPackets.Name = "rtxtPackets";
            this.rtxtPackets.ReadOnly = true;
            this.rtxtPackets.Size = new System.Drawing.Size(355, 143);
            this.rtxtPackets.TabIndex = 7;
            this.rtxtPackets.Text = "";
            // 
            // cmdNetRestart
            // 
            this.cmdNetRestart.Enabled = false;
            this.cmdNetRestart.Location = new System.Drawing.Point(404, 423);
            this.cmdNetRestart.Name = "cmdNetRestart";
            this.cmdNetRestart.Size = new System.Drawing.Size(107, 39);
            this.cmdNetRestart.TabIndex = 8;
            this.cmdNetRestart.Text = "Reactiver les cartes réseau";
            this.cmdNetRestart.UseVisualStyleBackColor = true;
            this.cmdNetRestart.Visible = false;
            this.cmdNetRestart.Click += new System.EventHandler(this.cmdNetRestartClick);
            // 
            // frmDHCPBreaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 485);
            this.Controls.Add(this.cmdNetRestart);
            this.Controls.Add(this.rtxtPackets);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.lblServeurDHCP);
            this.Controls.Add(this.lstServeurDHCP);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.lblNet);
            this.Controls.Add(this.cmbNet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDHCPBreaker";
            this.Text = "DHCP Breaker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbNet;
        private System.Windows.Forms.Label lblNet;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.ListBox lstServeurDHCP;
        private System.Windows.Forms.Label lblServeurDHCP;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.RichTextBox rtxtPackets;
        private System.Windows.Forms.Button cmdNetRestart;
    }
}

