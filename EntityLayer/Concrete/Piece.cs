﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Piece
    {

        [Key]
        public int PieceID { get; set; }
        public string PieceCode { get; set; }

        [StringLength(50)]
        public string PieceName { get; set; }
        public decimal PiecePrice { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
