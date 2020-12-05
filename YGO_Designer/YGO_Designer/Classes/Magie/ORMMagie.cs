using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using YGO_Designer.Classes.ORM;
using YGO_Designer.Classes.Carte;

namespace YGO_Designer
{
    /// <summary>
    /// Classe simulant un ORM pour la classe fille Magie
    /// </summary>
    public static class ORMMagie
    {
        /// <summary>
        /// Ajoute une carte magique dans la base de données
        /// </summary>
        /// <param name="ma">Un objet de type Magie</param>
        /// <returns>un booléen : true si l'insertion s'est bien déroulée, false sinon</returns>
        public static bool Add(Magie ma)
        {
            MySqlCommand cmd = ORMDatabase.GetConn().CreateCommand();

            cmd.CommandText = "" +
                "INSERT INTO CARTE(CODE_ATTR_CARTE , NOM, DESCRIPTION, TYPE_MO, ATTR_MO, NIVEAU_MO, TYPE_MA, TYPE_PI, ATK, DEF, TYPE_MONSTRE_CARTE) " +
                "VALUES (@cdAttrC, @nomC, @descriptC, NULL, NULL, NULL, NULL, @typeMagie, NULL, NULL, NULL, NULL)";

            cmd.Parameters.Add("@cdAttrC", MySqlDbType.VarChar).Value = ma.GetAttr().GetCdAttrCarte();
            cmd.Parameters.Add("@nomC", MySqlDbType.VarChar).Value = ma.GetNom();
            cmd.Parameters.Add("@descriptC", MySqlDbType.VarChar).Value = ma.GetDescription();

            cmd.Parameters.Add("@typeMagie", MySqlDbType.VarChar).Value = ma.GetNomType();
            if (cmd.ExecuteNonQuery() == 1)
            {
                string req = "SELECT LAST_INSERT_ID() FROM CARTE";
                cmd.CommandText = req;
                int no = Convert.ToInt32(cmd.ExecuteScalar());
                ma.SetNo(no);
                return ORMCarte.AjouterEffetsCarte(ma);
            }
            return false;   
        }
    }
}
