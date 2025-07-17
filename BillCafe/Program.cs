using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace BillCafe
{
    internal class Program
    {
        private static string[] products = new string[0];
        private static double[] prices = new double[0];
        private static double tipAmount = 0;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
            MenuOpen();
        }
        static void MenuOpen()
        {
            Console.WriteLine("#------------------------#");
            Console.WriteLine("| #--------------------# |");
            Console.WriteLine("| |                    | |");
            Console.WriteLine("| |   Chainmail Cafe   | |");
            Console.WriteLine("| | ------------------ | |");
            Console.WriteLine("| | 1. Add Item        | |");
            Console.WriteLine("| | 2. Remove Item     | |");
            Console.WriteLine("| | 3. Add Tip         | |");
            Console.WriteLine("| | 4. Display Bill    | |");
            Console.WriteLine("| | 5. Clear All       | |");
            Console.WriteLine("| | 6. Save to file    | |");
            Console.WriteLine("| | 7. Load from file  | |");
            Console.WriteLine("| | 0. Exit            | |");
            Console.WriteLine("| |                    | |");
            Console.WriteLine("| #--------------------# |");
            Console.WriteLine("#------------------------#");
            MenuChoice();
        }
        private static void MenuChoice()
        {
            Console.WriteLine("Enter your choice");
            int choice;
            do
            {
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                AddProduct();
                                break;
                            }
                        case 2:
                            {
                                DeleteProduct();
                                break;
                            }
                        case 3:
                            {
                                TipMethod();
                                break;
                            }
                        case 4:
                            {
                                DisplayProducts();
                                break;
                            }
                        case 5:
                            {
                                ClearAll();
                                break;
                            }
                        case 6:
                            {
                                SaveToFile();
                                break;
                            }
                        case 7:
                            {
                                LoadFromFile();
                                break;
                            }
                        case 0:
                            {
                                Console.WriteLine("Bye! Bye!");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid Input");
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error has occured" + ex.Message);
                }
            } while (true);
        }
            private static void AddProduct()
        {
            if (products.Length >= 5)
            {
                Console.WriteLine("Items quantity limit is 5!");
                return;
            }
            string productName;
            double price;
            do
            {
                Console.WriteLine("Enter product name from 3 to 20 symbols");
                productName = Console.ReadLine();
                if (productName.Length < 3 || productName.Length > 20 || string.IsNullOrWhiteSpace(productName))
                {
                    Console.WriteLine("Description must be in range of 3 to 20 symbols.");
                }

            } while (productName.Length < 3 || productName.Length > 20 || string.IsNullOrWhiteSpace(productName));

            do
            {
                Console.WriteLine("Enter product price");
                price = Convert.ToDouble(Console.ReadLine());
            } while (price < 0);
            try
            {

                int productsQuantity = products.Length;
                Array.Resize(ref prices, productsQuantity + 1);
                Array.Resize(ref products, productsQuantity + 1);
                products[productsQuantity] = productName;
                prices[productsQuantity] = price;
                Console.WriteLine("Adding item was successfull.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding the product" + ex.Message);
            }

        }
    }
}
