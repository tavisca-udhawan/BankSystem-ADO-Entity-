using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entity;
namespace Business_Logic
{
    public class Business
    {
      
        public static string Interest(Login login,int choice)
        {
            string AccountType="";
            if (choice == 1)
            {
                AccountType = Connections.Interest(login);
               
            }
            if (choice == 2)
            {
                AccountType = Connections.Interest1(login);
              
            }
            return AccountType;
        }
        public static int CalcInterest(Login login,int choice,int value)         //calculation for interest
        {
            int result = Connections.Calculted_Interest(login,choice,value);
            return result;
        }
            public static int Balance(Login login,int choice)
        {
            int balance = 0;
            if(choice==1)
            balance=Connections.Balance(login);
            else
                balance = Connections.Balance1(login);
            return balance;
        }
            public static int NewAccount(Customer user,int choice)                //for new account
        {
            int res=0;
            if (choice == 1)
            {
               res= Connections.CreateNewAccount(user);
            }
            if (choice == 2)
            {
                res=Connections.CreateNewAccount2(user);
            }
            if (res == 1)
                return 1;
            else
                return 0;
        }
        public static int UserLogin(Login login,int choice)
        {
            int result = 0;
            if(choice==1)
            result= Connections.LoginData(login);
            else if(choice==2)
                result = Connections.LoginData2(login);
            if (result == 1)
                return 1;
            else
                return 0;
        }
            public static int Details(Login login,int data,int choice,int checkValue,string types)
        {
            int result = 0;
            if(choice==1)
            result= Connections.AccountDetails(login,data,checkValue,types);
            if(choice==2)
                result=Connections.AccountDetails1(login, data,checkValue);
            return result;
        }

      

        
    }
}
