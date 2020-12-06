using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using YGO_Designer.Classes;

namespace YGO_Designer
{
    /// <summary>
    /// ORM entre Effet et la base de données
    /// </summary>
    public static class ORMEffet
    {
        /// <summary>
        /// Récupère l'ensemble des effets depuis la table 'effet'
        /// </summary>
        /// <returns>Une liste d'objets de type Effet</returns>
        public static List<Effet> GetEffets()
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT * FROM EFFET";
            List<Effet> lE = new List<Effet>();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
                lE.Add(new Effet(rdr["CODE_EFFET"].ToString(), rdr["NOM_EFFET"].ToString()));
            rdr.Close();
            return lE;
        }

        /// <summary>
        /// Récupère la liste des effets d'une carte
        /// </summary>
        /// <param name="noCarte">Le numéro de la carte</param>
        /// <returns>Une liste d'objets de type Effet</returns>
        public static List<Effet> GetEffetsByCard(int noCarte)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT E.* FROM EFFET_CARTE EC, EFFET E, CARTE C WHERE C.NO_CARTE = EC.NO_CARTE AND C.NO_CARTE = @noCarte AND EC.CODE_EFFET = E.CODE_EFFET";
            cmd.Parameters.Add("@noCarte", MySqlDbType.Int32).Value = noCarte;

            List<Effet> lE = new List<Effet>();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
                lE.Add(new Effet(rdr["CODE_EFFET"].ToString(), rdr["NOM_EFFET"].ToString()));
            rdr.Close();
            return lE;
        }

        /// <summary>
        /// Permet d'ajouter les effets d'une carte dans la tables effet_carte
        /// </summary>
        /// <param name="c">Un objet de type Carte</param>
        /// <returns>Un booléen : true si l'insertion de 0 ou n effets a réussie, false sinon</returns>
        public static bool AjouterEffetsCarte(Carte c)
        {
            if(c != null && ORMCarte.Exist(c))
            {
                MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
                cmd.CommandText = "INSERT INTO EFFET_CARTE(CODE_EFFET, NO_CARTE) VALUES(@cdEffet, @noCarte)";

                cmd.Parameters.Add("@noCarte", MySqlDbType.Int32).Value = c.GetNo();
                MySqlParameter cdEffet = new MySqlParameter("@cdEffet", MySqlDbType.VarChar);
                cmd.Parameters.Add(cdEffet);

                foreach(Effet e in c.GetListEffets())
                {
                        cdEffet.Value = e.GetCode();
                        if(cmd.ExecuteNonQuery() == 1)
                            Notification.ShowFormDanger("Echec : L'effet " + e.GetCode() + " n'a pas été lié à la carte");
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Vérifie si un effet existe
        /// </summary>
        /// <param name="eff">Un effet</param>
        /// <returns></returns>
        private static bool IsExistEffet(Effet eff)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT COUNT(CODE_EFFET) FROM EFFET WHERE CODE_EFFET = @cdEff";
            cmd.Parameters.Add("@cdEff", MySqlDbType.VarChar).Value = eff.GetCode();
            return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
        }

        /// <summary>
        /// Ajoute un effet à la liste globale des effets que peuvent posséder une carte
        /// </summary>
        /// <param name="eff">Un effet</param>
        /// <returns></returns>
        public static bool AddEffet(Effet eff)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            if(!IsExistEffet(eff))
            {
                cmd.CommandText = "INSERT INTO EFFET(CODE_EFFET, NOM_EFFET) VALUES(@cdEffet, @nomEffet)";
                cmd.Parameters.Add("@cdEffet", MySqlDbType.VarChar).Value = eff.GetCode();
                cmd.Parameters.Add("@nomEffet", MySqlDbType.VarChar).Value = eff.GetNom();
                return cmd.ExecuteNonQuery() == 1;
            }
            return false;
        }

        /// <summary>
        /// Ajoute les effets d'une stratégie de jeu par paire afin de déterminer les combos à réaliser
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /*
        public static bool AddEffetsFromCombo(Strategie s)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "INSERT INTO COMBO(CODE_EFFET, CODE_EFFET_1, CODE_STRAT, POIDS) VALUES(@cdE1,@cdE2,@cdStrat,@poids)";

            MySqlParameter cdE1 = new MySqlParameter("@cdE1", MySqlDbType.VarChar);
            MySqlParameter cdE2 = new MySqlParameter("@cdE2", MySqlDbType.VarChar);
            MySqlParameter cdStrat = new MySqlParameter("@cdStrat", MySqlDbType.VarChar);
            MySqlParameter poids = new MySqlParameter("@poids", MySqlDbType.Int16);

            foreach(Effet eff in s.GetListeEffets())
            {
                cdE1.Value = eff.
            }
            cmd.CommandText = "";
            return true;
        }
         */

        /// <summary>
        /// Ajoute les effets d'une stratégie de jeu
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool AddEffetsFromStrat(Strategie s)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "INSERT INTO EFFET_STRAT(CODE_EFFET, CODE_STRAT) VALUES(@cdEffet, @cdStrat)";

            cmd.Parameters.Add(new MySqlParameter("@cdEffet", MySqlDbType.VarChar));
            cmd.Parameters.Add(new MySqlParameter("@cdStrat", MySqlDbType.VarChar));

            bool noError = true;

            foreach(Effet eff in s.GetListeEffets())
            {
                try
                {
                    cmd.Parameters["@cdStrat"].Value = s.GetCode();
                    cmd.Parameters["@cdEffet"].Value = eff.GetCode();
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
                catch(MySqlException exep)
                {
                    Notification.ShowFormDanger(exep.Message);
                    noError = false;
                }
            }
            return noError;
        }
    }
}
