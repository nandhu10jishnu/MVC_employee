using EmployeeManagmenet.Models;

namespace EmployeeManagmenet.Interface
{
    public interface IEmployee
    {
        List<Employee> Get();
        Employee Get(string id);
        Employee Create(Employee employee);
        void Update(string id, Employee employee);
        void Remove(string id);
    }
}
