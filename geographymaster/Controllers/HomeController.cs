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
        InfoBoxRepository infoBoxRepository = new InfoBoxRepository();
        BadgeRepository badgeRepository = new BadgeRepository();
        ScoreRepository scoreRepository = new ScoreRepository();
        Random randNum = new Random();

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


        [HttpGet]
        public ViewResult ScorringTable()
        {
            List<Score> scores = scoreRepository.GetAllScores2();
            return View(scores);
        }
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult EnterScore()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnterScoreSubmit(Score score)
        {

            Score newScore = new Score()
            {
                PlayerName = score.PlayerName,
                Score1 = GetScore().TotalScore,
                IdBadge = 1
            };

            scoreRepository.CreateNewScore(newScore);
            scoreRepository.SaveChanges();

            return RedirectToAction("ScorringTable", "Home");

        }
        public ViewResult Category(long idCategory)
        {
            return View(new Category() { IdCategory = idCategory });
        }

        [HttpGet]
        public ActionResult Game(long idCategory, long idSubcategory)
        {
            Question question = questionRepository.GetAllQuestions(idCategory, idSubcategory);
            if (question != null)
                return View(new GameViewModel() { QuestionDetails = question, Score = GetScore().TotalScore });
            else
                return View(new GameViewModel() { QuestionDetails = new Question(), Score = GetScore().TotalScore });

        }

        [HttpGet]
        public ActionResult CheckAnswer(long idAnswer, long idQuestion)
        {
            bool localSuccess = false;
            bool newBadge = false;
            string congrats = "";
            bool masterOfAll = false;
            if (answerRepository.GetAllAnswers().Where(x => x.IdAnswer == idAnswer).SingleOrDefault().IsTrue)
            {

                int numberOfStars = questionRepository.GetQuestionByID(idQuestion).NoStars;
                long category = questionRepository.GetQuestionByID(idQuestion).IdCategory;

                Badge badge = badgeRepository.GetBadgeByCategoryID(category);
                ((ScoreSession)Session["ScoreSession"]).TotalScore = GetScore().TotalScore + numberOfStars;
                ((ScoreSession)Session["ScoreSession"]).ScoreByCategory[category] = GetScore().ScoreByCategory[category] + numberOfStars;
                if (GetScore().ScoreByCategory[category] >= 100 && GetScore().BadgeByCategory[category] == 0)
                {
                    newBadge = true;
                    GetScore().BadgeByCategory[category] = 1;
                    congrats = "Congratulations you just won the badge \n " + badge.Badge1;
                    for (int i = 1; i <= 6; i++)
                    {
                        if (GetScore().BadgeByCategory[category] == 0)
                        {
                            masterOfAll = false;
                            break;
                        }
                        masterOfAll = true;

                    }
                }

                localSuccess = true;

            }
            else
            {
                int numberOfStars = questionRepository.GetQuestionByID(idQuestion).NoStars;
                ((ScoreSession)Session["ScoreSession"]).TotalScore = GetScore().TotalScore - numberOfStars;
            }

            masterOfAll = true;

            return Json(new { success = localSuccess, score = GetScore().TotalScore, badge = newBadge, congratulations = congrats, master = masterOfAll }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetHints(long idQuestion)
        {
            List<string> localHints = new List<string>();
            foreach (Hint hint in questionRepository.GetQuestionByID(idQuestion).Hints)
            {
                localHints.Add(hint.Hint1);
            }

            return Json(new { success = localHints }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetInfoBox(long idQuestion)
        {
            string infoB = "";
            List<string> info = new List<string>();
            List<InfoBox> ls = infoBoxRepository.GetAllInfoBoxesByCategoryID(questionRepository.GetQuestionByID(idQuestion).IdCategory).ToList();

            if (ls != null && ls.Count > 0)
                infoB = ls[randNum.Next(ls.Count)].InfoBox1;

            return Json(new { success = infoB }, JsonRequestBehavior.AllowGet);
        }

        private ScoreSession GetScore()
        {
            ScoreSession score = (ScoreSession)Session["ScoreSession"];

            if (score == null)
            {
                Session["ScoreSession"] = new ScoreSession();
                Dictionary<long, int> tmp = new Dictionary<long, int>();
                Dictionary<long, int> badges = new Dictionary<long, int>();
                for (int i = 1; i <= 6; i++)
                {
                    tmp.Add(i, 0);
                    badges.Add(i, 0);

                }
                ((ScoreSession)Session["ScoreSession"]).ScoreByCategory = tmp;
                ((ScoreSession)Session["ScoreSession"]).BadgeByCategory = badges;
            }

            return (ScoreSession)Session["ScoreSession"];
        }

    }
}
