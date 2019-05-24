using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriyapilariotbs
{
    public class HashTable
    {
        int tabloBoyutu = 100;
        HashDugumu[] hashTablosu;

        public HashTable()
        {
            hashTablosu = new HashDugumu[tabloBoyutu];
            for (int i = 0; i < tabloBoyutu; i++)
                hashTablosu[i] = null;// ilk değerler null atandı
        }

        public void OtelEkle(int anahtar, object deger)
        {
            int indis = (anahtar % tabloBoyutu);//detayId'nin tablo boyutuna göre modu alındı ve eklenecek indis bulundu.
            if (hashTablosu[indis] == null)//indis null ise direk ekleme işlemi gerçekleşti
                hashTablosu[indis] = new HashDugumu(anahtar, deger);
            else
            {
                HashDugumu hashDugumu = hashTablosu[indis];
                while (hashDugumu.Next != null && hashDugumu.Anahtar != anahtar)//indis null değil ise null olan indise kadar ilerlendi ve eklendi
                    hashDugumu = hashDugumu.Next;
                if (hashDugumu.Anahtar == anahtar)
                    hashDugumu.Deger = deger;
                else
                    hashDugumu.Next = new HashDugumu(anahtar, deger);
            }
        }

        public void OtelSil(int anahtar)
        {
            int indis = (anahtar % tabloBoyutu);//detayıd ve tablo boyutu kullanılarak silinecek indis bulundu
            if (hashTablosu[indis] != null)
            {
                HashDugumu oncekiHashDugumu = null;
                HashDugumu hashDugumu = hashTablosu[indis];
                while (hashDugumu.Next != null && hashDugumu.Anahtar != anahtar)
                {
                    oncekiHashDugumu = hashDugumu;
                    hashDugumu = hashDugumu.Next;
                }
                if (hashDugumu.Anahtar == anahtar) //Silinecek düğüm bulunup silme işlemi gerçekleştirildi
                {
                    if (oncekiHashDugumu == null)
                        hashTablosu[indis] = hashDugumu.Next;
                    else
                        oncekiHashDugumu.Next = hashDugumu.Next;
                }
            }
        }
    }
}
