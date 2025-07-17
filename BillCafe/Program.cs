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
        private static void ClearAll()
        {
            if (products.Length == 0)
            {
                Console.WriteLine("Nothing to clear.");
            }
            else
            {
                products = [];
                prices = [];
                tipAmount = 0;
                Console.WriteLine("Everything has been cleared");
            }
        }
        private static void TipMethod()
        {
            if (products.Length == 0)
            {
                Console.WriteLine("Bill is empty!");
                return;
            }
            Console.WriteLine($"Net Total: {GetPrice():C}");
            Console.WriteLine("1 - Percent");
            Console.WriteLine("2 - Amount");
            Console.WriteLine("3 - No Tip");
            Console.WriteLine("0 - Return to main menu");
            do
            {
                Console.WriteLine("Enter your choice");
                int tipMethod = Convert.ToInt32(Console.ReadLine());
                switch (tipMethod) {
                    case 0:
                        {
                            Console.WriteLine("Going back.");
                            return;
                        }
                    case 1:
                        { 
                            TipAdding(tipMethod); 
                            break;
                        }
                    case 2:
                        {
                            TipAdding(tipMethod);
                            break;
                        }
                    case 3:
                        {
                            TipAdding(tipMethod);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("An error has occured.");
                            break;
                        }
                }
            }while (true);
        }
        private static void TipAdding(int tipMethod)
        {
            switch (tipMethod)
            {
                case 1:
                    {
                        Console.WriteLine("Enter percent or choose from pattern ");
                        Console.WriteLine("1 - 10%");
                        Console.WriteLine("2 - 25%");
                        Console.WriteLine("3 - 30%");
                        Console.WriteLine("4 - Personal Input");
                        Console.WriteLine("Enter your choice");
                        int percentType = Convert.ToInt32(Console.ReadLine());
                        int percent = 0;
                        switch (percentType)
                        {
                            case 1:
                                {
                                    percent = 10;
                                    break;
                                }
                            case 2:
                                {
                                    percent = 25;
                                    break;
                                }
                            case 3:
                                {
                                    percent = 30;
                                    break;
                                }
                            case 4:
                                {
                                    do
                                    {
                                        Console.WriteLine("Enter tip amount: ");
                                        percent = Convert.ToInt32(Console.ReadLine());
                                    } while (percent < 0);
                                    break;
                                }
                            default:
                                {
                                    break;
                                }

                        }
                        tipAmount = GetPrice() * (percent / 100.0);
                        Console.WriteLine("Tip with amount " + tipAmount + " added it equals " + percent + "%");
                        break;
                    }
                case 2:
                    {
                        do
                        {

                            Console.WriteLine("Enter tip amount ");
                            tipAmount = Convert.ToDouble(Console.ReadLine());

                        } while (tipAmount < 0);
                        Console.WriteLine("Tip added " + tipAmount);
                        break;
                    }
                case 3:
                    {
                        tipAmount = 0;
                        Console.WriteLine("Tip equals 0.");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("An error has occured ");
                        break;
                    }



            }
        }
            private static double GetPrice()
        {
            if (products.Length == 0)
            {
                Console.WriteLine("Bill is empty.");
                return -1;
            }
            double totalPrice = 0;
            foreach (double price in prices)
            {
                totalPrice += price;
            }
            return totalPrice;
        }
        private static double GST()
        {
            return GetPrice() * 0.05;
        }
        private static double TotalPrice()
        {
            return GetPrice() + GST() + tipAmount;
        }
        private static void DisplayProducts()
        {
            if (products.Length == 0)
            {
                Console.WriteLine("The bill is empty!");
                return;
            }

            Console.WriteLine("{0,-40} {1,10}", "Description", "Price");
            Console.WriteLine(new string('-', 52));

            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine("{0,-40} {1,10:C}", products[i], prices[i]);
            }

            Console.WriteLine(new string('-', 52));

            Console.WriteLine("{0,-40} {1,10:C}", "NetTotal:", GetPrice());
            Console.WriteLine("{0,-40} {1,10:C}", "Tip Amount:", tipAmount);
            Console.WriteLine("{0,-40} {1,10:C}", "GST Amount:", GST());
            Console.WriteLine("{0,-40} {1,10:C}", "Total Amount:", TotalPrice());
        }
        private static void SaveToFile()
        {
            if (products.Length == 0)
            {
                Console.WriteLine("There is nothing to save.");
                return;
            }
            Console.WriteLine("Enter file to save");
            string filePath = Console.ReadLine();
            if (filePath.Length > 10 || filePath.Length < 1)
            {
                return;
            }
            filePath = filePath + ".txt";

            if (File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' exists. Overwrite? 1 = yes | 2 = no.");
                int overwrite = Convert.ToInt32(Console.ReadLine());
                if (overwrite == 2)
                {
                    Console.WriteLine("Saving cancelled.");
                    return;
                }
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    for (int i = 0; i < products.Length; i++)
                    {
                        writer.WriteLine(products[i] + " « " + prices[i]);
                    }
                    writer.WriteLine("Tip = " + tipAmount);
                }
                Console.WriteLine($"Data saved successfully to '{filePath}'.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error has occured " + ex.Message);
            }
        }
        private static void LoadFromFile()
        {
            Console.WriteLine("Enter file name to load:");
            string filePath = Console.ReadLine();
            filePath = filePath + ".txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' does not exist.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length == 0)
                {
                    Console.WriteLine($"File '{filePath}' is empty.");
                    return;
                }

                products = new string[0];
                prices = new double[0];

                foreach (string line in lines)
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length == 2)
                    {
                        Array.Resize(ref products, products.Length + 1);
                        Array.Resize(ref prices, prices.Length + 1);
                        products[products.Length - 1] = parts[0];
                        prices[prices.Length - 1] = double.Parse(parts[1]);
                    }
                }

                Console.WriteLine($"Data loaded successfully from '{filePath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading file: " + ex.Message);
            }
        }



    }
}
            
    
    

