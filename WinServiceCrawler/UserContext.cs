using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WinServiceCrawler
{
    class UserContext : DbContext
    {
        public UserContext()
            : base("DbConnection")
        { }

        public DbSet<Post> Post { get; set; }
        public DbSet<Statistic> Statistic { get; set; }
    }
}