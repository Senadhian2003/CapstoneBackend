using CoffeeStoreManagementApp.Models;

namespace CoffeeStoreManagementApp.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
        public string GenerateEmployeeToken(Employee employee);
    }
}
