using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.InMemoryRep
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;
        public ProductRepository()
        {
             products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }

        public void Commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product p)
        {
            products.Add(p);
        }

        public void Update(Product p)
        {
            Product product = products.Find(x => x.Id == p.Id);
            if(product != null)
            {
                product = p;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
        public Product Find(string Id)
        {
            Product product = products.Find(p => p.Id == Id);
            if(product != null) {
                return product;
            }
            else
            {
                throw new Exception("Product was not found");
            }
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string Id)
        {
            Product p = products.Find(x => x.Id == Id);
            if(p != null)
            {
                products.Remove(p);
            }
            else
            {
                throw new Exception("Product was not found");
            }
        }
    }
}
