namespace UsersControl.DTO
{
    public class ActivityReadDTO
    {
        public string CreateDate { get; set; }

        public string ActivityDescription { get; set; }

        public UserReadDTO User { get; set; }
    }
}