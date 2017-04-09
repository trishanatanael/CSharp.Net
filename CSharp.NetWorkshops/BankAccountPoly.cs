using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISS.RV.LIB;

namespace CSharp.NetWorkshops
{
    //workshop 5a Polymorph
    public class CustomerPoly
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
        public CustomerPoly(string name, string address, string passport, DateTime dob) : this(name,address,passport)
        {
            this.dateOfBirth = dob;
        }
        public CustomerPoly(string name, string address, string passport, int age) : this(name, address, passport)
        {
            this.dateOfBirth = new DateTime(DateTime.Now.Year - age, 1, 1);
        }
        public CustomerPoly(string name, string address, string passport)
        {
            this.name = name;
            this.address = address;
            this.passport = passport;
        }
        public CustomerPoly():this("NoName", "NoAddress","NoPassport",new DateTime(1980,1,1))
        { 
        }

    }

    public class BankAccountPoly
    {
        //attributes
        private string accountNumber;
        private CustomerPoly accountHolder;
        protected double balance;

        // Constructor
        public BankAccountPoly(string number, CustomerPoly holder, double bal)
        {
            accountNumber = number;
            accountHolder = holder;
            balance = bal;
        }
        public BankAccountPoly() : this("000-000-000", new CustomerPoly(), 0)
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
        public CustomerPoly AccountHolder
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

        // methods = what it can do (Deposit,withdraw,transfer)
        public void Deposit(double amount)
        {
            balance = balance + amount;
        }
        public virtual bool Withdraw(double amount)
        {
                balance = balance - amount;
                return (true);
        }
        public bool TransferTo(double amount, BankAccountPoly another)
        {
            if (Withdraw(amount))
            {
                another.Deposit(amount);
                return (true);
            }
            else
            {
                Console.WriteLine("Cannot transfer");
                return (false);
            }
        }
        public virtual double CalculateInterest()
        {
            return (0);
        }
        public void CreditInterest()
        {
            Deposit(CalculateInterest());
        }

        public virtual string Show()
        {
            string m = String.Format("[BankAccount: accountNumber = {0}, accountHolder = {1}, balance = {2}]", AccountNumber, AccountHolder.Show(), Balance);
            return (m);
        }
    }
    
    public class CurrentAccountPoly : BankAccountPoly
    {
        public CurrentAccountPoly(string number, CustomerPoly holder, double bal) : base(number, holder, bal)
        {
        }
        public new double CalculateInterest()
        {
            return (Balance * 0.25 / 100);
        }
        public override string Show()
        {
            string m = String.Format("[OverdraftAccount: accountNumber = {0}, accountHolder = {1}, balance = {2}]", AccountNumber, AccountHolder.Show(), Balance);
            return (m);
        }

    }
    public class OverdraftAccountPoly : BankAccountPoly
    {
        private static double interestRate = 0.25;
        private static double overdraftInterest = 6;
        public OverdraftAccountPoly(string number, CustomerPoly holder, double bal) : base(number, holder, bal)
        {
        }
        public new bool Withdraw(double amount)
        {
            balance = balance - amount;
            return (true);
        }
        public new double CalculateInterest()
        {
            return ((Balance > 0) ?
                    (Balance * interestRate / 100) :
                    (Balance * overdraftInterest / 100));
        }
        public override string Show()
        {
            string g = String.Format("[CurrentAccount: accountNumber = {0}, accountHolder = {1}, balance = {2}]", AccountNumber, AccountHolder.Show(), Balance);
            return (g);
        }
    }
    public class BankAccountAppPoly
    {
        public static void Main()
        {
            CustomerPoly cus1 = new CustomerPoly("Tan Ah Kow", "2 Rich Street", "P123123", 20);
            CustomerPoly cus2 = new CustomerPoly("Kim May Mee", "89 Gold Road", "P334412", 60);
            BankAccountPoly a1 = new BankAccountPoly("S0000223", cus1, 2000);

            Console.WriteLine(a1.CalculateInterest());
            OverdraftAccountPoly a2 = new OverdraftAccountPoly("O1230124", cus1, 2000);
            Console.WriteLine(a2.CalculateInterest());
            CurrentAccountPoly a3 = new CurrentAccountPoly("C1230125", cus2, 2000);
            Console.WriteLine(a3.CalculateInterest()); ;

        }
    }
}
