using B_StateOnline.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace B_StateOnline.DataAccess.InMemoryRep
{
    public class CategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> categories;
        public CategoryRepository()
        {
            categories = cache["categories"] as List<ProductCategory>;
            if (categories == null)
            {
                categories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["categories"] = categories;
        }

        public void Insert(ProductCategory c)
        {
            categories.Add(c);
        }

        public void Update(ProductCategory c)
        {
            ProductCategory category = categories.Find(x => x.Id == c.Id);
            if (category != null)
            {
                category = c;
            }
            else
            {
                throw new Exception("Category not found");
            }
        }
        public ProductCategory Find(string Id)
        {
            ProductCategory category = categories.Find(c => c.Id == Id);
            if (category != null)
            {
                return category;
            }
            else
            {
                throw new Exception("Category was not found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return categories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory c = categories.Find(x => x.Id == Id);
            if (c != null)
            {
                categories.Remove(c);
            }
            else
            {
                throw new Exception("Category was not found");
            }
        }
    }
}
