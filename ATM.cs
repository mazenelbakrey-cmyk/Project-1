enum Menu1
{
    LogIn = 1,
    CreateAccount
}

enum MenuLogin
{
    CheckBalance = 1,
    DepositMoney,
    WithdrawMoney,
    ViewTransactionHistory,
    Exit
}

class Program
{
    static void DisplayMenu1()
    {
        Console.WriteLine();
        Console.WriteLine("1- Log in using your account number");
        Console.WriteLine("2- Create a new account");
        Console.WriteLine();
        Console.Write("Enter your choice: ");
    }

    static void DisplayMenuLogin()
    {
        Console.WriteLine();
        Console.WriteLine("1- Check balance");
        Console.WriteLine("2- Deposit money");
        Console.WriteLine("3- Withdraw money");
        Console.WriteLine("4- View transaction history");
        Console.WriteLine("5- Exit");
        Console.WriteLine();
        Console.Write("Enter your choice: ");
    }

    static double DepositMoney( ref double balance , double mount)
    {
        balance += amount;
        return balance;
    }

    static double WithdrawMoney(ref double balance, double amount)
    {
        balance -= amount;    
        return balance;
    }

    static void Main()
    {
        bool loop=true;
        String name;
        String pin;
        double balance = 0;
        double amount = 0;
        List<string> history = new List<string>();
        while (loop)
        {
            DisplayMenu1();
            int Choice1=Convert.ToInt32(Console.ReadLine());
            Menu1 m1 = (Menu1)Choice1;
            switch (m1)
            {
                case Menu1.LogIn:
                    Console.WriteLine("Enter the username : ");
                    name=Console.ReadLine();
                    Console.WriteLine("Enter the PIN : ");
                    pin = Console.ReadLine();
                    DisplayMenuLogin();
                    int choice2 = Convert.ToInt32(Console.ReadLine());
                    MenuLogin m2 = (MenuLogin)choice2;
                    switch (m2)
                    {
                        case MenuLogin.CheckBalance:
                            Console.WriteLine($"your balance : {balance}");
                            break;
                        case MenuLogin.DepositMoney:
                            Console.WriteLine("Enter the amount : ");
                            amount = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine($"You Deposited {amount} in your account , Now your balance : { DepositMoney(ref balance, amount)}"+ DateTime.Now);
                            history.Add($"Deposited {amount} at {DateTime.Now}");
                            break;
                        case MenuLogin.WithdrawMoney:
                            Console.WriteLine("Enter the amount : ");
                            amount = Convert.ToDouble(Console.ReadLine());
                            if (amount > balance)
                            {
                                Console.WriteLine("Insufficient balance.");
                            }
                            else
                            {
                                Console.WriteLine($" You Withdrew {amount} from your account , Now your balance : {WithdrawMoney(ref balance, amount)}" + DateTime.Now);
                                history.Add($"Withdrawed {amount} at {DateTime.Now}");
                            }
                            break;
                        case MenuLogin.ViewTransactionHistory:
                            Console.WriteLine("Your TransactionHistory : ");
                            for (int i = 0; i < history.Count; i++)
                            {
                                Console.WriteLine(history[i].ToString());
                            }
                            break;
                        case MenuLogin.Exit:
                            loop=false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;

                    }
                    break;
                case Menu1.CreateAccount:
                    Console.WriteLine("Enter the username : ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter the PIN : ");
                    pin = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}