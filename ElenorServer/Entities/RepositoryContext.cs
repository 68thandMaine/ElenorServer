using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<ProfileContent> ProfileContent { get; set;}
    }
}
