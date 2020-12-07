using System;
using MySql.Data.MySqlClient;

namespace YGO_Designer
{
    /// <summary>
    /// Classe servant d'ORM entre la classe Combo et la base de données
    /// </summary>
    public static class ORMCombo
    {
        /// <summary>
        /// Vérifie si un combo existe pour une stratégie donnée
        /// </summary>
        /// <param name="c">Le combo</param>
        /// <returns></returns>
        public static bool Exist(Combo c)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT * FROM COMBO WHERE CODE_EFFET = @cdE1 AND CODE_EFFET_1 = @cdE2 AND CODE_STRAT = @cdStrat";

            cmd.Parameters.Add("@cdE1", MySqlDbType.VarChar).Value = c.GetEffetPere().GetCode();
            cmd.Parameters.Add("@cdE2", MySqlDbType.VarChar).Value = c.GetEffetFils().GetCode();
            cmd.Parameters.Add("@cdStrat", MySqlDbType.VarChar).Value = c.GetStrategie().GetCode();

            MySqlDataReader rdr = cmd.ExecuteReader();
            bool exist = false;
            if(rdr.Read())
                exist = true;
            rdr.Close();
            return exist;
        }
        /// <summary>
        /// Ajoute les effets d'une stratégie de jeu par paire afin de déterminer les combos à réaliser
        /// </summary>
        /// <param name="c">Le combo</param>
        /// <returns></returns>
        public static bool Add(Combo c)
        {
            if(!Exist(c))
            {
                MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
                cmd.CommandText = "INSERT INTO COMBO(CODE_EFFET, CODE_EFFET_1, CODE_STRAT, POIDS) VALUES(@cdE1,@cdE2,@cdStrat,@poids)";

                cmd.Parameters.Add("@cdE1", MySqlDbType.VarChar).Value = c.GetEffetPere().GetCode();
                cmd.Parameters.Add("@cdE2", MySqlDbType.VarChar).Value = c.GetEffetFils().GetCode();
                cmd.Parameters.Add("@cdStrat", MySqlDbType.VarChar).Value = c.GetStrategie().GetCode();
                cmd.Parameters.Add("@poids", MySqlDbType.Int16).Value = c.GetPoids();

                return Convert.ToInt32(cmd.ExecuteNonQuery()) == 1;
            }

            return false;
        }

        public static Combo Get(Effet pere, Effet fils, Strategie s)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT * FROM COMBO WHERE CODE_EFFET = @cdE1 AND CODE_EFFET_1 = @cdE2 AND CODE_STRAT = @cdStrat";
            cmd.Parameters.Add("@cdE1", MySqlDbType.VarChar).Value = pere.GetCode();
            cmd.Parameters.Add("@cdE2", MySqlDbType.VarChar).Value = fils.GetCode();
            cmd.Parameters.Add("@cdStrat", MySqlDbType.VarChar).Value = s.GetCode();

            MySqlDataReader rdr = cmd.ExecuteReader();

            Combo c = new Combo(pere, fils, s, 0);
            if(rdr.Read())
                c.SetPoids(Convert.ToInt16(rdr["POIDS"]));
            rdr.Close();

            return c;
        }
    }
}
