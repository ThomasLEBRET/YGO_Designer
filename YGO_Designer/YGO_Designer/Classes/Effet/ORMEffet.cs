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
            if(c != null && ORMCarte.Exist(c.GetNo()))
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

        /// <summary>
        /// Récupère tous les effets d'une stratégie
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static List<Effet> GetEffetsByStrategie(Strategie s)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT E.* FROM EFFET_STRAT ES, EFFET E WHERE ES.CODE_EFFET = E.CODE_EFFET AND ES.CODE_STRAT = @cdStrat";

            cmd.Parameters.Add(new MySqlParameter("@cdStrat", MySqlDbType.VarChar)).Value = s.GetCode();
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Effet> lE = new List<Effet>();
            while(rdr.Read())
                lE.Add(new Effet(rdr["CODE_EFFET"].ToString(), rdr["NOM_EFFET"].ToString()));
            rdr.Close();

            return lE;
        }

        /// <summary>
        /// Récupère les effets pères d'une stratégie basées sur les combos de cette dernière
        /// </summary>
        /// <param name="s">Une stratégie</param>
        /// <returns></returns>
        public static List<Effet> GetEffetsComboPereByStrategie(Strategie s)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT C.CODE_EFFET, E.NOM_EFFET FROM COMBO C, EFFET E WHERE C.CODE_STRAT = @cdStrat AND C.CODE_EFFET = E.CODE_EFFET GROUP BY E.CODE_EFFET";

            cmd.Parameters.Add(new MySqlParameter("@cdStrat", MySqlDbType.VarChar)).Value = s.GetCode();

            List<Effet> lE = new List<Effet>();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
                lE.Add(new Effet(rdr["CODE_EFFET"].ToString(), rdr["NOM_EFFET"].ToString()));
            rdr.Close();

            return lE;
        }

        /// <summary>
        /// Récupère les effets fils d'une stratégie basées sur les combos de cette dernière
        /// </summary>
        /// <param name="s">Une stratégie</param>
        /// <returns></returns>
        public static List<Effet> GetEffetsComboFilsByStrategie(Strategie s, Effet e)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT C.CODE_EFFET_1  FROM COMBO C, EFFET_STRAT EF, EFFET E WHERE C.CODE_EFFET = EF.CODE_EFFET AND EF.CODE_EFFET = E.CODE_EFFET AND C.CODE_STRAT = @cdStrat AND C.CODE_EFFET = @pere AND EF.CODE_STRAT = @cdStrat";

            cmd.Parameters.Add(new MySqlParameter("@cdStrat", MySqlDbType.VarChar)).Value = s.GetCode();
            cmd.Parameters.Add(new MySqlParameter("@pere", MySqlDbType.VarChar)).Value = e.GetCode();

            List<Effet> lE = new List<Effet>();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
                lE.Add(new Effet(rdr["CODE_EFFET_1"].ToString(), ""));
            rdr.Close();
            foreach(Effet eff in lE)
                eff.SetNom(Get(eff.GetCode()));

            return lE;
        }

        /// <summary>
        /// Récupère un effet grâce à son code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Une chaine de caractère string qui est le nom de l'effet</returns>
        public static string Get(string code)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT NOM_EFFET FROM EFFET WHERE CODE_EFFET = @cd";

            cmd.Parameters.Add(new MySqlParameter("@cd", MySqlDbType.VarChar)).Value = code;
            MySqlDataReader rdr = cmd.ExecuteReader();
            string nom = "";
            if (rdr.Read())
                nom = rdr["NOM_EFFET"].ToString();
            rdr.Close();

            return nom;
        }

        /// <summary>
        /// Récupère un effet grâce à son code 
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Un Effet</returns>
        public static Effet GetEffet(string code)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT * FROM EFFET WHERE CODE_EFFET = @cd";

            cmd.Parameters.Add(new MySqlParameter("@cd", MySqlDbType.VarChar)).Value = code;
            MySqlDataReader rdr = cmd.ExecuteReader();
            Effet e = new Effet(code,"");
            if (rdr.Read())
                e.SetNom((string)rdr["NOM_EFFET"]);
            rdr.Close();

            return e;
        }
    }
}
