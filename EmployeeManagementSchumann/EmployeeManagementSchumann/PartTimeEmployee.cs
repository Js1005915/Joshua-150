using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSchumann
{
    internal class PartTimeEmployee : Employee
    {
        public float HourlyRate { get; set; }
        public int HoursWorked { get; set; }
        public PartTimeEmployee(int id, string name, string department, float basesalary, float hourlyrate, int hoursworked) : base(id, name, department, basesalary)
        {
            HourlyRate = hourlyrate;
            HoursWorked = hoursworked;
        }
        public override void CalculatePay()
        {
            float pay = HourlyRate * HoursWorked;
            Console.WriteLine($"The pay is ${pay}, with {HoursWorked} hours at {HourlyRate} an hour.");
        }
    }
}
