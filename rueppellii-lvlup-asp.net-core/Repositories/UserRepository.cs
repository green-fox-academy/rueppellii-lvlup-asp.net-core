using Microsoft.EntityFrameworkCore;
using rueppellii_lvlup_asp.net_core.Data;
using rueppellii_lvlup_asp.net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Repositories
{
    public class UserRepository : ICrudRepository<User>
    {
        private readonly LvlUpDbContext _context;

        public UserRepository(LvlUpDbContext context)
        {
            this._context = context;
        }
        public void Delete(long id)
        {
            _context.Users.Remove(_context.Users.Find(id));
            _context.SaveChanges();
        }

        public bool DoesEntityExistByProperty(string property, object propertyValue)
        {

            if (_context.Users.GetType().GetGenericArguments()[0].GetProperty(property) != null &&
                _context.Users.Any(user => user.GetType().GetProperty(property).GetValue(user) == propertyValue))
            {
                return true;
            }

            return false;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList<User>();
        }

        public User GetById(long id)
        {
            return _context.Users.Find(id);
        }

        public void Save(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Entry<User>(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
