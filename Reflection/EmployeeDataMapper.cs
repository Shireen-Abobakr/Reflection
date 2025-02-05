using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class EmployeeDataMapper : IDataMapper<Employee>
    {
        public Employee Map(Dictionary<string, string> data)
        {
            return new Employee
            {
                Id = int.Parse(data["Id"]),
                Name = data["Name"],
                Department = data["Department"],
                Salary = decimal.Parse(data["Salary"])
            };
        }
    }
}
