using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Physics
{
    public sealed partial class FormulCase : UserControl, INotifyPropertyChanged
    {
        public int myFontSize
        {
            get { return SettingApp.FontSize; }
            set { SettingApp.FontSize = value; }
        }
        private int idF;

        public int IdF
        {
            get { return idF; }
            set { idF = value; }
        }


        private int isOnAdd;

        public bool IsOnAdd
        {
            get
            {
                if (isOnAdd == 1)
                    return true;
                else return false;
            }
            set
            {
                if (value)
                {
                    isOnAdd = 1;
                    updateBd(1);
                }

                else {
                    updateBd(0);
                    isOnAdd = 0;
                }
            }
        }


        private void updateBd(int setForm)
        {
            using (PhysicsContext db = new PhysicsContext())
            {
                Formul forml1 = db.Formuls.FirstOrDefault(c => c.Id == idF);
                if (forml1 != null)
                {
                    forml1.addF = setForm;
                    db.Formuls.Update(forml1);
                    db.SaveChanges();
                }
            }
        }



        private string discript;

        public string Discription
        {
            get { return discript; }
            set { discript = value; OnPropertyChanged("Discription"); }
        }

        private BitmapImage mySourse;

        public BitmapImage MySourse
        {
            get { return mySourse; }
            set { mySourse = value; }
        }
        public FormulCase()
        {
            this.InitializeComponent();

            Form.DataContext = this;
        }
        public FormulCase(String myDiscpript, String imgName, int IsOnAdd, int Id)
        {
            
            InitializeComponent();
            this.IdF = Id;
            Discription = myDiscpript;
           MySourse = AddContent.CreateImageFromAssets(imgName);
            this.isOnAdd = IsOnAdd;
            Form.DataContext = this;


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

        private void SwitchThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {

        }
    }
}
