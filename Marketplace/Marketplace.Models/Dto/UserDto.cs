namespace Marketplace.Models.Dto
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
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
