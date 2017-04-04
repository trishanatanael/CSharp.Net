using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISS.RV.LIB;

namespace CSharp.NetWorkshops
{
    class Workshop22aRectangle
    {

        //attributes
        double length, breadth;

        //constructor
        public Workshop22aRectangle(double l, double b)
        {
            length = l;
            breadth = b;
        }

        //method
        public string StrValue()
        {
            return (String.Format("Rectangle: {0}, {1}", Length, Breadth));
        }
        //property
        public double Length
        {
            get
            {
                return (length);
            }
        }
        public double Breadth
        {
            get
            {
                return (breadth);
            }
        }
        public double Area
        {
            get
            {
                return (Length * Breadth);
            }
        }
        public double Perimeter
        {
            get
            {
                return (2*(Length + Breadth));
            }
        }
        
    }
    class Workshop22aRectangleApp
    {
        public static void Main()
        {
            Workshop22aRectangle r = new Workshop22aRectangle(10,10);
            Console.WriteLine(r.StrValue());
            Console.WriteLine(r.Perimeter);
            Console.WriteLine(r.Area);
        }
    }

}
