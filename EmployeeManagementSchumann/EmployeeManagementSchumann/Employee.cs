using EmployeeManagementSchumann;

public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public float BaseSalary { get; set; }

    public Employee(int id, string name, string department, float basesalary)
    {
        ID = id;
        Name = name;
        Department = department;
        BaseSalary = basesalary;
    }

    public virtual void CalculatePay()
    {
        Console.WriteLine(BaseSalary);
    }
    public void DisplayEmployeeDetails()
    {
        Console.WriteLine(ToString());
    }
    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Department: {Department}, Base Salary: {BaseSalary}";
    }
}

class Program()
{
    static void Main()
    {
        FullTimeEmployee John = new FullTimeEmployee(12, "John", "Health", 26000, 2000);
        John.DisplayEmployeeDetails();
        John.CalculatePay();

        PartTimeEmployee Juan = new PartTimeEmployee(27, "Juan", "Medical",0, 12, 80);
        Juan.DisplayEmployeeDetails();
        Juan.CalculatePay();

        Contractor Josh = new Contractor(90, "Josh", "Meth", 120000, new DateTime(2025, 3, 3));
        Josh.DisplayEmployeeDetails();
        Josh.CalculatePay();
    }
}