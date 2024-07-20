using ReflectionAndAttributes.Models;
using ReflectionAndAttributes.Mapper;
using ReflectionAndAttributes.Repository;
using ReflectionAndAttributes.Helper;

namespace ReflectionAndAttributes
{
    public class Program
    {
        static void Main(string[] args)
        {

            // Reflection-Based Mapping
            var employee = new Employee { Id = 1, Name = "Anusha", Department = "Delivery" };
            var secondEmployee = new Employee { Id = 2, Name = "John", Department = "HR" };

            var employeeDetails = new EmployeeDTO();
            EmployeeDetailsMapper.MapProperties(employee, employeeDetails);
            Console.WriteLine($"Reflection Mapping: Id={employeeDetails.Id}, Name={employeeDetails.Name}, Department={employeeDetails.Department}");

            // AutoMapper Mapping
            EmployeeDetailsMapper.MappingProfile(employee, employeeDetails);
            Console.WriteLine($"AutoMapper Mapping: Id={employeeDetails.Id}, Name={employeeDetails.Name}, Department={employeeDetails.Department}");

            // CRUD Operations
            var repository = new EmployeeRepository<Employee>();

            // Creating a new Emoployee
            repository.Create(employee);

            // Fetching through Id
            var retrievedEmployee = repository.Read(e => e.Id == 1);
            Console.WriteLine($"Retrieved Employee: Id={retrievedEmployee.Id}, Name={retrievedEmployee.Name}");

            // Updating the employee 
            repository.Update(secondEmployee);

            // JSON Serialization
            var employeeObj = new EmployeeDTO
            {
                Id = 1,
                Name = "John Doe",
                Department = "HR"
            };

            string json = JsonSerializationHelper.SerializeToJson(employeeObj);
            Console.WriteLine("Serialized JSON:");
            Console.WriteLine(json);

            // JSON Deserialization
            var employeeDeserializer = JsonSerializationHelper.DeserializeFromJson<EmployeeDTO>(json);
            Console.WriteLine($"Deserialized JSON in the form of class type: Id={employeeDeserializer.Id}, Name={employeeDeserializer.Name}");
        }
    }
}
