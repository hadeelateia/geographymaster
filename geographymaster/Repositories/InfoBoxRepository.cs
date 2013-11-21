using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geographymaster.Repositories
{
    public class InfoBoxRepository :IDisposable
    {
        private Models.GeographyMasterEntities _db = new Models.GeographyMasterEntities();

        # region -=CRUD=-
        public Models.InfoBox GetInfoBoxByID(int id)
        {
            return _db.InfoBoxes.FirstOrDefault(b => b.IdInfoBox == id);
        }

        public IEnumerable<Models.InfoBox> GetAllInfoBoxes()
        {
            return _db.InfoBoxes.ToList();
        }

        public void CreateNewInfoBox(Models.InfoBox ib)
        {
            _db.InfoBoxes.Add(ib);
            _db.SaveChanges();

        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void DeleteInfoBox(int id)
        {
            var ib = GetInfoBoxByID(id);
            _db.InfoBoxes.Remove(ib);
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