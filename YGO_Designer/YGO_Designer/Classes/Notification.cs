using YGO_Designer.Vues.Joueur;

namespace YGO_Designer
{
    public static class Notification
    {
        private static string description;
        
        private static FormAlert fa;
        private static FormInfo fi;
        private static FormSuccess fs;
        private static FormDanger fd;

        public static void ShowFormAlert(string otherDescription)
        {
            description = otherDescription;
            fa = new FormAlert();
            fa.ShowDialog();
        }

        public static void ShowFormInfo(string otherDescription)
        {
            description = otherDescription;
            fi = new FormInfo();
            fi.ShowDialog();
        }

        public static void ShowFormDanger(string otherDescription)
        {
            description = otherDescription;
            fd = new FormDanger();
            fd.ShowDialog();
        }

        public static void ShowFormSuccess(string otherDescription)
        {
            description = otherDescription;
            fs = new FormSuccess();
            fs.ShowDialog();
        }

        public static string GetDescription()
        {
            return description;
        }

        public static void SetDescription(string otherDescription)
        {
            description = otherDescription;
        }
    }
}
