using Aula1.Context;
using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aula1.Controllers
{
    public class CategoriesController : Controller
    {


        private readonly EFContext _context = new EFContext();

        public ActionResult Index()


        {
            return View(_context.Categories.OrderBy(s => s.Name));
        }


        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion


        #region Edit
        public ActionResult Edit(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categories = _context.Categories.Find(id.Value);

            if (categories == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(categories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Category categories)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(categories).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categories);

        }
        #endregion


        #region Details
        public ActionResult Details(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categories = _context.Categories.Find(id.Value);

            if (categories == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(categories);
        }
        #endregion


        #region Delete
        [HttpGet]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categories = _context.Categories.Find(id.Value);

            if (categories == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(categories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(long id)
        {
            try
            {
                Category category = _context.Categories.Find(id);
                _context.Categories.Remove(category);
                _context.SaveChanges();
                TempData["Message"] = "Categoria " + category.Name.ToUpper() + " foi removida";
                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
           

        }
        #endregion


    }

}