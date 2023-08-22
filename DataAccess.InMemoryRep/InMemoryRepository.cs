﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using SA_Hype.Core.Contracts;
using SA_Hype.Core.Models;

namespace SA_Hype.DataAccess.InMemoryRep
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;
        public InMemoryRepository()
        {
            className= typeof(T).Name;
            items = cache[className] as List<T>;
            if(items == null)
            {
                items = new List<T>();
            }
        }
        public IQueryable<T> Collection()
        {
           return items.AsQueryable();
        }

        public void Commit()
        {
            cache[className] = items;
        }

        public void Delete(string Id)
        {
            T t = items.Find(i => i.Id == Id);
            if (t == null)
                throw new Exception(className + " Not found");
            else
                items.Remove(t);
        }

        public T Find(string Id)
        {
            T t = items.Find(i => i.Id == Id);
            if (t != null)
                return t;
            else
                throw new Exception(className + " Not Found");
        }

        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.Id == t.Id);
            if (tToUpdate != null)
                tToUpdate = t;
            else
                throw new Exception(className + " Not Found");
        }
    }

}
