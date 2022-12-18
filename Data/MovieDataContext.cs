using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppTask.Models;

namespace WebAppTask.Data
{
    public class MovieDataContext : AuditContext
    {
        public MovieDataContext (DbContextOptions<MovieDataContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppTask.Models.Movie> Movie { get; set; } 
    }
}
