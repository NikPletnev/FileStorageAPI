﻿using FileStorageAPI.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorageAPI.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FileStorageContext _context;

        public UserRepository(FileStorageContext context)
        {
            _context = context;
        }
        public User GetUserById(int id) =>
            _context.Users.FirstOrDefault(x => x.Id == id);

        public List<User> GetAllUsers() =>
            _context.Users.Where(d => !d.IsDeleted).ToList();

        public int AddUser(User user)
        {
            var entity = _context.Users.Add(user);
            _context.SaveChanges();
            return entity.Entity.Id;
        }

        public void UpdateCustomer(User newUser, User oldUser)
        {
            oldUser.Name = newUser.Name;
            _context.SaveChanges();
        }
        public void UpdateCustomer(int id, bool isDeleted)
        {
            User user = GetUserById(id);
            user.IsDeleted = isDeleted;
            _context.SaveChanges();
        }
        public void DeleteCustomerById(int id)
        {
            var user = GetUserById(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public ICollection<StoragedFileRepository> GetStoragedFilesByUserId(int id)
        {
            var user = GetUserById(id);
            return user.StoragedFiles;
        }
    }
}
