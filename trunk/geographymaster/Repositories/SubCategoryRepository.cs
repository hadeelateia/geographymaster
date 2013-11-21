using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geographymaster.Repositories
{
    public class SubCategoryRepository
    {
        private Models.GeographyMasterEntities _db = new Models.GeographyMasterEntities();

        # region -=CRUD=-
        public Models.Subcategory GetSubCategoryByID(int id)
        {
            return _db.Subcategories.FirstOrDefault(b => b.IdSubcategory == id);
        }

        public IEnumerable<Models.Subcategory> GetAllSubCategories()
        {
            return _db.Subcategories.ToList();
        }

        public void CreateNewSubCategory(Models.Subcategory subcategory)
        {
            _db.Subcategories.Add(subcategory);
            _db.SaveChanges();

        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void DeleteSubCategory(int id)
        {
            var subcategory = GetSubCategoryByID(id);
            _db.Subcategories.Remove(subcategory);
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