namespace Mango.Services.CouponAPI.Models.Dto
{
    public class UserDto
    {
        public string ID { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        
        public class Builder : UserDtoInfo<Builder>
        {
            internal Builder() {}
        }

        public static Builder New => new Builder();

    }

    public abstract class UserDtoBuilder 
    {
        protected UserDto userDto = new UserDto();

        public UserDto Build() {
            return userDto;
        }

    }

    public class UserDtoInfo<SELF> : UserDtoBuilder
        where SELF: UserDtoInfo<SELF>
    {
        public SELF SetId(string id) {
            userDto.ID = id;
            return (SELF) this;
        }

        public SELF SetEmail(string email) {
            userDto.Email = email;
            return (SELF) this;
        }

        public SELF SetName(string name) {
            userDto.Name = name;
            return (SELF) this;
        }

        public SELF SetPhoneNumber(string phoneNumber) {
            userDto.PhoneNumber = phoneNumber;
            return (SELF) this;
        }
    }
}
