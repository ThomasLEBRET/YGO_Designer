using System.Collections.Generic;

namespace YGO_Designer
{
    /// <summary>
    /// Classe fille héritée de la classe Carte représentant une carte particulière d'attribut magie
    /// </summary>
    public class Magie : Carte
    {
        private string nomTypeMa;

        /// <summary>
        /// Constructeur hérité de la classe Carte 
        /// </summary>
        /// <param name="eff">La liste des effets</param>
        /// <param name="no">Le numéro</param>
        /// <param name="attr">L'objet Attribut</param>
        /// <param name="nom">Le nom</param>
        /// <param name="description">La description</param>
        /// <param name="nomTypeMa">Le nom du type de magie</param>
        public Magie(List<Effet> eff, int no, Attribut attr, string nom, string description, string nomTypeMa)
            : base(eff, no, attr, nom, description, 1)
        {
            this.nomTypeMa = nomTypeMa;
        }

        /// <summary>
        /// Surcharge du constructeur Magie hérité de la classe Carte
        /// </summary>
        /// <param name="eff">La liste des effets</param>
        /// <param name="no">Le numéro</param>
        /// <param name="attr">L'objet Attribut</param>
        /// <param name="nom">Le nom</param>
        /// <param name="description">La description</param>
        /// <param name="nomTypeMa">Le nom du type de magie</param>
        /// <param name="nbExemplaireDansDeck">Le nombre d'exemplaire d'une carte au sein d'un deck </param>
        public Magie(List<Effet> eff, int no, Attribut attr, string nom, string description, string nomTypeMa, int nbExemplaireDansDeck)
            : base(eff,no,attr,nom,description, nbExemplaireDansDeck)
        {
            this.nomTypeMa = nomTypeMa;
        }

        /// <summary>
        /// Accesseur du nom du type de magie
        /// </summary>
        /// <returns>Le nom du type de magie</returns>
        public string GetNomType()
        {
            return this.nomTypeMa;
        }

        public override bool EstStrater(List<Combo> lC)
        {
            bool isSarter = false;

            foreach(Combo c in lC)
            {
                if(this.GetListEffets().Contains(new Effet("INVSPE", "Invocation Spéciale")) || (this.GetListEffets().Contains(new Effet("EFFRAP", "Effet rapide")) && this.GetListEffets().Contains(c.GetEffetPere()) || this.GetListEffets().Contains(c.GetEffetFils())))
                {
                    isSarter = true;
                }
                    
            }
            return isSarter;
        }

        public override bool EstExtender(List<Combo> lC)
        {
            bool isExtender = false;
            foreach (Combo c in lC)
            {
                if (this.GetListEffets().Contains(new Effet("EFFRAP", "Effet rapide")) || c.GetEffetPere().Equals(new Effet("EFFRAP", "Effet rapide")))
                    isExtender = true;
                if (this.GetListEffets().Contains(c.GetEffetFils()) || this.GetListEffets().Contains(c.GetEffetPere()))
                    isExtender = true;
            }
            return isExtender;
        }

        public override bool EstHandtrap(List<Combo> lC)
        {
            bool isHandtrap = false;

            if (this.GetListEffets().Contains(new Effet("EFFRAP", "Effet rapide")))
            {
                if(this.GetListEffets().Contains(new Effet("ANNULATK", "Annulation attaque")) || this.GetListEffets().Contains(new Effet("INTEREFMO", "Interruption effet de Monstre")))
                {
                    isHandtrap = true;
                }
            }
            return isHandtrap;
        }
    }
}
