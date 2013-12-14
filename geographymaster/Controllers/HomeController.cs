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

            return View(question);
        }

        [HttpGet]
        public ActionResult CheckAnswer(long idAnswer, long idQuestion)
        {
            if (answerRepository.GetAllAnswers().Where(x => x.IdAnswer == idAnswer).SingleOrDefault().IsTrue)
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false }, JsonRequestBehavior.AllowGet); ;
        }
    }
}
