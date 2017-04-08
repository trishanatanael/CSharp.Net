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

        // methods = what it can do (Deposit,withdraw,transfer)
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
        public CurrentAccount(string number, CustomerInheritance holder, double bal) : base(number, holder, bal)
        {
        }
        public new double CalculateInterest()
        {
            return (Balance * 0.25 / 100);
        }
        public new string Show()
        {
            //solution doesnt use new
            string m = String.Format("[OverdraftAccount: accountNumber = {0}, accountHolder = {1}, balance = {2}]", AccountNumber, AccountHolder.Show(), Balance);
            return (m);
        }

    }
    public class OverdraftAccount : BankAccountInheritance
    {
        private static double interestRate = 0.25;
        private static double overdraftInterest = 6;
        public OverdraftAccount(string number, CustomerInheritance holder, double bal) : base(number, holder, bal)
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
        public new string Show()
        {
            //solution doesnt use new
            string g = String.Format("[CurrentAccount: accountNumber = {0}, accountHolder = {1}, balance = {2}]", AccountNumber, AccountHolder.Show(), Balance);
            return (g);
        }
    }
    public class BankAccountAppInheritance
    {
        public static void Main()
        {
            CustomerInheritance cus1 = new CustomerInheritance("Tan Ah Kow", "2 Rich Street", "P123123", 20);
            CustomerInheritance cus2 = new CustomerInheritance("Kim May Mee", "89 Gold Road", "P334412", 60);
            BankAccountInheritance a1 = new BankAccountInheritance("S0000223", cus1, 2000);

            Console.WriteLine(a1.CalculateInterest());
            OverdraftAccount a2 = new OverdraftAccount("O1230124", cus1, 2000);
            Console.WriteLine(a2.CalculateInterest());
            CurrentAccount a3 = new CurrentAccount("C1230125", cus2, 2000);
            Console.WriteLine(a3.CalculateInterest());

        }
    }
}
