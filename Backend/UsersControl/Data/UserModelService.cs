using System;
using System.Linq;
using System.Linq.Expressions;
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

        public IQueryable<User> GetAll()
        {
            return db.Users;
        }

        public IQueryable<User> GetFilteredPage(Expression<Func<User, bool>> predicate)
        {
            return db.Users.Where(predicate);
        }

        public User Find(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User user)
        {
            db.Entry(user).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Update(User userToUpdate)
        {
            try
            {
                db.Entry(userToUpdate).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(User user)
        {

            db.Entry(user).State = EntityState.Deleted;
            db.SaveChanges();
        }

    }
}