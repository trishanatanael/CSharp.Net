using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog8_1
{

    class Rectangle1
    {
        int length = 1;
        int breadth = 1;

        public int GetLength()
        {
            return (length);
        }

        public void SetLength(int v)
        {
            length = v;
        }

        public int GetBreadth()
        {
            return (breadth);
        }

        public void SetBreadth(int v)
        {
            breadth = v;
        }

        public void Grow()
        {
            breadth = breadth + 1;
            length = length + 1;
        }

        public int Area()
        {
            return (GetLength() * GetBreadth());
        }

        public int Perimeter()
        {
            return (2 * (GetLength() + GetBreadth()));
        }

        public string StrValue()
        {
            return (String.Format("Rectangle: {0},{1}", GetLength(), GetBreadth()));
        }
    }

    class Rectangle2
    {
        int length = 1;
        int breadth = 1;

        public int Length
        {
            get
            {
                return (length);
            }
            set
            {
                length = value;
            }
        }

        public int Breadth
        {
            get
            {
                return (breadth);
            }
            set
            {
                breadth = value;
            }
        }

        public void Grow()
        {
            breadth = breadth + 1;
            length = length + 1;
        }

        public int Area()
        {
            return (Length * Breadth);
        }

        public int Perimeter()
        {
            return (2 * (Length + Breadth));
        }

        public string StrValue()
        {
            return (String.Format("Rectangle: {0},{1}", Length, Breadth));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle1 b = new Rectangle1();
            b.SetBreadth(7);
            b.SetLength(6);
            Console.WriteLine(b.StrValue());
            Console.WriteLine(b.Area());
            b.Grow();
            Console.WriteLine(b.StrValue());
            Console.WriteLine(b.Area());

            Rectangle2 e = new Rectangle2();
            e.Breadth = 6;
            e.Length = 3;
            Console.WriteLine(e.StrValue());
            Console.WriteLine(e.Area());
            e.Grow();
            Console.WriteLine(e.StrValue());
            Console.WriteLine(e.Area());
        }
    }
}