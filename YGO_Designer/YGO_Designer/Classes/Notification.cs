using YGO_Designer.Vues.Joueur;

namespace YGO_Designer
{
	/// <summary>
	/// Classe permettant la génération de notifications push lors d'ajout/suppression/modification/evenements réalisés par un utilisateur
	/// </summary>
    public static class Notification
    {
		/// <summary>
		/// Attributs privés static
		/// </summary>
        private static string description;
        
        private static FormAlert fa;
        private static FormInfo fi;
        private static FormSuccess fs;
        private static FormDanger fd;

		/// <summary>
		/// Affiche un notification d'alerte
		/// </summary>
		/// <param name="otherDescription"></param>
        public static void ShowFormAlert(string otherDescription)
        {
            description = otherDescription;
            fa = new FormAlert();
            fa.Show();
        }

		/// <summary>
		/// Affiche une notification d'information
		/// </summary>
		/// <param name="otherDescription"></param>
        public static void ShowFormInfo(string otherDescription)
        {
            description = otherDescription;
            fi = new FormInfo();
			fi.Show();
        }

		/// <summary>
		/// Affiche une notification d'erreur grave
		/// </summary>
		/// <param name="otherDescription"></param>
        public static void ShowFormDanger(string otherDescription)
        {
            description = otherDescription;
            fd = new FormDanger();
			fd.Show();
        }

		/// <summary>
		/// Affiche une notification de succès
		/// </summary>
		/// <param name="otherDescription"></param>
        public static void ShowFormSuccess(string otherDescription)
        {
            description = otherDescription;
            fs = new FormSuccess();
			fs.Show();
        }

		/// <summary>
		/// Accesseur de description
		/// </summary>
		/// <returns></returns>
        public static string GetDescription()
        {
            return description;
        }

		/// <summary>
		/// Mutateur de description
		/// </summary>
		/// <param name="otherDescription"></param>
        public static void SetDescription(string otherDescription)
        {
            description = otherDescription;
        }
    }
}
