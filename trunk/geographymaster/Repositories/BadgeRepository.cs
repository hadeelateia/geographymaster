using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace geographymaster.Repositories
{
    public class BadgeRepository : IDisposable
    {
        private Models.GeographyMasterEntities _db = new Models.GeographyMasterEntities();

        # region -=CRUD=-
        public Models.Badge GetBadgeByID(int id)
        {
            return _db.Badges.FirstOrDefault(b => b.IdBadge == id);
        }

        public IEnumerable<Models.Badge> GetAllBadges()
        {
            return _db.Badges.ToList();
        }

        public void CreateNewBadge(Models.Badge badge)
        {
            _db.Badges.Add(badge);
            _db.SaveChanges();
            
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void DeleteBadge(int id)
        {
            var badge = GetBadgeByID(id);
            _db.Badges.Remove(badge);
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