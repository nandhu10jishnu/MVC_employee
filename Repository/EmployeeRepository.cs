using EmployeeManagmenet.Interface;
using EmployeeManagmenet.Models;
using MongoDB.Driver;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly IMongoCollection<Employee> _employee;

        public EmployeeRepository(IDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _employee = database.GetCollection<Employee>("Employe");
        }

        public Employee Create(Employee employee)
        {
            _employee.InsertOne(employee);
            return employee;
        }

        public List<Employee> Get()
        {
            return _employee.Find(employee => true).ToList();
        }

        public Employee Get(string id)
        {
            return _employee.Find(emp => emp.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _employee.DeleteOne(emp => emp.Id == id);
        }

        public void Update(string id, Employee updatedEmployee)
        {
            _employee.ReplaceOne(emp => emp.Id == id, updatedEmployee);
        }
    }
}
