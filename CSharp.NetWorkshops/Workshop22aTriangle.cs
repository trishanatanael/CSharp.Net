using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISS.RV.LIB;

namespace CSharp.NetWorkshops
{
    class Workshop22aTriangle
    {
        //attributes
        double s1,s2,s3;

        //constructor
        public Workshop22aTriangle(double a, double b, double c)
        {
            s1 = a;
            s2 = b;
            s3 = c;
        }

        //property
        public double S1
        {
            get
            {
                return (s1);
            }
        }
        public double S2
        {
            get
            {
                return (s2);
            }
        }
        public double S3
        {
            get
            {
                return (s3);
            }
        }
        //method
        public double Area
        {
            get
            {
                double s = (s1 + s2 + s3) / 2;
                double r = Math.Sqrt(s * (s - s1) * (s - s2) * (s - s3));
                return (r);
            }
        }
        public double Perimeter
        {
            get
            {
                return (s1 + s2 + s3);
            }
        }
        public bool IsRightAngle
        {
            get
            {
                return ((s1 * s1 + s2 * s2) == (s3 * s3));
            }

        }
        //property to return string
        public string StrValue()
        {
            return (String.Format("Triangle: {0}, {1}, {2}", S1, S2, S3));
        }


    }   
    class Workshop22aTriangleApp
    {
        public static void Main()
        {
            Workshop22aTriangle t = new Workshop22aTriangle(10, 24, 26);
            Console.WriteLine(t.StrValue());
            Console.WriteLine(t.Perimeter);
            Console.WriteLine(t.Area);
            Console.WriteLine(t.IsRightAngle);
        }
    }

}
