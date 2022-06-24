using System;
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
        IQueryable<User> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="User"></typeparam>
        IQueryable<User> GetFilteredPage(Expression<Func<User, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="User"></typeparam>
        User Find(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="user"></typeparam>
        void Create(User user);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntry"></typeparam>
        void Update(User user);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="id"></typeparam>
        void Delete(User user);
    }
}