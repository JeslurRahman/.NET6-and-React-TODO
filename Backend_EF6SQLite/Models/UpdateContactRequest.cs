namespace Backend_EF6SQLite.Models
{
    public class UpdateContactRequest
    {
        public int ID { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }

        public long Phone { get; set; }

        public string Address { get; set; }
    }
}
