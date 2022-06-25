using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<User>> GetAll()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetFilteredPage(Expression<Func<User, bool>> predicate)
        {
            return await db.Users.Where(predicate).ToListAsync();
        }

        public async Task<User> Find(int id)
        {
            return await db.Users.FindAsync(id);
        }

        public async Task<User> Create(User user)
        {
            var result = await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> Update(User userToUpdate)
        {
            db.Entry(userToUpdate).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return userToUpdate;
        }

        public async Task Delete(User user)
        {
            db.Entry(user).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }
    }
}