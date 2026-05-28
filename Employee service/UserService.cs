using employee_reppsitory;
using Entities.Dtos;
using Entities.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_service
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _UserRepository;
        public UserService(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        public async Task<UserSignInResponse> UserResgistration(UserDto usersObj)
        {
            Users users = new Users();
            users.Id = usersObj.Id;
            users.Username = usersObj.Username;
            users.Password = usersObj.Password;
            users.Email = usersObj.Email;
            users.Address = usersObj.Address;
            users.PhoneNumber = usersObj.PhoneNumber;
            users.IsActive = usersObj.IsActive;
            var result = await _UserRepository.UserResgistration(users);
            return result;
        }
    }
}
