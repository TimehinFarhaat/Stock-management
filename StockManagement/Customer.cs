using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class Customer
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SurnName { get; set; }
        public string OtherName { get; set; }
        public DateTime RegistrationDate { get; set; }

        public static List<Customer> people   = new List<Customer>();
        public static int  NumberofRegistered = 0;


        public Customer()
        { }


        public Customer(string firstName, string surnName, string otherName)
        {
            FirstName = firstName;
            SurnName = surnName;
            OtherName = otherName;
            Id = GenerateId();
            RegistrationDate = DateTime.Now;
            NumberofRegistered++;
        }


        


        private static string AddCustomer(Customer customer)
        {
            people.Add(customer);
            return customer.Id;
        }


        private string GenerateId()
        {
            Random rand = new Random();
            int id = rand.Next(1, 100);
            string c = id.ToString();
            return c;
        }


        public static void RegisterCustomer()
        {
           
            Console.Write("Enter your First Name: ");
            string firstname = Console.ReadLine();
            Console.Write("Enter your Surn Name: ");
            string surnname = Console.ReadLine();
            Console.Write("Enter your Other Name: ");
            string othername = Console.ReadLine();
            Console.Write("Enter your gender: ");
            string gender = Console.ReadLine().ToLower();
            Customer customer = new Customer(firstname, surnname, othername);
            string id = AddCustomer(customer);
            NumberofRegistered++;
            if (gender=="male")
            {
                Console.WriteLine($"Mr {surnname} {firstname} {othername} you are welcome ,your identification number is {id} ");
            }
            else if (gender == "female")
            {

                Console.WriteLine($"Mrs{surnname} {firstname} {othername} you are welcome ,your identification number is {id} ");

            }
        }


        public static void PrintCustomerList()
        {


            for (var i = 0; i < NumberofRegistered; i++)
            {
                Console.WriteLine(
                    $"{i + 1}.  {people[i].SurnName}  {people[i].FirstName} {people[i].OtherName}---------{people[i].RegistrationDate}------{people[i].Id}");
            }
        }


        public static Customer GetCustomer(string id)
        {
            foreach (var customer in people)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }

            return null;
        }

    }



}
