using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geographymaster.Repositories
{
    public class CategoryRepository:IDisposable
    {
        private Models.GeographyMasterEntities _db = new Models.GeographyMasterEntities();

        # region -=CRUD=-
        public Models.Category GetCategoryByID(long id)
        {
            return _db.Categories.FirstOrDefault(b => b.IdCategory == id);
        }

        public IEnumerable<Models.Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }

        public void CreateNewCategory(Models.Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();

        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = GetCategoryByID(id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        # endregion

        # region -=util=-

        # endregion
    }
}