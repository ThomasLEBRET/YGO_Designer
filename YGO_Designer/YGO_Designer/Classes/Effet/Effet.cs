namespace YGO_Designer
{
    /// <summary>
    /// Classe modélisant un Effet d'une Carte
    /// </summary>
    public class Effet
    {
        private string cdEffet;
        private string nomEffet;

        /// <summary>
        /// Constructeur de la classe affectant aux paramètres privés les paramètres du constructeur
        /// </summary>
        /// <param name="cdEffet">Le code d'effet de la carte</param>
        /// <param name="nomEffet">Le nom de l'effet de la carte</param>
        public Effet(string cdEffet, string nomEffet)
        {
            this.cdEffet = cdEffet;
            this.nomEffet = nomEffet;
        }

        /// <summary>
        /// Redéfinition de la méthode ToString 
        /// </summary>
        /// <returns>Le nom de l'effet</returns>
        public override string ToString()
        {
            return nomEffet;
        }

        public override bool Equals(object obj)
        {
            if((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;
            else
            {
                Effet e = (Effet)obj;
                return cdEffet == e.cdEffet;
            }
        }

        /// <summary>
        /// Demandé pour Equals
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.cdEffet.Length;
        }

        /// <summary>
        /// Accesseur du code de l'effet
        /// </summary>
        /// <returns>Le code de l'effet</returns>
        public string GetCode()
        {
            return this.cdEffet;
        }

        /// <summary>
        /// Accesseur du nom de l'effet
        /// </summary>
        /// <returns>Le nom de l'effet</returns>
        public string GetNom()
        {
            return this.nomEffet;
        }

        public void SetNom(string nomEffet)
        {
            this.nomEffet = nomEffet;
        }
    }
}
