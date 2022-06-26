using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UsersControl.DTO;
using UsersControl.Models;

namespace UsersControl.Data
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserModelService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="User"></typeparam>
        Task<IEnumerable<User>> GetUsers(UserSearchDTO searchDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="User"></typeparam>
        Task<User> GetUserById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="user"></typeparam>
        Task<User> CreateUser(User user);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntry"></typeparam>
        Task<User> UpdateUser(User user);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="id"></typeparam>
        Task DeleteUser(User user);
    }
}