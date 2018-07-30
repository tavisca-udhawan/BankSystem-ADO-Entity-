using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace DataAccess
{
    public class Connections
    {
        static string value1 = "";
        static string value2 = "";
        enum Accounts { Salary = 0, Current, DMAT };   //enums
        public static string Interest1(Login login)                          //entity framework function
        {
            string account = "";
            using (DBBankingSystemEntities model = new DBBankingSystemEntities())    
            {
                CustomerDetail data1 = model.CustomerDetails.FirstOrDefault(r => r.Name == login.Name);
                 account= data1.AccountType;
            }
            return account;
        }
        public static int Calculted_Interest(Login login, int choice, int value)    //entity framework function
        {
            int balance = 0;
            int interest = 0;
            using (DBBankingSystemEntities model = new DBBankingSystemEntities())
            {
                CustomerDetail data1 = model.CustomerDetails.FirstOrDefault(r => r.Name == login.Name);
                interest = data1.Balance;

                if (value == 1)
                {
                    balance= (4 * interest) / 100;
                }
                if (value == 2)
                {
                    balance = (1 * interest) / 100;
                }
            }
            return balance;
        }
        public static string Interest(Login login)                 //ADO.Net function
        {
            string AccType = "";
            SqlConnection connection = new SqlConnection("Data Source=TAVDESK087;Initial Catalog=DBBankingSystem;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("Login_Check", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", login.Name);
            command.Parameters.AddWithValue("@Password", login.password);
            SqlDataReader reader = command.ExecuteReader();
            int flag = 0;
            while (reader.Read())
            {
                if (login.Name == reader["Name"].ToString() && login.password == reader["Password"].ToString())
                {
                    AccType = reader["AccountType"].ToString();
                    flag = 1;
                    break;
                }
            }
            reader.Close();
            connection.Close();
            return AccType;
        }
        public static int Balance1(Login login)                       //entity framework function
        {
            int balance = 0;
            using (DBBankingSystemEntities model = new DBBankingSystemEntities())
            {
                CustomerDetail data1 = model.CustomerDetails.FirstOrDefault(r => r.Name == login.Name);
                balance = data1.Balance;
            }
            return balance;
        }
        public static int Balance(Login login)                       //ADO.Net Function
        {
            string balance = "";
            SqlConnection connection = new SqlConnection("Data Source=TAVDESK087;Initial Catalog=DBBankingSystem;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("Login_Check", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", login.Name);
            command.Parameters.AddWithValue("@Password", login.password);
            SqlDataReader reader = command.ExecuteReader();
            int flag = 0;
            while (reader.Read())
            {
                if (login.Name == reader["Name"].ToString() && login.password == reader["Password"].ToString())
                {
                    balance = reader["Balance"].ToString();
                    flag = 1;
                    break;
                }
            }
            reader.Close();
            connection.Close();
            return int.Parse(balance);
        }
        public static int LoginData2(Login login)              //entity framework function
        {
            int flag = 0;
            if (flag == 0)
            {
                using (DBBankingSystemEntities model = new DBBankingSystemEntities())
                {
                    CustomerDetail data1 = model.CustomerDetails.FirstOrDefault(r => r.Name == login.Name);
                    int ID = data1.AccountID;
                   

                    if (data1.Name==login.Name && data1.Password==login.password)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You are logging in....");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine("Name: " + data1.Name + "   Your ID is: " + ID);
                        Console.WriteLine("Password: " + data1.Password);
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        flag = 1;
                    }
                }
            }
            if (flag == 1)
                return 1;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid");
                Console.ForegroundColor = ConsoleColor.White;
                return 0;
            }
        }
        

        public static int LoginData(Login login)            //ADO.Net Function
        {
            value1 = login.Name;
            value2 = login.password;
            string AccountNumber = "";
            string UserName = "";
            string balance = "";
            string account = "";
            SqlConnection connection = new SqlConnection("Data Source=TAVDESK087;Initial Catalog=DBBankingSystem;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("Login_Check", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", login.Name);
            command.Parameters.AddWithValue("@Password", login.password);
            SqlDataReader reader = command.ExecuteReader();
            int flag = 0;
            while (reader.Read())
            {
                if (login.Name == reader["Name"].ToString() && login.password == reader["Password"].ToString())
                {
                    AccountNumber = reader["AccountID"].ToString();
                    UserName = reader["Name"].ToString();
                    balance = reader["Balance"].ToString();
                    account = reader["AccountType"].ToString();

                    flag = 1;
                    break;
                }
            }
            reader.Close();
            connection.Close();
            if (flag == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You are logging in....");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("Account Number: " + AccountNumber + "     Name: " + UserName);
                Console.WriteLine("Balance: " + balance + "          Account: " + account);
                Console.WriteLine("-----------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                return 1;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login failed.....");
                Console.ForegroundColor = ConsoleColor.White;

                return 0;
            }
        }
        public static int AccountDetails1(Login login, int Data,int checkValue)            //entity framework function
        {
            int result = 0;
            using (DBBankingSystemEntities model = new DBBankingSystemEntities())
            {
                CustomerDetail data1 = model.CustomerDetails.FirstOrDefault(r => r.Name == login.Name);
                if (checkValue == 3) {
                    if ((data1.Balance+Data) <= 8500)
                        data1.Balance = data1.Balance + Data;
                    model.SaveChanges();
                }
                if (checkValue == 4) {
                    if ((data1.Balance-Data) > 1000 && data1.AccountType == "Saving Account")
                    data1.Balance = data1.Balance - Data;
                    else if ((data1.Balance - Data) >= 0 && data1.AccountType == "Current Account")
                        data1.Balance = data1.Balance - Data;
                    else if ((data1.Balance - Data) >= -10000 && data1.AccountType == "DMAT Account")
                        data1.Balance = data1.Balance - Data;
                    else
                    {
                        data1.Balance = data1.Balance;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Sorry, we are not able to process your Transaction");
                        Console.WriteLine("--------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    model.SaveChanges();
                }
                
                result = data1.Balance;
            }
            return result;
            }
            public static int AccountDetails(Login login,int Data,int option,string types)                     //ADO.Net Function
        {
            SqlConnection Connection = new SqlConnection("Data Source=TAVDESK087;Initial Catalog=DBBankingSystem;Integrated Security=True");
            int result = 0;
            if (option == 3)
            {
                int balance=Balance(login);
                if ((balance + Data) <= 8500)
                {
                    result = Data + balance;
                    Connection.Open();
                    string Com = "update CustomerDetails set Balance= '" + result + "' where Name=@AName";
                    SqlCommand Command = new SqlCommand(Com, Connection);
                    Command.Parameters.AddWithValue("@AName", login.Name);
                    Command.ExecuteNonQuery();
                    Connection.Close();
                }
            }
            if (option == 4)
            {

                int balance = Balance(login);
                if ((balance - Data) > 1000 && types == "Saving Account")
                    result = Data - balance;
                else if ((balance - Data) >= 0 && types == "Current Account")
                    result = Data - balance;
                else if ((balance - Data) >= -10000 && types == "DMAT Account")
                    result = Data - balance;
                else
                {
                    result = Data;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("Sorry, we are not able to process your Transaction");
                    Console.WriteLine("--------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                }
               
                Connection.Open();
                string Com = "update CustomerDetails set Balance= '" +result+ "' where Name=@AName";
                SqlCommand Command = new SqlCommand(Com, Connection);
                Command.Parameters.AddWithValue("@AName", login.Name);
                Command.ExecuteNonQuery();
                Connection.Close();
              
            }
            return result;
        }
        public static int CreateNewAccount(Customer user)                          //ADO.Net Function
        {
            int flag = 0;
            SqlConnection connection = new SqlConnection("Data Source=TAVDESK087;Initial Catalog=DBBankingSystem;Integrated Security=True");
            if (flag == 0)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddCustomers", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@AccountType", user.AccountType);
                command.Parameters.AddWithValue("@Balance", user.Deposit);
                command.Parameters.AddWithValue("@Password", user.password);
                int result = command.ExecuteNonQuery();

                connection.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Data Successfully added");
                Console.ForegroundColor = ConsoleColor.White;
                flag = 1;
            }
            if (flag == 1)
                return 1;
            else
                return 0;
        }
        public static int CreateNewAccount2(Customer user)                   //entity framework function
        {
            int flag = 0;
            using (DBBankingSystemEntities model = new DBBankingSystemEntities())
            {
                CustomerDetail data1 = model.CustomerDetails.FirstOrDefault(r => r.Name == user.Name);
               if (data1.Name != user.Name)
                {
                    CustomerDetail data = new CustomerDetail()
                    {
                        Name = user.Name,
                        AccountType = user.AccountType,
                        Balance = user.Deposit,
                        Password = user.password
                    };
                    model.CustomerDetails.Add(data1);
                    model.SaveChanges();
                    Console.WriteLine("Successful");
                    flag = 1;
                }
            }
                if (flag == 1)
                    return 1;
                else
                {
                    
                    return 0;
                }
            
        }
    }
}
