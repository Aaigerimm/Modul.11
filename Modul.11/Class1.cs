using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul._11
{
    internal class Class1
    {
        static void Main()
        {
            Console.Write("Enter the number of employees: ");
            int size = int.Parse(Console.ReadLine());

            EmployeeManager employeeManager = new EmployeeManager(size);
            employeeManager.FillEmployees();

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Display All Employees");
            Console.WriteLine("2. Display Employees by Position");
            Console.WriteLine("3. Display Managers Above Clerk Average Salary");
            Console.WriteLine("4. Display Employees Hired After a Certain Date");
            Console.WriteLine("5. Display Employees by Gender");
            Console.Write("Enter your choice (1-5): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    employeeManager.DisplayAllEmployees();
                    break;
                case 2:
                    Console.Write("Enter Position (Manager, Clerk, Other): ");
                    Enum.TryParse(Console.ReadLine(), out Positions position);
                    employeeManager.DisplayEmployeesByPosition(position);
                    break;
                case 3:
                    employeeManager.DisplayManagersAboveClerkAverageSalary();
                    break;
                case 4:
                    Console.Write("Enter Date (YYYY.MM.DD): ");
                    int[] date = Console.ReadLine().Split('.').Select(int.Parse).ToArray();
                    employeeManager.DisplayEmployeesHiredAfterDate(date);
                    break;
                case 5:
                    Console.Write("Enter Gender (Male, Female, leave blank for all): ");
                    Enum.TryParse(Console.ReadLine(), out Gender gender);
                    employeeManager.DisplayEmployeesByGender(gender);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

    }
}
