using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Models.DTO;

namespace CoffeeStoreManagementApp.Services.Interfaces
{
    public interface IAuthService
    {

        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<User> Register(UserRegisterDTO registerDTO);


    }
}
