using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingModule
{
    class Expense
    {
        public int Id;
        public string Category;
        public double Amount;
        public string PaymentMode;
        public string ByWhom;
        public DateTime ExpenseDate;
    }

    class Program
    {
        static List<Expense> expenses = new List<Expense>();

        static void AddExpense()
        {
            try
            {
                Expense exp = new Expense();

                Console.Write("Enter Expense ID: ");
                exp.Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Person Name: ");
                exp.ByWhom = Console.ReadLine();

                Console.Write("Enter Expense Category: ");
                exp.Category = Console.ReadLine();

                Console.Write("Enter Expense Amount: ");
                exp.Amount = Convert.ToDouble(Console.ReadLine());

                if (exp.Amount <= 0)
                    throw new Exception("Expense amount must be greater than 0.");

                Console.Write("Enter Expense Date (YYYY-MM-DD): ");
                exp.ExpenseDate = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter Payment Mode (Cash/UPI/Card): ");
                exp.PaymentMode = Console.ReadLine();

                if (exp.PaymentMode.ToLower() != "cash" &&
                    exp.PaymentMode.ToLower() != "upi" &&
                    exp.PaymentMode.ToLower() != "card")
                {
                    throw new Exception("Invalid Payment Mode.");
                }

                expenses.Add(exp);

                Console.WriteLine("\nExpense Added Successfully!\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nInvalid Input!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError: " + ex.Message + "\n");
            }
        }

        static void ViewExpenses()
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("\nNo Expenses Found!\n");
                return;
            }

            Console.WriteLine("\n-------------------------------------------------------------------------------------------");
            Console.WriteLine("ID\tPerson\t\tCategory\tAmount\t\tDate\t\tPayment");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            foreach (Expense exp in expenses)
            {
                Console.WriteLine($"{exp.Id}\t{exp.ByWhom}\t{exp.Category}\t\t{exp.Amount}\t\t{exp.ExpenseDate:yyyy-MM-dd}\t{exp.PaymentMode}");
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------\n");
        }

        static void ViewTotalExpense()
        {
            double total = 0;

            foreach (Expense exp in expenses)
            {
                total += exp.Amount;
            }

            Console.WriteLine("\nTotal Expense = " + total + "\n");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("==================================");
                Console.WriteLine("   EXPENSE TRACKING MODULE");
                Console.WriteLine("==================================");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View All Expenses");
                Console.WriteLine("3. View Total Expense");
                Console.WriteLine("4. Exit");
                Console.Write("Enter Choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddExpense();
                            break;

                        case 2:
                            ViewExpenses();
                            break;

                        case 3:
                            ViewTotalExpense();
                            break;

                        case 4:
                            Console.WriteLine("Thank You!");
                            return;

                        default:
                            Console.WriteLine("Invalid Choice!\n");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a valid number.\n");
                }
            }
        }
    }
}