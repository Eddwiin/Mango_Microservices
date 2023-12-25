namespace Mango.Services.AuthAPI.Models.Dto
{
    public class LoginResponseDto
    {
        public string UserName { get; set; } = string.Empty;
        public String Token { get; set; } = string.Empty;
    }
}
