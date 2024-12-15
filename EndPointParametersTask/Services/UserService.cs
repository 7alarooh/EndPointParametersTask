using EndPointParametersTask.Models;
using EndPointParametersTask.Repositories;

namespace EndPointParametersTask.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userrepo;

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            // Example of additional business logic: ensure email is unique
            var existingUsers = await _userRepository.GetAllUsersAsync();
            if (existingUsers.Any(u => u.Email == user.Email))
            {
                throw new System.Exception("A user with this email already exists.");
            }

            return await _userRepository.AddUserAsync(user);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(user.UId);
            if (existingUser == null)
            {
                throw new System.Exception("User not found.");
            }

            return await _userRepository.UpdateUserAsync(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }
}
