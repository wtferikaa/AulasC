using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aula1.Context;
using Aula1.Models;

namespace Aula1.Controllers
{
    public class ProductsController : Controller
    {
        private EFContext _context = new EFContext();
        //	GET:	Produtos
        public ActionResult Index()
        {
            var products = _context.Products.Include(c => c.Category).Include(s => s.Supplier).OrderBy(n => n.Name);
            return View(products);
        }


        //	GET:	Produtos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.
                                BadRequest);
            }
            Product product = _context.Products.Where(p => p.ProductId == id).Include(c => c.Category).Include(s => s.Supplier).First();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //	GET:	Produtos/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories.OrderBy(n => n.Name), "CategoryId", "Name");
            ViewBag.SupplierId = new SelectList(_context.Suppliers.OrderBy(n => n.Name), "SupplierId", "Name");
            return View();
        }

        //	POST:	Produtos/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }


        //	GET:	Produtos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(_context.Categories.OrderBy(n => n.Name), "CategoryId", "Name", product.CategoryId);
            ViewBag.SupplierId = new SelectList(_context.Suppliers.OrderBy(n => n.Name), "SupplierId", "Name", product.SupplierId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(product).State = EntityState.Modified;
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        //	GET:	Produtos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _context.Products.Where(p => p.ProductId == id).Include(c => c.Category).Include(s => s.Supplier).First();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //	POST:	Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            
                Product product = _context.Products.Find(id);
                _context.Products.Remove(product);
                _context.SaveChanges();
                TempData["Message"] = "Produto	" + product.Name.ToUpper() + "	foi	removido";
                return RedirectToAction("Index");
            
            }
        }
    }
