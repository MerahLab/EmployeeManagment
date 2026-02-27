
namespace EmployeeManagment.Models
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public EFEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee employee)
        {
           context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
           Employee employee= context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
               
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
           return context.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return context.Employees.Find(id);
        }

        public Employee Update(Employee employee)
        {
          var employer =  context.Employees.Attach(employee);
            //context.Employees.Update(employee);
            employer.State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employee;
        }

    }
}
