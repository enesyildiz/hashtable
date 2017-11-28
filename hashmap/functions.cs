using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hashmap
{
    class functions
    {
 
        public int asci(string s)
        {//kelimenin ascii kod karşılığını bulan fonksiyon 
            int topasci = 0;
            for (int i=0; i<s.Length; i++)
            {
                char c = s[i];
                topasci += Convert.ToInt32(c) * (i + 1) * (i + 1);
            }



            return topasci;
        }
        public List<string> Parcala(string filepath)
        {//metni belirtilen karakterlere göre kelime kelime parçalayan fonksiyon
            List<string> dizi = new List<string>();
            dizi.Add("hata");
            try
            {
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("iso-8859-9"), false);
                string yazi = sr.ReadLine();
                dizi.Clear();
                while (yazi != null)
                {
                    yazi = donustur(yazi);
                    string[] k = yazi.Split(new char[] {  '.', '?', '!', ' ', ';', ':', ',','{','}','(',')',
                                                    '<', '>', '/', '$', '[', ']', '(', ')','€','₺','/','+','*',
                                                    '=', '\\', '_', '"','-' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < k.Length; i++)
                    {
                        dizi.Add(k[i]);
                    }
                    yazi = sr.ReadLine();
                }
                sr.Close();

            }
            catch
            {
                MessageBox.Show("Geçerli bir dosya seçiniz");
                
               
            }

            return dizi;

        }
        public string donustur(string s)
        {//türkçe karakterleri ingilizceleri ile değiştiren fonksiyon
            s=s.ToLower();
            s=s.Replace('ı', 'i');
            s=s.Replace('ğ', 'g');
            s=s.Replace('ü', 'u');
            s=s.Replace('ş', 's');
            s=s.Replace('ç', 'c');
            s=s.Replace('ö', 'o');

            return s;
            
        }

        public string Dosyasec()
        {//tezt dosyasını seçmek için yazılan fonksiyon
                      
                string dosyayolu;
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.RestoreDirectory = true;
                dosya.Filter = "text dosyası |*.txt";
                dosya.ShowDialog();

                dosyayolu = dosya.FileName;
            if (dosyayolu == "")
            {
                 MessageBox.Show("Bir text dosyası seçmediniz!");
                 dosyayolu= Dosyasec();
                 return dosyayolu;
                 
                
            }
            else
                return dosyayolu;
        }

        public List<string> kelimeAra(hashmap[] a, List<string> s, List<string> l)
        {//arama işleminin yapıldığı fonksiyon
            List<string> ar=new List<string>();
            asalmi(l.Count * 2,-1);
            int n = Form1.getAsal();
            //hashtable için kullanacağımız dizinin boyutunu buluyoruz
            bool first = true;
            int ind=0;
            int cnt=0;
            int cnt1 = 1;
            bool found = false;
            for (int i = 0; i < s.Count; i++)
            {
                ind = asci(s[i]) % n;
                int inder = asci(s[i]);
                
                while (found==false && cnt<n)
                {

                    if (a[ind].Anahtar == asci(s[i]))
                    {

                        found = true;
                        ar.Add(ind.ToString());
                        ar.Add( a[ind].Deger);
                        if (first == true)
                            ar.Add("yes");
                        else
                            ar.Add("no");
                      
                    }
                    else
                    {
                        first = false;
                        cnt++;
                        ind+=cnt1*cnt1;
                        if (ind >= n)
                        {
                            ind = ind % n;
                        }
                        cnt1++;
                    }
                }


                cnt = 0;
                cnt1 = 0;

                if (found == false)

                {
                    ind = -1;
                    ar.Add(ind.ToString());
                    ar.Add("boş");
                    ar.Add( "no");

                }
                found = false;

            }

            return ar;

        }

        public List<string> kelimeüret(string s)
        {//hatalı yazılan kelimeler için kelimenin hatalı halini üreten fonksiyon
            List<string> a = new List<string>();
            a.Add(s);//listenin ilk elemanına orjinal kelimeyi yazıyoruz.
            //daha sonra buna göre sonuç döndürüyoruz
            for (int i = 0; i < s.Length-1; i++)
            {
                string str;
                    str=swap(s, i, i+1);
                    a.Add(str);
            }
            for (int i = 0; i < s.Length; i++)
            {
                char[] str = new char[s.Length];

                char[] newstr= new char[s.Length-1];
                for (int m = 0; m < s.Length; m++)
                {
                    str[m] = s[m];

                }
                for (int j = i; j < s.Length-1; j++)
                {

                    str[j] = str[j + 1];

                    char l = str[j];
                }
                for (int k = 0; k < newstr.Length; k++)
                {
                    newstr[k] = str[k];
                }

                a.Add(new string(newstr));
            }
            

            return a;
        }
        public string swap(string s, int k, int j)
        {//iki hardin yerini değiştiren fonksiyon
            int boyut = s.Length;
            char[] ar = new char[boyut];
            for (int i = 0; i < boyut; i++)
            {
                ar[i] = s[i];
            }
            char temp = ar[k];
            ar[k] =  ar[j];
            ar[j] = temp;
            s = new string(ar);
            return s;
        }

        public void asalmi(int asal, int asalsayi)
        {
            int cnt = 0;
            for (int i = 1; i < asal; i++)
            {
                if (asal % i == 0)
                    cnt++; 
            }
            if ( cnt <= 2){
                Form1.setAsal(asal);

            }
            else
            {
                asalmi(++asal,asalsayi);
            }

        }
    }


}
