using System.ComponentModel.DataAnnotations;

namespace AspireApp.Web.Records
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Required]
        public string? Adress { get; set; }
        public DateOnly ClientSince { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Required]
        public float Balance { get; set; }
    }
}
