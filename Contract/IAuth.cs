using Microsoft.AspNetCore.Identity;
using ServeMe_M2.Model;
using ServeMe_M2.Model.DTOs;

namespace ServeMe_M2.Contract
{
    public interface IAuth
    {
        public Task<IEnumerable<IdentityError>> Register(ApiUserDto apiUserDto);
        public Task<Dictionary<string, string>> login(LoginDto loginDto);
        public Task<ApiUserDto> GetUserDetails(string email,string id);

    }
}
