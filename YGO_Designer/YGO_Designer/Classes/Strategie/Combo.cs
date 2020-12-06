using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGO_Designer.Classes.Strategie
{
    public struct Combo
    {
        private Effet effet;
        private List<Effet> listEffets;
        public Combo(Effet effet, List<Effet> listEffets)
        {
            this.effet = effet;
            this.listEffets = new List<Effet>();
            this.listEffets = listEffets;
        }

        public override string ToString()
        {
            string result = "";
            foreach(Effet e in this.listEffets)
            {
                result += "L'effet " + effet.ToString() + " fonctionne bien avec ";
                if(this.effet.Equals(e))
                    result +=  " lui-même \n";
                else
                    result +=  e.ToString() +  "\n";
            }
            if(result == "")
                result += "Il n'y a aucune notion de combo dans ce Deck";

            return result;
        }
    }
}
