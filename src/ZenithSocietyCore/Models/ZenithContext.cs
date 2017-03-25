using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ZenithSocietyCore.Models
{
    public class ZenithContext : DbContext
    {
        public ZenithContext(DbContextOptions<ZenithContext> options) 
            : base(options){}
        public DbSet<Event> Events { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}
