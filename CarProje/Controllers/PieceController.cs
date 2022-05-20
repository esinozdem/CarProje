using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarProje.Controllers
{
    public class PieceController : Controller
    {
        PieceManager pm = new PieceManager(new PieceRepo());
        Context DB = new Context();
        public IActionResult Index()
        {
            var values = pm.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult PieceAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PieceAdd(Piece piece)
        {
            pm.TAdd(piece);
            return RedirectToAction("Index");
        }

        public IActionResult PieceDelete(int id)
        {
            var piece = pm.GetById(id);
            pm.TDelete(piece);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult PieceEdit(int id)
        {
            var piece = pm.GetById(id);
            return View(piece);
        }
        [HttpPost]
        public IActionResult PieceEdit(Piece piece)
        {
            PieceValidation pw = new PieceValidation();
            ValidationResult results = pw.Validate(piece);
            if (results.IsValid)
            {
                pm.TUpdate(piece);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }
    }
}
