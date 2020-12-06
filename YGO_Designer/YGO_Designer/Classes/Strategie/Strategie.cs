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
        private int ratioStarter;
        private int ratioExtender;
        private int ratioHandtrap;
        private List<Effet> lE;

        /// <summary>
        /// Constructeur par défaut 
        /// </summary>
        /// <param name="code">Code identifiant une stratégie</param>
        /// <param name="nom">Nom</param>
        /// <param name="ratioStarter">Ratio des cartes servant à démarrer la partie</param>
        /// <param name="ratioExtender">Ratio des cartes servant à étendre notre jeu durant la partie</param>
        /// <param name="ratioHandtrap">Ratio des cartes servant à interrompre l'adversaire</param>
        /// <param name="lE">La liste des effets souhaités pour la stratégie en question</param>
        public Strategie(string code, string nom, int ratioStarter, int ratioExtender, int ratioHandtrap, List<Effet> lE)
        {
            this.code = code;
            this.nom = nom;
            this.ratioStarter = ratioStarter;
            this.ratioExtender = ratioExtender;
            this.ratioHandtrap = ratioHandtrap;
            this.lE = lE;
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
        /// Accesseur du ratio de starter
        /// </summary>
        /// <returns></returns>
        public int GetRatioStarter()
        {
            return this.ratioStarter;
        }

        /// <summary>
        /// Accesseur du ratio d'extender
        /// </summary>
        /// <returns></returns>
        public int GetRatioExtender()
        {
            return this.ratioExtender;
        }

        /// <summary>
        /// Accesseur du ratio de handtrap
        /// </summary>
        /// <returns></returns>
        public int GetRatioHandtrap()
        {
            return this.ratioHandtrap;
        }

        public List<Effet> GetListeEffets()
        {
            return this.lE;
        }
    }
}
