using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geographymaster.Repositories
{
    public class QuestionRepository : IDisposable
    {
        private Models.GeographyMasterEntities _db = new Models.GeographyMasterEntities();

        private Random random = new Random();

        # region -=CRUD=-
        public Models.Question GetQuestionByID(long id)
        {
            return _db.Questions.FirstOrDefault(b => b.IdQuestion == id);
        }

        public IEnumerable<Models.Question> GetAllQuestions()
        {
            return _db.Questions.ToList();
        }

        public Models.Question GetAllQuestions(long idCategory, long idSubcategory)
        {
            List<long> ids = new List<long>();
            var questions = _db.Questions.Where(x => x.IdCategory == idCategory && x.IdSubcategory == idSubcategory);
            foreach (var question in questions)
                ids.Add(question.IdQuestion);

            var randomNumber = random.Next(0, ids.Count() - 1);

            return questions.ToList().ElementAt(randomNumber);
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