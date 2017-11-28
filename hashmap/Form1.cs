using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hashmap
{

    public partial class Form1 : Form
    {
        List<string> k;

        hashmap[] kelimeler;
        int[] hashtable;
        List<string> liste=new List<string>();
        functions f = new functions();
        int n;
        static int asalsayi;
        bool tık = false;

        public static void setAsal(int asal)
        {
            asalsayi = asal;
        }
        public static int getAsal()
        {
            return asalsayi;
        }

        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> ar = f.kelimeüret(textBox1.Text);
            List<string> ind = f.kelimeAra(kelimeler, ar, liste);
            int cnt = 0;
            listBox3.Items.Clear();


            if(ind[0]=="-1" && ind[2]=="no")
            {
                for (int i = 0; i < ind.Count-3; i += 3)
                {
                    cnt++;
                    if (ind[i] != "-1")
                    {
                        listBox3.Items.Add(ind[i] + " - " + ind[i + 1]);
                        cnt--;
                    }
                }
                if (cnt == ar.Count-1)
                {
                    MessageBox.Show("Aradığınız Kelime Bulunamadı");

                }

            }

            if(ind[0] != "-1" && ind[2] == "yes")
            {
                listBox3.Items.Add(ind[0]+"-"+ ind[1]);
                MessageBox.Show("Aradığınız "+ind[1]+" kelimesi "+ind[0]+". indexte bulundu" );
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (liste.Count == 0)
            {
                liste = f.Parcala(textBox2.Text);
                f.asalmi(liste.Count*2, -1);
                n = getAsal();
                foreach (var item in liste)
                {
                    listBox1.Items.Add(item);
                }
                label2.Text = liste.Count + " Adet Kelime";

                kelimeler = new hashmap[n];
                hashtable = new int[n];
                for (int k = 0; k < n; k++)
                {
                    kelimeler[k] = new hashmap();
                    kelimeler[k].Anahtar = -1;
                    kelimeler[k].Deger = "";
                }
            }
            else
            {
                button4_Click(sender, e);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

           
            if (tık == false)
            {
                for (int i = 0; i < liste.Count; i++)
                {
                    int asci;
                    int cnt = 1;
                    string str = liste[i];
                    asci = f.asci(liste[i]);
                    int sira = asci % n;
                    int m = n;
                    int sira1 = asci % n;

                    while (kelimeler[sira].Deger != "")
                    {
                        sira += cnt * cnt;
                        if (sira >= n)
                        {
                            sira = sira % n;
                        }
                        cnt++;

                    }

                    kelimeler[sira].Anahtar = asci;
                    kelimeler[sira].Deger = str;



                }
                for (int i = 0; i < kelimeler.Length; i++)
                {
                    if (kelimeler[i].Anahtar != -1)
                        listBox2.Items.Add(i + ". " + kelimeler[i].Anahtar + "-" + kelimeler[i].Deger);

                }

                label3.Text = liste.Count + " kelime " + n + " boyutlu diziye yerleştirildi.";
                tık = true;
            }
            }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            liste.Clear();
            label2.Text = "0 Adet Kelime";
            label3.Text = "Kelime yerleştirilmedi";
            System.GC.SuppressFinalize(kelimeler);
            tık = false;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = f.Dosyasec();
        }


    }
}
