using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersControl.DTO;
using UsersControl.Models;

namespace UsersControl.Data
{
    public class UserModelService : IUserModelService
    {
        private readonly UsersControlDbContext db;

        public UserModelService(UsersControlDbContext db)
        {
            this.db = db;
        }


        /// <summary>
        /// Get an ordered and filtered page of users.
        /// </summary>
        /// <param name="searchDTO">Data Transfer Object with the properties to filter and pagination users.</param>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUsers(UserSearchDTO searchDTO)
        {
            //Create query...
            var query = from x in db.Users select x;

            //Apply filters to query based on user parametters...
            if (!string.IsNullOrEmpty(searchDTO.Name)) //Filter by Name...
            {
                query = query.Where(x => x.Name.Trim().Contains(searchDTO.Name.Trim()));
            }

            if (!string.IsNullOrEmpty(searchDTO.LastName)) //Filter by Last Name...
            {
                query = query.Where(x => x.LastName.Trim().Contains(searchDTO.LastName.Trim()));
            }

            if (searchDTO.CountryId != null && searchDTO.CountryId > 0) //Filter by Country...
            {
                query = query.Where(x => x.CountryId == searchDTO.CountryId);
            }

            //More filters could be added if needed :) ...

            //Count Total Records...
            searchDTO.TotalRecords = await query.CountAsync();

            //Calculete Total Pages...
            searchDTO.TotalPages = searchDTO.TotalRecords / searchDTO.RecordsPerPage;

            //Just in case there are records that cannot be included in the last page, let's add another page more...
            if (searchDTO.TotalRecords % searchDTO.RecordsPerPage > 0)
                searchDTO.TotalPages++;

            //Just in case the requested page no longer exist, let's go to a page back...
            if (searchDTO.TotalPages > 0 && searchDTO.Page > searchDTO.TotalPages)
                searchDTO.Page--;

            //Order and Paginate records..
            query = query.OrderBy(x => x.Name).ThenBy(x => x.LastName).Skip((searchDTO.Page - 1) * searchDTO.RecordsPerPage).Take(searchDTO.RecordsPerPage);

            //Finally, materialize records and return them...
            return await query.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await db.Users.FindAsync(id);
        }

        public async Task<User> CreateUser(User user)
        {
            var result = await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> UpdateUser(User userToUpdate)
        {
            db.Entry(userToUpdate).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return userToUpdate;
        }

        public async Task DeleteUser(User user)
        {
            db.Entry(user).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }
    }
}