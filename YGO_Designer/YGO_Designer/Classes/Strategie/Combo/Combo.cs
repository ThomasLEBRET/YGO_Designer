using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGO_Designer
{

    public struct Combo : IComparable<Combo>
    {
        /// <summary>
        /// Attributs privés de la classe
        /// </summary>
        private Effet effetPere;
        private Effet effetFils;
        private Strategie s;
        private int poids;

        /// <summary>
        /// Constructeur par défaut de la classe Combo
        /// </summary>
        /// <param name="effetPere"></param>
        /// <param name="effetFils"></param>
        /// <param name="s"></param>
        /// <param name="poids"></param>
        public Combo(Effet effetPere, Effet effetFils, Strategie s, int poids)
        {
            this.effetPere = effetPere;
            this.effetFils = effetFils;
            this.s = s;
            this.poids = poids;
        }

        public int CompareTo(Combo o)
        {
            return o.poids.CompareTo(this.poids);
        }

        /// <summary>
        /// Accesseur de l'effet père
        /// </summary>
        /// <returns></returns>
        public Effet GetEffetPere()
        { 
            return this.effetPere;
        }

        /// <summary>
        /// Accesseur de l'effet fils
        /// </summary>
        /// <returns></returns>
        public Effet GetEffetFils()
        {
            return this.effetFils;
        }

        /// <summary>
        /// Accesseur de stratégie
        /// </summary>
        /// <returns></returns>
        public Strategie GetStrategie()
        {
            return this.s;
        }

        /// <summary>
        /// Accesseur de poids
        /// </summary>
        /// <returns></returns>
        public int GetPoids()
        {
            return this.poids;
        }

        /// <summary>
        /// Mutateur de poids
        /// </summary>
        /// <param name="poids">Le poids du combo</param>
        public void SetPoids(int poids)
        {
            this.poids = poids;
        }

        /// <summary>
        /// Redéfinition de la méthode ToString de la superclasse Object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Les effets " + this.effetFils + " et " + this.effetPere +" sont liés";
        }
    }
    
}
