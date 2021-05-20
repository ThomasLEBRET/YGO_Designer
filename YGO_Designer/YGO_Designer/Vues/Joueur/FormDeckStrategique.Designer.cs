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
            this.label1 = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.gbEffets = new System.Windows.Forms.GroupBox();
            this.clbEffets = new System.Windows.Forms.CheckedListBox();
            this.btDeckConstruit = new System.Windows.Forms.Button();
            this.btGenererAleatoire = new System.Windows.Forms.Button();
            this.btDeckStrat = new System.Windows.Forms.Button();
            this.cbStrat = new System.Windows.Forms.ComboBox();
            this.gbGenerateDeck.SuspendLayout();
            this.gbEffets.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGenerateDeck
            // 
            this.gbGenerateDeck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGenerateDeck.Controls.Add(this.cbStrat);
            this.gbGenerateDeck.Controls.Add(this.btDeckStrat);
            this.gbGenerateDeck.Controls.Add(this.label1);
            this.gbGenerateDeck.Controls.Add(this.tbNom);
            this.gbGenerateDeck.Controls.Add(this.gbEffets);
            this.gbGenerateDeck.Controls.Add(this.btDeckConstruit);
            this.gbGenerateDeck.Controls.Add(this.btGenererAleatoire);
            this.gbGenerateDeck.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGenerateDeck.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbGenerateDeck.Location = new System.Drawing.Point(12, 12);
            this.gbGenerateDeck.Name = "gbGenerateDeck";
            this.gbGenerateDeck.Size = new System.Drawing.Size(960, 537);
            this.gbGenerateDeck.TabIndex = 0;
            this.gbGenerateDeck.TabStop = false;
            this.gbGenerateDeck.Text = "Générer un deck";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(698, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nom";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(788, 133);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(147, 31);
            this.tbNom.TabIndex = 3;
            // 
            // gbEffets
            // 
            this.gbEffets.Controls.Add(this.clbEffets);
            this.gbEffets.ForeColor = System.Drawing.SystemColors.Control;
            this.gbEffets.Location = new System.Drawing.Point(40, 41);
            this.gbEffets.Name = "gbEffets";
            this.gbEffets.Size = new System.Drawing.Size(639, 284);
            this.gbEffets.TabIndex = 2;
            this.gbEffets.TabStop = false;
            this.gbEffets.Text = "Effets";
            // 
            // clbEffets
            // 
            this.clbEffets.BackColor = System.Drawing.Color.DarkSlateGray;
            this.clbEffets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbEffets.ForeColor = System.Drawing.SystemColors.Window;
            this.clbEffets.FormattingEnabled = true;
            this.clbEffets.Location = new System.Drawing.Point(27, 44);
            this.clbEffets.Name = "clbEffets";
            this.clbEffets.Size = new System.Drawing.Size(587, 234);
            this.clbEffets.TabIndex = 0;
            // 
            // btDeckConstruit
            // 
            this.btDeckConstruit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btDeckConstruit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btDeckConstruit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDeckConstruit.FlatAppearance.BorderSize = 0;
            this.btDeckConstruit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDeckConstruit.Location = new System.Drawing.Point(702, 381);
            this.btDeckConstruit.Name = "btDeckConstruit";
            this.btDeckConstruit.Size = new System.Drawing.Size(252, 57);
            this.btDeckConstruit.TabIndex = 1;
            this.btDeckConstruit.Text = "Deck construit par effets";
            this.btDeckConstruit.UseVisualStyleBackColor = false;
            this.btDeckConstruit.Click += new System.EventHandler(this.btDeckConstruit_Click);
            // 
            // btGenererAleatoire
            // 
            this.btGenererAleatoire.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btGenererAleatoire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btGenererAleatoire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btGenererAleatoire.FlatAppearance.BorderSize = 0;
            this.btGenererAleatoire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGenererAleatoire.Location = new System.Drawing.Point(788, 318);
            this.btGenererAleatoire.Name = "btGenererAleatoire";
            this.btGenererAleatoire.Size = new System.Drawing.Size(166, 57);
            this.btGenererAleatoire.TabIndex = 0;
            this.btGenererAleatoire.Text = "Deck aléatoire";
            this.btGenererAleatoire.UseVisualStyleBackColor = false;
            this.btGenererAleatoire.Click += new System.EventHandler(this.btGenererAleatoire_Click);
            // 
            // btDeckStrat
            // 
            this.btDeckStrat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btDeckStrat.BackColor = System.Drawing.Color.Maroon;
            this.btDeckStrat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDeckStrat.FlatAppearance.BorderSize = 0;
            this.btDeckStrat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDeckStrat.Location = new System.Drawing.Point(702, 474);
            this.btDeckStrat.Name = "btDeckStrat";
            this.btDeckStrat.Size = new System.Drawing.Size(252, 57);
            this.btDeckStrat.TabIndex = 5;
            this.btDeckStrat.Text = "Deck construitpar stratégie";
            this.btDeckStrat.UseVisualStyleBackColor = false;
            this.btDeckStrat.Click += new System.EventHandler(this.btDeckStrat_Click);
            // 
            // cbStrat
            // 
            this.cbStrat.FormattingEnabled = true;
            this.cbStrat.Location = new System.Drawing.Point(395, 474);
            this.cbStrat.Name = "cbStrat";
            this.cbStrat.Size = new System.Drawing.Size(216, 31);
            this.cbStrat.TabIndex = 6;
            // 
            // FormDeckStrategique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(70)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.gbGenerateDeck);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDeckStrategique";
            this.Text = "FormDeckStrategique";
            this.Load += new System.EventHandler(this.FormDeckStrategique_Load);
            this.gbGenerateDeck.ResumeLayout(false);
            this.gbGenerateDeck.PerformLayout();
            this.gbEffets.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGenerateDeck;
        private System.Windows.Forms.Button btDeckConstruit;
        private System.Windows.Forms.Button btGenererAleatoire;
        private System.Windows.Forms.GroupBox gbEffets;
        private System.Windows.Forms.CheckedListBox clbEffets;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.ComboBox cbStrat;
        private System.Windows.Forms.Button btDeckStrat;
    }
}