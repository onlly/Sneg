using Sneg.Data.Entities;
using Sneg.Data.Repositories.Interfaces;
using Sneg.Service.Interfaces;
using Sneg.Service.Models;
using Sneg.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sneg.Common.Enums;
using Sneg.Common.Extensions;
using Microsoft.AspNet.Identity;

namespace Sneg.Service.Implementation
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserService(IUserRepository userRepository, IUserRoleRepository userRoleRepository): base(userRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public void Dispose()
        {
        }

        public async Task CreateAsync(UserDto user)
        {
            var entity = user.FromDto();
            await this.CreateAsync(entity);
            await AddToRoleAsync(entity.ToDto(), RoleEnum.User.ToString());
        }

        public Task UpdateAsync(UserDto user)
        {
            return Task.FromResult(user.FromDto());
        }

        public Task DeleteAsync(UserDto user)
        {
            return Task.FromResult(Repository.Delete(user.FromDto()));
        }
        public Task FindByIdAsync(int userId)
        {
            var user = Repository.Query().SingleOrDefault(x => x.Id == userId);
            if (user == null)
                throw new Exception("User not found");
            return Task.FromResult(user.ToDto());
        }

        Task<UserDto> IUserStore<UserDto, int>.FindByIdAsync(int userId)
        {
            var user = Repository.Query().SingleOrDefault(x => x.Id == userId);

            if (user == null)
                throw new Exception("User not found");

            return Task.FromResult(user.ToDto());
        }

        //public Task<User> IUserStore<UserDto, int>.FindByIdAsync (int userId)
        //{
        //    var user = Repository.Query().SingleOrDefault(x => x.Id == userId);
        //    if (user == null)
        //        throw new Exception("User not found");
        //    return Task.FromResult(user.ToDto());
        //}
         
        Task<UserDto> IUserStore<UserDto, int>.FindByNameAsync(string userName)
        {
            var user = Repository.Query().SingleOrDefault(x => x.UserName == userName);
            return Task.FromResult(user == null ? null : user.ToDto());
        }

        public Task SetPasswordHashAsync(UserDto user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(UserDto user)
        {
            return Task.FromResult(user.Password);
        }
        public Task<bool> HasPasswordAsync(UserDto user)
        {
            return Task.FromResult(!string.IsNullOrWhiteSpace(user.Password));
        }
        public Task AddToRoleAsync(UserDto user, string roleName)
        {
            var role = roleName.GetRole();
            _userRoleRepository.Add(new UserRole
                {
                    UserId = user.Id,
                    Role = role
                });
            return _userRoleRepository.SaveChangesAsync();

        }

        public Task RemoveFromRoleAsync(UserDto user, string roleName)
        {
            var role = roleName.GetRole();

            var userRole = _userRoleRepository.GetByUserIdAndRole(user.Id, role);
            _userRoleRepository.Delete(userRole);
            return _userRoleRepository.SaveChangesAsync();
        }

        public async Task<IList<string>> GetRolesAsync(UserDto user)
        {
            var userRoles = _userRoleRepository.GetByUserId(user.Id);
            var roles = userRoles.Select(x => x.Role.ToString()).ToList();
            var result = await Task.FromResult(roles);
            return result;
        }

        public Task<bool> IsInRoleAsync(UserDto user, string roleName)
        {
            var role = roleName.GetRole();
            return Task.FromResult(_userRoleRepository.HasRole(user.Id, role));
        }

        public IEnumerable<UserMinDto> GetUsers()
        {
            var users = Repository.Query()
                .SelectMinDto()
                .ToList();
            return users;
        }

    }
}
