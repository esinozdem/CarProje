using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ProductRepo : GenericRepo<Product>, IProductDal
    {
        public List<Product> GetListWithPiece()
        {
            using (var c = new Context())
            {
                return c.Products.Include(x => x.Piece).ToList();
            }
        }
    }
}
