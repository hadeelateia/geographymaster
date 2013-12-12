using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geographymaster.Repositories
{
    public class AnswerRepository
    {
        private Models.GeographyMasterEntities _db = new Models.GeographyMasterEntities();

        # region -=CRUD=-
        public Models.Answer GetAnswerByID(long id)
        {
            return _db.Answers.FirstOrDefault(b => b.IdAnswer == id);
        }

        public IEnumerable<Models.Answer> GetAllAnswers()
        {
            return _db.Answers.ToList();
        }

        public void CreateNewAnswer(Models.Answer answer)
        {
            _db.Answers.Add(answer);
            _db.SaveChanges();

        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void DeleteAnswer(long id)
        {
            var answer = GetAnswerByID(id);
            _db.Answers.Remove(answer);
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