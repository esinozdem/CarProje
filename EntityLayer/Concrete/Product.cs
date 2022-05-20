using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public int PieceID { get; set; }
        public virtual Piece Piece { get; set; }
    }
}
