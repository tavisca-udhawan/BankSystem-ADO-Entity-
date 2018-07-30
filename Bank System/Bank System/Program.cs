using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic;
using Entity;
namespace Bank_System
{
    class Program {
        static int id = 1000;
       public static void front()
        {
            
            int Option;
            //Main Menu
                Console.WriteLine("|-------Bank System-------|");
                Console.WriteLine("|1---Create New Account.  |");
                Console.WriteLine("|2---Account Details.     |");
                Console.WriteLine("|3---Exit                 |");
                Console.WriteLine("|-------------------------|");
                Console.WriteLine("Enter Option:");
                Option = int.Parse(Console.ReadLine());

                switch (Option)
                {
                    case 1:
                        {
                        UserEntries();
                         break;
                        }
                    case 2:
                        {
                        LoginDetail();
                           
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please Enter valid Option.");
                            break;
                        }
                }
            }
        public static void LoginDetail()
        {
           
            Login login = new Login();
            Console.WriteLine("1---ADO.NET");
            Console.WriteLine("2---Entity Framework");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("----Login----");
            Console.WriteLine("Enter Name:");
            login.Name = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            login.password = Console.ReadLine();
            int result=Business.UserLogin(login,choice);
            int checkValue = 0;
            if (result == 1)
            {
                while (checkValue != 5)
                {
                    Console.WriteLine("Select option:");
                    Console.WriteLine("1--To check Balance");
                    Console.WriteLine("2--To check Interest");
                    Console.WriteLine("3--To Add Balance");
                    Console.WriteLine("4--To Withdraw Money");
                    Console.WriteLine("5--To Log Out");
                    Console.WriteLine("Enter Choice:");
                    checkValue = int.Parse(Console.ReadLine());
                    if (checkValue == 1)   //To check Balance
                    {
                        Console.Clear();
                        int balance = Business.Balance(login,choice);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your Balance is: " + balance);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (checkValue == 2)   //To Check Interest
                    {

                        Console.Clear();
                        string AccountType = Business.Interest(login,choice);
                        if (AccountType == "Saving Account")       //checking saving account
                        {
                            int val = 1;
                            int Interest=Business.CalcInterest(login,checkValue,val);
                            Console.WriteLine("Interest: " + Interest);
                        }

                        else if (AccountType == "Current Account")  //checking current account
                        {
                            Console.Clear();
                            int val = 2;
                            int Interest = Business.CalcInterest(login, checkValue, val);
                            Console.WriteLine("Interest: " + Interest);
                        }
                        else
                        {

                            Console.Clear();
                            int balance = Business.Balance(login,choice);
                            Console.WriteLine("Interest: " + balance);
                        }
                    }
                    if (checkValue == 3) // To add Balance
                    {
                        Console.Clear();
                        int balance = Business.Balance(login,choice);
                        Console.WriteLine("Please enter an amount which you want to add:");
                        int newAmount = int.Parse(Console.ReadLine());
                        // newAmount += balance;
                        string AccountType = Business.Interest(login, choice);
                        int value = Business.Details(login, newAmount,choice,checkValue,AccountType);
                        if (value>0)
                        {
                            Console.Clear();
                            Console.WriteLine("New Balance: " + value);
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("Your Transaction has been successfully done");
                      
                            Console.WriteLine("--------------------------------------------");

                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("--------------------------------------------------");
                            Console.WriteLine("Sorry, You are crossing the Account balance limit i.e 85000");
                            Console.WriteLine("--------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    if (checkValue == 4)   //To Withdraw Money
                    {

                        Console.Clear();
                        Console.WriteLine("Please enter an amount which you want to withdraw:");
                        int WithdrawAmount = int.Parse(Console.ReadLine());
                        string AccountType = Business.Interest(login, choice);
                        int value = Business.Details(login,WithdrawAmount,choice,checkValue,AccountType);
                     
                         
                        }
                 
                        
                    }
                    if (checkValue == 5)
                    {
                        front();
                    }
                }
            
            else
                LoginDetail();
        }
            public static void UserEntries()
        {
            
            Customer user = new Customer();
            Console.WriteLine("Enter Account Holder's Name:");
            user.Name = Console.ReadLine();  //Reading customer name
          
            Console.WriteLine("Enter Password:");
            user.password = Console.ReadLine();
            Console.WriteLine("Enter Account Type:");
            Console.WriteLine("1---Savings");
            Console.WriteLine("2---Current");
            Console.WriteLine("3---DMAT");
            Console.WriteLine("Enter Choice:");
            int Choice = int.Parse(Console.ReadLine()); //reading account type

            if (Choice == 1)
            {//assigning details of a particular customer in Savings Account
           
                 user.Deposit = 1000;
                user.AccountType = "Saving Account";

            }
            else if (Choice == 2)
            {//Current Account

                user.Deposit = 0;
                user.AccountType = "Current Account";
            }
            else if (Choice == 3)
            {//DMAT Account

                user.Deposit = -10000;
                user.AccountType = "DMAT Account";
          }
            Console.WriteLine("1---ADO.NET");
            Console.WriteLine("2---Entity Framework");
            int choice = int.Parse(Console.ReadLine());
            
            int x=Business.NewAccount(user,choice);
            if (x == 1)
                Console.WriteLine("Account Created");
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Username already exists");
                Console.ForegroundColor = ConsoleColor.White;
            }
           
            front();
        }
       public static void Main(string[] args)
        {
            var _continue = true;
            while (_continue)
            {
                front();
                Console.WriteLine("Do you want to Exit? (y/n)");
                if (Console.ReadLine() == "y")
                    _continue = false;
            }
        }
    }
}
