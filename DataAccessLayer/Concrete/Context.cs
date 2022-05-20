using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
   public class Context:DbContext
    {
        //Connectionstring tanımlayabilmek için oluşturmuş olduğum yapı.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-U32R22S\\S2019;database=CarDb;integrated security=true;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Piece> Pieces { get; set; }
    }
}
