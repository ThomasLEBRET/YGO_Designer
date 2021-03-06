﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using YGO_Designer.Classes.User;

namespace YGO_Designer
{
    /// <summary>
    /// Classe static simulant un ORM associé à l'objet Deck
    /// </summary>
    public static class ORMDeck
    {
        /// <summary>
        /// Méthode privée récupérant le nombre d'exemplaire d'une carte inclus dans un Deck
        /// </summary>
        /// <param name="noDeck">Le numéro du Deck</param>
        /// <param name="noCarte">Le numéro d'une Carte</param>
        /// <returns></returns>
        private static int NbExemplaireCard(int noDeck, int noCarte)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT NB_EXEMPLAIRE FROM INCLUS WHERE NO_DECK = @noDeck AND NO_CARTE = @noCarte";
            cmd.Parameters.Add("@noDeck", MySqlDbType.Int32).Value = noDeck;
            cmd.Parameters.Add("@noCarte", MySqlDbType.Int32).Value = noCarte;
            MySqlDataReader rdr = cmd.ExecuteReader();
            int res = 0;
            if(rdr.Read())
                res = Convert.ToInt16(rdr["NB_EXEMPLAIRE"]);
            rdr.Close();
            return res;
        }

        /// <summary>
        /// Méthode privée vérifiant si un Deck existe
        /// </summary>
        /// <param name="noDeck">Le numéro d'un Deck</param>
        /// <returns>Un booléen : true si le deck existe, false sinon</returns>
        private static bool Exist(int noDeck)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT NO_DECK FROM INCLUS WHERE NO_DECK = @noDeck";
            cmd.Parameters.Add("@noDeck", MySqlDbType.Int32).Value = noDeck;
            MySqlDataReader rdr = cmd.ExecuteReader();
            bool exist = false;

            if(rdr.Read())
                exist = true;
            
