namespace UsersControl.DTO
{
    public class ActivitySearchDTO : SearchDTO
    {
        public int? UserId { get; set; }   

        public string ActivityType { get; set; }
    }
}