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

        /// <summary>
        /// Get a User by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetUserById(int id)
        {
            return await db.Users.FindAsync(id);
        }

        /// <summary>
        /// Create a new User a save it in database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> CreateUser(User user)
        {
            var result = await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        /// <summary>
        /// Update a user a save changes into database.
        /// </summary>
        /// <param name="userToUpdate"></param>
        /// <returns></returns>
        public async Task<User> UpdateUser(User userToUpdate)
        {
            db.Entry(userToUpdate).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return userToUpdate;
        }

        /// <summary>
        /// Delete a user from database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task DeleteUser(User user)
        {
            db.Entry(user).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }


        /// <summary>
        /// Validate common rules when creating or updating an user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string ValidateBeforeCreateOrUpdate(User user)
        {
            var errorMessage = string.Empty;

            //We don't wannt people from the future...
            if (user.Birthday.Date >= DateTime.Now.Date)
            {
                errorMessage = $"Please, type a valid birthday. Birthday must be less than today's date.";
                return errorMessage;
            }

            //Validate unique email...
            if (db.Users.Any(x => x.Id != user.Id && x.Email.ToLower().Trim() == user.Email.ToLower().Trim()))
            {
                errorMessage = $"The email {user.Email} is being used by another user. Please type a different and unique email.";
                return errorMessage;
            }

            return errorMessage;
        }

        /// <summary>
        /// Validate rules when creating a new user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string ValidateBeforeCreate(User user)
        {
            var errorMessage = ValidateBeforeCreateOrUpdate(user);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                return errorMessage;
            }
            //Si fuese necesario se podria seguir agregando validaciones propias del crear...

            return errorMessage;
        }

        /// <summary>
        /// Validate rules when updating a user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string ValidateBeforeUpdate(User user)
        {
            var errorMessage = ValidateBeforeCreateOrUpdate(user);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                return errorMessage;
            }
            //Si fuese necesario se podria seguir agregando validaciones propias del update...

            return errorMessage;
        }

        /// <summary>
        /// Validate rules when deleting a user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string ValidateBeforeDelete(User user)
        {
            var errorMessage = string.Empty;

            //Si se quisiera validar integridad referencial entre la relacion User -> Activities..
            // if (user.Activities.Any())
            // {
            //     errorMessage = $"Sorry, we can not delete the user because it has {user.Activities.Count} activities.";
            //     return errorMessage;
            // }

            return errorMessage;
        }

    }
}