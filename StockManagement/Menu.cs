using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace StockManagement
{
   class Menu
    {
        public static void MainMenu()
        {

            Console.WriteLine("--------------------WELCOME TO STORE-------------------");
            Console.WriteLine();
            Console.WriteLine("1.Buyer");
            Console.WriteLine("2.Manager");
            Console.Write(" Choose your option: ");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    CustomerMenu();
                    MainMenu();
                    break;
                case 2:
                    ManagerMenu();
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again");
                    MainMenu();
                    break;
            }
            

        }
        


        public static void CustomerMenu()
        {
            Console.WriteLine("1.Register");
            Console.WriteLine("2.Buy goods\n" +
                              "3.View all transactions");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Customer.RegisterCustomer();
                    MainMenu();
                    break;
                case 2:
                    Buy();
                    MainMenu();
                    break;
                case 3:
                    ViewAllTransactions();
                    break;
                case 4:
                    Console.WriteLine("Invalid option");
                    MainMenu();
                    break;
            }
        }


        public static void Buy()
        {
            Stock.PrintGoods();
            Console.WriteLine("Enter the your identification number: ");
            string id = Console.ReadLine();
            int amount = 0;
            for (int i = 0; i < Customer.NumberofRegistered; i++)
            {
                if (id==Customer.people[i].Id)
                {
                    Stock.PrintGoods();
                    Console.WriteLine("Enter what you want to buy: ");
                    string good = Console.ReadLine();
                    foreach (var products in Stock.Goods)
                    {
                        if (products.NameOfGood==good)
                        {
                            Console.WriteLine("What quantity do you want to buy: ");
                            int quantity = int.Parse(Console.ReadLine());
                            if (quantity <= products.Quantity)
                            {
                                amount = quantity * products.UnitPrice;
                                Console.WriteLine($"Your amount is {amount}");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Input a correct Id");
                }
            }
            Console.Write("Enter your payment: ");
            int pay = int.Parse(Console.ReadLine());
            int c = 0;
            if (pay > amount )
            {
                c = pay - amount;
                Console.WriteLine($"Your change is {c}\n" +
                                  $"Thanks for your patronage");
            }
            else if (pay == amount)
            {
                Console.WriteLine("Thanks for your patronage");
            }
            else
            {
                c = amount - pay;
                Console.WriteLine($"Your payment remain {c}\n");
            }
            
            
        }


        public static void ViewAllTransactions()
        {
           Transaction.PrintAllTransactions();
        }



        public static void ManagerMenu()
        {
           Console.WriteLine("1.Stock Menu\n" +
                             "2.Manager Menu\n" +
                             "3.Transaction Menu\n" +
                             "4.Print all customer details");
           Console.Write("Enter the choice: ");
           int choice = int.Parse(Console.ReadLine());
           switch (choice)
           {
                case 1: 
                    Stock.Create();
                    MainMenu();
                    break;
                case 2:
                    ManagarMenu();
                    MainMenu();
                    break;
                case 3:
                    MainMenu();
                    break;
                case 4:
                    CustomerDetails();
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    MainMenu();
                    break;
           }
        }


        public static void StockMenu()
        {
            Console.WriteLine("1.Add stock\n" +
                              "2.Update stock \n" +
                              "3.List all stock");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
        }


        public static void ManagarMenu()
        {
            Console.WriteLine("1.Register Manager\n" +
                              "2.Print all manager details");
            Console.Write("Enter your choice:  ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Manager.RegisterManager();
                    MainMenu();
                    break;
                case 2:
                    Manager.ManagerList();
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    MainMenu();
                    break;
            }
        }


        public static void TransactionMenu()
        {
            Transaction.PrintAllCustomerTransactions();
        }


        public static void CustomerDetails()
        {
            Customer.PrintCustomerList();
        }
    }

  


        
    
}
