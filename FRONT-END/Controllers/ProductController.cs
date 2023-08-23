using SA_Hype.Core.Contracts;
using SA_Hype.Core.Models;
using SA_Hype.Core.ViewModels;
using SA_Hype.DataAccess.InMemoryRep;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace FRONT_END.Controllers
{
    public class ProductController : Controller
    {

        IRepository<Product> context;
        IRepository<ProductCategory> categories;
        public ProductController(IRepository<ProductCategory> categoryContext, IRepository<Product> productContext)
        {
            context = productContext;
            categories = categoryContext;
        }

        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            //Product product = new Product();
            ProductVM v = new ProductVM();
            v.Product = new Product();
            v.Categories = categories.Collection();
            return View(v);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");
            }
        }   
        
        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);
            if(product == null) { 
                return HttpNotFound();
            }
            else
            {
                ProductVM v = new ProductVM();
                v.Product = product; 
                v.Categories = categories.Collection();
                return View(v);
            }
        }
        [HttpPost]
        public ActionResult Edit(Product product) { 
            Product p = context.Find(product.Id);
            if (p == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                p.Category = product.Category;
                p.Description = product.Description;
                p.Image = product.Image;
                p.Name = product.Name;
                p.Price = product.Price;
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Product p = context.Find(Id);
            if(p == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(p);
            }
        }
        [HttpPost]
        public ActionResult ConfirmDelete(string Id)
        {

            Product p = context.Find(Id);
            if (p == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                return RedirectToAction("Index");
            }
        }
    }
}