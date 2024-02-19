using System.ComponentModel.DataAnnotations;

namespace AspireApp.Web.Records
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required]
        public string? Adress { get; set; }

        [Required]
        public DateOnly ClientSince { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Range(0, 1000000000000, ErrorMessage = "Balance is between 0 and one trillion (0 - 1.000.000.000.000,00).")]
        public decimal Balance { get; set; }
    }
}
