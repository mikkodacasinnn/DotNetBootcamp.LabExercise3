using System;

namespace ConsoleApp3
{
    class UserAccount
    {
        public UserAccount()
        {

        }
        public decimal Balance { get; set; }
    }
    class BalanceChecker
    {
        UserAccount userAccount;
        public BalanceChecker(UserAccount userAccount)
        {
            this.userAccount = userAccount;
        }
        public void getBalance()
        {
            Console.WriteLine($"Your current balance now is PHP {userAccount.Balance}");
        }
    }
    class DepositChecker
    {
        UserAccount userAccount;
        public DepositChecker(UserAccount userAccount)
        {
            this.userAccount = userAccount;
        }
        public bool DepositValidation(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Invalid Input. Please enter amount greater than PHP 0");
                return false;
            }
            if (amount == null)
            {
                Console.WriteLine("Invalid Input");
                return false;
            }
            return true;
        }
    }

    class Depositor
    {
        UserAccount userAccount;
        public Depositor(UserAccount userAccount)
        {
            this.userAccount = userAccount;
        }
        public void DepositCash(decimal amount)
        {
            userAccount.Balance += amount;
            Console.WriteLine($"Thank you for your transaction. PHP {amount} is added to your account");
        }
    }

    class WithdrawChecker
    {
        UserAccount userAccount;
        public WithdrawChecker(UserAccount userAccount)
        {
            this.userAccount = userAccount;
        }
        public bool WithdrawValidation(decimal amount)
        {
            if (userAccount.Balance < amount)
            {
                Console.WriteLine("Insufficient Funds.");
                return false;
            }
            if (amount == null)
            {
                Console.WriteLine("Invalid Input.");
                return false;
            }
            if (amount < 0)
            {
                Console.WriteLine("Please withdraw within 100 and above");
                return false;
            }
            if (amount % 100 != 0)
            {
                Console.WriteLine("Withdraw within multiples of 100 only.");
                return false;
            }
            return true;
        }
    }

    class Withdrawer
    {
        UserAccount userAccount;
        public Withdrawer(UserAccount userAccount)
        {
            this.userAccount = userAccount;
        }
        public void WithdrawCash(decimal amount)
        {
            userAccount.Balance -= amount;
            Console.WriteLine($"Thank you for your transaction. PHP {amount} is deducted to your account");
        }
    }

    internal class Program
    {

        static void Main()
        {
            UserAccount userAccount = new UserAccount();
            BalanceChecker balanceChecker = new BalanceChecker(userAccount);
            DepositChecker depositChecker = new DepositChecker(userAccount);
            Depositor depositor = new Depositor(userAccount);
            WithdrawChecker withdrawChecker = new WithdrawChecker(userAccount);
            Withdrawer withdrawer = new Withdrawer(userAccount);

            do
            {
                Console.WriteLine("*****WELCOME TO MIKKO ATM SERVICES*****");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit Cash");
                Console.WriteLine("3. Withdraw Cash");
                Console.WriteLine("4. Exit");
                Console.WriteLine("***************************************");

                Console.Write("Enter your choice to transact: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    balanceChecker.getBalance();
                }
                if (choice == 2)
                {
                    Console.Write("How much would you like to deposit?: ");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());
                    if (depositChecker.DepositValidation(amount) == false)
                    {

                    }
                    else
                    {
                        depositor.DepositCash(amount);
                        balanceChecker.getBalance();
                    }
                }
                if (choice == 3)
                {
                    Console.Write("How much would you like to withdraw?: ");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());
                    if (withdrawChecker.WithdrawValidation(amount) == false)
                    {

                    }
                    else
                    {
                        withdrawer.WithdrawCash(amount);
                        balanceChecker.getBalance();
                    }
                }
                if (choice == 4)
                {
                    Environment.Exit(-1);
                }
            } while (true);
        }
    }
}
