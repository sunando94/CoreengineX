﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreenginex.Models;

namespace coreenginex.Repository
{
   public interface ICategoryRepository:IDisposable
    {
        IEnumerable<Category> Get();
        Category Get(int id);
        void Insert(Category model);
        void Update(Category model);
        void Delete(int id);
        void Save();
    }
   public interface ISubCategoryRepository:IDisposable
    {
        IEnumerable<SubCategory> Get();
        SubCategory Get(int id);
        void Insert(SubCategory model);
        void Update(SubCategory model);
        void Delete(int id);
        void Save();

    }
    public interface IItemRepository:IDisposable
    {
         IEnumerable<Item> Get();
         Item Get(int id);
         void Insert(Item model);
         void Update(Item model);
         void Delete(int id);
         void Save();
         void AddAttributes(int id,Attributes model);
         void UpdateAttribute(int id,string key,Attributes model);
         void DeleteAttribute(int id,string key);
    }
}
