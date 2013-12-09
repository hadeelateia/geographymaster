using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geographymaster.Repositories
{
    public class QuestionRepository : IDisposable
    {
        private Models.GeographyMasterEntities _db = new Models.GeographyMasterEntities();

        # region -=CRUD=-
        public Models.Question GetQuestionByID(long id)
        {
            return _db.Questions.FirstOrDefault(b => b.IdQuestion == id);
        }

        public IEnumerable<Models.Question> GetAllQuestions()
        {
            return _db.Questions.ToList();
        }

        public void CreateNewQuestion(Models.Question question)
        {
            _db.Questions.Add(question);
            _db.SaveChanges();

        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void DeleteQuestion(long id)
        {
            var question = GetQuestionByID(id);
            _db.Questions.Remove(question);
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