using System;
using System.Windows.Forms;

namespace YGO_Designer
{
    /// <summary>
    /// Formulaire servant de template aux autres formulaires pour un administrateur se connectant
    /// </summary>
    public partial class FormTemplateAdmin : Form
    {
        private Form activeForm = null;

        private FormHome fh;
        private FormAjouterCartes fac;
        private FormChercherCarte fcc;
        private FormCreerStrategie fcs;
        public FormTemplateAdmin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ouvre le formulaire d'accueil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btHome_Click(object sender, EventArgs e)
        {
            openChildForm(fh);
        }

        /// <summary>
        /// Ouvre le formulaire d'ajout d'une carte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAjouterCarte_Click(object sender, EventArgs e)
        {
            openChildForm(fac);
        }

        /// <summary>
        /// Ouvre le formulaire de recherche d'une carte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btChercherCarte_Click(object sender, EventArgs e)
        {
            openChildForm(fcc);
        }

        /// <summary>
        /// Permet de charger un formulaire dans un panel
        /// </summary>
        /// <param name="childForm"></param>
        private void openChildForm(Form childForm)
        {
            if (childForm != activeForm)
            {
                if (activeForm != null)
                    activeForm.Hide(); //On cache le formulaire enfant actif

                activeForm = childForm;
                childForm.TopLevel = false; //Le formulaire s'affiche en tant que formulaire enfant à celui-ci
                childForm.FormBorderStyle = FormBorderStyle.None; //Pas de bordures
                childForm.Dock = DockStyle.Fill; //Ancrage bord à bord du formulaire enfant
                pnFormChild.Controls.Add(childForm); //Ajout du formulaire enfant dans le panel
                pnFormChild.Tag = childForm; //On y associe le tag
                childForm.BringToFront(); //On affiche le formulaire enfant au premier plan devant le panel
                childForm.Show(); //On affiche le formulaire enfant
            }
        }

        /// <summary>
        /// Charge le formulaire Template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTemplate_Load(object sender, EventArgs e)
        {
            fh = new FormHome();
            fac = new FormAjouterCartes();
            fcc = new FormChercherCarte();
            fcs = new FormCreerStrategie();

            openChildForm(fh);
        }

        /// <summary>
        /// Quitte l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Charge le formulaire CreerStrategie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCreerStrat_Click(object sender, EventArgs e)
        {
            openChildForm(fcs);
        }
    }
}
