namespace DTO
{
    // What the API returns for a user - never includes the password.
    public class UserResponseDTO
    {
        public int UserCode { get; set; }

        public string UserId { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int CountNotDoneTasks { get; set; }

        public static UserResponseDTO FromUser(UsersDTO user) => new UserResponseDTO
        {
            UserCode = user.UserCode,
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            CountNotDoneTasks = user.countNotDoneTasks
        };
    }
}
