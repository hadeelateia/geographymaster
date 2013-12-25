using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geographymaster.Repositories
{
    public class ScoreRepository
    {
        private Models.GeographyMasterEntities _db = new Models.GeographyMasterEntities();

        # region -=CRUD=-
        public Models.Score GetScoreByID(int id)
        {
            return _db.Scores.FirstOrDefault(b => b.IdScore == id);
        }

        public IEnumerable<Models.Score> GetAllScores()
        {
            return _db.Scores.ToList();
        }
        public List<Models.Score> GetAllScores2()
        {
            return _db.Scores.OrderByDescending(s => s.Score1).Take(20).ToList();
        }

        public void CreateNewScore(Models.Score score)
        {
            _db.Scores.Add(score);
            _db.SaveChanges();

        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void DeleteScore(int id)
        {
            var score = GetScoreByID(id);
            _db.Scores.Remove(score);
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