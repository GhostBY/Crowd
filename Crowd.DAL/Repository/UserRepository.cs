using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Crowd.DAL.Interfaces;
using Crowd.DAL.Entities;
using Crowd.DAL.EF;

namespace Crowd.DAL.Repository
{
    public class UserRepository : IRepository<User>
    {
        public ApplicationContext context = new ApplicationContext();
        public UserRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Add(User item)
        {
            context.Users.Add(item);
            context.SaveChanges();
        }

        public void Remove(int Id)
        {
            var item = context.Users.SingleOrDefault(r => r.Id == Id);
            if (item != null)
            {
                context.Remove(item);
                context.SaveChanges();
            }
        }

        public User Find(int id)
        {
            var item = context.Users.SingleOrDefault(r => r.Id == id);
            return item;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public void Update(User item)
        {
            var user = context.Users.SingleOrDefault(r => r.Id == item.Id);
            if (user != null)
            {
                user.Mail = item.Mail;
                user.Password = item.Password;
                user.Role = item.Role;
                context.SaveChanges();
            }
        }
    }
}
