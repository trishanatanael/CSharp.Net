using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISS.RV.LIB;

namespace CSharp.NetWorkshops
{
    class Workshop22aCircle
    {

        //attributes
        double radius;

        //constructor
        public Workshop22aCircle(double rad)
        {
            radius = rad;

        }

        //method
        public string StrValue()
        {
            return (String.Format("Circle: {0}",Rad));
        }
        //property
        public double Rad
        {
            get
            {
                return (radius);
            }
        }
        public double Area
        {
            get
            {
                double a = (Math.PI * radius * radius);
                return (a);
            }
        }
        public double Perimeter
        {
            get
            {
                return (Math.PI*radius/4);
            }
        }

    }   
    class Workshop22aCircleApp
    {
        public static void Main()
        {
            Workshop22aTriangle t = new Workshop22aTriangle(6, 10, 12);
            Console.WriteLine(t.StrValue());
            Console.WriteLine(t.Perimeter);
            Console.WriteLine(t.Area);
            Console.WriteLine(t.IsRightAngle);
        }
    }

}
