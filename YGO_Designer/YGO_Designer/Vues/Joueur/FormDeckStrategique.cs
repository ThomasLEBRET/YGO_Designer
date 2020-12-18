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
        private List<Carte> deck;
        public FormDeckStrategique()
        {
            InitializeComponent();
            deck = new List<Carte>();
            lE = ORMEffet.GetEffets();
        }

        private void ChargeEffets()
        {
            clbEffets.Items.AddRange(lE.ToArray());
        }

        private void FormDeckStrategique_Load(object sender, EventArgs e)
        {
            ChargeEffets();
        }

        private void btVider_Click(object sender, EventArgs e)
        {
            lbDeck.Items.Clear();
            deck.Clear();
        }

        private void tbSearchEffet_TextChanged(object sender, EventArgs e)
        {
            string filtre = tbSearchEffet.Text;
            var query =
                from effet in lE
                where effet.GetNom().ToUpper().Contains(filtre.ToUpper())
                select effet;
            clbEffets.Items.Clear();
            List<Effet> listEffetsFiltre = query.ToList();
            clbEffets.Items.AddRange(listEffetsFiltre.ToArray());

        }

		private int NbCartes(List<Carte> lC)
		{
			int nbExemplaire = 0;
			foreach(Carte c in lC)
			{
				nbExemplaire += c.GetNbExemplaireFromDeck();
			}
			return nbExemplaire;
		}

        private void btGenererAleatoire_Click(object sender, EventArgs e)
        {
			lbDeck.Items.Clear();
			int numDeck = 0;
            //TODO
			if(tbNom.Text != "" && tbNo.Text != "" && int.TryParse(tbNo.Text, out numDeck))
			{
				//ratio aléatoire
				int ratioMagie = new Random().Next(5, 11);
				int ratioPiege = new Random().Next(1, 5);
				int ratioMonstre = new Random().Next(10, 21);

				//Nombre d'exemplaires effectifs de chaque types de cartes
				int nbMag = 0;
				int nbPie = 0;
				int nbMon = 0;

				Deck deck = new Deck(numDeck, User.GetUsername(), tbNom.Text);
				ORMDeck.Add(deck);
				int nbCartesDeck = new Random().Next(40, 61);
				Carte c = null;

				while(deck.GetCartes().Count < nbCartesDeck)
				{
					c = ORMDeck.PiocheAlea(deck);

					if(c.GetAttr().GetCdAttrCarte() == "MAG" && ratioMagie < nbMag)
					{
						ORMDeck.AddCard(c.GetNo(), deck.GetNo());
						nbMag++;
					}
					else
						if(c.GetAttr().GetCdAttrCarte() == "MON" && ratioMagie < nbMon)
						{
							ORMDeck.AddCard(c.GetNo(), deck.GetNo());
							nbMon++;
						}
					else
					{
						if(c.GetAttr().GetCdAttrCarte() == "PIE" && ratioMagie < nbPie)
						{
							ORMDeck.AddCard(c.GetNo(), deck.GetNo());
							nbPie++;
						}
					}
					deck = ORMDeck.Get(deck.GetNo());
					deck.SetCartes(ORMDeck.GetCartes(deck.GetNo()));
				}
				Notification.ShowFormSuccess("Votre deck a bien été créé !");
			}

			else
				Notification.ShowFormAlert("Entrez un nom avant de générer un deck svp");
        }

        private void btDeckConstruit_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void btCreerDeck_Click(object sender, EventArgs e)
        {
            //TODO
        }
    }
}
