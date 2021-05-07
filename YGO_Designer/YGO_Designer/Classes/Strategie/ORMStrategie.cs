using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace YGO_Designer
{
    /// <summary>
    /// Interation entre l'objet Strategie et la base de données
    /// </summary>
    public static class ORMStrategie
    {
        /// <summary>
        /// Vérifie qu'une stratégie de jeu n'existe pas déjà avant insertion/modification d'une stratégie
        /// </summary>
        /// <param name="s">Un objet de type Strategie</param>
        /// <returns></returns>
        public static bool Exist(Strategie s)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT COUNT(CODE_STRAT) FROM STRATEGIE WHERE CODE_STRAT = @cdStrat";
            cmd.Parameters.Add("@cdStrat", MySqlDbType.VarChar).Value = s.GetCode();
            return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
        }

        /// <summary>
        /// Ajoute un objet de type Strategie à la base de données
        /// </summary>
        /// <param name="s">Un objet de type Strategie</param>
        /// <returns></returns>
        public static bool Add(Strategie s)
        {
            if(!Exist(s))
            {
                MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
                cmd.CommandText = "INSERT INTO STRATEGIE(CODE_STRAT, NOM_STRAT, RATIO_STARTER, RATIO_EXTENDER, RATIO_HANDTRAP) VALUES (@cd, @nom, @starter, @extender, @handtrap)";

                cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = s.GetCode();
                cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = s.GetNom();
                cmd.Parameters.Add("@starter", MySqlDbType.Int16).Value = s.GetRatioStarter();
                cmd.Parameters.Add("@extender", MySqlDbType.Int16).Value = s.GetRatioExtender();
                cmd.Parameters.Add("@handtrap", MySqlDbType.Int16).Value = s.GetRatioHandtrap();

                if(Convert.ToInt32(cmd.ExecuteNonQuery()) == 1 && ORMEffet.AddEffetsFromStrat(s))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Récupère et renvoi toutes les stratégies existantes
        /// </summary>
        /// <returns></returns>
        public static List<Strategie> GetAll()
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT * FROM STRATEGIE";

            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Strategie> lS = new List<Strategie>();
            while(rdr.Read())
                lS.Add(new Strategie(rdr["CODE_STRAT"].ToString(), rdr["NOM_STRAT"].ToString(), Convert.ToInt16(rdr["RATIO_STARTER"]), Convert.ToInt16(rdr["RATIO_EXTENDER"]), Convert.ToInt16(rdr["RATIO_HANDTRAP"]), new List<Effet>()));
            rdr.Close();

            foreach(Strategie s in lS)
                s.SetListEffet(ORMEffet.GetEffetsByStrategie(s));

            return lS;
        }
    }
}
