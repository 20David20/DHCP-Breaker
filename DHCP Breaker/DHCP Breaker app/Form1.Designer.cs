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
            this.lblServeursDHCP = new System.Windows.Forms.Label();
            this.cmdStop = new System.Windows.Forms.Button();
            this.rtxtPackets = new System.Windows.Forms.RichTextBox();
            this.cmdNetRestart = new System.Windows.Forms.Button();
            this.lblAdresseDebut = new System.Windows.Forms.Label();
            this.txtDeb1b = new System.Windows.Forms.TextBox();
            this.txtDeb2b = new System.Windows.Forms.TextBox();
            this.txtDeb3b = new System.Windows.Forms.TextBox();
            this.txtDeb4b = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblAdresseFin = new System.Windows.Forms.Label();
            this.cmdAddRange = new System.Windows.Forms.Button();
            this.groupRange = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupRange.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.lstServeurDHCP.Size = new System.Drawing.Size(207, 169);
            this.lstServeurDHCP.TabIndex = 4;
            // 
            // lblServeursDHCP
            // 
            this.lblServeursDHCP.AutoSize = true;
            this.lblServeursDHCP.Location = new System.Drawing.Point(22, 49);
            this.lblServeursDHCP.Name = "lblServeursDHCP";
            this.lblServeursDHCP.Size = new System.Drawing.Size(184, 15);
            this.lblServeursDHCP.TabIndex = 1;
            this.lblServeursDHCP.Text = "Adresses serveurs DHCP autorisés";
            this.lblServeursDHCP.Click += new System.EventHandler(this.label1_Click);
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
            // lblAdresseDebut
            // 
            this.lblAdresseDebut.AutoSize = true;
            this.lblAdresseDebut.Location = new System.Drawing.Point(11, 27);
            this.lblAdresseDebut.Name = "lblAdresseDebut";
            this.lblAdresseDebut.Size = new System.Drawing.Size(98, 15);
            this.lblAdresseDebut.TabIndex = 1;
            this.lblAdresseDebut.Text = "Adresse de début";
            this.lblAdresseDebut.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDeb1b
            // 
            this.txtDeb1b.Location = new System.Drawing.Point(115, 24);
            this.txtDeb1b.Name = "txtDeb1b";
            this.txtDeb1b.Size = new System.Drawing.Size(29, 23);
            this.txtDeb1b.TabIndex = 9;
            // 
            // txtDeb2b
            // 
            this.txtDeb2b.Location = new System.Drawing.Point(150, 24);
            this.txtDeb2b.Name = "txtDeb2b";
            this.txtDeb2b.Size = new System.Drawing.Size(29, 23);
            this.txtDeb2b.TabIndex = 9;
            // 
            // txtDeb3b
            // 
            this.txtDeb3b.Location = new System.Drawing.Point(185, 24);
            this.txtDeb3b.Name = "txtDeb3b";
            this.txtDeb3b.Size = new System.Drawing.Size(29, 23);
            this.txtDeb3b.TabIndex = 9;
            // 
            // txtDeb4b
            // 
            this.txtDeb4b.Location = new System.Drawing.Point(220, 24);
            this.txtDeb4b.Name = "txtDeb4b";
            this.txtDeb4b.Size = new System.Drawing.Size(29, 23);
            this.txtDeb4b.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(220, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(29, 23);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(185, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(29, 23);
            this.textBox2.TabIndex = 9;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(150, 51);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(29, 23);
            this.textBox3.TabIndex = 9;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(115, 51);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(29, 23);
            this.textBox4.TabIndex = 9;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // lblAdresseFin
            // 
            this.lblAdresseFin.AutoSize = true;
            this.lblAdresseFin.Location = new System.Drawing.Point(11, 54);
            this.lblAdresseFin.Name = "lblAdresseFin";
            this.lblAdresseFin.Size = new System.Drawing.Size(81, 15);
            this.lblAdresseFin.TabIndex = 1;
            this.lblAdresseFin.Text = "Adresse de fin";
            this.lblAdresseFin.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmdAddRange
            // 
            this.cmdAddRange.Location = new System.Drawing.Point(174, 80);
            this.cmdAddRange.Name = "cmdAddRange";
            this.cmdAddRange.Size = new System.Drawing.Size(75, 23);
            this.cmdAddRange.TabIndex = 10;
            this.cmdAddRange.Text = "Ajouter";
            this.cmdAddRange.UseVisualStyleBackColor = true;
            // 
            // groupRange
            // 
            this.groupRange.Controls.Add(this.cmdAddRange);
            this.groupRange.Controls.Add(this.lblAdresseFin);
            this.groupRange.Controls.Add(this.textBox4);
            this.groupRange.Controls.Add(this.textBox3);
            this.groupRange.Controls.Add(this.textBox2);
            this.groupRange.Controls.Add(this.textBox1);
            this.groupRange.Controls.Add(this.txtDeb4b);
            this.groupRange.Controls.Add(this.txtDeb3b);
            this.groupRange.Controls.Add(this.txtDeb2b);
            this.groupRange.Controls.Add(this.txtDeb1b);
            this.groupRange.Controls.Add(this.lblAdresseDebut);
            this.groupRange.Location = new System.Drawing.Point(237, 49);
            this.groupRange.Name = "groupRange";
            this.groupRange.Size = new System.Drawing.Size(265, 115);
            this.groupRange.TabIndex = 11;
            this.groupRange.TabStop = false;
            this.groupRange.Text = "Ajouter un range d\'adresses";
            this.groupRange.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Ajouter";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(220, 24);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(29, 23);
            this.textBox9.TabIndex = 9;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(185, 24);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(29, 23);
            this.textBox10.TabIndex = 9;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(150, 24);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(29, 23);
            this.textBox11.TabIndex = 9;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(115, 24);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(29, 23);
            this.textBox12.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Adresse";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.textBox11);
            this.groupBox1.Controls.Add(this.textBox12);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(237, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 86);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ajouter une adresse particulière";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // frmDHCPBreaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 485);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupRange);
            this.Controls.Add(this.cmdNetRestart);
            this.Controls.Add(this.rtxtPackets);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.lblServeursDHCP);
            this.Controls.Add(this.lstServeurDHCP);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.lblNet);
            this.Controls.Add(this.cmbNet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDHCPBreaker";
            this.Text = "DHCP Breaker";
            this.groupRange.ResumeLayout(false);
            this.groupRange.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbNet;
        private System.Windows.Forms.Label lblNet;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.ListBox lstServeurDHCP;
        private System.Windows.Forms.Label lblServeursDHCP;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.RichTextBox rtxtPackets;
        private System.Windows.Forms.Button cmdNetRestart;
        private System.Windows.Forms.Label lblAdresseDebut;
        private System.Windows.Forms.TextBox txtDeb1b;
        private System.Windows.Forms.TextBox txtDeb2b;
        private System.Windows.Forms.TextBox txtDeb3b;
        private System.Windows.Forms.TextBox txtDeb4b;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lblAdresseFin;
        private System.Windows.Forms.Button cmdAddRange;
        private System.Windows.Forms.GroupBox groupRange;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

