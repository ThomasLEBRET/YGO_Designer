namespace YGO_Designer
{
    partial class FormCombo
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
            if(disposing && (components != null))
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
            this.cbStrategie = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEffet2 = new System.Windows.Forms.ComboBox();
            this.cbEffet1 = new System.Windows.Forms.ComboBox();
            this.lbNomStrat = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPoids = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btAjouterCombo = new System.Windows.Forms.Button();
            this.gbCombos = new System.Windows.Forms.GroupBox();
            this.lbCombos = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.gbCombos.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbStrategie
            // 
            this.cbStrategie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStrategie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbStrategie.FormattingEnabled = true;
            this.cbStrategie.Location = new System.Drawing.Point(181, 20);
            this.cbStrategie.Margin = new System.Windows.Forms.Padding(5);
            this.cbStrategie.Name = "cbStrategie";
            this.cbStrategie.Size = new System.Drawing.Size(257, 31);
            this.cbStrategie.TabIndex = 0;
            this.cbStrategie.SelectedIndexChanged += new System.EventHandler(this.cbStrategie_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choisi la Stratégie";
            // 
            // cbEffet2
            // 
            this.cbEffet2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEffet2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEffet2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEffet2.FormattingEnabled = true;
            this.cbEffet2.Location = new System.Drawing.Point(415, 67);
            this.cbEffet2.Margin = new System.Windows.Forms.Padding(5);
            this.cbEffet2.Name = "cbEffet2";
            this.cbEffet2.Size = new System.Drawing.Size(350, 31);
            this.cbEffet2.TabIndex = 2;
            // 
            // cbEffet1
            // 
            this.cbEffet1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEffet1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEffet1.FormattingEnabled = true;
            this.cbEffet1.Location = new System.Drawing.Point(25, 67);
            this.cbEffet1.Margin = new System.Windows.Forms.Padding(5);
            this.cbEffet1.Name = "cbEffet1";
            this.cbEffet1.Size = new System.Drawing.Size(350, 31);
            this.cbEffet1.TabIndex = 3;
            // 
            // lbNomStrat
            // 
            this.lbNomStrat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNomStrat.AutoSize = true;
            this.lbNomStrat.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomStrat.Location = new System.Drawing.Point(455, 20);
            this.lbNomStrat.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbNomStrat.Name = "lbNomStrat";
            this.lbNomStrat.Size = new System.Drawing.Size(162, 29);
            this.lbNomStrat.TabIndex = 4;
            this.lbNomStrat.Text = "Nom Stratégie";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbPoids);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btAjouterCombo);
            this.groupBox1.Controls.Add(this.cbEffet1);
            this.groupBox1.Controls.Add(this.cbEffet2);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(63, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 220);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Créer un combo à partir d\'une stratégie";
            // 
            // tbPoids
            // 
            this.tbPoids.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPoids.Location = new System.Drawing.Point(298, 115);
            this.tbPoids.Name = "tbPoids";
            this.tbPoids.Size = new System.Drawing.Size(199, 31);
            this.tbPoids.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(410, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Effet Fils";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Effet père";
            // 
            // btAjouterCombo
            // 
            this.btAjouterCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btAjouterCombo.BackColor = System.Drawing.Color.Green;
            this.btAjouterCombo.FlatAppearance.BorderSize = 0;
            this.btAjouterCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAjouterCombo.ForeColor = System.Drawing.SystemColors.Control;
            this.btAjouterCombo.Location = new System.Drawing.Point(253, 152);
            this.btAjouterCombo.Name = "btAjouterCombo";
            this.btAjouterCombo.Size = new System.Drawing.Size(292, 53);
            this.btAjouterCombo.TabIndex = 4;
            this.btAjouterCombo.Text = "Ajouter le combo";
            this.btAjouterCombo.UseVisualStyleBackColor = false;
            this.btAjouterCombo.Click += new System.EventHandler(this.btAjouterCombo_Click);
            // 
            // gbCombos
            // 
            this.gbCombos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCombos.Controls.Add(this.lbCombos);
            this.gbCombos.ForeColor = System.Drawing.SystemColors.Control;
            this.gbCombos.Location = new System.Drawing.Point(65, 328);
            this.gbCombos.Name = "gbCombos";
            this.gbCombos.Size = new System.Drawing.Size(762, 235);
            this.gbCombos.TabIndex = 6;
            this.gbCombos.TabStop = false;
            this.gbCombos.Text = "Liste des combos pour la stratégie sélectionnée";
            // 
            // lbCombos
            // 
            this.lbCombos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCombos.FormattingEnabled = true;
            this.lbCombos.ItemHeight = 23;
            this.lbCombos.Location = new System.Drawing.Point(23, 30);
            this.lbCombos.Name = "lbCombos";
            this.lbCombos.Size = new System.Drawing.Size(705, 188);
            this.lbCombos.TabIndex = 0;
            // 
            // FormCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(70)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(843, 627);
            this.Controls.Add(this.gbCombos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbNomStrat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbStrategie);
            this.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormCombo";
            this.Text = "FormCombo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbCombos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbStrategie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEffet2;
        private System.Windows.Forms.ComboBox cbEffet1;
        private System.Windows.Forms.Label lbNomStrat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btAjouterCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPoids;
        private System.Windows.Forms.GroupBox gbCombos;
        private System.Windows.Forms.ListBox lbCombos;
    }
}