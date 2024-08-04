using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models.DTO;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using CoffeeStoreManagementApp.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace CoffeeStoreManagementApp.Services
{
    public class AdminAuthService : IAdminAuthService
    {
        private readonly IRepository<int, Employee> _employeeRepo;
        private readonly IRepository<int, EmployeeCredential> _employeeCredentialRepo;
        private readonly ITokenService _tokenService;


        public AdminAuthService(IRepository<int, Employee> employeeRepo, IRepository<int, EmployeeCredential> employeeCreentialRepo, ITokenService tokenService)
        {
            _employeeCredentialRepo = employeeCreentialRepo;
            _employeeRepo = employeeRepo;
            _tokenService = tokenService;

        }


        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var employeeCredentials = await _employeeCredentialRepo.GetAll();
            EmployeeCredential employeeCredential = employeeCredentials.FirstOrDefault(uc => uc.Email == loginDTO.Email);
            if (employeeCredential == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(employeeCredential.HashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, employeeCredential.HashPassword);
            if (isPasswordSame)
            {
                var employee = await _employeeRepo.GetByKey(employeeCredential.EmployeeId);
                //if (userDB.Status == "Active")
                //    return employee;
                LoginReturnDTO loginReturnDTO = MapEmployeeToLoginReturnDTO(employee);
                return loginReturnDTO;
                //throw new UserNotActiveException("Your account is not activated");
            }
            throw new UnauthorizedUserException("Invalid username or password");


        }

        private LoginReturnDTO MapEmployeeToLoginReturnDTO(Employee employee)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.UserID = employee.EmployeeId;
            returnDTO.Role = employee.Role ?? "Employee";
            returnDTO.Token = _tokenService.GenerateEmployeeToken(employee);
            return returnDTO;
        }


        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }




        public async Task<Employee> Register(UserRegisterDTO registerDTO)
        {
            Employee employee = null;
            EmployeeCredential employeeCredential = null;
            try
            {
                employee = MapRegisterDTOToUser(registerDTO);
                employeeCredential = MapRegisterDTOToEmployeeCredential(registerDTO);
                employee = await _employeeRepo.Add(employee);
                employeeCredential.EmployeeId = employee.EmployeeId;
                employeeCredential = await _employeeCredentialRepo.Add(employeeCredential);

                return employee;
            }
            catch (Exception) { }
            if (employee != null)
                await RevertUserInsert(employee);
            if (employeeCredential != null && employee == null)
                await RevertUserCredentialInsert(employeeCredential);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private async Task RevertUserCredentialInsert(EmployeeCredential employeeCredential)
        {
            await _employeeCredentialRepo.DeleteByKey(employeeCredential.EmployeeId);
        }

        private async Task RevertUserInsert(Employee employee)
        {
            await _employeeRepo.DeleteByKey(employee.EmployeeId);
        }



        private Employee MapRegisterDTOToUser(UserRegisterDTO registerDTO)
        {
            Employee employee = new Employee();

            employee.Name = registerDTO.Name;
            employee.Role = registerDTO.Role;
            employee.Phone = registerDTO.Phone;
            employee.Email = registerDTO.Email;


            return employee;
        }


        private EmployeeCredential MapRegisterDTOToEmployeeCredential(UserRegisterDTO registerDTO)
        {
            EmployeeCredential employeeCredential = new EmployeeCredential();


            HMACSHA512 hMACSHA = new HMACSHA512();
            employeeCredential.Email = registerDTO.Email;
            employeeCredential.HashKey = hMACSHA.Key;
            employeeCredential.HashPassword = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password));
            return employeeCredential;
        }



    }
}
