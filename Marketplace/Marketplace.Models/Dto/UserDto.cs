namespace Marketplace.Models.Dto
{
    public class UserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public bool IsSeller { get; set; }
    }
    public class UserCreateDto : UserDto
    {
    }

    public class UserUpdateDto : UserDto
    {
        public int IDUser { get; set; }
    }

    public class UserResponseDto : UserDto
    {
        public int IDUser { get; set; }
    }
}
