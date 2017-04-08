using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISS.RV.LIB;

namespace CSharp.NetWorkshops
{

    //workshop 4
    public class CustomerInheritance
    {
        //attributes
        private string name;
        private string address;
        private string passport;
        private DateTime dateOfBirth;

        //property
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
        //Methods
        public string Show()
        {

            string n = String.Format("[Customer: name={0},address={1},passport={2},age={3}]", Name, Address, Passport, Age);
            return (n);
        }
        //Constructor
        public CustomerInheritance(string name, string address, string passport, DateTime dob) : this(name,address,passport)
        {
            this.dateOfBirth = dob;
        }
        public CustomerInheritance(string name, string address, string passport, int age) : this(name, address, passport)
        {
            this.dateOfBirth = new DateTime(DateTime.Now.Year - age, 1, 1);
        }
        public CustomerInheritance(string name, string address, string passport)
        {
            this.name = name;
            this.address = address;
            this.passport = passport;
        }
        public CustomerInheritance():this("NoName", "NoAddress","NoPassport",new DateTime(1980,1,1))
        { 
        }

    }

    public class BankAccountInheritance
    {
        //attributes
        private string accountNumber;
        private CustomerInheritance accountHolder;
        protected double balance;
       // private double interestRate;

        // Constructor
        public BankAccountInheritance(string number, CustomerInheritance holder, double bal)
        {
            accountNumber = number;
            accountHolder = holder;
            balance = bal;
        }
        public BankAccountInheritance() : this("000-000-000", new CustomerInheritance(), 0)
        {
            //default value
        }
        //propeties
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public CustomerInheritance AccountHolder
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

        // methods = what it can do
        //Dep,withdraw,transfer
        public void Deposit(double amount)
        {
            balance = balance + amount;
        }
        public bool Withdraw(double amount)
        {
            if (amount < Balance)
            {
                balance = balance - amount;
                return (true);
            }
            else
                Console.WriteLine("Cannot withdraw");
            return (false);
        }
        public void TransferTo(double amount, BankAccountInheritance another)
        {
            if (Withdraw(amount))
            {
                another.Deposit(amount);
            }
        }
        public double CalculateInterest()
        {
            return (Balance*1/100);
        }
        public void CreditInterest()
        {
            Deposit(CalculateInterest());
        }
        public string Show()
        {
            string m = String.Format("[BankAccount: accountNumber = {0}, accountHolder = {1}, balance = {2}]", AccountNumber, AccountHolder.Show(), Balance);
            return (m);
        }
    }
    public class CurrentAccount : BankAccountInheritance
    {
        public CurrentAccount(string number, CustomerInheritance holder, double balance) : base(number, holder, bal)
        {
        }
        public new double CalculateInterest()
        {
            return (Balance * 0.25 / 100);
        }
        public string Show()
        {
            string m = String.Format("[CurrentAccount: accountNumber = {0}, accountHolder = {1}, balance = {2}]", AccountNumber, AccountHolder.Show(), Balance);
            return (m);
        }

    }
    public class OverdraftAccount : BankAccountInheritance
    {
        public OverdraftAccount(string number, CustomerInheritance holder, double balance) : base(number, holder, bal)
        {
            private static double interestRate = 0.25;
            private static double overdraftInterest = 6;

        }
        public new double CalculateInterest()
        {
            return (Balance * 0.25 / 100);
        }
        public string Show()
        {
            string m = String.Format("[CurrentAccount: accountNumber = {0}, accountHolder = {1}, balance = {2}]", AccountNumber, AccountHolder.Show(), Balance);
            return (m);
        }

    }
    public class BankAccountAppInheritance
    {
        static void Main()
        {
            CustomerInheritance y = new CustomerInheritance("Tan Ah Kow", "20, Seaside Road", "XXX20", new DateTime(1989, 10, 11));
            CustomerInheritance z = new CustomerInheritance("Kim Lee Keng", "2, Rich View", "XXX9F", new DateTime(1993, 4, 25));
            BankAccountInheritance a = new BankAccountInheritance("001-001-001", y, 2000);
            BankAccountInheritance b = new BankAccountInheritance("001-001-002", z, 5000);

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
}
