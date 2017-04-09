using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISS.RV.LIB;
using System.Collections;

namespace CSharp.NetWorkshops
{
    //workshop 5a Polymorph
    public class CustomerBranch
    {
        //attributes
        private string name;
        private string address;
        private string passport;
        private int age;

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
                return age;
            }
            set
            {
                age = value;
            }
        }
        //Methods
        public override string ToString()
        {
            string m = String.Format("[Customer:name={0},address={1},passport={2},age={3}]",
                Name, Address, Passport, Age);
            return (m);
        }
        public void GrowOld()
        {
            age = age + 1;
        }
        //Constructor
        
        public CustomerBranch(string name, string address, string passport, int age)
        {
            this.name = name;
            this.address = address;
            this.passport = passport;
            this.age = age;
        }
        public CustomerBranch(string name)
            : this(name, "ThisAddress", "ThisPassport", 0) 
        {
        }

        public CustomerBranch()
            : this("ThisName", "ThisAddress", "ThisPassport", 0) 
        {
        }
    }

    public class BankAccountBranch
    {
        //attributes
        private string accountNumber;
        private CustomerBranch accountHolder;
        protected double balance;

        // Constructor
        public BankAccountBranch(string number, CustomerBranch holder, double bal)
        {
            accountNumber = number;
            accountHolder = holder;
            balance = bal;
        }
        public BankAccountBranch() : this("000-000-000", new CustomerBranch(), 0)
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
        public CustomerBranch AccountHolder
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

        public bool TransferTo(double amount, BankAccountBranch another)
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

       
        public override string ToString()
        {
            string m = String.Format("[BankAccount:accountNumber={0},accountHolder={1},balance={2}]",
                AccountNumber, AccountHolder.ToString(), Balance);
            return (m);
        }
    }
    public class SavingsAccount : BankAccountBranch
    {
        private static double interestRate = 1;
        public SavingsAccount(string number, CustomerBranch holder, double bal) : base(number, holder, bal)
        {
        }
        public override double CalculateInterest()
        {
            return (Balance * interestRate / 100);
        }
        public override bool Withdraw(double amount)
        {
            if (amount < Balance)
                return (base.Withdraw(amount));
            else
            {
                Console.WriteLine("Cannot withdraw");
                return (false);
            }
        }
        public override string ToString()
        {
            string m = String.Format("[SavingsAccount:accountNumber={0},accountHolder={1},balance={2}]",
                AccountNumber, AccountHolder, Balance);
            return (m);
        }
    }
        public class CurrentAccountBranch : BankAccountBranch
    {
        private static double interestRate = 0.25;
        public CurrentAccountBranch(string number, CustomerBranch holder, double bal) : base(number, holder, bal)
        {
        }
        public override double CalculateInterest()
        {
            return (Balance * interestRate / 100);
        }
        public override bool Withdraw(double amount)
        {
            if (amount < Balance)
                return (base.Withdraw(amount));
            else
            {
                Console.WriteLine("Cannot withdraw");
                return (false);
            }
        }
        public override string ToString()
        {
            string m = String.Format("[CurrentAccount:accountNumber={0},accountHolder={1},balance={2}]",
                AccountNumber, AccountHolder.ToString(), Balance);
            return (m);
        }
    }
    public class OverdraftAccountBranch : BankAccountBranch
    {
        private static double interestRate = 0.25;
        private static double overdraftInterest = 6;
        public OverdraftAccountBranch(string number, CustomerBranch holder, double bal) : base(number, holder, bal)
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
    }
    public class BankBranch
    {
        //attributes
        private string branchName;
        private string branchManager;
        private ArrayList accounts;
        //accessmut
        public string BranchName
        {
            get
            {
                return branchName;
            }
        }
        public string BranchManager
        {
            get
            {
                return branchManager;
            }
        }
        //methods
        public void AddAccount(BankAccountBranch a)
        {
            accounts.Add(a);
        }
        public void PrintAccounts()
        {
            for (int i = 0; i < accounts.Count; i++)
                Console.WriteLine(accounts[i]);
        }
        public void PrintCustomers()
        {
            ArrayList cust = new ArrayList();
            for(int i = 0; i < accounts.Count; i++)
            {
                BankAccountBranch a = (BankAccountBranch) accounts[i];
                CustomerBranch t = a.AccountHolder;
                int c = cust.IndexOf(t);
                if (c < 0)
                    cust.Add(t);
            }
            for (int i = 0; i < cust.Count; i++)
                Console.WriteLine(cust[i]);

        }
        public void CreditInterest()
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                BankAccountBranch a = (BankAccountBranch)accounts[i];
                a.CreditInterest();
            }
        }
        public double TotalDeposits()
        {
            double total = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                BankAccountBranch a = (BankAccountBranch)accounts[i];
                double bal = a.Balance;
                if (bal > 0)
                    total += bal;
            }
            return (total);
        }
        public double TotalInterestPaid()
        {
            double total = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                BankAccountBranch a = (BankAccountBranch)accounts[i];
                double intr = a.CalculateInterest();
                if (intr > 0)
                    total += intr;
            }
            return (total);
        }
        public double TotalInterestEarned()
        {
            double total = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                BankAccountBranch a = (BankAccountBranch)accounts[i];
                double intr = a.CalculateInterest();
                if (intr < 0)
                    total += (-intr);
            }
            return (total);
        }
        //const
        public BankBranch(string n, string m)
        {
            branchName = n;
            branchManager = m;
            accounts = new ArrayList();
        }
    }

    public class BankAccountAppBranch
    {
        public static void Main()
        {
            BankBranch branch = new BankBranch("KOKO Bank Branch",
                                              "Tan Mon Nee");
            CustomerBranch cus1 = new CustomerBranch("Tan Ah Kow", "2 Rich Street",
                                      "P345123", 40);
            CustomerBranch cus2 = new CustomerBranch("Lee Tee Kim", "88 Fatt Road",
                                      "P678678", 54);
            CustomerBranch cus3 = new CustomerBranch("Alex Gold", "91 Dream Cove",
                                      "P333221", 34);
            branch.AddAccount(new SavingsAccount("S1230123", cus1, 2000));
            branch.AddAccount(new OverdraftAccountBranch("O1230124", cus1, 2000));
            branch.AddAccount(new CurrentAccountBranch("C1230125", cus2, 2000));
            branch.AddAccount(new OverdraftAccountBranch("O1230126", cus3, -2000));
            branch.PrintCustomers();
            branch.PrintAccounts();
            Console.WriteLine(branch.TotalInterestEarned());
            Console.WriteLine(branch.TotalInterestPaid());
            branch.CreditInterest();
            branch.PrintAccounts();
        }
    }
}
