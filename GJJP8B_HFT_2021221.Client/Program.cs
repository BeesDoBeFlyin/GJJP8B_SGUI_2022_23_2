using GJJP8B_HFT_2021221.Models;
using System;
using ConsoleTools;
using System.Collections.Generic;

namespace GJJP8B_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService server = new RestService("http://localhost:37371");

            var milkMenu = new ConsoleMenu()
                .Add("Create new Milk", () => AddNewMilk(server))
                .Add("List one Milk", () => ReturnOneMilk(server))
                .Add("List all the milks there is", () => ReturnMilks(server))
                .Add("Delete a Milk from existance", () => DeleteMilk(server))
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "#>";
                    config.SelectedItemBackgroundColor = ConsoleColor.Cyan;
                });

            var cheeseMenu = new ConsoleMenu()
                .Add("Create new Cheese", () => AddNewCheese(server))
                .Add("List one Cheese", () => ReturnOneCheese(server))
                .Add("List all the cheeses there is", () => ReturnCheeses(server))
                .Add("Delete a Cheese from existance", () => DeleteCheese(server))
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "#>";
                    config.SelectedItemBackgroundColor = ConsoleColor.Cyan;
                });

            var buyerMenu = new ConsoleMenu()
                .Add("Create new Buyer", () => AddNewBuyer(server))
                .Add("List one Buyer", () => ReturnOneBuyer(server))
                .Add("List all the buyers there is", () => ReturnBuyers(server))
                .Add("Delete a Buyer from existance", () => DeleteBuyer(server))
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "#>";
                    config.SelectedItemBackgroundColor = ConsoleColor.Cyan;
                });
        }
        #region Milks
        public static void AddNewMilk(RestService server)
        {
            try
            {
                Console.WriteLine("Creating a new Milk!");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                float price = float.Parse(Console.ReadLine());
                server.Post(new Milk { Name = name, Price = price, Cheeses = new List<Cheese>() }, "milk");
                Console.WriteLine("Milk has been created. Don't ask how.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ReturnMilks(RestService server)
        {
            try
            {
                Console.WriteLine("Listing all the milks there is.");
                var milks = server.Get<Milk>("Milk");
                milks.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine($"\n Press ENTER to continue!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ReturnOneMilk(RestService server)
        {
            try
            {
                Console.Write("Milk id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine($"{server.Get<Milk>(id, "milk").ToString()}");
                Console.WriteLine($"\n Press ENTER to continue!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void DeleteMilk(RestService server)
        {
            try
            {
                Console.Write("Milk id: ");
                int id = int.Parse(Console.ReadLine());
                server.Delete(id, "milk");
                Console.WriteLine($"Milk with the id {id} deleted! Sad day indeed... Press ENTER to continue.");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
        #region Cheeses
        public static void AddNewCheese(RestService server)
        {
            try
            {
                Console.WriteLine("Creating a new Cheese!");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                float price = float.Parse(Console.ReadLine());
                Console.Write("Made of (milk id): ");
                int milkId = int.Parse(Console.ReadLine());
                server.Post(new Cheese { Name = name, Price = price, MilkId = milkId, Buyers = new List<Buyer>() }, "cheese");
                Console.WriteLine("Cheese has been created. Don't drop it!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ReturnCheeses(RestService server)
        {
            try
            {
                Console.WriteLine("Listing all the cheeses there is.");
                var cheeses = server.Get<Cheese>("Cheese");
                cheeses.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine($"\n Press ENTER to continue!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ReturnOneCheese(RestService server)
        {
            try
            {
                Console.Write("Cheese id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine($"{server.Get<Cheese>(id, "cheese").ToString()}");
                Console.WriteLine($"\n Press ENTER to continue!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void DeleteCheese(RestService server)
        {
            try
            {
                Console.Write("Cheese id: ");
                int id = int.Parse(Console.ReadLine());
                server.Delete(id, "cheese");
                Console.WriteLine($"Cheese with the id {id} deleted! They will be missed... Press ENTER to continue.");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
        #region Buyers
        public static void AddNewBuyer(RestService server)
        {
            try
            {
                Console.WriteLine("Creating a new Buyer (oh no, 18+)!");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Money: ");
                float money = float.Parse(Console.ReadLine());
                Console.Write("Preferred cheese (cheese id): ");
                int cheeseId = int.Parse(Console.ReadLine());
                server.Post(new Buyer { Name = name, Money = money, CheeseId = cheeseId }, "buyer");
                Console.WriteLine("Buyer has been created. Parent responsibely!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ReturnBuyers(RestService server)
        {
            try
            {
                Console.WriteLine("Listing all the buyers there is.");
                var buyers = server.Get<Buyer>("Buyer");
                buyers.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine($"\n Press ENTER to continue!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ReturnOneBuyer(RestService server)
        {
            try
            {
                Console.Write("Buyer id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine($"{server.Get<Buyer>(id, "buyer").ToString()}");
                Console.WriteLine($"\n Press ENTER to continue!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void DeleteBuyer(RestService server)
        {
            try
            {
                Console.Write("Buyer id: ");
                int id = int.Parse(Console.ReadLine());
                server.Delete(id, "buyer");
                Console.WriteLine($"Buyer with the id {id} deleted! Bring pogácsa to their funeral... Press ENTER to continue.");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
    }
}

