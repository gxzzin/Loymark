using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
        Task<IEnumerable<User>> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="User"></typeparam>
        Task<IEnumerable<User>> GetFilteredPage(Expression<Func<User, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="User"></typeparam>
        Task<User> Find(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="user"></typeparam>
        Task<User> Create(User user);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntry"></typeparam>
        Task<User> Update(User user);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="id"></typeparam>
        Task Delete(User user);
    }
}