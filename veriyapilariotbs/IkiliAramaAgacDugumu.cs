using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriyapilariotbs
{
    class IkiliAramaAgacDugumu
    {
        public object veri;
        public IkiliAramaAgacDugumu sol;
        public IkiliAramaAgacDugumu sag;
        public IkiliAramaAgacDugumu()
        {
        }

        public IkiliAramaAgacDugumu(object veri)
        {
            this.veri = veri;
            sol = null;
            sag = null;
        }
    }
}
