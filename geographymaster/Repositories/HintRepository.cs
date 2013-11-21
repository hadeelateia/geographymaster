using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geographymaster.Repositories
{
    public class HintRepository:IDisposable
    {
        private Models.GeographyMasterEntities _db = new Models.GeographyMasterEntities();

        # region -=CRUD=-
        public Models.Hint GetHintByID(int id)
        {
            return _db.Hints.FirstOrDefault(b => b.IdHint == id);
        }

        public IEnumerable<Models.Hint> GetAllHints()
        {
            return _db.Hints.ToList();
        }

        public void CreateNewHint(Models.Hint hint)
        {
            _db.Hints.Add(hint);
            _db.SaveChanges();

        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void DeleteHint(int id)
        {
            var hint = GetHintByID(id);
            _db.Hints.Remove(hint);
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