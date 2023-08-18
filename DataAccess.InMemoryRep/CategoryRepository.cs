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
        List<Category> categories;
        public CategoryRepository()
        {
            categories = cache["categories"] as List<Category>;
            if (categories == null)
            {
                categories = new List<Category>();
            }
        }

        public void Commit()
        {
            cache["categories"] = categories;
        }

        public void Insert(Category c)
        {
            categories.Add(c);
        }

        public void Update(Category c)
        {
            Category category = categories.Find(x => x.Id == c.Id);
            if (category != null)
            {
                category = c;
            }
            else
            {
                throw new Exception("Category not found");
            }
        }
        public Category Find(string Id)
        {
            Category category = categories.Find(c => c.Id == Id);
            if (category != null)
            {
                return category;
            }
            else
            {
                throw new Exception("Category was not found");
            }
        }

        public IQueryable<Category> Collection()
        {
            return categories.AsQueryable();
        }

        public void Delete(string Id)
        {
            Category c = categories.Find(x => x.Id == Id);
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
