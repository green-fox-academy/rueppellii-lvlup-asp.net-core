using Microsoft.EntityFrameworkCore;
using rueppellii_lvlup_asp.net_core.Data;
using rueppellii_lvlup_asp.net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rueppellii_lvlup_asp.net_core.Repositories
{
    public class UserRepository : IUserRepository
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

        public bool DoesEntityExistByProperty(string property, string propertyValue)
        {
            try
            {
                return _context.Users.Any(user => (string)user.GetType().GetProperty(property).GetValue(user) == propertyValue);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Model User does not have a {0} property. " + e.Message, property);
            }
            return false;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
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
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
} 