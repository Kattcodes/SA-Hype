using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using B_StateOnline.DataAccess.InMemoryRep;

namespace B_StateOnline.UI.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository context;
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
    }
}