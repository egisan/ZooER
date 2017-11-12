using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooER.Models;
using System.Data.Entity;

namespace ZooER.DAL
{
    class ZooContext : DbContext
    {
        public ZooContext() : base ("ZooER")
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<ChildParent> ChildrenParents { get; set; }
    }


}
