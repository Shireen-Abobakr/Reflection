using System;
using System.Collections.Generic;
using Reflection;

public class EmployeeService
{
    private readonly IExcelReader _excelReader;
    private readonly IDataMapper<Employee> _dataMapper;

    public EmployeeService(IExcelReader excelReader, IDataMapper<Employee> dataMapper)
    {
        _excelReader = excelReader;
        _dataMapper = dataMapper;
    }

    public List<Employee> GetEmployeesFromExcel(string filePath)
    {
        var excelData = _excelReader.ReadExcel(filePath);
        var employees = new List<Employee>();

        foreach (var data in excelData)
        {
            var employee = _dataMapper.Map(data);
            employees.Add(employee);
        }

        return employees;
    }
}