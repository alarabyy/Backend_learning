using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop6_indexer
{
    public class ip
    {
        private int[] segmentes=new int[4];

        public int this[int index]
            {
            get { return segmentes[index]; }
            set { segmentes[index] = value;}
            }

        public ip(int segmentes1, int segmentes2 ,int segmentes3 ,int segmentes4) 
        {
            segmentes[0]=segmentes1;
            segmentes[1]=segmentes2;
            segmentes[2]=segmentes3;
            segmentes[3]=segmentes4;
        }

        public string Adrees => string.Join (".", segmentes);
    }
}
