using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AdoNet_HW_4
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Game_Shop> Game_Shops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             
        }
        

    }
}
