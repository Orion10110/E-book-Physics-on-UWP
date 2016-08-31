using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace Physics
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Tests : Page
    {
        public Tests()
        {
            this.InitializeComponent();
             Main();
        }

        private void Main()
        {

            Stack.Background = SettingApp.BackgroundColor;

            List<TaskTest> tst;
            Stack.Children.Clear();


            using (PhysicsContext db = new PhysicsContext())
            {

                tst = db.Tests.ToList();
            }

            //flipView.Items.Add(new StackPanel());
            int k = 0;

            foreach (TaskTest tr in tst)
            {
                k++;
                Stack.Children.Add(new Exep(tr.content, tr.answers, tr.answer, tr.type, "Задача " + k) {Margin=new Thickness(10)});


            }



        }
    }
}
