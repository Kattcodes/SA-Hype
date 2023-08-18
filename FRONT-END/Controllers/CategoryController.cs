using B_StateOnline.Core.Models;
using B_StateOnline.DataAccess.InMemoryRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRONT_END.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository context;
        public CategoryController()
        {
            context = new CategoryRepository();
        }
        // GET: Category
        public ActionResult Index()
        {
            List<Category> categories = context.Collection().ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            else
            {
                context.Insert(category);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Category category = context.Find(Id);
            if (category == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(category);
            }
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            Category c = context.Find(category.Id);
            if (c == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }
                c.Name = category.Name;
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Category c = context.Find(Id);
            if (c == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(c);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Category c = context.Find(Id);
            if(c == null) { 
            return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                return RedirectToAction("index");
            }
        }
    }
}