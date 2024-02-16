namespace AspireApp.Web.Records
{
    public record Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
