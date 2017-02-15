using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISS.RV.LIB;

namespace CSharp.NetWorkshops
{
    public class Coin
    {
        //attributes
        private int face;
        

        //methods
        public int GetFace()
        {
            return face;
        }
        public void Throw()
        {
        face = ISSMath.RNDInt(2);
        }
        //constructors
        public Coin()
        {
            //Flip();
        }
        // properties 
        public string StrFace
        {
            get
            {
            if (GetFace() == 0) return "Head";
            else if (GetFace() == 1) return "Tail";
            else return "Error";
            }
        }
    }
    public class CoinApp
    {
        public static void Main()
        {
            Coin coin1 = new Coin();
            //coin1.Flip();
            Console.WriteLine(coin1.StrFace);
        }
    }
}
