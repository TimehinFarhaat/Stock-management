using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace StockManagement
{
    public  class Stock
    {
        public  string NameOfGood { get; set; }
        public  int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public  string Id { get; set; }
        public  DateTime RegisteredDate { get; set; }

        public static List<Stock> Goods=new List<Stock>();

        public static int NumberOfGoods = 0;
        public Stock (string nameOfGood, int unitprice,int quantity)
        {
            NameOfGood = nameOfGood;
            UnitPrice = unitprice;
            Quantity = quantity;
            Id = Generateid();
            RegisteredDate=DateTime.Now;
            NumberOfGoods++;


        }

        public Stock()
        {

        }
        private static  string AddStock(Stock stock)
        {
            Goods.Add(stock);
            return stock.Id;
        }


        public static void CreateStock()
        {
            Console.WriteLine("Enter the name of Stock: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter the unit price: ");
            int unitPrice = int.Parse(Console.ReadLine());
            Stock stock=new Stock(name,unitPrice,quantity);
            string id = AddStock(stock);
            Console.WriteLine($" You have successfully added the stock .The good identification number is {id}");

        }


        private static string Generateid()
        {

            Random rand = new Random();
            int id = rand.Next(1, 100);
            string c = id.ToString();
            return c;
        }
        public static void PrintGoods()
        {
            for (int i = 0; i < NumberOfGoods; i++)
            {
                Console.WriteLine($"{Goods[i].NameOfGood}                     {Goods[i].UnitPrice}");
            }
        }


        public static void Create()
        {
            Console.WriteLine("Enter your identification number: ");
            string id = Console.ReadLine();
            for (int i = 0; i < Manager.NumberofRegistered; i++)
            {
                if (id == Manager.Managers[i].Id)
                {
                    CreateStock();
                    break;
                }
            }
        }


        public static void Update(string ManagerId, int Quantity, string StockId)
        {
            if (ManagerId != null)
            {
                
                
                    Console.Write("Are you Selling or buying \n" +
                                  "1.Buying\n" +
                                  "2.Seling\n" +
                                  "Enter your choice: ");

                    int choice = int.Parse(Console.ReadLine());
                    if (choice==1)
                    {
                        foreach (var good in Goods)
                        {
                            if (StockId == good.Id)
                            {
                                good.Quantity += Quantity;
                            }
                        }
                    }
                     else  if (choice == 2)
                    {
                        foreach (var good in Goods)
                        {
                            if (StockId == good.Id)
                            {
                                good.Quantity -= Quantity;
                            }
                        }
                    }

            }
        }

        public static Stock GetStock (string id)
        {
            foreach (var stock in Goods)
            {
                if (stock.Id == id)
                {
                    return stock;
                }
            }

            return null;
        }
    }

    
}
