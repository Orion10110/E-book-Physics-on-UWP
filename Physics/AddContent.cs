using Physics.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;




namespace Physics
{
    public class AddContent : INotifyPropertyChanged
    {




        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        /// <summary>
        /// сохранение последней страницы
        /// </summary>
        public double ProcentPage { get; set; }



        private FlipView changedFV;


        public FlipView ChangedFV
        {
            get { return changedFV; }
            set { changedFV = value; }
        }

        /// <summary>
        /// Конструктор на добовляемую flipView
        /// </summary>
        /// <param name="changeFV"></param>
        public AddContent(FlipView changeFV, Size SizeElement)
        {
            ChangedFV = changeFV;
            this.SizeElement = SizeElement;
            changeFV.SelectionChanged += ChangeFV_SelectionChanged;

        }



        /// <summary>
        /// Количество страниц в flipView
        /// </summary>
        public int CountPageFV
        {
            get
            {

                return (changedFV.Items.Count);

            }
            private set { }
        }


        /// <summary>
        /// Выделенная страница в flipView
        /// </summary>
        public double SelectPageFV
        {
            get
            {

                return ((double)changedFV.SelectedIndex);

            }

            private set { }
        }



        private void ChangeFV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChangedFV.SelectedIndex > 0)
            {
                SettingApp.ProcentPage = (double)SelectPageFV / CountPageFV;
            }
            OnPropertyChanged("CountPageFV");
            OnPropertyChanged("SelectPageFV");
        }



        /// <summary>
        /// Размер шрифта
        /// </summary>
        private int fontSize = SettingApp.FontSize;

        /// <summary>
        /// Размер шрифта
        /// </summary>
        public int FontSize
        {
            get { return fontSize; }
            set
            {
                fontSize = value;

            }
        }




        
        public static SolidColorBrush FontColor
        {
            get { return SettingApp.FontColor; }
            set { SettingApp.FontColor = value; }
        }












        /// <summary>
        /// размер для добовляемого контента
        /// </summary>
        public Size SizeElement { get; set; }




        public double therePlace(FlipView flipView)
        {
            if (flipView.Items.Count != 0)
            {
                StackPanel stack = flipView.Items.Last() as StackPanel;
                return SizeElement.Height - returnSize(stack).Height;
            }
            return 0;
        }






        public void Content()
        {
            changedFV.Background = SettingApp.BackgroundColor;
            List<Ptable> ptab;
            List<Formul> forl;
            changedFV.Items.Clear();
            ScrollViewer sv = new ScrollViewer();
            sv.Content = addStack(addTitleFirsDiscript("Содержание"));
            changedFV.Items.Add(sv);
            using (PhysicsContext db = new PhysicsContext())
            {
                ptab = db.Ptables.ToList();
               forl = db.Formuls.ToList();
            }

            //flipView.Items.Add(new StackPanel());

            foreach (Ptable pt in ptab)
            {
                if (pt.type == "text")
                {


                    addMegaText(pt.mcontent);

                }
                else if (pt.type == "button")
                {

                    ChangedFV.Items.Add(addButton(pt.mcontent));
                }
                else if (pt.type == "image")
                {

                    addMegaImage(pt.mcontent);
                }
                else if (pt.type == "title")
                {

                    ChangedFV.Items.Add(addTitle(pt.mcontent));
                }
                else if (pt.type == "formyl")
                {
                    Formul formTemp = new Formul();
                    foreach (Formul fr in forl)
                    {
                        if (fr.Id.ToString() == pt.mcontent) { formTemp = fr; }
                    }
                    //ChangedFV.Items.Add(addFormyl(formTemp));
                    addFormyl(formTemp);
                }
                else if (pt.type == "animation2")
                {

                    ChangedFV.Items.Add(addStack(addStack(new Animation2() { HorizontalAlignment = HorizontalAlignment.Center })));
                }
                else if (pt.type == "animation1")
                {
                    
                    ChangedFV.Items.Add(addStack( new Animation1() { HorizontalAlignment=HorizontalAlignment.Center}));
                }
              
            }

            double s = (Math.Round(CountPageFV * SettingApp.ProcentPage, 0));
            if (!Double.IsInfinity(s) && !Double.IsNaN(s))
            {
                int sel = Convert.ToInt32(s);
                changedFV.SelectedIndex = sel;
            }

            OnPropertyChanged("CountPageFV");
            OnPropertyChanged("SelectPageFV");



        }





















        public void addMegaText(string text)
        {
            double fHeight = SizeElement.Height;
            int i = 0;
            int k = 0;
            int j = 1000;
            do
            {
                if (therePlace(changedFV) > 200)
                {

                    StackPanel stack = changedFV.Items.Last() as StackPanel;
                    TextBlock rezervtext = addText("", SizeElement.Width - 20);
                    stack.Children.Add(rezervtext);
                    //  rezervtext.Text = text.Substring(k, text.Length - k);

                    while (therePlace(changedFV) > 10 && k + i != text.Length)
                    {
                        j = text.Length - (k + i);

                        if (j > 100)
                        {
                            rezervtext.Text = text.Substring(k, i += 100);
                        }
                        else if (j > 10)
                        {
                            rezervtext.Text = text.Substring(k, i += 10);
                        }
                        else if (j >= 0)
                        {
                            rezervtext.Text = text.Substring(k, i += 1);
                        }

                        #region
                        //if (j > 100)
                        //{

                        //    rezervtext.Text = text.Substring(k, j -= 100);
                        //}
                        //if (j > 10)
                        //{

                        //    rezervtext.Text = text.Substring(k, j -= 10);
                        //}
                        //if (j > 1)
                        //{

                        //    rezervtext.Text = text.Substring(k, j -= 1);
                        //}


                        //if (j>100)
                        //{

                        //}

                        //rezervtext.Text = rezervtext.Text + text[i];
                        //i++;
                        #endregion


                    }
                    // k = i;
                    j = rezervtext.Text.Length;
                    while (therePlace(changedFV) < 10)
                    {
                        j = rezervtext.Text.LastIndexOf(" ");
                        rezervtext.Text = text.Substring(k, j);




                        //if (j>100)
                        //{

                        //}







                        //rezervtext.Text = rezervtext.Text + text[i];
                        //i++;
                    }

                    i = 0;
                    k += j;
                    //  string ted = rezervtext.Text;
                    // string exitT = text.Substring(k, ted.Length-10);
                    //  k = i-10;
                    //stack.Children.Remove(rezervtext);

                    //stack.Children.Add(addStack(addText(exitT, SizeElement.Width - 50)));
                }
                else
                {
                    changedFV.Items.Add(new StackPanel());
                }
            } while (k < text.Length);






            //while (i < text.Length)
            //{
            //    TextBlock rezervtext = addText("");
            //    flipView.Items.Add(rezervtext);
            //    while (therePlace(flipView) > fHeight - 100 && i < text.Length)
            //    {
            //        rezervtext.Text = rezervtext.Text + text[i];
            //        i++;
            //    }

            //    string ted = rezervtext.Text;
            //    string exitT = text.Substring(k, ted.Length);
            //    k = i;
            //    flipView.Items.Remove(rezervtext);

            //    flipView.Items.Add(addStack(addText(exitT, SizeElement.Width - 50)));
            //}
        }

        private void addFormyl(Formul formTemp)
        {
            FormulCase temp = new FormulCase(formTemp.description, formTemp.uriImage, formTemp.addF, formTemp.Id);
            temp.Width = SizeElement.Width - 90;
            if (ChangedFV.Items[ChangedFV.Items.Count - 1] is StackPanel)
            {
                
                StackPanel stackp = (StackPanel)ChangedFV.Items[ChangedFV.Items.Count - 1];
                if (returnSize(stackp).Height < SizeElement.Height - 300)
                {
                    
                    stackp.Children.Add(temp);
                }
                else
                {
                    ChangedFV.Items.Add(addStack(temp));
                }

            }
            //FormulCase temp = new FormulCase(formTemp.description, formTemp.uriImage, formTemp.addF, formTemp.Id);
            //temp.Width = SizeElement.Width - 90;



           
        }

        public UIElement addTitleFirsDiscript(string text)
        {

            TextBlock temp = new TextBlock();
            temp.Width = SizeElement.Width - 10;
            temp.Text = text;

            temp.FontSize = fontSize;
            temp.Foreground = FontColor;
            temp.TextWrapping = TextWrapping.Wrap;
            temp.FontWeight = FontWeights.Bold;


            return addStack(temp);
        }

        public UIElement addTitle(string text)
        {

            TextBlock temp = new TextBlock();
            temp.Width = SizeElement.Width - 10;
            temp.Text = text;

            temp.FontSize = fontSize;
            temp.Foreground = FontColor;
            temp.TextWrapping = TextWrapping.Wrap;
            temp.FontWeight = FontWeights.Bold;
            if (ChangedFV.Items[0] is ScrollViewer)
            {
                Button tempNav = new Button();
                tempNav.Content = text;
                tempNav.Foreground = FontColor;
                tempNav.Width = SizeElement.Width - 40;
                tempNav.Margin = new Thickness(5);
                int t = ChangedFV.Items.Count;
                tempNav.Click += (sender, e) =>
                {
                    ChangedFV.SelectedIndex = t;
                };

                ScrollViewer sv = (ScrollViewer)ChangedFV.Items[0];

                StackPanel stackp = (StackPanel)sv.Content;
                stackp.Children.Add(tempNav);



              

                
            }

            return addStack(temp);
        }



        public void addMegaImage(string image)
        {
            if (ChangedFV.Items[ChangedFV.Items.Count - 1] is StackPanel)
            {
                StackPanel stackp = (StackPanel)ChangedFV.Items[ChangedFV.Items.Count - 1];
                if (returnSize(stackp).Height < SizeElement.Height - 300)
                {
                    stackp.Children.Add(addImage(image));
                }
                else
                {
                    ChangedFV.Items.Add(addStack(addImage(image)));
                }

            }

        }

        public TextBlock addSimplText(string text)
        {
            TextBlock temp = new TextBlock();
            List<string> mysplit = new List<string>(text.Split());
            TextBlock rezervtext = addText("");
            int count = mysplit.Count;
            int i = 0;
            while (returnSize(rezervtext).Height + 200 < SizeElement.Height && i + 1 <= count)
            {
                rezervtext.Text = rezervtext.Text + mysplit[i] + " ";
                i++;
            }
            string ted = rezervtext.Text;
            temp.Text = ted;
            temp.FontSize = 25;
            temp.TextWrapping = TextWrapping.Wrap;

            return temp;
        }


        public StackPanel addStack(UIElement stack)
        {
            StackPanel temp = new StackPanel();

            temp.Children.Add(stack);

            return temp;
        }
        public StackPanel addStack(List<UIElement> stackList)
        {
            StackPanel temp = new StackPanel();
            foreach (UIElement elem in stackList)
            {
                temp.Children.Add(elem);

            }
            return temp;
        }
        public Image addImage(string text)
        {
            Image temp = new Image();
            temp.Height = 300;
            temp.Source = CreateImageFromAssets(text);
            return temp;
        }


        public static BitmapImage CreateImageFromAssets(string imageFilename)
        {
            return new BitmapImage(new Uri("ms-appx:///Assets/" + imageFilename));
        }



        public TextBlock addText(string text)
        {
            TextBlock temp = new TextBlock();
            temp.Width = SizeElement.Width;
            temp.Text = text;
            temp.FontSize = fontSize;
            temp.Foreground = FontColor;
            temp.TextWrapping = TextWrapping.Wrap;

            return temp;
        }


        public TextBlock addText(string text, double width)
        {
            TextBlock temp = new TextBlock();

            temp.Width = width;
            temp.Text = text;
            temp.FontSize = fontSize;
            temp.TextWrapping = TextWrapping.Wrap;
            temp.Foreground = FontColor;
            return temp;
        }
        public Button addButton(string text)
        {
            Button temp = new Button();
            temp.Height = 25;
            temp.Width = 50;
            temp.Content = text;

            return temp;
        }

        public Size returnSize(UIElement needElemSize)
        {
            needElemSize.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            needElemSize.Arrange(new Rect(new Point(0, 0), needElemSize.DesiredSize));
            Size temp = needElemSize.DesiredSize;
            return temp;
        }



        public UIElement addTitle(string text, FlipView flipView)
        {

            TextBlock temp = new TextBlock();
            temp.Width = SizeElement.Width - 10;
            temp.Text = text;

            temp.FontSize = fontSize;
            temp.Foreground = FontColor;
            temp.TextWrapping = TextWrapping.Wrap;
            temp.FontWeight = FontWeights.Bold;
            if (flipView.Items[0] is ScrollViewer)
            {

                Button tempNav = new Button();
                tempNav.Foreground = FontColor;
                tempNav.Content = text;
                tempNav.Width = SizeElement.Width - 20;
                int t = flipView.Items.Count;
                tempNav.Click += (sender, e) =>
                {
                    flipView.SelectedIndex = t;
                };

                ScrollViewer sv = (ScrollViewer)flipView.Items[0];

                StackPanel stackp = (StackPanel)sv.Content;
                stackp.Children.Add(tempNav);


            }

            return addStack(temp);
        }





    }
}