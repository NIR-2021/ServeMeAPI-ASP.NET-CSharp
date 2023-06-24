using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServeMe_M2.Contract;
using ServeMe_M2.Model;
using ServeMe_M2.Model.DTOs;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ServeMe_M2.Repo
{
    public class AuthManager : IAuth
    {
        private readonly IMapper mapper;
        private readonly UserManager<ApiUser> userManager;
        private readonly IConfiguration configuration;

        public AuthManager(IMapper mapper,UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<Dictionary<string,string>> login(LoginDto loginDto)
        {
            Dictionary<string, string> ret_data = new Dictionary<string, string>();
            bool isValid = false;
            try
            {
                var user = await userManager.FindByEmailAsync(loginDto.Email);
                isValid = await userManager.CheckPasswordAsync(user,loginDto.Password);
                if (isValid)
                {
                    ret_data.Add("userId", user.Id.ToString());
                    ret_data.Add("email", user.Email.ToString());
                    ret_data.Add("isValid", isValid.ToString());
                }
                else
                {
                    ret_data.Add("isValid", isValid.ToString());
                }
                

            }
            catch(Exception e)
            {
               
            }

            return ret_data;
        }
        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto apiUserDto)
        {
            
            var user = mapper.Map<ApiUser>(apiUserDto);
            user.UserName = apiUserDto.Email;

            var result = await userManager.CreateAsync(user,apiUserDto.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");
            }

            return result.Errors;//If it is empty user registration is successfull. Else not succressfull
        }

        public async Task<ApiUserDto> GetUserDetails(string email,string id)
        {
            var sameUser = await userManager.Users.FirstOrDefaultAsync(u => u.Email == email);

            if(sameUser == null)
            {
                return new ApiUserDto();
            }
            else
            { 
                if(sameUser.Id == id)
                {
                    ApiUserDto apiUserDto = new ApiUserDto();
                    apiUserDto.Address = sameUser.Address;
                    apiUserDto.FirstName = sameUser.FirstName;
                    apiUserDto.Email = sameUser.Email;
                    apiUserDto.LastName = sameUser.LastName;
                    apiUserDto.PhoneNumber = sameUser.PhoneNumber;
                    return apiUserDto;
                }
                else
                {
                    return new ApiUserDto();
                }
                
            }

        }

      /*  private async Task<string> GenerateToken(ApiUser apiUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await userManager.GetRolesAsync(apiUser);

            var roleClaims = roles.Select(X => new Claim(ClaimTypes.Role, X)).ToList();
            var userClaims = await userManager.GetClaimsAsync(apiUser);
        }*/
    }
}
