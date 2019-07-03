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

        //Used for testing
        public RepositoryContext()
        {

        }

        public virtual DbSet<Messages> Messages { get; set; }
    }
}
