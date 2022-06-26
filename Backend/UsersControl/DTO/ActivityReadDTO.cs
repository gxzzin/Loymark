namespace UsersControl.DTO
{
    public class ActivityReadDTO
    {
        public int Id { get; set; }

        public string CreateDate { get; set; }

        public string ActivityType { get; set; }

        public string ActivityDescription { get; set; }

        public int UserId { get; set; }

        public UserReadDTO User { get; set; }
    }
}