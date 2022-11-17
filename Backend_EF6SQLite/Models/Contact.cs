namespace Backend_EF6SQLite.Models
{
    public class Contact
    {
        public int ID { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public long Phone { get; set; }

        public string Address { get; set; } = string.Empty;
    }
}
