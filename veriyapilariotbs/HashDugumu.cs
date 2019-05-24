using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriyapilariotbs
{
    public class HashDugumu
    {
        public HashDugumu(int anahtar, object deger)
        {
            this.anahtar = anahtar;
            this.deger = deger;
            this.next = null;
        }

        private int anahtar;
        public int Anahtar { get { return anahtar; } set { anahtar = value; } }

        private object deger;
        public object Deger { get { return deger; } set { deger = value; } }

        private HashDugumu next;

        public HashDugumu Next { get { return next; } set { next = value; } }
    }
}
