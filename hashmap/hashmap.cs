using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashmap
{
    //hashmap mantığı kullanarak dizi de veri tutmaya yardımcı olması için bu class yazıldı
    //bu türde bir dizi oluşturduğumuz zaman hashmap mantığı ile bir dizi oluşturmuş olacağız
    //kelimelerin asci olay anahtar değerlerini ve kendi string değerlerini tutuyoruz
    class hashmap
    {
        private int anahtar;
        private string deger;

        public int Anahtar
        {
            get { return anahtar; }
            set { anahtar = value; }
        }

        public string Deger {
            get { return deger; }
            set { deger = value; }
        }

    }
}
