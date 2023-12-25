using Mango.Services.CouponAPI.Models.Dto;

namespace Mango.Services.AuthAPI.Models.Dto
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public String Token { get; set; } = string.Empty;
    }
}
