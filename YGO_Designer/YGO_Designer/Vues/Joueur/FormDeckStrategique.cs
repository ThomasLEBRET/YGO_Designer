using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YGO_Designer.Classes.User;

namespace YGO_Designer
{
    public partial class FormDeckStrategique : Form
    {
        private List<Effet> lE;
        public FormDeckStrategique()
        {
            InitializeComponent();
            lE = ORMEffet.GetEffets();
            foreach (Strategie s in ORMStrategie.GetAll())
                cbStrat.Items.Add(s);
        }

        private void ChargeEffets()
        {
            clbEffets.Items.AddRange(lE.ToArray());
        }

        private void FormDeckStrategique_Load(object sender, EventArgs e)
        {
            ChargeEffets();
        }

        private void btGenererAleatoire_Click(object sender, EventArgs e)
        {
			if(tbNom.Text != "")
			{
				int nbCartesDeck = new Random().Next(40, 61);


				Deck deck = new Deck(tbNom.Text);
                List<Carte> listCartes = new List<Carte>();

				Carte c;

                int i = 0;

                while (i < nbCartesDeck)
				{
                    c = ORMDeck.PiocheAlea();
                    if (deck.AjouteCarte(c))
                        i++;
                }

				if (ORMDeck.Add(deck))
					Notification.ShowFormSuccess("Votre deck a bien été créé !");
			}

			else
				Notification.ShowFormAlert("Entrez un nom avant de générer un deck svp");
        }

        private void btDeckConstruit_Click(object sender, EventArgs e)
        {
            List<Effet> lECheck = new List<Effet>();
            Deck d = new Deck(tbNom.Text);

            List<Carte> lCEffets;
            foreach (Effet eff in clbEffets.CheckedItems)
                lECheck.Add(eff);

            if (lECheck.Count > 0)
            {
                lCEffets = ORMCarte.GetByEffets(lECheck);
                if(lCEffets.Count < 14)
                {
                    Notification.ShowFormAlert("Il n'y a pas assez de cartes pour constituer un deck cohérent");
                    return;
                }
                else 
                {
                    MessageBox.Show(lCEffets.Count+"");
                    foreach(Carte c in lCEffets)
                    {
                        if(d.GetSize() < 40)
                        {
                            d.AjouteCarte(c);
                        }
                    }
                    if (ORMDeck.Add(d))
                        Notification.ShowFormSuccess("Votre deck a été ajouté");
                }
            }
            else
                Notification.ShowFormAlert("Cochez au moins 1 effet svp");
        }

        private void btDeckStrat_Click(object sender, EventArgs e)
        {
            if (cbStrat.SelectedIndex >= 0)
            {
                Strategie s = (Strategie)cbStrat.SelectedItem;
                List<Combo> lC = ORMCombo.GetAll(s);
                lC.Sort();
                int deckSize = 40;
                int nbStarterUtil = 19;
                List<Carte> lS = ORMCarte.GetStarter(lC, nbStarterUtil);

                string st = "";
                foreach(Carte c in lS)
                {
                    st += c.GetNom()+" "+c.GetNbExemplaireFromDeck() + "\n";
                }
                MessageBox.Show(st);


                //TODO :
                //Récupère la quantité de starter et complète avec des extenders - (2-5) handtrap (3 listes : 1 pour chaque catégorie stratégique)
                //3 foreach (pour starter, extenders et handtrap) jusqu'à ce que la taille du deck soit égale à la liste des cartes du deck
                //Insère deck
            }
            else
                Notification.ShowFormAlert("Veuillez sélectionner une stratégie valide svp");
        }
    }
}