            rdr.Close();
            return exist;
        }

        /// <summary>
        /// Ajoute un deck vierge
        /// </summary>
        /// <param name="d">Un objet de type Deck</param>
        /// <returns>Un booléen : true si le deck a été ajouté, false sinon</returns>
        public static bool Add(Deck d)
        {
            if (Exist(d.GetNo()))
                return false;

            string userName = User.GetUsername();
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "INSERT INTO DECK(USER, NOM_DECK) VALUES(@user, @nom)";
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = userName;
            cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = d.GetNom();
            bool cdt = true;
            if (Convert.ToInt32(cmd.ExecuteNonQuery()) == 1)
            {
                int lastIdDeck = GetIdInsertedDeck();
                if (d.GetCartes().Count > 0)
                {
                    foreach (Carte c in d.GetCartes())
                    {
                        if(c.GetNbExemplaireFromDeck() == 1)
                        {
                            AddCard(c.GetNo(), lastIdDeck);
                        }
                        else
                        {
                            for (int i = 1; i <= c.GetNbExemplaireFromDeck(); i++)
                            {
                                if (AddCard(c.GetNo(), lastIdDeck) == false)
                                {
                                    cdt = false;
                                }
                            }
                        }
                    }
                }
                return cdt;
            }
            else
                return false;
        }

        /// <summary>
        /// Ajoute une carte dans un deck
        /// </summary>
        /// <param name="numCarte">Le numéro d'une carte</param>
        /// <param name="numDeck">Le numéro d'un deck</param>
        /// <returns>Un booléen : true si la carte a pu être ajoutée au deck, false sinon</returns>
        public static bool AddCard(int numCarte, int numDeck)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            if (NbExemplaireCard(numDeck, numCarte) == 0)
                cmd.CommandText = "INSERT INTO INCLUS(NO_DECK, NO_CARTE, NB_EXEMPLAIRE) VALUES(@noDeck, @noCarte, 1)";
            else
                if (NbExemplaireCard(numDeck, numCarte) <= 2 && NbExemplaireCard(numDeck, numCarte) > 0)
                    cmd.CommandText = "UPDATE INCLUS SET NB_EXEMPLAIRE = NB_EXEMPLAIRE + 1 WHERE NO_DECK = @noDeck AND NO_CARTE = @noCarte";
                else
                    return true;

            cmd.Parameters.Add("@noDeck", MySqlDbType.Int32).Value = numDeck;
            cmd.Parameters.Add("@noCarte", MySqlDbType.Int32).Value = numCarte;
			return Convert.ToInt32(cmd.ExecuteNonQuery()) == 1;
        }

        /// <summary>
        /// Récupère une liste de decks associés à un joueur
        /// </summary>
        /// <returns>Une liste typée Deck</returns>
        public static List<Deck> GetByUser()
        {
            string userName = User.GetUsername();
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT * FROM DECK WHERE USER = @user";
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = userName;
            List<Deck> ld = new List<Deck>();

            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
                ld.Add(new Deck(Convert.ToInt32(rdr["NO_DECK"]), (string)rdr["USER"], (string)rdr["NOM_DECK"]));
            rdr.Close();
            foreach(Deck d in ld)
                d.SetCartes(ORMDeck.GetCartes(d.GetNo()));
            return ld;
        }

        /// <summary>
        /// Récupère les cartes d'un deck
        /// </summary>
        /// <param name="noDeck">Le numéro d'un deck</param>
        /// <returns>Une liste typée Carte</returns>
        public static List<Carte> GetCartes(int noDeck)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT NO_CARTE FROM INCLUS WHERE NO_DECK = @noDeck";
            cmd.Parameters.Add("@noDeck", MySqlDbType.Int32).Value = noDeck;
            List<int> lNbCartes = new List<int>();

            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                lNbCartes.Add(Convert.ToInt32(rdr["NO_CARTE"]));
            rdr.Close();

            List<Carte> listCartes = new List<Carte>();
            foreach (int i in lNbCartes)
                listCartes.Add(ORMCarte.GetByNoForDeck(i, noDeck));
            return listCartes;
        }

        /// <summary>
        /// Supprime un deck de la base de données pour un utilisateur
        /// </summary>
        /// <param name="id"></param>
        public static bool Delete(int id)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "DELETE FROM DECK WHERE NO_DECK = @noDeck AND USER = @user";
            cmd.Parameters.Add("@noDeck", MySqlDbType.Int32).Value = id;
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = User.GetUsername();
            return Convert.ToInt32(cmd.ExecuteNonQuery()) == 1;
        }

        /// <summary>
        /// Procédure supprimant les cartes d'un deck 
        /// </summary>
        /// <param name="noDeck">Le numéro du deck</param>
        public static void DeleteCards(int noDeck)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "DELETE FROM INCLUS WHERE NO_DECK = @noDeck";
            cmd.Parameters.Add("@noDeck", MySqlDbType.Int32).Value = noDeck;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Méthode suprimant une carte d'un deck
        /// </summary>
        /// <param name="c">Un objet de type Carte</param>
        /// <param name="d">Un objet de type Deck</param>
        /// <returns>Un booléen : true si la carte a pu être supprimée du deck, false sinon</returns>
        public static bool DeleteCard(Carte c, Deck d)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "DELETE FROM INCLUS WHERE NO_DECK = @noDeck AND NO_CARTE = @noCarte";
            cmd.Parameters.Add("@noDeck", MySqlDbType.Int32).Value = d.GetNo();
            cmd.Parameters.Add("@noCarte", MySqlDbType.Int32).Value = c.GetNo();
            return Convert.ToInt32(cmd.ExecuteNonQuery()) == 1;
        }

        /// <summary>
        /// Supprime une copie d'une carte dans un deck
        /// </summary>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns>True si la suppression a été effective, false sinon</returns>
        public static bool RemoveCopyCard(Carte c, Deck d)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "UPDATE INCLUS SET NB_EXEMPLAIRE = NB_EXEMPLAIRE - 1 WHERE NO_DECK = @noDeck AND NO_CARTE = @noCarte";
            cmd.Parameters.Add("@noDeck", MySqlDbType.Int32).Value = d.GetNo();
            cmd.Parameters.Add("@noCarte", MySqlDbType.Int32).Value = c.GetNo();
            return Convert.ToInt32(cmd.ExecuteNonQuery()) == 1;
        }

		/// <summary>
		/// Pioche une carte aléatoirement et l'ajoute au Deck 
		/// </summary>
		/// <returns></returns>
		public static Carte PiocheAlea()
		{
			int noMax = ORMCarte.GetNoMax();
			int no = new Random().Next(1, noMax + 1);
			MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
			cmd.CommandText = "SELECT NO_CARTE FROM CARTE WHERE NO_CARTE = @noCarte";
			cmd.Parameters.Add("@noCarte", MySqlDbType.Int32).Value = no;

			MySqlDataReader rdr;
			while(ORMCarte.Exist(no) == false)
			{
				cmd.Parameters["@noCarte"].Value = new Random().Next(1, noMax);
				rdr = cmd.ExecuteReader();

				if(rdr.Read())
				{
					no = Convert.ToInt32(rdr["NO_CARTE"]);
					rdr.Close();
				}
				else
					rdr.Close();
			}

			return ORMCarte.GetByNo(no);
		}

        /// <summary>
        /// Retourne un deck à un utilisateur
        /// </summary>
        /// <param name="no">Le numéro du Deck à récupére</param>
        /// <returns></returns>
        public static Deck Get(int no)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT * FROM Deck WHERE NO_DECK = @noDeck";
            cmd.Parameters.Add("@noDeck", MySqlDbType.Int32).Value = no;
            MySqlDataReader rdr = cmd.ExecuteReader();

            Deck d = null;
            if (rdr.Read())
            {
                d = new Deck(Convert.ToInt16(rdr["NO_DECK"]), rdr["USER"].ToString(), rdr["NOM_DECK"].ToString());
                rdr.Close();
            }
            return d;
        }

        /// <summary>
        /// Récupère le dernier id de deck inséré dans la base de données
        /// </summary>
        /// <returns></returns>
        public static int GetIdInsertedDeck()
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT LAST_INSERT_ID() as id FROM Deck WHERE USER = @user";
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = User.GetUsername();
            MySqlDataReader rdr = cmd.ExecuteReader();
            int id = 0;
            if (rdr.Read())
                id = Convert.ToInt32(rdr["id"]);
            rdr.Close();
            return id;
        }

        /// <summary>
        /// Compte le nombre de decks de la base de données
        /// </summary>
        /// <returns></returns>
        public static int CountDecks()
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) as qteDecks FROM Deck";
            MySqlDataReader rdr = cmd.ExecuteReader();
            int n = 0;
            if (rdr.Read())
                n = Convert.ToInt32(rdr["qteDecks"]);
            rdr.Close();
            return n;
        }
    }
}
