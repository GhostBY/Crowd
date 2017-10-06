using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crowd.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crowd.DAL.EF
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        { }
        public ApplicationContext(){ }
        public DbSet<User> Users { get; set; }
    }
}
