using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Net
{
    class Prog11_1
    {
        class P
        {
            protected int x, y;
            public P(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public int M()
            {
                return x + y;
            }
            public virtual int N()
            {
                return 2 * x + y;
            }
        }
        class Q : P
        {
            public Q(int x, int y)
                : base(x, y)
            {
            }
            public new int M()
            {
                return x * x + y * y;
            }
            public override int N()
            {
                return 3 * x + y;
            }
        }
        abstract class Shape
        {
            protected int x, y;
            public Shape(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public abstract void Draw();
        }
        class Circle : Shape
        {
            public Circle(int x, int y)
                : base(x, y)
            {
            }
            public override void Draw()
            {
                Console.WriteLine("Circle.Draw at {0},{1}", x, y);
            }
        }
        class Triangle : Shape
        {
            public Triangle(int x, int y)
                : base(x, y)
            {
            }
            public override void Draw()
            {
                Console.WriteLine("Triangle.Draw at {0},{1}", x, y);
            }
        }
        class Rectangle : Shape
        {
            public Rectangle(int x, int y)
                : base(x, y)
            {
            }
            public override void Draw()
            {
                Console.WriteLine("Rectangle.Draw at {0},{1}", x, y);
            }
        }
        class Drawing
        {
            List<Shape> list = new List<Shape>();

            public void Add(Shape s)
            {
                list.Add(s);
            }

            public void Draw()
            {
                foreach (Shape s in list)
                {
                    s.Draw();
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                
                P a = new P(3, 4);
                Q b = new Q(3, 4);
                P c = b;
                Console.WriteLine(a.M());
                Console.WriteLine(b.M());
                Console.WriteLine(c.M());
                Console.WriteLine(a.N());
                Console.WriteLine(b.N());
                Console.WriteLine(c.N());
                /*
                Drawing d = new Drawing();
                d.Add(new Circle(3, 4));
                d.Add(new Rectangle(5, 2));
                d.Add(new Circle(8, 1));
                d.Add(new Triangle(2, 6));
                d.Add(new Rectangle(7, 5));
                d.Add(new Circle(2, 1));
                d.Add(new Triangle(3, 2));
                d.Add(new Rectangle(5, 4));
                d.Add(new Circle(13, 4));
                d.Draw();
                */
            }
        }
    }
}
