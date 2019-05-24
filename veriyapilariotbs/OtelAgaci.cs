using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriyapilariotbs
{
     class OtelAgaci
    {
        private IkiliAramaAgacDugumu kok;
        private string dugumler;
        public OtelAgaci()
        {
        }

        public OtelAgaci(IkiliAramaAgacDugumu kok)
        {
            this.kok = kok;
        }
        public string DugumleriYazdir()
        {
            return dugumler;
        }

        private void Ziyaret(IkiliAramaAgacDugumu dugum)
        {
            dugumler += ((oteller)dugum.veri).Ad + Environment.NewLine;
        }

        public void PreOrder()
        {
            dugumler = "";
            PreOrderInt(kok);
        }
        private void PreOrderInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            Ziyaret(dugum);
            PreOrderInt(dugum.sol);
            PreOrderInt(dugum.sag);
        }
        public void InOrder()
        {
            dugumler = "";
            InOrderInt(kok);
        }
        private void InOrderInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            InOrderInt(dugum.sol);
            Ziyaret(dugum);
            InOrderInt(dugum.sag);
        }

        public void PostOrder()
        {
            dugumler = "";
            PostOrderInt(kok);
        }
        private void PostOrderInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            PostOrderInt(dugum.sol);
            PostOrderInt(dugum.sag);
            Ziyaret(dugum);
        }
        public void Ekle(oteller deger)
        {
            Boolean isSol = true;
            //Yeni eklenecek düğümün parent'ını tutmak için kullanıldı
            IkiliAramaAgacDugumu tempParent = new IkiliAramaAgacDugumu();
            //Kökten itibaren ilerlemek için kullanıldı
            IkiliAramaAgacDugumu tempSearch = kok;

            while (tempSearch != null)
            {
                tempParent = tempSearch;
                //Deger zaten var. Eklemeden çık.
                if (deger.Ad == ((oteller)tempSearch.veri).Ad)
                    return;
                else if (deger.Ad[0] < ((oteller)tempSearch.veri).Ad[0]) //İlk harflerin ascii karşılığı küçükse ağaçta sola git 
                    tempSearch = tempSearch.sol;
                else if (deger.Ad[0] == ((oteller)tempSearch.veri).Ad[0]) //ilk harflerin eşit olması durumunda diğer harfler kontrol edilir
                {
                    int i = 1;
                    while (deger.Ad[i] != null) //adın harfleri bitene kadar ve farklı harfi bulana kadar ilerle
                    {
                        if (deger.Ad[i] == ((oteller)tempSearch.veri).Ad[i])//eşit olması durumunda diğer harfe bak
                        {
                            i++;
                            continue;
                        }
                        else if (deger.Ad[i] < ((oteller)tempSearch.veri).Ad[i]) //küçük olması durumunda ağaçta sola ilerle ve çık
                        {
                            tempSearch = tempSearch.sol;
                            break;
                        }
                        else //büyük olması durumunda ağaçta sağa ilerle ve çık
                        {
                            isSol = false;
                            tempSearch = tempSearch.sag;
                            break;
                        }
                    }
                }
                else //ilk harfin ascii karşılığı büyükse ağaçta sağa git 
                    tempSearch = tempSearch.sag;
            }
            IkiliAramaAgacDugumu eklenecek = new IkiliAramaAgacDugumu(deger);

            //Yukarıda bulunan konuma yeni değeri ekle
            if (kok == null)
                kok = eklenecek;
            else if (deger.Ad[0] < ((oteller)tempParent.veri).Ad[0])
                tempParent.sol = eklenecek;
            else if (deger.Ad[0] == ((oteller)tempParent.veri).Ad[0] && isSol)
                tempParent.sol = eklenecek;
            else
                tempParent.sag = eklenecek;
        }
        public IkiliAramaAgacDugumu Ara(string anahtar)
        {
            return AraInt(kok, anahtar);
        }
        private IkiliAramaAgacDugumu AraInt(IkiliAramaAgacDugumu dugum, string anahtar)
        {
            if (dugum == null)
                return null;
            else if (((oteller)dugum.veri).Ad == anahtar) //düğümdeki kişi adı arana kişiye eşitse düğümü döndür
                return dugum;
            else if (((oteller)dugum.veri).Ad[0] > anahtar[0]) //düğümdeki kişi adının ilk harfi aranan kişinin ilk harfindan büyükse sola git
                return (AraInt(dugum.sol, anahtar));
            else //düğümdeki kişi adının ilk harfi aranan kişinin ilk harfindan küçükse sağa git
                return (AraInt(dugum.sag, anahtar));
        }

        private IkiliAramaAgacDugumu Successor(IkiliAramaAgacDugumu silDugum)
        {
            IkiliAramaAgacDugumu successorParent = silDugum;
            IkiliAramaAgacDugumu successor = silDugum;
            IkiliAramaAgacDugumu current = silDugum.sag; //silinecek düğümün sağı varsa current'a ata

            while (current != null)
            {
                //Current null değilse null olana kadar sola git
                successorParent = successor;
                successor = current;
                current = current.sol;
            }
            if (successor != silDugum.sag) //successor silinecek düğümün sağıdaysa yani daha küçük yoksa(sola gidilmediyse) yer değiştirme işlemi yap daha sonra successor'ü gönder
            {
                successorParent.sol = successor.sag;
                successor.sag = silDugum.sag;
            }
            return successor;
        }
        public bool Sil(string deger)
        {
            if (kok == null) //ağaç boşsa silme işlemi yapılamaz
                return false;
            else
            {
                IkiliAramaAgacDugumu current = kok;
                IkiliAramaAgacDugumu parent = kok;
                bool issol = true;
                //Kişi adına göre silinecek düğümü bul
                while (((oteller)current.veri).Ad != deger)
                {
                    parent = current;
                    if (deger[0] < ((oteller)current.veri).Ad[0]) //silinecek kişi isminin ilk harfi düğümdeki kişinin ilk harfnden küçükse silinecek değer ağacın sol tarafındadır. sola git.
                    {
                        issol = true;
                        current = current.sol;
                    }
                    else if (deger[0] == ((oteller)current.veri).Ad[0])
                    { //silinecek kişi isminin ilk harfi düğümdeki kişinin ilk harfine eşitse diğer harfleri kontrol et
                        int i = 1;
                        while (deger[i] != null) //Farklı harfi bulana kadar dön
                        {
                            if (deger[i] == ((oteller)current.veri).Ad[i])
                            {
                                i++;
                                continue;
                            }
                            else if (deger[i] < ((oteller)current.veri).Ad[i])
                            {
                                current = current.sol;
                                break;
                            }
                            else
                            {
                                issol = false;
                                current = current.sag;
                                break;
                            }
                        }
                    }
                    else//silinecek kişi isminin ilk harfi düğümdeki kişinin ilk harfinden büyükse silinecek değer ağacın sağ tarafındadır. sağa git.
                    {
                        issol = false;
                        current = current.sag;
                    }
                    if (current == null)
                        return false;
                }

                //Current(silinecek düğüm) bulunursa ilk olarak onun eğitim ve iş bilgilerini sil.
                //((oteller)current.veri).EgitimBilgisi = null;
               // ((oteller)current.veri).Deneyimler = null;
                //Daha sonra direk current düğümü sil.
                //Düğüm yaprak düğümse buraya gir
                if (current.sol == null && current.sag == null)
                {
                    if (current == kok)
                        kok = null;
                    else if (issol)
                        parent.sol = null;
                    else
                        parent.sag = null;
                }
                //Düğüm tek çocuklu düğümse buraya gir.
                else if (current.sag == null)
                {
                    if (current == kok)
                        kok = current.sol;
                    else if (issol)
                        parent.sol = current.sol;
                    else
                        parent.sag = current.sol;
                }
                else if (current.sol == null)
                {
                    if (current == kok)
                        kok = current.sag;
                    else if (issol)
                        parent.sol = current.sag;
                    else
                        parent.sag = current.sag;
                }
                //Düğüm iki çocuklu düğümse buraya gir.
                else
                {
                    IkiliAramaAgacDugumu successor = Successor(current);
                    if (current == kok)
                        kok = successor;
                    else if (issol)
                        parent.sol = successor;
                    else
                        parent.sag = successor;
                    successor.sol = current.sol;
                }
                return true; //silme işlemi başarıyla gerçekleştiyse true dön
            }
        }

       

        private int DerinlikBulInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return 0;
            else
            {
                int solYukseklik = 0, sagYukseklik = 0;
                solYukseklik = DerinlikBulInt(dugum.sol); //Düğümün solu oldukça sola git
                sagYukseklik = DerinlikBulInt(dugum.sag); //Düğümün sağı oldukça sağa git
                if (solYukseklik > sagYukseklik)
                    return solYukseklik + 1;
                else
                    return sagYukseklik + 1;
            }
        }

        public int DerinlikBul()
        {
            return DerinlikBulInt(kok);
        }

        public int ElemanSayisi()
        {
            return ElamanSayisiInt(kok);
        }
        private int ElamanSayisiInt(IkiliAramaAgacDugumu dugum)
        {
            int elemanSayisi = 0;
            if (dugum != null)
            {
                elemanSayisi = 1;
                elemanSayisi += ElamanSayisiInt(dugum.sol);
                elemanSayisi += ElamanSayisiInt(dugum.sag);
            }
            return elemanSayisi;
        }

        private void YildizKontrol(IkiliAramaAgacDugumu dugum)
        {
            if (((oteller)dugum.veri).OtelYildizi == "5") //gönderilen düğümün yabancı dili ingilizceyse kişi adını yazdır
                dugumler += ((oteller)dugum.veri).Ad + Environment.NewLine;
        }

        public void YildizAra()
        {
            dugumler = "";
            YildizAraInt(kok);
        }
        private void YildizAraInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            YildizKontrol(dugum); //dil kontrol işlemine git
            YildizAraInt(dugum.sol); //kontrol bittiyse sola git
            YildizAraInt(dugum.sag); //kontrol bittiyse sağa git
        }

       

    }
}
