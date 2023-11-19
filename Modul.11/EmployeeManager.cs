using System;
using System.Linq;

public class EmployeeManager
{
    private Employee[] employees;

    public EmployeeManager(int size)
    {
        employees = new Employee[size];
    }

    public void FillEmployees()
    {
        for (int i = 0; i < employees.Length; i++)
        {
            Console.WriteLine($"Enter details for employee {i + 1}:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Position (Manager, Clerk, Other): ");
            Enum.TryParse(Console.ReadLine(), out Positions position);

            Console.Write("Hire Date (YYYY.MM.DD): ");
            int[] hireDate = Console.ReadLine().Split('.').Select(int.Parse).ToArray();

            Console.Write("Salary: ");
            int salary = int.Parse(Console.ReadLine());

            Console.Write("Gender (Male, Female): ");
            Enum.TryParse(Console.ReadLine(), out Gender gender);

            employees[i] = new Employee(name, position, hireDate, salary, gender);
        }
    }

    public void DisplayAllEmployees()
    {
        Console.WriteLine("All Employees:");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee.ToString());
        }
    }

    public void DisplayEmployeesByPosition(Positions position)
    {
        Console.WriteLine($"Employees with Position {position}:");
        foreach (var employee in employees.Where(e => e.Position == position))
        {
            Console.WriteLine(employee.ToString());
        }
    }

    public void DisplayManagersAboveClerkAverageSalary()
    {
        var clerkAverageSalary = employees.Where(e => e.Position == Positions.Clerk).Average(e => e.Salary);
        var managers = employees.Where(e => e.Position == Positions.Manager && e.Salary > clerkAverageSalary)
                                .OrderBy(e => e.Name);

        Console.WriteLine("Managers with Salary above Clerk Average Salary:");
        foreach (var manager in managers)
        {
            Console.WriteLine(manager.ToString());
        }
    }

    public void DisplayEmployeesHiredAfterDate(int[] date)
    {
        var filteredEmployees = employees.Where(e => CompareDates(e.HireDate, date) > 0)
                                         .OrderBy(e => e.Name);

        Console.WriteLine($"Employees Hired After {string.Join(".", date)}:");
        foreach (var employee in filteredEmployees)
        {
            Console.WriteLine(employee.ToString());
        }
    }

    public void DisplayEmployeesByGender(Gender? gender)
    {
        var filteredEmployees = gender.HasValue ? employees.Where(e => e.Gender == gender.Value) : employees;

        Console.WriteLine($"Employees{(gender.HasValue ? $" ({gender.Value})" : "")}:");
        foreach (var employee in filteredEmployees)
        {
            Console.WriteLine(employee.ToString());
        }
    }

    private static int CompareDates(int[] date1, int[] date2)
    {
        for (int i = 0; i < Math.Min(date1.Length, date2.Length); i++)
        {
            if (date1[i] != date2[i])
            {
                return date1[i] - date2[i];
            }
        }

        return 0;
    }
}

