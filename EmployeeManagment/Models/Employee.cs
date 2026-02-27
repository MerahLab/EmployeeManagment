using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        [Required]
        [MaxLength(25,ErrorMessage ="Name cannot exceed 25 characters")]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public Dept? Department { get; set;}

        public string? Photopath { get; set; }

       
    }
}
