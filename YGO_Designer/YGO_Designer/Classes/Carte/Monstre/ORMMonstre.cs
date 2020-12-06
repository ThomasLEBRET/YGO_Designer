using System;
using MySql.Data.MySqlClient;

namespace YGO_Designer
{
    /// <summary>
    /// Classe static simulant un ORM pour l'objet Monstre 
    /// </summary>
    public static class ORMMonstre
    {
        /// <summary>
        /// Ajoute une carte monstre dans la base de données
        /// </summary>
        /// <param name="m">Une carte Monstre</param>
        /// <returns>Un booléen : true si la carte a pu être ajoutée, false sinon</returns>
        public static bool Add(Monstre m)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();

            cmd.CommandText = "" +
                "INSERT INTO CARTE(CODE_ATTR_CARTE , NOM, DESCRIPTION, TYPE_MO, ATTR_MO, NIVEAU_MO, TYPE_MA, TYPE_PI, ATK, DEF, TYPE_MONSTRE_CARTE) " +
                "VALUES (@cdAttrC, @nomC, @descriptC, @typeMo, @attrMo, @nivMo, NULL, NULL, @atk, @def, @typesCarteMonstre)";

            cmd.Parameters.Add("@cdAttrC", MySqlDbType.VarChar).Value = m.GetAttr().GetCdAttrCarte();
            cmd.Parameters.Add("@nomC", MySqlDbType.VarChar).Value = m.GetNom();
            cmd.Parameters.Add("@descriptC", MySqlDbType.VarChar).Value = m.GetDescription();

            cmd.Parameters.Add("@typeMo", MySqlDbType.VarChar).Value = m.GetTypeM();
            cmd.Parameters.Add("@attrMo", MySqlDbType.VarChar).Value = m.GetAttribut();
            cmd.Parameters.Add("@nivMo", MySqlDbType.Int32).Value = m.GetNiveau();
            cmd.Parameters.Add("@atk", MySqlDbType.Int32).Value = m.GetAtk();
            cmd.Parameters.Add("@def", MySqlDbType.Int32).Value = m.GetDef();
            cmd.Parameters.Add("@typesCarteMonstre", MySqlDbType.VarChar).Value = m.GetSousTypes();

            if (cmd.ExecuteNonQuery() == 1)
            {
                string req = "SELECT LAST_INSERT_ID() FROM CARTE";
                cmd.CommandText = req;
                int no = Convert.ToInt32(cmd.ExecuteScalar());
                m.SetNo(no);
                return ORMEffet.AjouterEffetsCarte(m);
            }
            return false;
        }
    }
}
