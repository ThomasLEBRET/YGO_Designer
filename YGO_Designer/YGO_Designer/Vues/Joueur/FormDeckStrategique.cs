using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

        private void btGenererAleatoire_Click(object sender, EventArgs e)
        {
            //TODO
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
