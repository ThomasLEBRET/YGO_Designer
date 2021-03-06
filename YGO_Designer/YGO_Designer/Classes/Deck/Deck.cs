﻿using System.Collections.Generic;
using YGO_Designer.Classes.User;

namespace YGO_Designer
{
    /// <summary>
    /// Classe représentant une liste de cartes appartenant à un joueur appelé Deck 
    /// </summary>
    public class Deck
    {
        private int numDeck;
        private string user;
        private string nom;
        private List<Carte> listCartes;

        //Les constantes servent à déterminer le nombre minimum de carte et le nombre maximum de carte que peut comporter un Deck
        private const int nbrCarteMinClassic = 40;
        private const int nbrCarteMaxClassic = 60;

        public Deck()
		{
			this.numDeck = -1;
			this.user = User.GetUsername();
			this.nom = "???";
			this.listCartes = new List<Carte>();
		}

        public Deck(string nom)
            : this()
        {
            this.nom = nom;
        }

        /// <summary>
        /// Constructeur par défaut 
        /// </summary>
        /// <param name="numDeck">Le numéro du deck</param>
        /// <param name="user">Le nom d'utilisateur du joueur</param>
        /// <param name="nom">Le nom du deck</param>
        public Deck(int numDeck, string user, string nom) 
            : this(nom)
        {
            this.numDeck = numDeck;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;
            else
            {
                Deck d = (Deck)obj;
                return numDeck == d.numDeck;
            }
        }

        public override int GetHashCode()
        {
            return this.numDeck;
        }

        /// <summary>
        /// Accesseur du numéro du deck
        /// </summary>
        /// <returns>Le numéro du deck</returns>
        public int GetNo()
        {
            return this.numDeck;
        }

        /// <summary>
        /// Mutateur du numéro de deck
        /// </summary>
        /// <param name="numDeck"></param>
        public void SetNo(int numDeck)
        {
            this.numDeck = numDeck;
        }

        /// <summary>
        /// Accesseur du joueur
        /// </summary>
        /// <returns>Le username du joueur</returns>
        public string GetUsername()
        {
            return this.user;
        }

        /// <summary>
        /// Accesseur du nom du deck
        /// </summary>
        /// <returns>Le nom du deck</returns>
        public string GetNom()
        {
            return this.nom;
        }

        /// <summary>
        /// Accesseur de la liste de cartes du deck
        /// </summary>
        /// <returns>Une liste typée Carte associée au deck</returns>
        public List<Carte> GetCartes()
        {
            return this.listCartes;
        }

        /// <summary>
        /// Mutateur de la liste de cartes du deck
        /// </summary>
        /// <param name="listCartes">Une nouvelle liste typée Carte</param>
        public void SetCartes(List<Carte> listCartes)
        {
            this.listCartes = listCartes;
        }

        /// <summary>
        /// Vérifie si le nombre de cartes d'un deck est compris entre les 2 constantes de la classe
        /// </summary>
        /// <returns>Un booléen : true si le deck est valide, false sinon</returns>
        public bool IsDeckValid()
        {
            bool estValide = false;
            int i = 0;
            foreach(Carte c in this.listCartes)
            {
                i += c.GetNbExemplaireFromDeck();
            }
            if (i >= nbrCarteMinClassic && i <= nbrCarteMaxClassic)
                estValide = true;
            return estValide;
        }

        /// <summary>
        /// Récupère la taille effective du deck en fonction du nombre d'exemplaire de chaque cartes
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            int i = 0;

            foreach (Carte c in this.listCartes)
            {
                i += c.GetNbExemplaireFromDeck();
            }
            return i;
        }

        /// <summary>
        /// Ajoute une carte si elle n'existe pas déjà, sinon ajoute un exemplaire si elle n'existe qu'en moins de 3 exemplaires
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool AjouteCarte(Carte c)
        {
            bool cdt = false;
            if(this.listCartes.Contains(c))
            {
                Carte carte = this.listCartes.Find(x => x.Equals(c));
                if (carte.GetNbExemplaireFromDeck() < 3 && carte.GetNbExemplaireFromDeck() > 0)
                {
                    carte.AjouteExemplaire();
                    this.listCartes.Remove(c);
                    this.listCartes.Add(carte);
                    cdt = true;
                }
            }
            else
            {
                this.listCartes.Add(c);
                cdt = true;
            }
            return cdt;
        }

        /// <summary>
        /// Redéfinition de la méthode ToString
        /// </summary>
        /// <returns>Le nom et le nombre de cartes du deck</returns>
        public override string ToString()
        {
            return this.nom + " : " + GetSize() + " cartes";
        }
    }
}
