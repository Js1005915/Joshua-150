using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSchumann
{
    internal class FullTimeEmployee : Employee
    {
        public float AnnualBonus { get; set; }
        public FullTimeEmployee(int id, string name, string department, float basesalary, float annualbonus ) : base(id, name, department, basesalary)
        {
            AnnualBonus = annualbonus;
        }
        public override void CalculatePay()
        {
            float pay = BaseSalary + AnnualBonus;
            Console.WriteLine($"The salary with bonus is a total of ${pay}.");
        }
    }
}
