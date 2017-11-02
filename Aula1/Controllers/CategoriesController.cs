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


        // GET: Categories
        public ActionResult Index()

        {
            return View(_context.Categories.OrderBy(s => s.Name));
        }

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

        public ActionResult Edit(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var category = _context.Categories.Find(id.Value);


            if (category == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier category)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(category).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }

    }

    /*private static IList<Category> categoryList =
        new List<Category>()
        {
            new Category() {CategoryId = 1, Name = "Laptop" },
            new Category() {CategoryId = 2, Name = "Monitor" },
            new Category() {CategoryId = 3, Name = "Kayboard" },
            new Category() {CategoryId = 4, Name = "Mouse" },
        };


    // GET: Categories
    public ActionResult Index()


    {
        return View(categoryList);
    }


    public ActionResult Details(long id)
    {
        var category = categoryList.Where(c => c.CategoryId == id).First();

        return View(category);
    }

    //GET: Create
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Category category)
    {

        categoryList.Add(category);
        category.CategoryId = categoryList.Max(c => c.CategoryId) + 1;
        return RedirectToAction("Create");
    }

    public ActionResult Edit(long id)
    {
        var category = categoryList.Where(c => c.CategoryId == id).First();

        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Category modified)
    {

        var category = categoryList.Where(c => c.CategoryId == modified.
        CategoryId).First();

        category.Name = modified.Name;

        return RedirectToAction("Index");
    }


    public ActionResult Delete(long id)
    {
        var category = categoryList.Where(c => c.CategoryId == id).First();

        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Category toDelete)
    {

        var category = categoryList.Where(c => c.CategoryId == toDelete.
        CategoryId).First();


        categoryList.Remove(category);

        return RedirectToAction("Index");
    }


}*/

}

