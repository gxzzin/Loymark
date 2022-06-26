using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersControl.Models;

namespace UsersControl.Data
{
    public class CountryModelService : ICountryModelService
    {
        private readonly UsersControlDbContext db;

        public CountryModelService(UsersControlDbContext db)
        {
            this.db = db;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await db.Countries.OrderBy(x => x.CountryName).ToListAsync();
        }
    }
}