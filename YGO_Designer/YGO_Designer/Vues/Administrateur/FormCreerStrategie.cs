using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace YGO_Designer
{
    /// <summary>
    /// Formulaire de création d'une stratégie de jeu
    /// </summary>
    public partial class FormCreerStrategie : Form
    {
		/// <summary>
		/// Attribut privé
		/// </summary>
        private List<Effet> lE;

        /// <summary>
        /// Génère la liste d'effet lors de l'appel du constructeur
        /// </summary>
        public FormCreerStrategie()
        {
            InitializeComponent();
            lE = new List<Effet>();
            lE = ORMEffet.GetEffets();
            clbEffets.Items.AddRange(lE.ToArray());
        }

        /// <summary>
        /// Vérifie si le ration des cartes total vaut 100%
        /// </summary>
        /// <returns></returns>
        private bool EstRatioCorrect()
        {
            int ratioS = 0;
            int ratioE = 0;
            int ratioH = 0;

            int.TryParse(tbStarter.Text, out ratioS);
            int.TryParse(tbExtender.Text, out ratioE);
            int.TryParse(tbHandtrap.Text, out ratioH);
            if (ratioS + ratioE + ratioH == 100)
                return true;
            return false;
        }

        /// <summary>
        /// Vérifie si une stratégie de jeu peut être ajoutée dans une base de données et l'ajoute si c'est le cas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btValider_Click(object sender, EventArgs e)
        {
			// Contrôle de validité
            if(EstRatioCorrect())
            {
                if(tbCode.Text != "" && tbNom.Text != "")
                {
					// Créé les attributs de la stratégie
                    string code = tbCode.Text;
                    string nom = tbNom.Text;

                    int ratioStarter = int.Parse(tbStarter.Text);
                    int ratioExtender = int.Parse(tbExtender.Text);
                    int ratioHandtrap = int.Parse(tbHandtrap.Text);

                    List<Effet> lE = new List<Effet>();

					// Ajoute les effets à la liste d'effets
                    foreach(Effet eff in clbEffets.CheckedItems)
                        lE.Add(eff);

					// Créé la stratégie
                    Strategie s = new Strategie(code, nom, ratioStarter, ratioExtender, ratioHandtrap, lE);

					// Ajoute et vérifie si l'ajout de la stratégie s'est bien passé
                    if(ORMStrategie.Add(s))
                        Notification.ShowFormSuccess("La Stratégie " + s.ToString() + " a été ajouté");
                    else
                        Notification.ShowFormDanger("Une erreur inconnue s'est produite, veuillez vérifier votre connexion internet");
                }
                else
                    Notification.ShowFormAlert("Entrez un code et un nom valide svp");
            }
            else
                Notification.ShowFormAlert("Le ratio ne fait pas 100%, veuillez vérifier vos calculs svp");
        }

        /// <summary>
        /// Recherche un effet dans une combo list box avec une requête LINQ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSearchEffet_TextChanged(object sender, EventArgs e)
        {
			// Requête LINQ permettant de chercher un effet
            var effets = 
                from eff in lE
                where eff.GetNom().ToUpper().Contains(tbSearchEffet.Text.ToUpper())
                select eff;

            clbEffets.Items.Clear();
            clbEffets.Items.AddRange(effets.ToList().ToArray());
        }
    }
}
