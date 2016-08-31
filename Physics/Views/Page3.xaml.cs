using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Physics;


namespace Physics.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page3 : Page
    {
        public Page3()
        {
            this.InitializeComponent();
            Main();
        }

        private void Main()
        {
            Stack.Background = SettingApp.BackgroundColor;
            
            List<Formul> forl;
            Stack.Children.Clear();

            
            using (PhysicsContext db = new PhysicsContext())
            {
               
                forl = db.Formuls.ToList();
            }

            //flipView.Items.Add(new StackPanel());

            foreach (Formul fr in forl)
            {
               
               
               if(fr.addF == 1)
                {
                    Formul formTemp = fr;
                    
                    Stack.Children.Add(addFormyl(formTemp));
                }
            }

           


        }


        private UIElement addFormyl(Formul formTemp)
        {
            FormulCase temp = new FormulCase(formTemp.description, formTemp.uriImage, formTemp.addF, formTemp.Id);

            temp.Margin = new Thickness(0, 5, 0, 0);


            return temp;
        }
    }
}
