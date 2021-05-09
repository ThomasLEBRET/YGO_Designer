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

        private void btGenererAleatoire_Click(object sender, EventArgs e)
        {
			lbDeck.Items.Clear();

			if(tbNom.Text != "")
			{
				int nbCartesDeck = new Random().Next(40, 61);


				Deck deck = new Deck(User.GetUsername(), tbNom.Text);
                List<Carte> listCartes = new List<Carte>();

				Carte c;

                int i = 0;

                while (i < nbCartesDeck)
				{
                    c = ORMDeck.PiocheAlea();
                    if (deck.AjouteCarte(c))
                        i++;
                }

                MessageBox.Show(deck.GetSize().ToString());
                MessageBox.Show(nbCartesDeck+"");

				if (ORMDeck.Add(deck))
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
