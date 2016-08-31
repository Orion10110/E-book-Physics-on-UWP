using System;
using System.ComponentModel;
using System.IO;

using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Newtonsoft.Json;
using Windows.Storage.Streams;
using System.Runtime.Serialization.Json;

namespace Physics.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page,INotifyPropertyChanged
    {
        
        public SolidColorBrush BackgroundColor
        {
            get { return SettingApp.BackgroundColor; }
            set {

                
                SettingApp.BackgroundColor = value;
                
//b = value.Color;
                //f = SettingApp.FontColor.Color;
                WritSetting();
                
            }
        }




       
        public SolidColorBrush FontColor
        {
            get { return SettingApp.FontColor; }
            set {
                SettingApp.FontColor = value;
                //f = value.Color;
                //b = SettingApp.BackgroundColor.Color;
                WritSetting();
            }
        }






    

        /// <summary>
        /// Размеры шрифта
        /// </summary>
        public int FontSizeM
        {
            get {

                return SettingApp.FontSize;

            }
            set {

                if (value<90 && value!=0) 
                {
                    SettingApp.FontSize = value;
                }
                else
                {
                    SettingApp.FontSize = 90;
                }
                if (value == 0)
                {
                    SettingApp.FontSize = 1;
                }
                WritSetting();
            }
        }


        public SettingsPage()
        {
            this.InitializeComponent();
            st.DataContext = this;
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {


            FontColor = (SolidColorBrush)((sender as Button).Background);
            OnPropertyChanged("FontColor");
            f = FontColor.Color;
            //

        }

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            BackgroundColor = (SolidColorBrush)((sender as Button).Background);
            OnPropertyChanged("BackgroundColor");
            b = BackgroundColor.Color;
            //SettingApp.BackgroundColor = BackgroundColor;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void tSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnPropertyChanged("FontSizeM");
        }

        Color b;
        Color f;
        private async void WritSetting()
        {
            

           


          
           

        }
    }
}
