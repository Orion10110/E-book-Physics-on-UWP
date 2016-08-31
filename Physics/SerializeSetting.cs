using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace Physics
{
    [DataContract]
    class SerializeSetting
    {
        [JsonConstructor]
        public SerializeSetting(int FontSize, Byte Fa, Byte Fr, Byte Fg, Byte Fb, Byte Ba, Byte Br, Byte Bg, Byte Bb,double ProcentPage)
        {
            this.FontSize = FontSize;
            this.Fa = Fa;
            this.Fr = Fr;
            this.Fg = Fg;
            this.Fb = Fb;

            this.Ba = Ba;
            this.Br = Br;
            this.Bg = Bg;
            this.Bb = Bb;
            this.ProcentPage = ProcentPage;

        }



        public SerializeSetting(int FontSize, SolidColorBrush FontColor, SolidColorBrush BackgroundColor)
        {
            this.FontSize = FontSize;
            Fa = FontColor.Color.A;
            Fr = FontColor.Color.R;
            Fg = FontColor.Color.G;
            Fb = FontColor.Color.B;


            Ba = BackgroundColor.Color.A;
            Ba = BackgroundColor.Color.R;
            Ba = BackgroundColor.Color.G;
            Ba = BackgroundColor.Color.B;
          

        }


        [DataMember]
        public byte Fa { get; set; }
        [DataMember]
        public byte Fr { get; set; }
        [DataMember]
        public byte Fg { get; set; }
        [DataMember]
        public byte Fb { get; set; }

        [DataMember]
        public byte Ba { get; set; }
        [DataMember]
        public byte Br { get; set; }
        [DataMember]
        public byte Bg { get; set; }
        [DataMember]
        public byte Bb { get; set; }


        [DataMember]
        public double ProcentPage { get; set; }
        /// <summary>
        /// Размеры шрифта
        /// </summary>
        /// 


        private int fontSize;

        [DataMember]
        public int FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }

        public SolidColorBrush BackgroundColor
        {
            get { return new SolidColorBrush(Color.FromArgb(Ba, Br, Bg, Bb)); }
            private set
            {
            }
        }

        public SolidColorBrush FontColor
        {
            get { return new SolidColorBrush(Color.FromArgb(Fa, Fr, Fg, Fb)); }
            private set
            {
            }
        }









    }
}
