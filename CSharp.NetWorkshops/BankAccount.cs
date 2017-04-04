﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISS.RV.LIB;

namespace CSharp.NetWorkshops
{
    public class Customer
    {
        private string name;
        private string address;
        private string passportNumber;
        private DateTime dateOfBirth;

        //propeties-accessmut
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
        public string PassportNumber
        {
            get
            {
                return passportNumber;
            }
        }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - dateOfBirth.Year;
            }
        }
    }
    public class BankAccount2
    {
        //attributes
        public string accountNumber;
        public string accountHolder;
        public double balance;

        // properties 
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public string AccountHolder
        {
            get
            {
                return accountHolder;
            }
        }
        public double Balance
        {
            get
            {
                return balance;
            }
        }

        // Constructor
        public BankAccount2(string number, string holder, double bal)
        {
            accountNumber = number;
            accountHolder = holder;
            balance = bal;

        }
        public BankAccount2() : this("000-000-000", "NONAME", 0) { }

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
                Console.WriteLine("Withdrawal for {0} is unsuccesful", AccountHolder);
                return (false);
        }
        public bool TransferTo(double amount, BankAccount2 another)
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
            public string Show()
            {
            string m = String.Format("[Account:AccountNumber{0}, AccountHolder={1}, Balance{2}]", AccountNumber, AccountHolder, Balance);
            return m;
        }
    }
    public class BankAccountApp2
    {
        static void Main()
        {
            BankAccount2 a = new BankAccount2("001-001-001", "Tan Ah Kow", 2000);
            BankAccount2 b = new BankAccount2("001-001-002", "Kim Keng Lee", 5000);
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
