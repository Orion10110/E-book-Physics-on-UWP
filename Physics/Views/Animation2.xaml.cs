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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Physics.Views
{
    public sealed partial class Animation2 : UserControl
    {
        DispatcherTimer myTimer = new DispatcherTimer();
        public Animation2()
        {
            this.InitializeComponent();
           
            myTimer.Interval = TimeSpan.FromMilliseconds(30);
            myTimer.Tick += MyTimer_Tick;
            myTimer.Start();
        }
        private int rotaT=0;

        public int RotaT
        {
            get { return rotaT;  }
            set {
                if (rotaT>360)
                {
                    rotaT = 0;
                }
                else
                {
                    rotaT=value;
                }
                

            }
        }

        private void MyTimer_Tick(object sender, object e)
        {
            RotaT++;
            RotateTransform rotate = new RotateTransform();
            rotate.Angle = RotaT;
             image.RenderTransform = rotate;
        }
    }
}
