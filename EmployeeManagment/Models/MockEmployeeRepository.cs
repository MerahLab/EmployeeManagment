
namespace EmployeeManagment.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;
        public MockEmployeeRepository()
        {
            _employees = new List<Employee>() {

            new Employee() {Id=1,Name="Mary",Department=Dept.HR,Email="mary.pragim.com"},
            new Employee() {Id=2,Name="John",Department=Dept.IT,Email="john.pragim.com"},
            new Employee() {Id=3,Name="Sam",Department=Dept.IT,Email="sam.pragim.com"},

            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);

            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {

                _employees.Remove(employee);

            }
            return employee;

        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employees;
        }

        public Employee? GetEmployee(int Id)
        {
            return _employees.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employee)
        {
            Employee employer = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (employer != null)
            {

                employee.Name = employer.Name;
                employee.Email = employer.Email;
                employee.Department = employer.Department;


            }
            return employee;
        }
    }
}
