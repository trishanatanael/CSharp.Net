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
        string[] val = { "Zero", "One", "Two", "Three", "Four", "Five", "Six" };
        //methods
        public int GetFaceUp()
        {
            return faceUp;
        }
        public int Throw()
        {
        faceUp = ISSMath.RNDInt(6) + 1;
            return GetFaceUp();
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
                int f = GetFaceUp();
                if (1 <= f && f <= 6)
                    return val[GetFaceUp()];
                else
                    return "Error";
            }
        }
    }
    public class DiceApp2
    {
        public static void Test8()
        {
            Dice2 dice2 = new Dice2();
            int eight = 0;
            int total = 100000;
            for (int i = 0; i < total; i++)
            {
                if (dice2.Throw() + dice2.Throw() == 8)
                    eight++;
            }
            Console.WriteLine("Occurrence of 8 is {0}", ((double)eight) / total);
        }
        public static void Test(int n)
        {
            Dice2 dice2 = new Dice2();
            int occurs = 0;
            int total = 100000;
            for (int i = 0; i < total; i++)
            {
                if (dice2.Throw() + dice2.Throw() == 8)
                    occurs++;
            }
            Console.WriteLine("Occurrence of {1} is {0}", ((double)occurs) / total,n);
        }
        public static void Probability8()
        {
            int occurs = 0;
            for (int i = 1; i <= 6; i++)
                for (int j = 1; j <= 6; j++)
                    if (i + j == 8)
                        occurs = occurs + 1;
            Console.WriteLine("Probability of 8 is {0}", ((double)occurs) / 36);
        }
        public static void Probability(int n)
        {
            int occurs = 0;
            for (int i = 1; i <= 6; i++)
                for (int j = 1; j <= 6; j++)
                    if (i + j == n)
                        occurs = occurs + 1;
            Console.WriteLine("Probability of {0} is {1}", n, ((double)occurs) / 36);
        }
        public static void Main()
        {

            Test8();
            Probability8();
            // (2,6) (3,5) (4,4) (5,3) (6,2) / 6x6
            Test(7);
            Probability(7);
        }
    }
}
