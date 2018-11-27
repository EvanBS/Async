using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncAwait
{
    public delegate void AccountStateHandler(object sender, AccountEventArgs e);

    class Account
    {
        public event AccountStateHandler Added;

        public event AccountStateHandler Withdrawn;

        private int money;

        public string Name { get; set; }

        public Account(int money, string Name = null)
        {
            this.money = money;
            this.Name = Name ?? "Pots";
        }

        public void RegisterAdded(AccountStateHandler accountStateHandler)
        {
            Added += accountStateHandler;
        }

        public void RegisterWithdrawn(AccountStateHandler accountStateHandler)
        {
            Withdrawn += accountStateHandler;
        }

        public bool Withdraw(int val)
        {

            if (money <= val)
            {
                Withdrawn?.Invoke(this, new AccountEventArgs("not enough", val));
                return false;
            }

            money -= val;
            Withdrawn?.Invoke(this, new AccountEventArgs("ok", val));
            return true;

        }

        public bool Addval(int val)
        {
            money += val;
            Added?.Invoke(this, new AccountEventArgs("ok", val));
            return true;

        }

    }

    public class AccountEventArgs
    {
        public string Message { get; }

        public int Sum { get; }

        public AccountEventArgs(string mes, int sum)
        {
            Message = mes;
            Sum = sum;
        }
    }

    public static class States
    {
        public static void Show_Message_Reply(string message)
        {
            Console.WriteLine(message);
        }

        public static void ShowMessage(object sender, AccountEventArgs e)
        {
            Console.WriteLine($"transaction result : {e.Message}");
            Console.WriteLine($"transaction value : {e.Sum}");
        }
    }

}
