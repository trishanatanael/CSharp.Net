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
        //prop to print string
        public string StrValue()
        {
            return (String.Format("Circle: {0}", Rad));
        }

    }   
    class Workshop22aCircleApp
    {
        public static void Main()
        {
            Workshop22aCircle c = new Workshop22aCircle(7);
            Console.WriteLine(c.StrValue());
            Console.WriteLine(c.Perimeter);
            Console.WriteLine(c.Area);
        }
    }

}
