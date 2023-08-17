﻿using B_StateOnline.Core.Models;
using B_StateOnline.DataAccess.InMemoryRep;
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

        ProductRepository context;
        public ProductController()
        {
            context = new ProductRepository();
        }
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
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
                return View(product);
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