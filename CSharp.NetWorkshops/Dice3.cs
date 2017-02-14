using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISS.RV.LIB;

namespace CSharp.NetWorkshops
{
    public class Dice3
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
        public Dice3()
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
    public class DiceApp3
    {
        public static void Main()
        {

            Dice3 dice1 = new Dice3();
            int success = 0;
            Console.Write("Please input target: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 10000; i++)
            {
                int num1 = dice1.GetFaceUp();
                dice1.Throw();
                int num2 = dice1.GetFaceUp();
                dice1.Throw();
                if (num1 + num2 == n)
                    success = success + 1;
            }
            Console.WriteLine("Occurence is of {1} is {0}",((double)success) / 10000, n);
        }
    }
}
