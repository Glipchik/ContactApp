namespace ContactApp.Web.Models
{
    public class CreateContactModel
    {
        public string? Name { get; set; }
        public int MobilePhone { get; set; }
        public string? JobTitle { get; set; }
        public DateTimeOffset BirthDate { get; set; }
    }
}
