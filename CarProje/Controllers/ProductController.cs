using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarProje.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new ProductRepo());
        PieceManager bm = new PieceManager(new PieceRepo());
        Context c = new Context();
        public IActionResult Index()
        {
            var values = pm.GetProductListPiece();
            return View(values);
        }
        [HttpGet]
        public IActionResult ProductAdd()

        {
            //Yedek parça Id'sini seçebilmek için yazılan sorgu.

            List<SelectListItem> piecevalues = (from x in bm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PieceName,
                                                    Value = x.PieceID.ToString()
                                                }).ToList();
            //Viewbag kullanarak piecevalue değişkeninden gelen değerleri dropdona taşıyabiliriz.
            ViewBag.v1 = piecevalues;

            return View();
        }
        [HttpPost]
        public IActionResult ProductAdd(Product product)
        {
            pm.TAdd(product);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = pm.GetById(id);
            List<SelectListItem> productvalues = (from x in bm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.PieceName,
                                                      Value = x.PieceID.ToString()

                                                  }).ToList();
            ViewBag.v2 = productvalues;
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            pm.TUpdate(product);
            return RedirectToAction("Index");
        }
         
        public IActionResult DeleteProduct(int id)
        {
            var productvalue = pm.GetById(id);
            pm.TDelete(productvalue);
            return RedirectToAction("Index");
        }
    }
}
