namespace YGO_Designer
{
    partial class FormCreerStrategie
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
            this.gbBase = new System.Windows.Forms.GroupBox();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbEffets = new System.Windows.Forms.GroupBox();
            this.tbSearchEffet = new System.Windows.Forms.TextBox();
            this.clbEffets = new System.Windows.Forms.CheckedListBox();
            this.btValider = new System.Windows.Forms.Button();
            this.gbBase.SuspendLayout();
            this.gbEffets.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBase
            // 
            this.gbBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBase.Controls.Add(this.tbNom);
            this.gbBase.Controls.Add(this.tbCode);
            this.gbBase.Controls.Add(this.label2);
            this.gbBase.Controls.Add(this.label1);
            this.gbBase.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBase.ForeColor = System.Drawing.SystemColors.Control;
            this.gbBase.Location = new System.Drawing.Point(12, 12);
            this.gbBase.Name = "gbBase";
            this.gbBase.Size = new System.Drawing.Size(803, 108);
            this.gbBase.TabIndex = 0;
            this.gbBase.TabStop = false;
            this.gbBase.Text = "Dénomination";
            // 
            // tbNom
            // 
            this.tbNom.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbNom.Location = new System.Drawing.Point(541, 43);
            this.tbNom.MaxLength = 30;
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(229, 31);
            this.tbNom.TabIndex = 3;
            // 
            // tbCode
            // 
            this.tbCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbCode.Location = new System.Drawing.Point(85, 43);
            this.tbCode.MaxLength = 12;
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(132, 31);
            this.tbCode.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(472, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code";
            // 
            // gbEffets
            // 
            this.gbEffets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEffets.Controls.Add(this.tbSearchEffet);
            this.gbEffets.Controls.Add(this.clbEffets);
            this.gbEffets.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEffets.ForeColor = System.Drawing.SystemColors.Control;
            this.gbEffets.Location = new System.Drawing.Point(345, 141);
            this.gbEffets.Name = "gbEffets";
            this.gbEffets.Size = new System.Drawing.Size(437, 326);
            this.gbEffets.TabIndex = 2;
            this.gbEffets.TabStop = false;
            this.gbEffets.Text = "Effets";
            // 
            // tbSearchEffet
            // 
            this.tbSearchEffet.Location = new System.Drawing.Point(89, 23);
            this.tbSearchEffet.Name = "tbSearchEffet";
            this.tbSearchEffet.Size = new System.Drawing.Size(342, 31);
            this.tbSearchEffet.TabIndex = 1;
            this.tbSearchEffet.TextChanged += new System.EventHandler(this.tbSearchEffet_TextChanged);
            // 
            // clbEffets
            // 
            this.clbEffets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbEffets.BackColor = System.Drawing.Color.DarkSlateGray;
            this.clbEffets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbEffets.ForeColor = System.Drawing.SystemColors.Window;
            this.clbEffets.FormattingEnabled = true;
            this.clbEffets.Location = new System.Drawing.Point(6, 60);
            this.clbEffets.Name = "clbEffets";
            this.clbEffets.Size = new System.Drawing.Size(425, 260);
            this.clbEffets.TabIndex = 0;
            // 
            // btValider
            // 
            this.btValider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btValider.BackColor = System.Drawing.Color.Green;
            this.btValider.FlatAppearance.BorderSize = 0;
            this.btValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btValider.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btValider.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btValider.Location = new System.Drawing.Point(597, 504);
            this.btValider.Name = "btValider";
            this.btValider.Size = new System.Drawing.Size(218, 72);
            this.btValider.TabIndex = 3;
            this.btValider.Text = "Valider";
            this.btValider.UseVisualStyleBackColor = false;
            this.btValider.Click += new System.EventHandler(this.btValider_Click);
            // 
            // FormCreerStrategie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(70)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(827, 588);
            this.Controls.Add(this.btValider);
            this.Controls.Add(this.gbEffets);
            this.Controls.Add(this.gbBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCreerStrategie";
            this.Text = "FormCreerStrategie";
            this.gbBase.ResumeLayout(false);
            this.gbBase.PerformLayout();
            this.gbEffets.ResumeLayout(false);
            this.gbEffets.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBase;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbEffets;
        private System.Windows.Forms.CheckedListBox clbEffets;
        private System.Windows.Forms.TextBox tbSearchEffet;
        private System.Windows.Forms.Button btValider;
    }
}