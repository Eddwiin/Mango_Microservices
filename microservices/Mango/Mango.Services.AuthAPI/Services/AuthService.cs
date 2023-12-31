﻿using Mango.Services.AuthAPI.Data;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Services.IService;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AppDbContext db, UserManager<ApplicationUser> userManager,
         RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == email.ToLower());

            if(user != null) {
                if(!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult()) 
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter();
                }

                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }

            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());
            var userNotFoundDto = new LoginResponseDto() { User = null, Token = ""};

            if (user == null) return userNotFoundDto;

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if(!isValid) return userNotFoundDto;

            var token = _jwtTokenGenerator.GenerateToken(user);
            UserDto userDto = UserDto.New
                    .SetEmail(user.Email)
                    .SetId(user.Id)
                    .SetName(user.Name)
                    .SetPhoneNumber(user.PhoneNumber)
                    .Build();

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = ""
            };

            return loginResponseDto;
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                Name = registrationRequestDto.Name,
                PhoneNumber = registrationRequestDto.PhoneNumber
            };

            try 
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
            
                if(result.Succeeded) {
                    var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);

        
                    UserDto userDto = UserDto.New
                        .SetEmail(userToReturn.Email)
                        .SetId(userToReturn.Id)
                        .SetName(userToReturn.Name)
                        .SetPhoneNumber(userToReturn.PhoneNumber)
                        .Build();

                    return "";
                } else {
                    return result.Errors.FirstOrDefault().Description;
                }
            } 
            catch(Exception ex)
            {

            }

            return "Error creation account";
        }
    }
}
