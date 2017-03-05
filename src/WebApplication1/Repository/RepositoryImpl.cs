using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreenginex.Models;

namespace coreenginex.Repository
{
    public class CategoryRepository:ICategoryRepository,IDisposable
    {
        private ApplicationDbContext _context;
       public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

    
        public IEnumerable<Category> Get()
        {
            return _context.categories.ToList();
        }

        public Category Get(int id)
        {
            return _context.categories.Find(id);

        }

        public void Insert(Category model)
        {
            _context.categories.Add(model);
        }

        public void Update(Category model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var category = _context.categories.Find(id);
            _context.categories.Remove(category);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                this.disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CategoryRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
             GC.SuppressFinalize(this);
        }
        #endregion
    }
    public class SubCategoryRepository : ISubCategoryRepository, IDisposable
    {
        private ApplicationDbContext _context;
        public SubCategoryRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void Delete(int id)
        {
            _context.subCategories.Remove(_context.subCategories.Find(id));
        }

        public IEnumerable<SubCategory> Get()
        {
            return _context.subCategories.ToList();
        }

        public SubCategory Get(int id)
        {
            return _context.subCategories.Find(id);
        }
        /// <summary>
        /// insert data to 
        /// </summary>
        /// <param name="model"></param>
        public void Insert(SubCategory model)
        {
            if(model!=null)
            {
                _context.Entry(model.category).State = EntityState.Unchanged;
                _context.subCategories.Add(model);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(SubCategory model)
        {
            _context.Entry(model.category).State = EntityState.Unchanged;
            _context.Entry(model).State=EntityState.Modified;
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                this.disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CategoryRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
