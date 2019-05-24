using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriyapilariotbs
{
    public class LinkDetay: ListADT
    {

      
            public override void InsertFirst(object value)
            {
                Node tempHead = new Node() { Data = value };

                if (Head == null) //ilk düğüm null ise (yani liste boşsa) heade ekle
                {
                    Head = tempHead;
                }
                else
                {
                    //head'i head'in next'i yap ve yeni head'i eklenecek düğüm yap
                    tempHead.Next = Head;
                    Head = tempHead;
                }
                Size++;
            }

            public override void DeletePos(object Position)
            {
                if (Head != null)
                {
                    Node temp = Head;

                    Node posPreNode = new Node();
                    posPreNode = Head;

                    if (((OtelDetay)temp.Data).detayId == ((OtelDetay)Position).detayId) //Silinecek düğüm head ise head'i bir sonraki düğüm yap
                    {
                        Head = temp.Next;
                    }
                    while (temp != null) //silinecek değer bulunana kadar (ilan id ile kontrol edilecek) listede ilerle
                    {
                        if (((OtelDetay)temp.Data).detayId == ((OtelDetay)Position).detayId) //silinecek değer bulunduğunda silinecek değerin next'ini bi önceki değerin next'i yap böylece listede artık temp'i gösteren eleman kalmadı ve silme işlemi gerçekleşti
                            posPreNode.Next = temp.Next;
                        else
                            posPreNode = temp;

                        temp = temp.Next;
                    }
                    Size--;
                }
            }


            public override string DisplayElements()
            {
                string temp = "";
                Node i = Head;
                while (i != null) //Liste null olana kadar listedeki iş bilgilerini temp'e ekle ve ilerle
                {
                    temp += "İşyeri adı : " + ((OtelDetay)i.Data).otls.Ad + Environment.NewLine;
                    i = i.Next;
                }
                return temp;
            }

        public string IlGetir()
        {
            string temp = "";
            Node i = Head;
            while (i != null) //Liste null olana kadar listedeki iş bilgilerini temp'e ekle ve ilerle
            {
                temp += ((OtelDetay)i.Data).Il;
                i = i.Next;
            }
            return temp;
        }
            public string IlceGetir()
            {
                string temp = "";
                Node i = Head;
                while (i != null) //Liste null olana kadar listedeki iş bilgilerini temp'e ekle ve ilerle
                {
                    temp += ((OtelDetay)i.Data).Ilce;
                    i = i.Next;
                }
                return temp;
            }
        public double PuanCek()
        {
            double temp =0;
            Node i = Head;
            while (i != null) //Liste null olana kadar listedeki iş bilgilerini temp'e ekle ve ilerle
            {
                temp = ((OtelDetay)i.Data).Puan;
                i = i.Next;
            }
            return temp;
        }
    }
    }

