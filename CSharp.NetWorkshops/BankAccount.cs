//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using ISS.RV.LIB;

//namespace CSharp.NetWorkshops
//{
//    //workshop 3.1
//    public class BankAccount
//    {
//        //attributes
//        private string accountNumber;
//        private string accountHolder;
//        private double balance;

//        // Constructor
//        public BankAccount(string number, string holder, double bal)
//        {
//            accountNumber = number;
//            accountHolder = holder;
//            balance = bal;
//        }
//        public BankAccount() : this("000-000-000", "NONAME", 0)
//        {
//        }
//        //propeties
//        public string AccountNumber
//        {
//            get
//            {
//                return accountNumber;
//            }
//        }
//        public string AccountHolder
//        {
//            get
//            {
//                return accountHolder;
//            }
//            set
//            {
//                accountHolder = value;
//            }
//        }
//        public double Balance
//        {
//            get
//            {
//                return balance;
//            }
//        }

//        // methods = what it can do
//        //Dep,withdraw,transfer
//        public void Deposit(double amount)
//        {
//            balance = balance + amount;
//        }
//        public bool Withdraw(double amount)
//        {
//            if (amount < balance)
//            {
//                balance = balance - amount;
//                return (true);
//            }
//            else
//                Console.Error.WriteLine("Withdrawal for {0} is unsuccesful", AccountHolder);
//                return (false);
//        }
//        public bool TransferTo(double amount, BankAccount another)
//        {
//            if (Withdraw(amount))
//            {
//                another.Deposit(amount);
//                return (true);
//            }
//            else
//            {
//                Console.Error.WriteLine("Transfer to {0} is unsuccessful", another);
//                return (false);
//            }
//        }
//            public string Show()
//            {
//            string m = String.Format("[Account:AccountNumber{0}, AccountHolder= {1}, Balance {2}]", AccountNumber, AccountHolder, Balance);
//            return m;
//        }
//    }
//    public class BankAccountApp
//    {
//        static void Main()
//        {
//            BankAccount a = new BankAccount("001-001-001", "Tan Ah Kow", 2000);
//            BankAccount b = new BankAccount("001-001-002", "Kim Keng Lee", 5000);
//            Console.WriteLine(a.Show());
//            Console.WriteLine(b.Show());
//            a.Deposit(100);
//            Console.WriteLine(a.Show());
//            a.Withdraw(200);
//            Console.WriteLine(a.Show());
//            a.TransferTo(300, b);
//            Console.WriteLine(a.Show());
//            Console.WriteLine(b.Show());
//        }
//    }
//}
