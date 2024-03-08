
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

}
