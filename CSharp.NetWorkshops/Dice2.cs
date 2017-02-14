using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISS.RV.LIB;

namespace CSharp.NetWorkshops
{
    public class Dice2
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
        faceUp = ISSMath.RNDInt(6) + 1;
        }
        //constructors
        public Dice2()
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
    public class DiceApp2
    {
        public static void Main()
        {

            Dice2 dice1 = new Dice2();
            int success = 0;
            for (int i = 0; i < 10000; i++)
            {
                int num1 = dice1.GetFaceUp();
                dice1.Throw();
                int num2 = dice1.GetFaceUp();
                dice1.Throw();
                if (num1 + num2 == 8)
                    success = success + 1;
            }
            Console.WriteLine("Occurence is {0}",((double)success) / 10000);
        }
    }
}
