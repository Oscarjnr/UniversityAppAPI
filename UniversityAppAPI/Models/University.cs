namespace UniversityAppAPI.Models
{
    public class University
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string VC { get; set; }
        public string Email { get; set; }
        public long Contact { get; set; }
    }
}
