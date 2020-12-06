using System;
using MySql.Data.MySqlClient;

namespace YGO_Designer
{
    /// <summary>
    /// Classe static simulant un ORM pour l'objet Piege 
    /// </summary>
    public static class ORMPiege
    {
        /// <summary>
        /// Ajoute une carte piege dans la base de données
        /// </summary>
        /// <param name="pi">Une carte Piege</param>
        /// <returns>Un booléen : true si la carte a pu être ajoutée, false sinon</returns>
        public static bool Add(Piege pi)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();

            cmd.CommandText = "" +
                "INSERT INTO CARTE(CODE_ATTR_CARTE , NOM, DESCRIPTION, TYPE_MO, ATTR_MO, NIVEAU_MO, TYPE_MA, TYPE_PI, ATK, DEF, TYPE_MONSTRE_CARTE) " +
                "VALUES (@cdAttrC, @nomC, @descriptC, NULL, NULL, NULL, NULL, @typePiege, NULL, NULL, NULL)";

            cmd.Parameters.Add("@cdAttrC", MySqlDbType.VarChar).Value = pi.GetAttr().GetCdAttrCarte();
            cmd.Parameters.Add("@nomC", MySqlDbType.VarChar).Value = pi.GetNom();
            cmd.Parameters.Add("@descriptC", MySqlDbType.VarChar).Value = pi.GetDescription();

            cmd.Parameters.Add("@typePiege", MySqlDbType.VarChar).Value = pi.GetNomTypePi();
            if (cmd.ExecuteNonQuery() == 1)
            {
                string req = "SELECT LAST_INSERT_ID() FROM CARTE";
                cmd.CommandText = req;
                int no = Convert.ToInt32(cmd.ExecuteScalar());
                pi.SetNo(no);
                return ORMEffet.AjouterEffetsCarte(pi);
            }
            return false;
        }
    }
}
