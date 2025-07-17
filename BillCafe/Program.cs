using System.Globalization;
using System.Text;

namespace BillCafe
{
    internal class Program
    {
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
    }
}
