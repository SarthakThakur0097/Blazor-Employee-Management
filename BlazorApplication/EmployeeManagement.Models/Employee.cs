using EmployeeManagement.Models.CustomValidators;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "First Name must be provided")]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name must be provided")]
        public string LastName { get; set; }
        [EmailAddress]
        [EmailDomainValidator(AllowedDomain = "SarthakThakur.com",
            ErrorMessage = "Domain must be SarthakThakur.com")]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        
        public Department Department { get; set; }
    }
}
