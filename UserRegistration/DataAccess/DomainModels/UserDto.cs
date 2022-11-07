namespace UserRegistration.DataAccess.DomainModels
{
    public class UserDto
    {
        public int UserId { get; set; }

        public int UserRoleId { get; set; }

        public string? UserRoleName { get; set; }

        public string Forenames { get; set; }

        public string Surname { get; set; }

        public string FullName { get; set; }

        public string? Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
