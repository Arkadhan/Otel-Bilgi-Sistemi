using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriyapilariotbs
{
   public class oteller
    {

        public oteller()
            {
            this.otlyorumbilgisi = new ListYorumlar();
            this.otlpersonelbilgisi = new ListPersonel();
            this.otldetaylar = new LinkDetay();
        }

        public string Ad { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public string OdaSayisi { get; set; }
        public string OtelYildizi { get; set; }
        public double OtelPuani { get; set; }

        public ListYorumlar otlyorumbilgisi;
        public ListPersonel otlpersonelbilgisi;
        public LinkDetay otldetaylar;
    }


}
