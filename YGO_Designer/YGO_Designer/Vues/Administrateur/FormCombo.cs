using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace YGO_Designer
{
	/// <summary>
	/// Formulaire permettant d'ajouter et de visualiser des combinaisons d'effets liées à une stratégie de jeu
	/// </summary>
    public partial class FormCombo : Form
    {
		/// <summary>
		/// Attributs privés
		/// </summary>
        private List<Strategie> lS;

		/// <summary>
		/// Constructeur
		/// </summary>
        public FormCombo()
        {
            InitializeComponent();

            lS = ORMStrategie.GetAll();
            cbStrategie.Items.AddRange(lS.ToArray());
        }

		/// <summary>
		/// Affiche les liens entre les effets de la stratégie
		/// </summary>
		/// <param name="s"></param>
        private void AfficheLiens(Strategie s)
        {
            lbCombos.Items.Clear();
            List<Effet> effetsPere = ORMEffet.GetEffetsComboPereByStrategie(s);
            List<Effet> effetsFils = new List<Effet>();
            string result = "";
            Combo c;

            foreach(Effet eP in effetsPere)
            {
                effetsFils = ORMEffet.GetEffetsComboFilsByStrategie(s, eP);
                foreach(Effet eF in effetsFils)
                {
                    c = ORMCombo.Get(eP, eF, s);
                    result = "";
                    result += "L'effet " + eP.ToString() + " fonctionne bien avec ";

                    if(eP.Equals(eF) || eP == eF)
                        result +=  " lui-même" + " : POIDS : " + c.GetPoids();
                    else
                        result +=  eF.ToString() +  " : POIDS : " + c.GetPoids();

                    lbCombos.Items.Add(result);
                }
            }
            if(result == "")
            {
                result += "Il n'y a aucune notion de combo dans ce Deck";
                lbCombos.Items.Add(result);
            }
            
        }

		/// <summary>
		/// Quand on change de stratégie, on affiche les combinaisons de cette stratégie ainsi que ses effets 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void cbStrategie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbStrategie.SelectedIndex >= 0)
            {
                Strategie s = (Strategie)cbStrategie.SelectedItem;
                lbNomStrat.Text = s.GetNom();

                cbEffet1.Items.Clear();
                cbEffet2.Items.Clear();

                cbEffet1.Items.AddRange(s.GetListeEffets().ToArray());
                cbEffet2.Items.AddRange(s.GetListeEffets().ToArray());

                AfficheLiens(s);
            }
            
        }

		/// <summary>
		/// Ajoute une combinaison d'effet dans une stratégie
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void btAjouterCombo_Click(object sender, EventArgs e)
        {
            if(cbEffet1.SelectedIndex >= 0 && cbEffet2.SelectedIndex >= 0 && cbStrategie.SelectedIndex >= 0 && tbPoids.Text != "")
            {
                Strategie s = (Strategie)cbStrategie.SelectedItem;
                Effet e1 = (Effet)cbEffet1.SelectedItem;
                Effet e2 = (Effet)cbEffet2.SelectedItem;
                int poids = 0;
                
                if(int.TryParse(tbPoids.Text, out poids) && poids != 0)
                {
                    Combo c = new Combo(e1, e2, s, poids);
                    if(ORMCombo.Add(c))
                    {
                        AfficheLiens(s);
                        Notification.ShowFormSuccess("Le combo d'effet " + e1.ToString() + " / " + e2.ToString() + " a bien été ajouté");
                    }
                    else
                        Notification.ShowFormDanger("Une erreur innatendue est survenue, veillez vérifier votre connexion internet");
                }
                else
                    Notification.ShowFormAlert("Le poids doit être un entier supérieur à 0");
            }
            
        }
    }
}
