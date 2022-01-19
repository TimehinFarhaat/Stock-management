using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace StockManagement
{
    class Manager : Customer
    {
        public string Email { get; set; }
        public static List<Manager> Managers   = new List<Manager>();
        public static int    NumberofRegisterdManager = 0;
        public string Id { get; set; }
        public DateTime RegistrationDate { get; set; }


        public Manager(string firstName, string surName, string otherName, string email) : base(
            firstName,
            surName,
            otherName)


        {
            Email = email;
            RegistrationDate = DateTime.Now;
            Id = GenerateId();
            NumberofRegisterdManager++;
        }


        public Manager()
        { }


       


        private static string GenerateId()
        {
            Random rand = new Random();
            int id = rand.Next(1, 100);
            string c = id.ToString();
            return c;
        }

        private static string AddManager(Manager manager)
        {
            Managers.Add(manager);
            return manager.Id;
        }





        public static void RegisterManager()
        {
            Console.Write("Enter your First Name :");
            string firstname = Console.ReadLine();
            Console.Write("Enter your SurName: ");
            string surnname = Console.ReadLine();
            Console.Write("Enter your other name: ");
            string othername = Console.ReadLine();
            Console.Write("Enter your gender: ");
            string gender = Console.ReadLine().ToLower();
            Console.Write("Enter your email ");
            string email = Console.ReadLine();
            Manager manage = new Manager(firstname, surnname, othername, email);
           string id = AddManager(manage);
            if (gender == "male")
            {
                Console.WriteLine($"Mr {surnname} {firstname} {othername} you are welcome ,your identification number is {id} ");
            }
            else if (gender == "female")
            {

                Console.WriteLine($"Mrs{surnname} {firstname} {othername} you are welcome ,your identification number is {id} ");

            }
        }


        public static Manager GetManager(string id)
        {
            foreach (var person in Managers)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }

            return null;
        }




        public static void ManagerList()
        {
            for (int i = 0; i < NumberofRegisterdManager; i++)
            {
                Console.WriteLine(
                    $"{Managers[i].SurnName}     {Managers[i].FirstName}      {Managers[i].OtherName}     {Managers[i].Email}      {Managers[i].Id}     {Managers[i].RegistrationDate}");
            }

        }
    }
}
