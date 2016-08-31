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
    public sealed partial class PagePMechanics : Page, INotifyPropertyChanged
    {

        AddContent addInFv;
        Size mainSize = new Size(100, 100);
        public PagePMechanics()
        {
            this.InitializeComponent();
            addInFv = new AddContent(flipView, mainSize);
            myMainPage.DataContext = this.addInFv;
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            mainSize = e.NewSize;


            addInFv.SizeElement = mainSize;

            addInFv.Content();
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

        private void flipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            j.Value = addInFv.SelectPageFV;
        }
    }
}
