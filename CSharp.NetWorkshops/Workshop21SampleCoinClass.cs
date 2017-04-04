using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISS.RV.LIB;

namespace CSharp.NetWorkshops
{
    class Workshop21SampleCoinClass
    {
        //attributes
        private int face;

        //Methods
        public int GetFace()
        {
            return face;
        }
        public void Flip()
        {
            face = ISSMath.RNDInt(2);
        }

        public Workshop21SampleCoinClass()
        {
            Flip();
        }
        public string StrFace
        {
            get
            {
                if (GetFace() == 0) return "HEAD";
                else return "TAIL";
            }
        }
    }


    public class SampleCoinApp
    {
        public static void Main()
        {
            Workshop21SampleCoinClass coin1 = new Workshop21SampleCoinClass();
            coin1.Flip();
            coin1.Flip(); Console.WriteLine("Coin1: {0}", coin1.StrFace);
            coin1.Flip(); Console.WriteLine("Coin1: {0}", coin1.StrFace);
            coin1.Flip(); Console.WriteLine("Coin1: {0}", coin1.StrFace);

            Workshop21SampleCoinClass coin2 = new Workshop21SampleCoinClass();
            coin2.Flip();
            coin2.Flip(); Console.WriteLine("Coin2: {0}", coin2.StrFace);
            coin2.Flip(); Console.WriteLine("Coin2: {0}", coin2.StrFace);
            coin2.Flip(); Console.WriteLine("Coin2: {0}", coin2.StrFace);

        }
    }

    
}
