using System.ComponentModel.DataAnnotations;

namespace DemoMvcCore.Models
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = String.Empty;


        public string? EmpRole { get; set; } = String.Empty;
    }
}
