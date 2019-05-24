using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriyapilariotbs
{
    class OtelDetay
    {

        public OtelDetay()
        {
            heapislemi = new Heapİslemi(100);
        }
        public int detayId { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public double Puan { get; set; }
        public oteller otls { get; set; }

        public Heapİslemi heapislemi;
    }
}
