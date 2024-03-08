
using System;
using static System.Console;

namespace DemoBankEvent
{
    class BankAccount
    {
    private int acctNum;
    private double balance;
    public event EventHandler BalanceAdjusted;
        public BankAccount(int acct)
        {
            acctNum = acct;
            balance = 0;
        }

        public int AcctNum
        {
            get
            {
                return acctNum;
            }
        }
        public double Balance
        { 
            get 
            { return balance; 
            } 
        }
        public void MakeDeposit(double amt)
        {
            balance += amt;
            OnBalanceAdjusted(EventArgs.Empty);
        }
        public void MakeWithdrawal (double amt) 
        {
            balance -= amt;
            OnBalanceAdjusted(EventArgs.Empty);
        }
        public void OnBalanceAdjusted(EventArgs e)
        {
            BalanceAdjusted(this, e);    
        }
    }
    class EventLister
    {
        private BankAccount acct;
        public EventLister(BankAccount account) 
        {
            acct = account;
            acct.BalanceAdjusted += new EventHandler(BankAccountBalanceAdjusted);
        }
        private void BankAccountBalanceAdjusted(Object sender, EventArgs e) 
        {
            WriteLine("The account balance has been adjusted");
            WriteLine(" Account# {0} balance {1}", acct.AcctNum, acct.Balance.ToString("C2"));
        }
    }
    class DemoBankAccountEvent
    {
        static void Main()
        {
            const int TRANSACTIONS = 5;
            char code;
            double amt;

            BankAccount acct = new BankAccount(334455);
            EventLister listener = new EventLister(acct);

            for(int x = 0; x < TRANSACTIONS; ++x)
            {
                Write("Enter D for deposit or W for withdrawal ");
                code = Convert.ToChar(ReadLine());
                Write("Enter dollar amount ");
                amt = Convert.ToDouble(ReadLine());
                if (code == 'D')
                    acct.MakeDeposit(amt);
                else
                    acct.MakeWithdrawal(amt);
            }
        }
    }
}
