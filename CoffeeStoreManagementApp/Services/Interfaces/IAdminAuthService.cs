using CoffeeStoreManagementApp.Models.DTO;
using CoffeeStoreManagementApp.Models;

namespace CoffeeStoreManagementApp.Services.Interfaces
{
    public interface IAdminAuthService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(UserRegisterDTO registerDTO);

    }
}
