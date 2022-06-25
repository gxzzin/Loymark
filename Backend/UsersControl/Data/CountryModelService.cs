using System;
using System.Linq;
using System.Linq.Expressions;
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

        public void Create(Country country)
        {
            throw new NotImplementedException();
        }

        public void Delete(Country country)
        {
            throw new NotImplementedException();
        }

        public Country Find(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Country> GetAll()
        {
            return db.Countries.OrderBy(x => x.CountryName);
        }

        public IQueryable<Country> GetFilteredPage(Expression<Func<Country, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Country country)
        {
            throw new NotImplementedException();
        }
    }
}