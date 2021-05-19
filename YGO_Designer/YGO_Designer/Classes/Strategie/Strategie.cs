using System.Collections.Generic;

namespace YGO_Designer
{
    /// <summary>
    /// Créer un objet de type Stratégie afin de construire automatiquement un Deck
    /// </summary>
    public class Strategie
    {
        /// <summary>
        /// Attributs privés
        /// </summary>
        private string code;
        private string nom;
        private List<Effet> lE;

        /// <summary>
        /// Constructeur par défaut 
        /// </summary>
        /// <param name="code">Code identifiant une stratégie</param>
        /// <param name="nom">Nom</param>
        /// <param name="lE">La liste des effets souhaités pour la stratégie en question</param>
        public Strategie(string code, string nom, List<Effet> lE)
        {
            this.code = code;
            this.nom = nom;
            this.lE = lE;
        }

        /// <summary>
        /// Redéfinition de la méthode ToString issue de la superclasse Object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.code + " : " + this.nom;
        }

        /// <summary>
        /// Accesseur du code
        /// </summary>
        /// <returns></returns>
        public string GetCode()
        {
            return this.code;
        }

        /// <summary>
        /// Accesseur du nom
        /// </summary>
        /// <returns></returns>
        public string GetNom()
        {
            return this.nom;
        }

        /// <summary>
        /// Récupère la liste des effets de la stratégie
        /// </summary>
        /// <returns>Une liste d'Effet</returns>
        public List<Effet> GetListeEffets()
        {
            return this.lE;
        }

        /// <summary>
        /// Mutateur de la liste d'effets de la stratégie
        /// </summary>
        /// <param name="lE">Une liste d'Effet</param>
        public void SetListEffet(List<Effet> lE)
        {
            this.lE = lE;
        }
    }
}
