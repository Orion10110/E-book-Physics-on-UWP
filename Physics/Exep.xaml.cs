using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Physics
{
    public sealed partial class Exep : UserControl,INotifyPropertyChanged
    {
        private string questText;

        public string QuestText
        {
            get { return questText; }
            set { questText = value;
                OnPropertyChanged("QuestText");
            }
        }

        private string header;

        public string Header
        {
            get { return header; }
            set { header = value;
                OnPropertyChanged("Header");
            }
        }


        private string answer;

        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }


        public Exep()
        {
            this.InitializeComponent();
        }

        public Exep(String text,String listAns, String answer, String type, string header)
        {
            
            this.InitializeComponent();
           
            textB.FontSize = SettingApp.FontSize;
            textB.Foreground = SettingApp.FontColor;
            Dat.DataContext = this;
            Header = header;
            QuestText = text;
            List<string> listR = new List<string>(listAns.Split('|'));


            List<string> answerL = new List<string>(answer.Split(';'));
            List<string> typesL = new List<string>(type.Split(';'));
            string ans = "";
            for (int i = 0, j = 0; i < answerL.Count && j < typesL.Count; i++, j++)
            {
                ans += answerL[i] + " " + typesL[j] + " ";
            }
            this.Answer = ans;
            foreach (string item in listR)
            {
                List<string> znach = new List<string>(item.Split(';'));
                List<string> types = new List<string>(type.Split(';'));
                String ret="";
                for (int i = 0,j=0; i < znach.Count && j<types.Count; i++,j++)
                {
                    ret += znach[i] + " " + types[j]+" ";
                }
                Rad.Children.Add(new RadioButton() { Content = ret });
            }

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (RadioButton rad in Rad.Children)
            {
                bool tr = (bool)rad.IsChecked;
                if (tr && rad.Content.ToString()==Answer)
                {
                    tue.Background = new SolidColorBrush(Color.FromArgb(0xCC, 0x39, 0xE4, 0x44));
                }
               
            }
        }
    }
}
