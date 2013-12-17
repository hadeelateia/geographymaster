using geographymaster.Models;
using geographymaster.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace geographymaster.Controllers
{
    public class HomeController : Controller
    {
        #region Properties

        QuestionRepository questionRepository = new QuestionRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        SubcategoryRepository subcategoryRepository = new SubcategoryRepository();
        AnswerRepository answerRepository = new AnswerRepository();

        public IEnumerable<Category> activeCategories;
        public IEnumerable<Subcategory> activeSubcategories;

        #endregion

        public IEnumerable<Category> GetActiveCategories()
        {
            return activeCategories = categoryRepository.GetAllCategories();
        }

        public IEnumerable<Subcategory> GetActiveSubcategories()
        {
            return activeSubcategories = subcategoryRepository.GetAllSubCategories();
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Category(long idCategory)
        {
            return View(new Category() { IdCategory = idCategory });
        }

        [HttpGet]
        public ActionResult Game(long idCategory, long idSubcategory)
        {
            Question question = questionRepository.GetAllQuestions(idCategory, idSubcategory);

            return View(new GameViewModel() { QuestionDetails = question, Score = GetScore() });
        }

        [HttpGet]
        public ActionResult CheckAnswer(long idAnswer, long idQuestion)
        {
            bool localSuccess = false;

            if (answerRepository.GetAllAnswers().Where(x => x.IdAnswer == idAnswer).SingleOrDefault().IsTrue)
            {
                int numberOfStars = questionRepository.GetQuestionByID(idQuestion).NoStars;
                Session["Score"] = GetScore() + numberOfStars;

                localSuccess = true;

            }

            return Json(new { success = localSuccess, score = GetScore() }, JsonRequestBehavior.AllowGet);
        }

        private int GetScore()
        {
            int? score = (int?)Session["Score"];

            if (score == null)
            {
                Session["Score"] = 0;
            }

            return (int)Session["Score"];
        }
    }
}
