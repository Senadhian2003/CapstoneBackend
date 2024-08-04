using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Models.DTO;
using CoffeeStoreManagementApp.Repositories.Interface;
using CoffeeStoreManagementApp.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace CoffeeStoreManagementApp.Services
{
    public class AuthService : IAuthService
    {


        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, UserCredential> _userCredentialRepo;
        private readonly ITokenService _tokenService;
        private readonly IRepository<int, Cart> _cartRepository;


        public AuthService(IRepository<int, User> userRepo, IRepository<int, UserCredential> userCredentialRepo, ITokenService tokenService, IRepository<int, Cart> cartRepository)
        {
            _userRepo = userRepo;
            _userCredentialRepo = userCredentialRepo;
            _tokenService = tokenService;
            _cartRepository = cartRepository;

        }


        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var userCredentials = await _userCredentialRepo.GetAll();
            UserCredential userCredential = userCredentials.FirstOrDefault(uc=>uc.Email==loginDTO.Email);
            if (userCredential == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userCredential.HashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userCredential.HashPassword);
            if (isPasswordSame)
            {
                var user = await _userRepo.GetByKey(userCredential.UserId);
                //if (userDB.Status == "Active")
                //    return employee;
                LoginReturnDTO loginReturnDTO = MapEmployeeToLoginReturnDTO(user);
                return loginReturnDTO;
                //throw new UserNotActiveException("Your account is not activated");
            }
            throw new UnauthorizedUserException("Invalid username or password");


        }

        private LoginReturnDTO MapEmployeeToLoginReturnDTO(User user)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.UserID = user.UserId;
            returnDTO.Role = user.Role ?? "User";
            returnDTO.Token = _tokenService.GenerateToken(user);
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




        public async Task<User> Register(UserRegisterDTO registerDTO)
        {
            User user = null;
            UserCredential userCredential = null;
            try
            {
                user = MapRegisterDTOToUser(registerDTO);
                userCredential = MapRegisterDTOToUserCredential(registerDTO);
                user = await _userRepo.Add(user);
                userCredential.UserId = user.UserId;
                userCredential = await _userCredentialRepo.Add(userCredential);

                Cart cart = new Cart()
                {
                    UserId = user.UserId,
                };

                await _cartRepository.Add(cart);

                return user;
            }
            catch (Exception) { }
            if (user != null)
                await RevertUserInsert(user);
            if (userCredential != null && user == null)
                await RevertUserCredentialInsert(userCredential);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private async Task RevertUserCredentialInsert(UserCredential userCredential)
        {
            await _userCredentialRepo.DeleteByKey(userCredential.UserId);
        }

        private async Task RevertUserInsert(User user)
        {
            await _userRepo.DeleteByKey(user.UserId);
        }



        private User MapRegisterDTOToUser(UserRegisterDTO registerDTO)
        {
            User user = new User();

            user.Name = registerDTO.Name;
            user.Role = registerDTO.Role;
            user.Phone = registerDTO.Phone;
            user.Email = registerDTO.Email;


            return user;
        }


        private UserCredential MapRegisterDTOToUserCredential(UserRegisterDTO registerDTO)
        {
            UserCredential userCredential = new UserCredential();


            HMACSHA512 hMACSHA = new HMACSHA512();
            userCredential.Email = registerDTO.Email;
            userCredential.HashKey = hMACSHA.Key;
            userCredential.HashPassword = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password));
            return userCredential;
        }


    }
}
