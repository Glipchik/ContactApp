namespace ContactApp.Core.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int MobilePhone { get; set; }
        public string? JobTitle { get; set; }
        public DateTimeOffset BirthDate { get; set; }
    }
}
