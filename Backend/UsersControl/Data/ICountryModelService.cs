using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UsersControl.Models;

namespace UsersControl.Data
{
    public interface ICountryModelService
    {
         /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Country"></typeparam>
        Task<IEnumerable<Country>> GetAll();

    }
}