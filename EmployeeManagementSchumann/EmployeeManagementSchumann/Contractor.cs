using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSchumann
{
    internal class Contractor : Employee
    {
        public DateTime ContractExpiryDate { get; set; }
        public Contractor(int id, string name, string department, float basesalary, DateTime contractexpirydate) : base(id, name, department, basesalary)
        {
            ContractExpiryDate = contractexpirydate;
        }
        public override void CalculatePay()
        {
            Console.WriteLine($"The contract pay is {BaseSalary}");
        }
    }
}
