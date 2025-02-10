﻿using Microsoft.VisualBasic;
using System.Security.Principal;

namespace Task4
{
    public class Account 
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string Name = "Unnamed Account", double Balance = 0.0)
        {
            this.Name = Name;
            this.Balance = Balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public static double operator + (Account lhs, Account rhs)
        {
            return lhs.Balance + rhs.Balance;
        }
    }
    public class Program
        {
            static void Main()
            {
                // Accounts
                var accounts = new List<Account>();
                accounts.Add(new Account());
                accounts.Add(new Account("Larry"));
                accounts.Add(new Account("Moe", 2000));
                accounts.Add(new Account("Curly", 5000));

                AccountUtil.Display(accounts);
                AccountUtil.Deposit(accounts, 1000);
                AccountUtil.Withdraw(accounts, 2000);

                // Savings
                var savAccounts = new List<Account>();
                savAccounts.Add(new SavingsAccount());
                savAccounts.Add(new SavingsAccount("Superman"));
                savAccounts.Add(new SavingsAccount("Batman", 2000));
                savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));
           

                AccountUtil.Display(savAccounts);
                AccountUtil.Deposit(savAccounts, 1000);
                AccountUtil.Withdraw(savAccounts, 2000);

                // Checking
                var checAccounts = new List<Account>();
                checAccounts.Add(new CheckingAccount());
                checAccounts.Add(new CheckingAccount("Larry2"));
                checAccounts.Add(new CheckingAccount("Moe2", 2000));
                checAccounts.Add(new CheckingAccount("Curly2", 5000));

                AccountUtil.Display(checAccounts);
                AccountUtil.Deposit(checAccounts, 1000);
                AccountUtil.Withdraw(checAccounts, 2000);
                AccountUtil.Withdraw(checAccounts, 2000);

                // Trust
                var trustAccounts = new List<Account>();
                trustAccounts.Add(new TrustAccount());
                trustAccounts.Add(new TrustAccount("Superman2"));
                trustAccounts.Add(new TrustAccount("Batman2", 2000));
                trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));



                AccountUtil.Display(trustAccounts);
                AccountUtil.Deposit(trustAccounts, 1000);
                AccountUtil.Deposit(trustAccounts, 6000);
                AccountUtil.Withdraw(trustAccounts, 2000);
                AccountUtil.Withdraw(trustAccounts, 3000);
                AccountUtil.Withdraw(trustAccounts, 500);
          




            Account account = new Account("nada" , 1000);
            Account account2 = new Account("sama", 2000);
            Console.WriteLine(account +account2);

                Console.WriteLine();
            }
        }

    class TrustAccount:Account
    {
        public double InterstRate { get; set; }
        public int WithdrawCount = 0;
        public DateTime FirstWithdraw;
        public TrustAccount(string name ="unknown" , double balance = 0 ,double ir= 0):base(name ,balance)
        {
            InterstRate=ir;
        }
        public override bool Deposit(double amount)
        {
            if (amount > 0)
            {
                if (amount >= 5000)
                {
                    Balance += amount * InterstRate+50;
                    return true;
                }
                Balance += amount * InterstRate ;
                return true;
            }
            return false;
        }
        public override bool Withdraw(double amount)
        {
            DateTime currentDate = DateTime.Now;

           
            if (WithdrawCount > 0 && (currentDate - FirstWithdraw).TotalDays >= 365)
            {
                WithdrawCount = 0;
                FirstWithdraw = currentDate;
            }

            if (Balance - amount >= 0 && amount < Balance*0.2 && WithdrawCount <=3)
            {
                if (WithdrawCount == 0)
                {
                    FirstWithdraw = DateTime.Now;
                }
                
                WithdrawCount++;
                Balance -= amount;
                return true;
            }
            return false;
        }
    
    }

    class CheckingAccount:Account
    {
        public CheckingAccount(string name = "none" , double balance=0.0):base(name ,balance)
        {
            
        }
        public override bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount+1.50;
                return true;
            }
            return false;
        }
    }

    class SavingsAccount : Account 
    {
        public double InterstRate { get; set; }

        public SavingsAccount(string name="unknown" , double balance=0.0 ,double ir=0) :base(name , balance) 
        {
            InterstRate = ir;
        }
        public override bool Deposit(double amount) {
            if (amount > 0)
            {
                Balance += amount * InterstRate;
                return true;
            }
            return false;
        }

    }

    public static class AccountUtil
    {
        // Utility helper functions for Account class

        public static void Display(List<Account> accounts)
        {
            Console.WriteLine("\n=== Accounts ==========================================");
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc +" "+ acc.Name + "__" + acc.Balance);
            }
        }

        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine($"\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc.Name}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc.Name}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc.Name} account");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc.Name} account");
            }
        }
    }
}
    

