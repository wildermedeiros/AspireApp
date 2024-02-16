namespace AspireApp.ApiCustomer.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Adress { get; set; }
        public DateOnly ClientSince { get; set; }
        public float Balance { get; set; }
    }
}
