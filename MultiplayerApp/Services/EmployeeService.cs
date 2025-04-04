using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class EmployeeService
{
    private const string FilePath = "employees.json";

    public static void SaveEmployees(List<Employee> employees)
    {
        var json = JsonConvert.SerializeObject(employees, Formatting.Indented);
        File.WriteAllText(FilePath, json);
    }

    public static List<Employee> LoadEmployees()
    {
        if (File.Exists(FilePath))
        {
            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Employee>>(json);
        }
        return new List<Employee>();
    }
}
