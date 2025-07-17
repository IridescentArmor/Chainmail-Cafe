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
            static void DeleteProduct()
            {
                if (products.Length == 0)
                {
                    Console.WriteLine("There are no items to delete.");
                    return;
                }

                if (tipAmount != 0)
                {
                    Console.WriteLine("Tip will be reset to 0.");
                }

                Console.WriteLine("List of items:");
                Console.WriteLine(new string('-', 40));

                for (int i = 0; i < products.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {products[i]} - {prices[i]:F2}$");
                }

                Console.WriteLine("\n0. Cancel");
                Console.WriteLine(new string('-', 40));

                Console.Write("Enter the number of the item to delete: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice) || choice < 0 || choice > products.Length)
                {
                    Console.WriteLine("Invalid input. Operation cancelled.");
                    return;
                }

                if (choice == 0)
                {
                    Console.WriteLine("Deletion cancelled.");
                    return;
                }

                string result = RemoveProduct(choice - 1);
                Console.WriteLine(result);

                if (products.Length > 0)
                {
                    TipMethod();
                }

            }
            static string RemoveProduct(int index)
            {
                if (index < 0 || index >= products.Length)
                {
                    return "Invalid selection.";
                }

                string deletedName = products[index];
                double deletedCost = prices[index];

                for (int i = index; i < products.Length - 1; i++)
                {
                    products[i] = products[i + 1];
                    prices[i] = prices[i + 1];
                }

                Array.Resize(ref products, products.Length - 1);
                Array.Resize(ref prices, prices.Length - 1);




                return $"Deleted '{deletedName}' with price {deletedCost:F2}$.";
            }
        }
    }
}
