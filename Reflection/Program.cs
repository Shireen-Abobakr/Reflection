using Reflection;

class Program
{
    static void Main()
    {
        IExcelReader excelReader = new ExcelReader();
        IDataMapper<Employee> employeeDataMapper = new EmployeeDataMapper();
        var employeeService = new EmployeeService(excelReader, employeeDataMapper);

        string filePath = "Employee.xlsx"; // Your file path here

        var employees = employeeService.GetEmployeesFromExcel(filePath);

        // Print the employees data
        foreach (var employee in employees)
        {
            Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name}, Department: {employee.Department}, Salary: {employee.Salary}");
        }
    }
}