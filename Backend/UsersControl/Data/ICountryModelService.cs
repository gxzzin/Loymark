using System;
using System.Linq;
using System.Linq.Expressions;
using UsersControl.Models;

namespace UsersControl.Data
{
    public interface ICountryModelService
    {
         /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Country"></typeparam>
        IQueryable<Country> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Country"></typeparam>
        IQueryable<Country> GetFilteredPage(Expression<Func<Country, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Country"></typeparam>
        Country Find(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="country"></typeparam>
        void Create(Country country);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntry"></typeparam>
        void Update(Country country);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="id"></typeparam>
        void Delete(Country country);
    }
}