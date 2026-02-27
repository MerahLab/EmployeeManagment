using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Employee>().HasData(

                  new Employee
                  {
                      Id = 1,
                      Name = "Mary",
                      Email = "mary@yahoo.com",
                      Department = Dept.IT,
                      Photopath = ""
                  },
                   new Employee
                   {
                       Id = 2,
                       Name = "John",
                       Email = "john@yahoo.com",
                       Department = Dept.HR,
                       Photopath=""
                   },
                    new Employee
                    {
                        Id = 3,
                        Name = "David",
                        Email = "david@yahoo.com",
                        Department = Dept.PayRoll,
                        Photopath=""
                    }
               );

        }
    }
}
