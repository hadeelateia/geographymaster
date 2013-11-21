using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geographymaster.Repositories
{
    public class UserRepository :IDisposable
    {
        private Models.GeographyMasterEntities _db = new Models.GeographyMasterEntities();

        # region -=CRUD=-
        public Models.User GetUserByID(int id)
        {
            return _db.Users.FirstOrDefault(b => b.IdUser == id);
        }

        public IEnumerable<Models.User> GetAllUsers()
        {
            return _db.Users.ToList();
        }

        public void CreateNewUser(Models.User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();

        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = GetUserByID(id);
            _db.Users.Remove(user);
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