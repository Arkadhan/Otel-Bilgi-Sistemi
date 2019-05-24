using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriyapilariotbs
{
    public class Heapİslemi
    {
        private HeapDugumu[] heapBasvuru;
        private int maksBoyut;
        private int gecerliBoyut;
        public Heapİslemi(int maskHeapBoyutu)
        {
            maksBoyut = maskHeapBoyutu;
            gecerliBoyut = 0;
            heapBasvuru = new HeapDugumu[maksBoyut];
        }
        public bool IsEmpty()
        {
            return gecerliBoyut == 0;
        }
        public bool Insert(oteller deger)
        {
            //Heap dolu ise ekleme işlemi gerçekleştirilmedi
            if (gecerliBoyut == maksBoyut)
                return false;
            //Başvuru yapan kişi nesnesi heap'in son boş düğümüne eklendi
            HeapDugumu yeniHeapDugumu = new HeapDugumu(deger);
            heapBasvuru[gecerliBoyut] = yeniHeapDugumu;
            //Son düğüme eklenen Kişi nesnesi ad'a göre heap'de yerini alması için MoveToUp() methodu kullanıldı.
            MoveToUp(gecerliBoyut++);
            return true;
        }
        public void MoveToUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapDugumu bottom = heapBasvuru[index];
            //Yeni eklenen otel adının (ilk harfinin) ascii karşılığı Heap'de o an bulunduğu parentının adının(ilk harfinin) ascii karşılığından büyük olduğu sürece yer değiştirme işlemi gerçekleştirildi
            while (index > 0 && Convert.ToInt32(((oteller)heapBasvuru[parent].Deger).Ad[0]) < Convert.ToInt32(((oteller)bottom.Deger).Ad[0]))
            {
                heapBasvuru[index] = heapBasvuru[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapBasvuru[index] = bottom;
        }

        public string BasvuruListele(Heapİslemi temp)
        {
            int i = 0;
            string liste = "";
            while (((HeapDugumu)temp.heapBasvuru[i]) != null) //Heap'deki (ilana başvurmuş olan kişiler) kişi isimlerinin listeletme işlemleri gerçekleştirildi.
            {
                liste += ((oteller)((HeapDugumu)temp.heapBasvuru[i]).Deger).Ad + Environment.NewLine;
                i++;
            }
            return liste;
        }

        public bool Ara(Heapİslemi temp, oteller k)
        {
            //Bu method daha önce bir ilana başvuran kişinin tekrar başvuru yapmaması için oluşturuldu.
            //ilandaki başvuruların hepsi kontrol edilerek başvurunun ilanda kayıtlı olması durumunda true, aksi halde false döndürülerek kontrol işlemi gerçekleştirildi.
            int i = 0;
            Boolean bulundu = false;
            while (((HeapDugumu)temp.heapBasvuru[i]) != null)
            {
                if (((oteller)((HeapDugumu)temp.heapBasvuru[i]).Deger) == k)
                {
                    bulundu = true;
                    break;
                }
                i++;
            }
            return bulundu;
        }

        

    }
}
