using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace StockManagement
{
    class Transaction
    {
        public string CustomerId { get; set; }
        public List<Stock> Stocks=new List<Stock>();
        public string Id { get; set; }
        public  int TotalPrice { get; set; }
        public  DateTime TransactionDate { get; set; }
        public static int NumberOfTransaction = 0;
        public string ManagerId { get; set; }
        public static List<Transaction>Transactions=new List<Transaction>();


        public Transaction(string customerId, int totalPrice,string managerid)
        {
            TotalPrice = totalPrice;
            CustomerId = customerId;
            ManagerId = managerid;
             TransactionDate=DateTime.Now;
            Id = GenerateId();
            NumberOfTransaction++;
        }
        private static string GenerateId ()
        {
            Random rand = new Random();
            int id = rand.Next(1, 100);
            string c = id.ToString();
            return c;
        }


        private static string AddTransactions(Transaction transaction)
        {
            Transactions.Add(transaction);
            return transaction.Id;
        }


        public static void GenerateTransactions(Transaction t)
        {
            Console.Write("Input Managers id:  ");
            string idM = Console.ReadLine(); 
             Console.Write("Input Customer's id:  ");
            string id = Console.ReadLine();
            int totalPrice = 0;
            if (Customer.GetCustomer(id) != null)
            {
                Stock.PrintGoods();
                bool buying = true;
                List<Stock> stocks = new List<Stock>();

              

                while (buying)
                {
                    Console.WriteLine("Please input GoodsId");
                    string GoodId = Console.ReadLine();
                    Console.WriteLine("Please input quantity");
                    int quantity = int.Parse(Console.ReadLine());

                    Stock s = Stock.GetStock(GoodId);

                    if (s != null)
                    {
                        Stock.Update(idM, quantity, s.Id);
                        stocks.Add(s);
                        totalPrice += s.UnitPrice * quantity;
                    }

                    Console.WriteLine("Are you still buying, input Yes or No");
                    string answer = Console.ReadLine();
                    if (answer.Equals("No"))
                    {
                        buying = false;
                    }
                    else
                    {
                        Stock.PrintGoods();
                    }

                }

            }
            Transaction transaction=new Transaction(id,totalPrice,idM);
            string Id = AddTransactions(transaction); 
        }


        public static void PrintAllTransactions()
        {
            foreach (var transaction in Transactions)
            {
                Console.Write("Input your id:  ");
                string id = Console.ReadLine();
                if (id==transaction.Id)
                {
                    Customer customer=new Customer();
                    Console.WriteLine($"{transaction.TransactionDate}   {id}   {transaction.Id}   {transaction.Stocks}  {transaction.TotalPrice} ");
                }
            }
        }
        public static void PrintAllCustomerTransactions ()
        {
            foreach (var transaction in Transactions)
            {

                Customer customer=new Customer();
                    Console.WriteLine($"{transaction.TransactionDate}   {customer.Id}   {transaction.Id}   {transaction.Stocks}  {transaction.TotalPrice} ");
                
            }
        }
    }
}
