namespace UsersControl.DTO
{
    public class UserReadDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Birthday { get; set; }

        public int? TelephoneNumber { get; set; }

        public bool SendNews { get; set; }

        public string CountryName { get; set; }
    }
}