using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISS.RV.LIB;

//namespace CSharp.NetWorkshops
//{
  /*  public class BankAccount3

    {
        //attributes
        private string accountNumber;
        private Customer accountHolder;
        protected double balance;

        // properties 
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public Customer AccountHolder

        {
            get
            {
                return accountHolder;
            }
            set
            {
                accountHolder = value;
            }
        }
        public double Balance
        {
            get
            {
                return balance;
            }
            protected set
            {
                balance = value;
            }
        }

        // Constructor
        public BankAccount3(string number, Customer holder, double bal)
        {
            accountNumber = number;
            accountHolder = holder;
            balance = bal;

        }
        public BankAccount3() : this("000-000-000", new Customer(), 0) { }

        // methods = what it can do
        //Dep,withdraw,transfer
        public void Deposit(double amount)
        {
            balance = balance + amount;
        }
        public bool Withdraw(double amount)
        {
            if (amount < balance)
            {
                balance = balance - amount;
                return (true);
            }
            else
                Console.WriteLine("Withdrawal unsuccesful");
                return (false);
        }
        public bool TransferTo(double amount, BankAccount3 another)
        {
            if (Withdraw(amount))
            {
                another.Deposit(amount);
                return (true);
            }
            else
            {
                Console.WriteLine("Transfer to {0} is unsuccessful", another);
                return (false);
            }
        }
        public double CalculateInterest()
        {
            return (Balance * 1 / 100);
        }
        public void CreditInterest()
        {
            Deposit(CalculateInterest());
        }
        public string Show()
            {
            string m = String.Format("[Bank Account:AccountNumber{0}, AccountHolder={1}, Balance{2}]", AccountNumber, AccountHolder.Show(), Balance);
            return (m);
        }
    }
    public class CurrentAccount : BankAccount3
    {
        public CurrentAccount(string number, Customer holder, double bal) : base(number, holder, bal)
        {
        }
        public new double CalculateInterest()
        {
            return (Balance * 0.25 / 100);
        }
        public string Show()
        {
            string m = String.Format("[Current Account:AccountNumber{0}, AccountHolder={1}, Balance{2}]", AccountNumber, AccountHolder.Show(), Balance);
            return (m);
        }

    }
    public class OverdraftAccount : BankAccount3
    {
        private static double interestRate = 0.25;
        private static double overdraftInterest = 6;

        public OverdraftAccount(string number, Customer holder, double bal) : base(number, holder, bal)
        { }
        public new bool Withdraw(double amount)
        {
            balance = balance - amount;
            return (true);
        }
        public new double CalculateInterest()
        {
            return (Balance > 0 ? (Balance*interestRate) : (Balance * overdraftInterest));
        }
        public string Show()
        {
            string m = String.Format("[Current Account:AccountNumber{0}, AccountHolder={1}, Balance{2}]", AccountNumber, AccountHolder.Show(), Balance);
            return (m);
        }

    }

    public class Customer
    {
        //attributes
        private string name;
        private string address;
        private string passport;
        private DateTime dateOfBirth;

        //properties
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
            set
            {
                address = value;
            }
        }

        public string Passport
        {
            get
            {
                return passport;
            }
            set
            {
                passport = value;
            }
        }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - dateOfBirth.Year;
            }
        }

        //constructor
        public Customer(string name, string address, string passport, DateTime dob) : this (name, address,passport)
        {
            this.dateOfBirth = dob;
        }
        public Customer(string name, string address, string passport, int age)
            : this(name, address, passport)
        {
            this.dateOfBirth = new DateTime(DateTime.Now.Year - age, 1, 1);
        }

        public Customer(string name, string address, string passport)
        {
            this.name = name;
            this.address = address;
            this.passport = passport;
        }

        public Customer()
            : this("ThisName", "ThisAddress", "ThisPassport", new DateTime(1980, 1, 1))
        {
        }
        //Methods
        public string Show()
        {
            string m = String.Format
                 ("[Customer:name={0},address={1},passport={2},age={3}]",
                          Name, Address, Passport, Age);
            return (m);
        }
    }
    public class BankAccount3App
    {
        static void Main()
        {
            Customer a = new Customer( "Tan Ah Kow","2 Rich Street", 2000);
            Customer b = new Customer( "Kim Keng Lee", 5000);
            Console.WriteLine(a.Show());
            Console.WriteLine(b.Show());
            a.Deposit(100);
            Console.WriteLine(a.Show());
            a.Withdraw(200);
            Console.WriteLine(a.Show());
            a.TransferTo(300, b);
            Console.WriteLine(a.Show());
            Console.WriteLine(b.Show());
        }
    } 
}*/
