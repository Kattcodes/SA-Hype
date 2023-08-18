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
    }
}