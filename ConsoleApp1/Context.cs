using System;
using System.Data.Entity;
using System.Linq;
using Entities.Concrete

namespace ConsoleApp1
{
    public class Context : DbContext
    {
      
        public Context()
            : base("name=Context")
        {
        }

       

         public virtual DbSet<Car> MyEntities { get; set; }
    }

}