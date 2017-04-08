using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISS.RV.LIB;

namespace CSharp.NetWorkshops
{

    //workshop 3.2a
    public class Customer2Mul
    {
        //attributes
        private string name;
        private string address;
        private string passport;
        private DateTime dateOfBirth;
        private BankAccount2Mul[] bankAccounts2Mul;
        private int noOfBankAccounts;
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
        public void AddBankAccount(BankAccount2Mul a)
        {
            bankAccounts2Mul[noOfBankAccounts] = a;
            noOfBankAccounts++;

        }
        public string Show()
        {

            string n = String.Format("[Customer: name={0},address={1},passport={2},age={3}]", Name, Address, Passport, Age);
            return (n);
        }
        //Constructor
        public Customer2Mul(string name, string address, string passport, DateTime dob) : this(name,address,passport)
        {
            this.dateOfBirth = dob;
        }
        public Customer2Mul(string name, string address, string passport, int age) : this(name, address, passport)
        {
            this.dateOfBirth = new DateTime(DateTime.Now.Year - age, 1, 1);
        }
        public Customer2Mul(string name, string address, string passport)
        {
            this.name = name;
            this.address = address;
            this.passport = passport;
            this.bankAccounts2Mul = new BankAccount2Mul[10];
            this.noOfBankAccounts = 0;
        }
        public Customer2Mul():this("NoName", "NoAddress","NoPassport",new DateTime(1980,1,1))
        { 
        }

    }


    //workshop 3.2b
    public class BankAccount2Mul
    {
        //attributes
        private string accountNumber;
        private Customer2Mul accountHolder;
        private double balance;


        // Constructor
        public BankAccount2Mul(string number, Customer2Mul holder, double bal)
        {
            accountNumber = number;
            accountHolder = holder;
            balance = bal;
            holder.AddBankAccount(this);
        }
        public BankAccount2Mul(): this("000-000-000", new Customer2Mul(), 0)
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
        public Customer2Mul AccountHolder
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
        }

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
                Console.Error.WriteLine("Withdrawal for {0} is unsuccesful", AccountHolder);
            return (false);
        }
        public bool TransferTo(double amount, BankAccount2Mul another)
        {
            if (Withdraw(amount))
            {
                another.Deposit(amount);
                return (true);
            }
            else
            {
                Console.Error.WriteLine("Transfer to {0} is unsuccessful", AccountHolder);
                return (false);
            }
        }
        public string Show()
        {
            string m = String.Format("[Account: accountNumber = {0}, accountHolder = {1}, balance = {2}]", AccountNumber, AccountHolder.Show(), Balance);
            return (m);
        }
    }
    public class BankAccountApp2Mul
    {
        public static void Main()
        {
            Customer2Mul t = new Customer2Mul("Tan Ah Kow", "20, Seaside Road", "XXX20", new DateTime(1989, 10, 11));
            Customer2Mul c = new Customer2Mul("Kim Lee Keng", "2, Rich View", "XXX9F", new DateTime(1993, 4, 25));
            BankAccount2Mul a = new BankAccount2Mul("001-001-001", t, 2000);
            BankAccount2Mul b = new BankAccount2Mul("001-001-002", c, 5000);

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
