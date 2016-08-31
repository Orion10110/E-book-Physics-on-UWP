using System.ComponentModel;
using Windows.UI;
using Windows.UI.Xaml.Media;


namespace Physics
{
   
    static class SettingApp
    {
        /// <summary>
        /// Размеры шрифта
        /// </summary>
        private static int fontSize = 18;

        /// <summary>
        /// Размеры шрифта
        /// </summary>
        public static int FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }



        public static SolidColorBrush FontColor
        {
            get;
            set;
        }



        public static double ProcentPage { get; set; }


        public static SolidColorBrush BackgroundColor
        {
            get;
            set;
        }

     

    }
}
