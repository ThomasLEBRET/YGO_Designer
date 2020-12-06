using System;
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
        public static bool EstStrategieValide(Strategie s)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();
            cmd.CommandText = "SELECT COUNT(CODE_STRAT) FROM STRATEGIE WHERE CODE_STRAT = @cdStrat";
            cmd.Parameters.Add("@cdStrat", MySqlDbType.VarChar).Value = s.GetCode();
            return Convert.ToInt32(cmd.ExecuteScalar()) == 0;
        }

        /// <summary>
        /// Ajoute un objet de type Strategie à la base de données
        /// </summary>
        /// <param name="s">Un objet de type Strategie</param>
        /// <returns></returns>
        public static bool Add(Strategie s)
        {
            if(EstStrategieValide(s))
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

        
    }
}
