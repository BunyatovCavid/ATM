using ATM;
using ATM.Models;
using System.Diagnostics;

Processes process = new();

string choose = "";
string amount;
Model account;




Console.Clear();
do
{
    do
    {
        Console.Write("Name : ");
        string name = Console.ReadLine();
        Console.WriteLine();

        Console.Write("Password : ");
        string password = Console.ReadLine();
        Console.WriteLine();

        process.Login(new PostModel() { Name = name, Password = password }, out account);
    } while (account.Name == "" || account.Password == "" || account.Name == null || account.Password == null);

    choose = "";

    if (!(account.Name == "" || account.Password == "" || account.Name == null || account.Password == null))
    {

        if (account.Name != "Boss")
        {
            while (choose != "E" && choose != "Q")
            {
                Console.WriteLine("Press Enter to see the options");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"Hello {account.Name}, Please select an option.");
                Console.WriteLine("[P] : Look at the account.");
                Console.WriteLine("[D] : Deposit.");
                Console.WriteLine("[W] : Withdraw.");
                Console.WriteLine("[O] : Look at the operations.");
                Console.WriteLine("[E] : Sign out. ");
                Console.WriteLine("[Q] : Close the system. ");
                Console.WriteLine();

                choose = Console.ReadLine();
                Console.WriteLine();

                switch (choose)
                {
                    case "P":
                        Console.WriteLine("Name : " + account.Name);
                        Console.WriteLine("Balance : " + account.Balance);
                        Console.WriteLine();
                        break;
                    case "D":
                        Console.Write("Amount :");
                        amount = Console.ReadLine();
                        Console.WriteLine();
                        process.Deposit(amount, account);
                        Console.WriteLine();
                        break;
                    case "W":
                        Console.Write("Amount :");
                        amount = Console.ReadLine();
                        Console.WriteLine();
                        process.Withdraw(amount, account);
                        Console.WriteLine();
                        break;
                    case "O":
                        process.GetOperations(new PostModel { Name = account.Name, Password = account.Password });
                        break;
                    case "E":
                        for (int i = 0; i < 3; i++)
                        {
                            Console.Clear();
                            Console.WriteLine("exits the account.");
                            Thread.Sleep(500);

                            Console.Clear();
                            Console.WriteLine("exits the account..");
                            Thread.Sleep(500);

                            Console.Clear();
                            Console.WriteLine("exits the account...");
                            Thread.Sleep(500);
                                                       
                        }
                        Console.Clear();
                        Console.WriteLine($"Goodbye {account.Name}.");
                        ///prosesleri 1 saniye dayandiriram.
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;

                }


            }
        }
        else
        {
            while (choose != "E" && choose != "Q")
            {
                Console.WriteLine("Press Enter to see the options");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"Hello {account.Name}, Please select an option.");
                Console.WriteLine("[C] : Create account.");
                Console.WriteLine("[P] : Look at the account.");
                Console.WriteLine("[A] : view all accounts.");
                Console.WriteLine("[D] : Deposit.");
                Console.WriteLine("[W] : Withdraw.");
                Console.WriteLine("[O] : Look at the operations.");
                Console.WriteLine("[E] : Sign out. ");
                Console.WriteLine("[Q] : Close the system. ");
                Console.WriteLine();


                choose = Console.ReadLine();
                Console.WriteLine();

                switch (choose)
                {
                    case "C":
                        bool create_check = false;
                        do
                        {
                            Console.Write("Name : ");
                            string name = Console.ReadLine();
                            Console.WriteLine();

                            Console.Write("Password : ");
                            string password = Console.ReadLine();
                            Console.WriteLine();
                            create_check = process.CreateAccount(new PostModel() { Name = name, Password = password });
                        } while (!create_check);
                        break;
                    case "P":
                        Console.WriteLine("Name : " + account.Name);
                        Console.WriteLine("Password : " + account.Password);
                        Console.WriteLine();
                        break;
                    case "A":
                        process.GetAccounts();
                        break;
                    case "D":
                        Console.Write("Amount :");
                        amount = Console.ReadLine();
                        Console.WriteLine();
                        process.Deposit(amount, account);
                        Console.WriteLine();
                        break;
                    case "W":
                        Console.Write("Amount :");
                        amount = Console.ReadLine();
                        Console.WriteLine();
                        process.Withdraw(amount, account);
                        Console.WriteLine();
                        break;
                    case "O":
                        process.GetOperations(new PostModel { Name = account.Name, Password = account.Password });
                        break;
                    case "E":
                        for (int i = 0; i < 3; i++)
                        {
                            Console.Clear();
                            Console.WriteLine("exits the account.");
                            Thread.Sleep(500);

                            Console.Clear();
                            Console.WriteLine("exits the account..");
                            Thread.Sleep(500);

                            Console.Clear();
                            Console.WriteLine("exits the account...");
                            Thread.Sleep(500);

                        }
                        Console.Clear();
                        Console.WriteLine($"Goodbye {account.Name}.");
                        ///prosesleri 1 saniye dayandiriram.
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;

                }
            }            
        }
        if (choose == "Q")
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                Console.WriteLine("exits the system.");
                Thread.Sleep(500);

                Console.Clear();
                Console.WriteLine("exits the system..");
                Thread.Sleep(500);

                Console.Clear();
                Console.WriteLine("exits the system...");
                Thread.Sleep(500);
            }
            Console.Clear();
            Console.WriteLine($"Goodbye {account.Name}.");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
} while (choose != "Q");
