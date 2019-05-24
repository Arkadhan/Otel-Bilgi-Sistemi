using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace veriyapilariotbs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        HashTable ht = new HashTable();
        IkiliAramaAgacDugumu dugum = new IkiliAramaAgacDugumu();
        OtelAgaci otlagac = new OtelAgaci();
        oteller otl = new oteller();
        OtelDetay dty = new OtelDetay();
        ListPersonel listotlpersonel = new ListPersonel();
        Personel otlpersonel = new Personel();
        yorumlar otlyorumlar = new yorumlar();
        ListYorumlar listotlyorumlar = new ListYorumlar();
        private void yoneticiform_Load(object sender, EventArgs e)
        {
            StreamReader oku;
            oku = File.OpenText(@"C:\Users\HP-PC\source\repos\veriyapilariotbs\veriyapilariotbs\bin\Debug\Oteller.txt");
            string yazi;

            while ((yazi = oku.ReadLine()) != null)
            {

                otl = new oteller();
                OtelDetay dty = new OtelDetay();
                otl.Ad = yazi;
                yazi = oku.ReadLine();
                dty.Il = yazi;
                yazi = oku.ReadLine();
                dty.Ilce = yazi;
                yazi = oku.ReadLine();
                otl.Telefon = yazi;
                yazi = oku.ReadLine();
                otl.Eposta = yazi;
                yazi = oku.ReadLine();
                otl.Adres = yazi;
                yazi = oku.ReadLine();
                otl.OdaSayisi = yazi;
                yazi = oku.ReadLine();
                otl.OtelYildizi = yazi;
                yazi = oku.ReadLine();
                dty.Puan = double.Parse(yazi);
                yazi = oku.ReadLine();
                otlagac.Ekle(otl);
                dty.otls = otl;
                otl.otldetaylar.InsertFirst(dty);
                ht.OtelEkle(dty.detayId, dty.heapislemi);

            }
        }
        int dtyId;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Otel adını boş geçmeyiniz.");
            }
            else
            {
                otl = new oteller();
                otl.Ad = textBox1.Text;
                otl.Telefon = textBox3.Text;
                otl.Eposta = textBox4.Text;
                otl.Adres = textBox2.Text;
                otl.OdaSayisi = textBox5.Text;
                otl.OtelYildizi = textBox6.Text;
                 otlagac.Ekle(otl);
                 dty = new OtelDetay();
                dty.detayId = dtyId++;
                dty.Il = textBox51.Text;
                dty.Ilce = textBox52.Text;
                dty.Puan= double.Parse(textBox7.Text);
                dty.otls = otl;
                otl.otldetaylar.InsertFirst(dty);
                
                ht.OtelEkle(dty.detayId, dty.heapislemi);

                MessageBox.Show("Otel Eklendi...");

                textBox1.Text = textBox3.Text = textBox4.Text = textBox2.Text = textBox5.Text = textBox6.Text = textBox51.Text = textBox52.Text = "";
                textBox7.Text = "0";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("Güncellenecek Otelin Adını Giriniz...");
            }
            else
            {
                otl.Ad = textBox15.Text;
                otl.Il = textBox57.Text;
                otl.Ilce = textBox58.Text;
                otl.Telefon = textBox13.Text;
                otl.Eposta = textBox12.Text;
                otl.Adres = textBox14.Text;
                otl.OdaSayisi = textBox11.Text;
                otl.OtelYildizi = textBox10.Text;
                MessageBox.Show("Otel Güncellendi...");
                otl = new oteller();

                textBox8.Text = textBox15.Text = textBox57.Text = textBox58.Text = textBox13.Text = textBox12.Text = textBox14.Text = textBox11.Text = textBox10.Text = "";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("Aranacak Otelin Adını Giriniz...");
            }
            else
            {
                dugum = otlagac.Ara(textBox8.Text);
                if (dugum == null)
                {
                    MessageBox.Show("Otel Bulunamadı...");
                }
                else
                {
                    otl = ((oteller)dugum.veri);
                    textBox15.Text = ((oteller)dugum.veri).Ad;
                    textBox57.Text = ((oteller)dugum.veri).otldetaylar.IlGetir();
                    textBox58.Text = ((oteller)dugum.veri).otldetaylar.IlceGetir();
                    textBox13.Text = ((oteller)dugum.veri).Telefon;
                    textBox12.Text = ((oteller)dugum.veri).Eposta;
                    textBox14.Text = ((oteller)dugum.veri).Adres;
                    textBox11.Text = ((oteller)dugum.veri).OdaSayisi;
                    textBox10.Text = ((oteller)dugum.veri).OtelYildizi;
                   

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("Silmek İstediğiniz Otelin Adını Giriniz...");
            }
            bool silinecekotel = otlagac.Sil(otl.Ad);
            if (silinecekotel)
            {
                MessageBox.Show("Otel Sistemden Silindi...");

                textBox8.Text = textBox15.Text = textBox57.Text = textBox58.Text = textBox13.Text = textBox12.Text = textBox14.Text = textBox11.Text = textBox10.Text = "";
               
            }
            else
            {
                MessageBox.Show("Otel Bulunamadı..");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (textBox16.Text == "")
            {
                MessageBox.Show("Aranacak Otelin Adını Giriniz...");
            }
            else
            {
                dugum = otlagac.Ara(textBox16.Text);
                if (dugum == null)
                {
                    MessageBox.Show("Otel Bulunamadı...");
                }
                else
                {
                    otl = ((oteller)dugum.veri);
                    textBox17.Text = ((oteller)dugum.veri).Ad;
                    //Oteldeki personel  bilgileri   listesi null olana kadar listelendi
                    Node ndpersonel = new Node();
                    ndpersonel = ((oteller)dugum.veri).otlpersonelbilgisi.Head;
                    while (ndpersonel != null)
                    {
                        listBox1.Items.Add(((Personel)ndpersonel.Data).PersonelAdSoyad.ToString());
                        ndpersonel = ndpersonel.Next;
                    }
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox18.Text == "")
            {
                MessageBox.Show("Personel Bilgilerini Giriniz...");
            }
            else
            {
                otlpersonel.PersonelTC = textBox18.Text;
                otlpersonel.PersonelAdSoyad = textBox19.Text;
                otlpersonel.Telefon = textBox20.Text;
                otlpersonel.Eposta = textBox21.Text;
                otlpersonel.Adres = textBox22.Text;
                otlpersonel.Departman = textBox23.Text;
                otlpersonel.Pozisyon = textBox24.Text;
                otlpersonel.PersonelPuani = textBox25.Text;
                ((oteller)dugum.veri).otlpersonelbilgisi.InsertFirst(otlpersonel);
                MessageBox.Show("Personel  eklendi.");
                otlpersonel = new Personel();
                listBox1.Items.Clear();
                otl = ((oteller)dugum.veri);
                textBox17.Text = ((oteller)dugum.veri).Ad;
                //Oteldeki personel  bilgileri   listesi null olana kadar listelendi
                Node ndpersonel = new Node();
                ndpersonel = ((oteller)dugum.veri).otlpersonelbilgisi.Head;
                while (ndpersonel != null)
                {
                    listBox1.Items.Add(((Personel)ndpersonel.Data).PersonelAdSoyad.ToString());
                    ndpersonel = ndpersonel.Next;
                }
                textBox18.Text = textBox19.Text = textBox20.Text = textBox21.Text = textBox22.Text = textBox23.Text = textBox24.Text = textBox25.Text = "";
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (textBox35.Text == "")
            {
                MessageBox.Show("Aranacak Otelin Adını Giriniz...");
            }
            else
            {
                dugum = otlagac.Ara(textBox35.Text);
                if (dugum == null)
                {
                    MessageBox.Show("Otel Bulunamadı...");
                }
                else
                {
                    otl = ((oteller)dugum.veri);
                    textBox34.Text = ((oteller)dugum.veri).Ad;
                    //Oteldeki personel  bilgileri   listesi null olana kadar listelendi
                    Node ndpersonel = new Node();
                    ndpersonel = ((oteller)dugum.veri).otlpersonelbilgisi.Head;
                    while (ndpersonel != null)
                    {
                        listBox2.Items.Add(((Personel)ndpersonel.Data).PersonelAdSoyad.ToString());
                        ndpersonel = ndpersonel.Next;
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {


        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Listeden Personel Seçiniz...");
            }
            else
            {
                Node pbilgi = new Node();
                pbilgi = ((oteller)dugum.veri).otlpersonelbilgisi.Head;
                while (true)
                {
                    // textboxlardaki bilgiler gönderildi ve güncelleme gerçekleştirildi.
                    if (((Personel)pbilgi.Data).PersonelAdSoyad == listBox2.SelectedItem.ToString())
                    {
                        ((Personel)pbilgi.Data).PersonelTC = textBox33.Text;
                        ((Personel)pbilgi.Data).PersonelAdSoyad = textBox32.Text;
                        ((Personel)pbilgi.Data).Telefon = textBox31.Text;
                        ((Personel)pbilgi.Data).Eposta = textBox30.Text;
                        ((Personel)pbilgi.Data).Adres = textBox29.Text;
                        ((Personel)pbilgi.Data).Departman = textBox28.Text;
                        ((Personel)pbilgi.Data).Pozisyon = textBox27.Text;
                        ((Personel)pbilgi.Data).PersonelPuani = textBox26.Text;

                        MessageBox.Show("Personel bilgisi güncellendi.");
                        listBox2.Items.Clear();
                        otl = ((oteller)dugum.veri);
                        textBox34.Text = ((oteller)dugum.veri).Ad;
                        //Oteldeki personel  bilgileri   listesi null olana kadar listelendi
                        Node ndpersonel = new Node();
                        ndpersonel = ((oteller)dugum.veri).otlpersonelbilgisi.Head;
                        while (ndpersonel != null)
                        {
                            listBox2.Items.Add(((Personel)ndpersonel.Data).PersonelAdSoyad.ToString());
                            ndpersonel = ndpersonel.Next;
                        }
                        break;


                    }
                    else//bulunamazsa diğer düğümlerde ara
                        pbilgi = pbilgi.Next;
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Listeden Personel Seçiniz...");
            }
            else
            {
                Node pbilgi = new Node();
                pbilgi = ((oteller)dugum.veri).otlpersonelbilgisi.Head;

                //Listbox'da seçilmiş olan personel bilgisi adına göre bulundu
                while (((Personel)pbilgi.Data).PersonelAdSoyad != listBox2.SelectedItem.ToString())
                    pbilgi = pbilgi.Next;

                //bulunan personel bilgileri listelendi
                textBox33.Text = ((Personel)pbilgi.Data).PersonelTC;
                textBox32.Text = ((Personel)pbilgi.Data).PersonelAdSoyad;
                textBox31.Text = ((Personel)pbilgi.Data).Telefon;
                textBox30.Text = ((Personel)pbilgi.Data).Eposta;
                textBox29.Text = ((Personel)pbilgi.Data).Adres;
                textBox28.Text = ((Personel)pbilgi.Data).Departman;
                textBox27.Text = ((Personel)pbilgi.Data).Pozisyon;
                textBox26.Text = ((Personel)pbilgi.Data).PersonelPuani;
            }
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {


        }

        private void button9_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl2.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl2.Visible = true;
        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            otlagac.PreOrder();
            textBox36.Text = otlagac.DugumleriYazdir();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            otlagac.InOrder();
            textBox37.Text = otlagac.DugumleriYazdir();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            otlagac.PostOrder();
            textBox38.Text = otlagac.DugumleriYazdir();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox39.Text = otlagac.DerinlikBul().ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox40.Text = otlagac.ElemanSayisi().ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            if (textBox41.Text == "")
            {
                MessageBox.Show("Aranacak Otelin Adını Giriniz...");
            }
            else
            {
                dugum = otlagac.Ara(textBox41.Text);
                if (dugum == null)
                {
                    MessageBox.Show("Otel Bulunamadı...");
                }
                else
                {
                    otl = ((oteller)dugum.veri);
                    textBox17.Text = ((oteller)dugum.veri).Ad;
                    //Oteldeki yorum  bilgileri   listesi null olana kadar listelendi
                    Node ndyorumlar = new Node();
                    ndyorumlar = ((oteller)dugum.veri).otlyorumbilgisi.Head;
                    while (ndyorumlar != null)
                    {
                        listBox3.Items.Add(((yorumlar)ndyorumlar.Data).YorumYapan.ToString());
                        ndyorumlar = ndyorumlar.Next;
                    }
                }
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {

            if (textBox44.Text == "")
            {
                MessageBox.Show("Aranacak Otelin Adını Giriniz...");
            }
            else
            {
                dugum = otlagac.Ara(textBox44.Text);
                if (dugum == null)
                {
                    MessageBox.Show("Otel Bulunamadı...");
                }
                else
                {
                    label46.Text = textBox44.Text + " isimli otele yorum yazınız...";
                    otl = ((oteller)dugum.veri);
                    textBox17.Text = ((oteller)dugum.veri).Ad;
                    //Oteldeki yorum  bilgileri   listesi null olana kadar listelendi
                    Node ndyorumlar = new Node();
                    ndyorumlar = ((oteller)dugum.veri).otlyorumbilgisi.Head;
                    while (ndyorumlar != null)
                    {
                        listBox3.Items.Add(((yorumlar)ndyorumlar.Data).YorumYapan.ToString());
                        ndyorumlar = ndyorumlar.Next;
                    }
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {

            if (textBox46.Text == "")
            {
                MessageBox.Show("Yorum Yapan Bilgilerini Giriniz...");
            }
            else
            {
                otlyorumlar.YorumYapan = textBox46.Text;
                otlyorumlar.YorumIcerik = textBox45.Text;

                ((oteller)dugum.veri).otlyorumbilgisi.InsertFirst(otlyorumlar);
                MessageBox.Show("Yorum  eklendi.");
                otlyorumlar = new yorumlar();
                textBox46.Text= textBox45.Text= "";



            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem == null)
            {
                MessageBox.Show("Listeden Yorum Yapan Kişiyi Seçiniz...");
            }
            else
            {
                Node yorumdetay = new Node();
                yorumdetay = ((oteller)dugum.veri).otlyorumbilgisi.Head;

                //Listbox'da seçilmiş olan personel bilgisi adına göre bulundu
                while (((yorumlar)yorumdetay.Data).YorumYapan != listBox3.SelectedItem.ToString())
                    yorumdetay = yorumdetay.Next;

                //bulunan yorum detayları listelendi
                textBox42.Text = ((yorumlar)yorumdetay.Data).YorumYapan;
                textBox43.Text = ((yorumlar)yorumdetay.Data).YorumIcerik;

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            otlagac.InOrder();
            textBox47.Text = otlagac.DugumleriYazdir();

        }

        private void button19_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            if (textBox48.Text == "")
            {
                MessageBox.Show("Departman alanını doldurunuz");
            }
            else
            {
                Node ndpersonel = new Node();
                ndpersonel = ((oteller)dugum.veri).otlpersonelbilgisi.Head;
                while (ndpersonel != null)
                {
                    if (((Personel)ndpersonel.Data).Departman == textBox48.Text)
                    {
                        listBox4.Items.Add(((Personel)ndpersonel.Data).PersonelAdSoyad.ToString());
                        ndpersonel = ndpersonel.Next;
                    }
                    else
                    {
                        MessageBox.Show("Departman Bulunamadı...");
                        break;
                    }
                }
            }


        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        
        private void button20_Click(object sender, EventArgs e)
        {
        
                textBox53.Text = otlagac.DugumleriYazdir();
           
                             
        }
        private void button21_Click(object sender, EventArgs e)
        {
            textBox54.Text = "";
            otlagac.YildizAra(); //yıldız sayısına gore oteller listelendi.
            textBox54.Text = otlagac.DugumleriYazdir();

        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox55.Text == "")
            {
                MessageBox.Show("Aranacak Otelin Adını Giriniz...");
            }
            else
            {
                dugum = otlagac.Ara(textBox55.Text);
                if (dugum == null)
                {
                    MessageBox.Show("Otel Bulunamadı...");
                }
                else
                {

                    textBox9.Text = ((oteller)dugum.veri).otldetaylar.PuanCek().ToString();

                }
            }
        }

       

            private void button23_Click(object sender, EventArgs e)
        {
            if (textBox55.Text == "")
            {
                MessageBox.Show("Güncellenecek Otelin Adını Giriniz...");
            }
            else
            {
                   double p = ((oteller)dugum.veri).otldetaylar.PuanCek() + double.Parse(textBox56.Text);
                textBox9.Text = p.ToString();

                dty.detayId = dtyId;
                dty.Puan = p;
                dty.otls = otl;
                otl.otldetaylar.InsertFirst(dty);
 ht.OtelEkle(dty.detayId, dty.heapislemi);


                MessageBox.Show("Otel Güncellendi...");
                textBox56.Text = "";
                         
                otl = new oteller();
            }
        }
    }      }     

