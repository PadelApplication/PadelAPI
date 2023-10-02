namespace PadelAPI.Models
{
    public class Padel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public string? Place { get; set; }
        public string? Court { get; set; }
        public int People { get; set; }
    }
}
