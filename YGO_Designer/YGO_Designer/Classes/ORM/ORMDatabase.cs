using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace YGO_Designer
{
    /// <summary>
    /// Classe simulant un ORM pour un objet de tye MySqlConnection
    /// </summary>
    public static class ORMDatabase
    {
        private static MySqlConnection conn = null;

        /// <summary>
        /// Permet d'opérer une connexion entre le client applicatif et le serveur de base de données
        /// </summary>
        /// <returns>Un booléen : true si la connexion a pu s'opérer, false sinon</returns>
        public static bool Connexion()
        {
            try
			{
				conn.Open();
			} 
			catch(MySqlException e)
			{
				MessageBox.Show("La connexion a échouée : " + e.Message);
			}
            return conn.State == System.Data.ConnectionState.Open;
        }

        /// <summary>
        /// Permet de fermer une connexion entre le client applicatif et le serveur de base de données
        /// </summary>
        /// <returns>Un booléen : true si la déconnexion a pu s'opérer, false sinon</returns>
        public static bool Deconnexion()
        {
            conn.Close();
            return conn.State == System.Data.ConnectionState.Closed;
        }

        /// <summary>
        /// Accesseur de l'objet MySqlConnection
        /// </summary>
        /// <returns>La connexion au format MySqlConnection</returns>
        public static MySqlConnection GetConn()
        {
            return conn;
        }

        /// <summary>
        /// Choisi la connexion (base de données distante ou locale via WAMP)
        /// </summary>
        /// <param name="choix"></param>
        public static void ChooseConnexion(string choix)
        {
            switch(choix)
            {
                case "Local":
                    conn = new MySqlConnection(Properties.Settings.Default.loginLocal);
                    break;
                case "Distant":
                    conn = new MySqlConnection(Properties.Settings.Default.loginDist);
                    break;
                default:
                    conn = new MySqlConnection(Properties.Settings.Default.loginLocal);
                    break;
            }
        }

        /// <summary>
        /// Permet de changer la connexion 
        /// </summary>
        /// <param name="choix"></param>
        /// <returns></returns>
        public static bool ChangeConnexion(string choix)
        {
            ChooseConnexion(choix);
            return Connexion();
        }
    }
}
