using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISS.RV.LIB;

namespace CSharp.NetWorkshops
{
    public class Dice
    {
        //attributes
        private int faceUp;

        //methods
        public int GetFaceUp()
        {
            return faceUp;
        }
        public void Throw()
        {
        faceUp = ISSMath.RNDInt(6)+1;
        }
        //constructors
        public Dice()
        {
            Throw ();
        }
        // properties 
        public string StrFaceUp
        {
            get
            {
            if (GetFaceUp() == 1) return "1";
            else if (GetFaceUp() == 2) return "2";
            else if (GetFaceUp() == 3) return "3";
            else if (GetFaceUp() == 4) return "4";
            else if (GetFaceUp() == 5) return "5";
            else if (GetFaceUp() == 6) return "6";
            else return "Error";
    }
        }
    }
    public class DiceApp
    {
        public static void Main()
        {
            Dice dice1 = new Dice();
            dice1.Throw(); Console.WriteLine(dice1.StrFaceUp);
            dice1.Throw(); Console.WriteLine(dice1.StrFaceUp);
            dice1.Throw(); Console.WriteLine(dice1.StrFaceUp);
        }
    }
}
