using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.NetWorkshops
{
    public class CustomerTS
    {
        private string name;
        private string address;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
        }
        public CustomerTS(string n, string a)
        {
            name = n;
            address = a;
        }

        public string ToStringTS()
        {
            return (String.Format("Customer: Name ={0}, Address = {1}", Name, Address));
        }
    }
    public class Tostring
    {
        public static void Main(string[] args)
        {
            CustomerTS c = new CustomerTS("Tan Ah Kow", "4 Short Street");
            int n = 65;
            Console.WriteLine(n);
            Console.WriteLine(c);
            Console.WriteLine(n.ToString());//cant use var & obj interchangebly
            Console.WriteLine(c.ToStringTS());
        }
    }
}
