using System;

public enum Positions
{
    Manager,
    Clerk,
    Other
}

public struct Employee : IEmployeeInfo
{
    public string Name { get; set; }
    public Positions Position { get; set; }
    public int[] HireDate { get; set; }
    public int Salary { get; set; }
    public Gender Gender { get; set; }

    public Employee(string name, Positions position, int[] hireDate, int salary, Gender gender)
    {
        Name = name;
        Position = position;
        HireDate = hireDate;
        Salary = salary;
        Gender = gender;
    }

    public override string ToString()
    {
        return $"{Name}, {Position}, Hired on: {string.Join(".", HireDate)}, Salary: {Salary}, Gender: {Gender}";
    }
}

public interface IEmployeeInfo
{
    string ToString();
}

public enum Gender
{
    Male,
    Female
}
