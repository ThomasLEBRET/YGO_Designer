﻿
namespace YGO_Designer
{
    partial class FormTemplateAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTemplateAdmin));
            this.pnContainer = new System.Windows.Forms.Panel();
            this.btCreerStrat = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btChercherCarte = new System.Windows.Forms.Button();
            this.btAjouterCarte = new System.Windows.Forms.Button();
            this.btHome = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnFormChild = new System.Windows.Forms.Panel();
            this.btCombo = new System.Windows.Forms.Button();
            this.pnContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnContainer
            // 
            this.pnContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnContainer.BackColor = System.Drawing.Color.Black;
            this.pnContainer.Controls.Add(this.btCombo);
            this.pnContainer.Controls.Add(this.btCreerStrat);
            this.pnContainer.Controls.Add(this.btClose);
            this.pnContainer.Controls.Add(this.btChercherCarte);
            this.pnContainer.Controls.Add(this.btAjouterCarte);
            this.pnContainer.Controls.Add(this.btHome);
            this.pnContainer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnContainer.Location = new System.Drawing.Point(1, 1);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Size = new System.Drawing.Size(171, 485);
            this.pnContainer.TabIndex = 4;
            // 
            // btCreerStrat
            // 
            this.btCreerStrat.BackColor = System.Drawing.Color.Transparent;
            this.btCreerStrat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCreerStrat.FlatAppearance.BorderSize = 0;
            this.btCreerStrat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btCreerStrat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btCreerStrat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCreerStrat.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.btCreerStrat.ForeColor = System.Drawing.Color.White;
            this.btCreerStrat.Location = new System.Drawing.Point(0, 242);
            this.btCreerStrat.Name = "btCreerStrat";
            this.btCreerStrat.Size = new System.Drawing.Size(171, 75);
            this.btCreerStrat.TabIndex = 4;
            this.btCreerStrat.Text = "Créer une stratégie de jeu";
            this.btCreerStrat.UseVisualStyleBackColor = false;
            this.btCreerStrat.Click += new System.EventHandler(this.btCreerStrat_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btClose.BackColor = System.Drawing.Color.Maroon;
            this.btClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.btClose.ForeColor = System.Drawing.Color.White;
            this.btClose.Location = new System.Drawing.Point(0, 416);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(171, 69);
            this.btClose.TabIndex = 3;
            this.btClose.Text = "Quitter";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btChercherCarte
            // 
            this.btChercherCarte.BackColor = System.Drawing.Color.Transparent;
            this.btChercherCarte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btChercherCarte.FlatAppearance.BorderSize = 0;
            this.btChercherCarte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btChercherCarte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btChercherCarte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btChercherCarte.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.btChercherCarte.ForeColor = System.Drawing.Color.White;
            this.btChercherCarte.Location = new System.Drawing.Point(0, 161);
            this.btChercherCarte.Name = "btChercherCarte";
            this.btChercherCarte.Size = new System.Drawing.Size(171, 75);
            this.btChercherCarte.TabIndex = 2;
            this.btChercherCarte.Text = "Chercher une carte";
            this.btChercherCarte.UseVisualStyleBackColor = false;
            this.btChercherCarte.Click += new System.EventHandler(this.btChercherCarte_Click);
            // 
            // btAjouterCarte
            // 
            this.btAjouterCarte.BackColor = System.Drawing.Color.Transparent;
            this.btAjouterCarte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAjouterCarte.FlatAppearance.BorderSize = 0;
            this.btAjouterCarte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btAjouterCarte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btAjouterCarte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAjouterCarte.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.btAjouterCarte.ForeColor = System.Drawing.Color.White;
            this.btAjouterCarte.Location = new System.Drawing.Point(0, 81);
            this.btAjouterCarte.Name = "btAjouterCarte";
            this.btAjouterCarte.Size = new System.Drawing.Size(171, 75);
            this.btAjouterCarte.TabIndex = 1;
            this.btAjouterCarte.Text = "Ajouter une carte";
            this.btAjouterCarte.UseVisualStyleBackColor = false;
            this.btAjouterCarte.Click += new System.EventHandler(this.btAjouterCarte_Click);
            // 
            // btHome
            // 
            this.btHome.BackColor = System.Drawing.Color.Transparent;
            this.btHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btHome.FlatAppearance.BorderSize = 0;
            this.btHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHome.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold);
            this.btHome.ForeColor = System.Drawing.Color.White;
            this.btHome.Location = new System.Drawing.Point(0, 0);
            this.btHome.Name = "btHome";
            this.btHome.Size = new System.Drawing.Size(171, 75);
            this.btHome.TabIndex = 0;
            this.btHome.Text = "Home";
            this.btHome.UseVisualStyleBackColor = false;
            this.btHome.Click += new System.EventHandler(this.btHome_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(578, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // pnFormChild
            // 
            this.pnFormChild.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnFormChild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(70)))), ((int)(((byte)(107)))));
            this.pnFormChild.Location = new System.Drawing.Point(171, 1);
            this.pnFormChild.Name = "pnFormChild";
            this.pnFormChild.Size = new System.Drawing.Size(672, 485);
            this.pnFormChild.TabIndex = 5;
            // 
            // btCombo
            // 
            this.btCombo.BackColor = System.Drawing.Color.Transparent;
            this.btCombo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCombo.FlatAppearance.BorderSize = 0;
            this.btCombo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btCombo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCombo.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.btCombo.ForeColor = System.Drawing.Color.White;
            this.btCombo.Location = new System.Drawing.Point(0, 323);
            this.btCombo.Name = "btCombo";
            this.btCombo.Size = new System.Drawing.Size(171, 87);
            this.btCombo.TabIndex = 5;
            this.btCombo.Text = "Organiser les combos d\'une stratégie";
            this.btCombo.UseVisualStyleBackColor = false;
            this.btCombo.Click += new System.EventHandler(this.btCombo_Click);
            // 
            // FormTemplateAdmin
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(843, 486);
            this.Controls.Add(this.pnFormChild);
            this.Controls.Add(this.pnContainer);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTemplateAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YGO Designer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormTemplate_Load);
            this.pnContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btHome;
        private System.Windows.Forms.Button btAjouterCarte;
        private System.Windows.Forms.Button btChercherCarte;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel pnFormChild;
        private System.Windows.Forms.Button btCreerStrat;
        private System.Windows.Forms.Button btCombo;
    }
}

