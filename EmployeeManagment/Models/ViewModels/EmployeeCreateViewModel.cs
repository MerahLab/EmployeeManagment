using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Models.ViewModels
{
    public class EmployeeCreateViewModel
    {
        //public Employee Employee { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "Name cannot exceed 25 characters")]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public Dept? Department { get; set; }

        public IFormFile Photo { get; set; }
    }
}
