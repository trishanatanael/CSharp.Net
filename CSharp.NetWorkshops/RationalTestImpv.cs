using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.NetWorkshops
{
    public class RationalImpv
    {
        private int numerator, denominator;

        public int GetNumerator()
        {
            return numerator;
        }

        public int GetDenominator()
        {
            return denominator;
        }
        public RationalImpv Add(RationalImpv num2)
        {
            int commonDenom = denominator * num2.GetDenominator();
            int numer1 = numerator * num2.GetDenominator();
            int numer2 = num2.GetNumerator() * denominator;
            int sum = numer1 + numer2;
            RationalImpv result = new RationalImpv(sum, commonDenom);
            return result;
        }
        public RationalImpv Subtract(RationalImpv num2)
        {
            int commonDenom = denominator * num2.GetDenominator();
            int numer1 = numerator * num2.GetDenominator();
            int numer2 = num2.GetNumerator() * denominator;
            int difference = numer1 - numer2;
            RationalImpv result = new RationalImpv(difference, commonDenom);
            return result;
        }
        public static RationalImpv operator + (RationalImpv num1, RationalImpv num2)
        {
            int commonDenom = num1.denominator * num2.GetDenominator();
            int numer1 = num1.numerator * num2.GetDenominator();
            int numer2 = num2.GetNumerator() * num1.denominator;
            int sum = numer1 + numer2;
            RationalImpv result = new RationalImpv(sum, commonDenom);
            return result;
        }

        public static RationalImpv operator - (RationalImpv num1, RationalImpv num2)
        {
            int commonDenom = num1.denominator * num2.GetDenominator();
            int numer1 = num1.numerator * num2.GetDenominator();
            int numer2 = num2.GetNumerator() * num1.denominator;
            int difference = numer1 - numer2;
            RationalImpv result = new RationalImpv(difference, commonDenom);
            return result;
        }

        public static RationalImpv operator * (RationalImpv num1, RationalImpv num2)
        {
            int numer = num1.numerator * num2.GetNumerator();
            int denom = num1.denominator * num2.GetDenominator();
            RationalImpv result = new RationalImpv (numer, denom);
            return result;
        }

        public static RationalImpv operator / (RationalImpv num1, RationalImpv num2)
        {
            int numer = num2.GetDenominator();
            int denom = num2.GetNumerator();

            RationalImpv r = new RationalImpv(numer, denom);
            RationalImpv result = num1 * r;
            return result;
        }
        public string StrVal()
        {
            string result;

            if (numerator == 0)
                result = "0";
            else
            {
                if (denominator == 1)
                    result = numerator.ToString();
                else
                    result = numerator + "/" + denominator;
            }
            return result;
        }
        public override string ToString()
        {
            string result;

            if (numerator == 0)
                result = "0";
            else
            {
                if (denominator == 1)
                    result = numerator.ToString();
                else
                    result = numerator + "/" + denominator;
            }
            return result;
        }
        public RationalImpv(int numer, int denom)
        {
            if (denom == 0)    // set denominator to 1 if
                denom = 1;      // argument is zero
            if (denom < 0)
            {   // make numerator "store" the sign
                numer = numer * -1;
                denom = denom * -1;
            }
            numerator = numer;
            denominator = denom;
            Reduce();          // calling a private method
        }

        private void Reduce()
        {
            if (numerator != 0)
            {
                int common = HCF(Math.Abs(numerator), denominator);
                numerator = numerator / common;
                denominator = denominator / common;
            }
        }

        private int HCF(int num1, int num2)
        {
            while (num1 != num2)
            {
                if (num1 > num2)
                    num1 -= num2;
                else
                    num2 -= num1;
            }
            return num1;
        }
    }
    public class RationalTestImpv
    {
        public static void Main()
        {
            // Old one
            //RationalImpv a = new RationalImpv(3, 4);
            //RationalImpv b = new RationalImpv(4, 5);
            //RationalImpv c = a.Add(b);
            //Console.WriteLine(c.StrVal());
            //c = b.Subtract(a);
            //Console.WriteLine(c.StrVal());
            //New one
            RationalImpv a = new RationalImpv(3, 4);
            RationalImpv b = new RationalImpv(4, 5);
            RationalImpv c = a + b;    // c=operator+(a,b);
            Console.WriteLine(c);
            c = b - a;
            Console.WriteLine(c);
        }
    }
}
