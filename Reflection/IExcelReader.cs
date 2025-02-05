using System;


namespace Reflection
{
    public interface IExcelReader
    {
        List<Dictionary<string, string>> ReadExcel(string filePath);
    }

    public interface IDataMapper<T>
    {
        T Map(Dictionary<string, string> data);
    }
}
