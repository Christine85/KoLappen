namespace KoLappen.Models
{
    public class UserJobLocation
    {
        public int UserJobLocationId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}