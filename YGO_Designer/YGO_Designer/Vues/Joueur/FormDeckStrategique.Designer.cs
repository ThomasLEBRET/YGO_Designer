namespace YGO_Designer
{
    partial class FormDeckStrategique
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
            this.gbGenerateDeck = new System.Windows.Forms.GroupBox();
            this.btGenererAleatoire = new System.Windows.Forms.Button();
            this.btDeckConstruit = new System.Windows.Forms.Button();
            this.gbEffets = new System.Windows.Forms.GroupBox();
            this.gbDeck = new System.Windows.Forms.GroupBox();
            this.lbDeck = new System.Windows.Forms.ListBox();
            this.btCreerDeck = new System.Windows.Forms.Button();
            this.btVider = new System.Windows.Forms.Button();
            this.clbEffets = new System.Windows.Forms.CheckedListBox();
            this.tbSearchEffet = new System.Windows.Forms.TextBox();
            this.lbSearchEffet = new System.Windows.Forms.Label();
            this.gbGenerateDeck.SuspendLayout();
            this.gbEffets.SuspendLayout();
            this.gbDeck.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGenerateDeck
            // 
            this.gbGenerateDeck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGenerateDeck.Controls.Add(this.gbEffets);
            this.gbGenerateDeck.Controls.Add(this.btDeckConstruit);
            this.gbGenerateDeck.Controls.Add(this.btGenererAleatoire);
            this.gbGenerateDeck.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGenerateDeck.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbGenerateDeck.Location = new System.Drawing.Point(12, 12);
            this.gbGenerateDeck.Name = "gbGenerateDeck";
            this.gbGenerateDeck.Size = new System.Drawing.Size(960, 352);
            this.gbGenerateDeck.TabIndex = 0;
            this.gbGenerateDeck.TabStop = false;
            this.gbGenerateDeck.Text = "Générer un deck";
            // 
            // btGenererAleatoire
            // 
            this.btGenererAleatoire.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btGenererAleatoire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btGenererAleatoire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btGenererAleatoire.FlatAppearance.BorderSize = 0;
            this.btGenererAleatoire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGenererAleatoire.Location = new System.Drawing.Point(788, 41);
            this.btGenererAleatoire.Name = "btGenererAleatoire";
            this.btGenererAleatoire.Size = new System.Drawing.Size(166, 57);
            this.btGenererAleatoire.TabIndex = 0;
            this.btGenererAleatoire.Text = "Deck aléatoire";
            this.btGenererAleatoire.UseVisualStyleBackColor = false;
            this.btGenererAleatoire.Click += new System.EventHandler(this.btGenererAleatoire_Click);
            // 
            // btDeckConstruit
            // 
            this.btDeckConstruit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btDeckConstruit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btDeckConstruit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDeckConstruit.FlatAppearance.BorderSize = 0;
            this.btDeckConstruit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDeckConstruit.Location = new System.Drawing.Point(702, 289);
            this.btDeckConstruit.Name = "btDeckConstruit";
            this.btDeckConstruit.Size = new System.Drawing.Size(252, 57);
            this.btDeckConstruit.TabIndex = 1;
            this.btDeckConstruit.Text = "Deck construit par effets";
            this.btDeckConstruit.UseVisualStyleBackColor = false;
            this.btDeckConstruit.Click += new System.EventHandler(this.btDeckConstruit_Click);
            // 
            // gbEffets
            // 
            this.gbEffets.Controls.Add(this.lbSearchEffet);
            this.gbEffets.Controls.Add(this.tbSearchEffet);
            this.gbEffets.Controls.Add(this.clbEffets);
            this.gbEffets.ForeColor = System.Drawing.SystemColors.Control;
            this.gbEffets.Location = new System.Drawing.Point(40, 41);
            this.gbEffets.Name = "gbEffets";
            this.gbEffets.Size = new System.Drawing.Size(639, 284);
            this.gbEffets.TabIndex = 2;
            this.gbEffets.TabStop = false;
            this.gbEffets.Text = "Effets";
            // 
            // gbDeck
            // 
            this.gbDeck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbDeck.Controls.Add(this.lbDeck);
            this.gbDeck.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDeck.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gbDeck.Location = new System.Drawing.Point(12, 388);
            this.gbDeck.Name = "gbDeck";
            this.gbDeck.Size = new System.Drawing.Size(654, 161);
            this.gbDeck.TabIndex = 1;
            this.gbDeck.TabStop = false;
            this.gbDeck.Text = "Deck généré";
            // 
            // lbDeck
            // 
            this.lbDeck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDeck.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lbDeck.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbDeck.ForeColor = System.Drawing.SystemColors.Info;
            this.lbDeck.FormattingEnabled = true;
            this.lbDeck.ItemHeight = 23;
            this.lbDeck.Location = new System.Drawing.Point(20, 32);
            this.lbDeck.Name = "lbDeck";
            this.lbDeck.Size = new System.Drawing.Size(611, 115);
            this.lbDeck.TabIndex = 0;
            // 
            // btCreerDeck
            // 
            this.btCreerDeck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreerDeck.BackColor = System.Drawing.Color.Green;
            this.btCreerDeck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCreerDeck.FlatAppearance.BorderSize = 0;
            this.btCreerDeck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCreerDeck.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCreerDeck.Location = new System.Drawing.Point(772, 388);
            this.btCreerDeck.Name = "btCreerDeck";
            this.btCreerDeck.Size = new System.Drawing.Size(194, 70);
            this.btCreerDeck.TabIndex = 2;
            this.btCreerDeck.Text = "Créer le deck";
            this.btCreerDeck.UseVisualStyleBackColor = false;
            this.btCreerDeck.Click += new System.EventHandler(this.btCreerDeck_Click);
            // 
            // btVider
            // 
            this.btVider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btVider.BackColor = System.Drawing.Color.Silver;
            this.btVider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btVider.FlatAppearance.BorderSize = 0;
            this.btVider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVider.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVider.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btVider.Location = new System.Drawing.Point(772, 479);
            this.btVider.Name = "btVider";
            this.btVider.Size = new System.Drawing.Size(194, 70);
            this.btVider.TabIndex = 3;
            this.btVider.Text = "Vider ";
            this.btVider.UseVisualStyleBackColor = false;
            this.btVider.Click += new System.EventHandler(this.btVider_Click);
            // 
            // clbEffets
            // 
            this.clbEffets.BackColor = System.Drawing.Color.DarkSlateGray;
            this.clbEffets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbEffets.ForeColor = System.Drawing.SystemColors.Window;
            this.clbEffets.FormattingEnabled = true;
            this.clbEffets.Location = new System.Drawing.Point(27, 96);
            this.clbEffets.Name = "clbEffets";
            this.clbEffets.Size = new System.Drawing.Size(587, 182);
            this.clbEffets.TabIndex = 0;
            // 
            // tbSearchEffet
            // 
            this.tbSearchEffet.Location = new System.Drawing.Point(260, 59);
            this.tbSearchEffet.Name = "tbSearchEffet";
            this.tbSearchEffet.Size = new System.Drawing.Size(277, 31);
            this.tbSearchEffet.TabIndex = 1;
            this.tbSearchEffet.TextChanged += new System.EventHandler(this.tbSearchEffet_TextChanged);
            // 
            // lbSearchEffet
            // 
            this.lbSearchEffet.AutoSize = true;
            this.lbSearchEffet.Location = new System.Drawing.Point(35, 62);
            this.lbSearchEffet.Name = "lbSearchEffet";
            this.lbSearchEffet.Size = new System.Drawing.Size(150, 23);
            this.lbSearchEffet.TabIndex = 2;
            this.lbSearchEffet.Text = "Chercher un effet";
            // 
            // FormDeckStrategique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(70)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btVider);
            this.Controls.Add(this.btCreerDeck);
            this.Controls.Add(this.gbDeck);
            this.Controls.Add(this.gbGenerateDeck);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDeckStrategique";
            this.Text = "FormDeckStrategique";
            this.Load += new System.EventHandler(this.FormDeckStrategique_Load);
            this.gbGenerateDeck.ResumeLayout(false);
            this.gbEffets.ResumeLayout(false);
            this.gbEffets.PerformLayout();
            this.gbDeck.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGenerateDeck;
        private System.Windows.Forms.Button btDeckConstruit;
        private System.Windows.Forms.Button btGenererAleatoire;
        private System.Windows.Forms.GroupBox gbEffets;
        private System.Windows.Forms.GroupBox gbDeck;
        private System.Windows.Forms.ListBox lbDeck;
        private System.Windows.Forms.Button btCreerDeck;
        private System.Windows.Forms.Button btVider;
        private System.Windows.Forms.CheckedListBox clbEffets;
        private System.Windows.Forms.Label lbSearchEffet;
        private System.Windows.Forms.TextBox tbSearchEffet;
    }
}