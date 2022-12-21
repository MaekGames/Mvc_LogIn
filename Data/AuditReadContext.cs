using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppTask.Models.Audit;

namespace WebAppTask.Data
{
    public class AuditReadContext : DbContext
    {
        public AuditReadContext (DbContextOptions<AuditReadContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppTask.Models.Audit.Audit> AuditLogs { get; set; } = default!;
    }
}
