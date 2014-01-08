using geographymaster.Models;
using geographymaster.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace geographymaster.Controllers
{
    public class AdminController : Controller
    {
        #region Properties

        UserRepository userRepository = new UserRepository();
        QuestionRepository questionRepository = new QuestionRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        SubcategoryRepository subcategoryRepository = new SubcategoryRepository();
        AnswerRepository answerRepository = new AnswerRepository();
        HintRepository hintRepository = new HintRepository();
        InfoBoxRepository infoboxRepository = new InfoBoxRepository();

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

        #region Login

        [HttpGet]
        public ViewResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var activeUser = userRepository.GetUserByUsername(model.Username);

                if (Membership.ValidateUser(model.Username, model.Password))
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();

                    string userData = serializer.Serialize(model);

                    FormsAuthenticationTicket authTicket =
                    new FormsAuthenticationTicket(1,
                                                        activeUser.Username,
                                                        DateTime.Now,
                                                        DateTime.Now.AddMinutes(45),
                                                        model.RememberMe,
                                                        userData);
                    string encTicket = FormsAuthentication.Encrypt(authTicket);

                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);

                    return RedirectToAction("ListQuestions", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        #endregion

        #region Question

        [HttpGet]
        [Authorize]
        public ViewResult ListQuestions()
        {
            IEnumerable<Question> questions = questionRepository.GetAllQuestions();
            return View(questions);
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddQuestion()
        {
            return View(new QuestionViewModel()
            {
                Categories = GetActiveCategories(),
                Subcategories = GetActiveSubcategories()
            });
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddQuestion(QuestionViewModel question)
        {
            if (ModelState.IsValid)
            {
                Question newQuestion = new Question()
                {
                    IdCategory = question.CategoryId,
                    IdSubcategory = question.SubcatetegoryId,
                    Question1 = question.QuestionDetails.Question1,
                    NoStars = question.QuestionDetails.NoStars
                };

                questionRepository.CreateNewQuestion(newQuestion);
                questionRepository.SaveChanges();

                return RedirectToAction("ListQuestions", "Admin");
            }
            else
            {
                return RedirectToAction("AddQuestion", "Admin");
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditQuestion(long idQuestion)
        {
            Question activeQuestion = questionRepository.GetQuestionByID(idQuestion);

            return View(new QuestionViewModel()
            {
                QuestionDetails = activeQuestion,
                Categories = GetActiveCategories(),
                Subcategories = GetActiveSubcategories(),
                QuestionId = idQuestion,
                SubcatetegoryId = activeQuestion.IdSubcategory,
                CategoryId = activeQuestion.IdCategory
            });
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditQuestion(QuestionViewModel question)
        {
            Question activeQuestion = questionRepository.GetQuestionByID(question.QuestionId);

            if (activeQuestion != null && question.QuestionDetails.Question1 != null)
            {
                activeQuestion.IdCategory = question.CategoryId;
                activeQuestion.IdSubcategory = question.SubcatetegoryId;
                activeQuestion.NoStars = question.QuestionDetails.NoStars;
                activeQuestion.Question1 = question.QuestionDetails.Question1;

                questionRepository.SaveChanges();
            }

            return RedirectToAction("ListQuestions", "Admin");
        }

        [Authorize]
        [HttpGet]
        public ActionResult DetailsQuestion(long idQuestion)
        {
            Question activeQuestion = questionRepository.GetQuestionByID(idQuestion);

            return View(activeQuestion);
        }

        [Authorize]
        [HttpGet]
        public ActionResult DeleteQuestion(long idQuestion)
        {
            questionRepository.DeleteQuestion(idQuestion);
            questionRepository.SaveChanges();

            return RedirectToAction("ListQuestions", "Admin");
        }

        #endregion

        #region Answer

        [Authorize]
        [HttpGet]
        public ViewResult ListAnswers(long idQuestion)
        {
            IEnumerable<Answer> answers = answerRepository.GetAllAnswers().Where(x => x.IdQuestion == idQuestion);

            return View(new AnswerViewModel() { Answers = answers, IdQuestion = idQuestion });
        }

        [Authorize]
        [HttpGet]
        public ViewResult AddAnswer(long idQuestion)
        {
            return View(new AnswerViewModel()
            {
                QuestionDescription = questionRepository.GetAllQuestions()
                            .Where(x => x.IdQuestion == idQuestion)
                            .SingleOrDefault().Question1,
                IdQuestion = idQuestion
            });
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddAnswer(AnswerViewModel answer)
        {
            if (ModelState.IsValid)
            {
                Answer newAnswer = new Answer()
                {
                    IdQuestion = answer.IdQuestion,
                    AnswerDescription = answer.AnswerDescription,
                    IsTrue = answer.IsTrue
                };

                answerRepository.CreateNewAnswer(newAnswer);
                answerRepository.SaveChanges();

                return RedirectToAction("ListAnswers", "Admin", new { idQuestion = answer.IdQuestion });
            }
            else
            {
                return RedirectToAction("AddAnswer", "Admin");
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditAnswer(int idAnswer)
        {
            Answer activeAnswer = answerRepository.GetAnswerByID(idAnswer);

            return View(new AnswerViewModel()
            {
                AnswerDescription = activeAnswer.AnswerDescription,
                IsTrue = activeAnswer.IsTrue,
                IdQuestion = activeAnswer.IdQuestion
            });
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditAnswer(AnswerViewModel answer)
        {
            Answer activeAnswer = answerRepository.GetAnswerByID(answer.IdAnswer);

            if (activeAnswer != null && answer.AnswerDescription != null)
            {
                activeAnswer.AnswerDescription = answer.AnswerDescription;
                activeAnswer.IsTrue = answer.IsTrue;

                answerRepository.SaveChanges();
            }

            return RedirectToAction("ListAnswers", "Admin", new { idQuestion = answer.IdQuestion });
        }

        [Authorize]
        [HttpGet]
        public ActionResult DeleteAnswer(long idAnswer)
        {
            long id = answerRepository.GetAnswerByID(idAnswer).IdQuestion;

            answerRepository.DeleteAnswer(idAnswer);
            answerRepository.SaveChanges();

            return RedirectToAction("ListAnswers", "Admin", new { idQuestion = id });
        }

        #endregion

        #region Hints

        [Authorize]
        [HttpGet]
        public ViewResult ListHints(long idQuestion)
        {
            IEnumerable<Hint> hints = hintRepository.GetAllHints().Where(x => x.IdQuestion == idQuestion);

            return View(new HintViewModel() { Hints = hints, IdQuestion = idQuestion });
        }

        [Authorize]
        [HttpGet]
        public ViewResult AddHint(long idQuestion)
        {
            return View(new HintViewModel()
            {
                QuestionDescription = questionRepository.GetAllQuestions()
                            .Where(x => x.IdQuestion == idQuestion)
                            .SingleOrDefault().Question1,
                IdQuestion = idQuestion
            });
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddHint(HintViewModel hint)
        {
            if (ModelState.IsValid)
            {
                Hint newHint = new Hint()
                {
                    IdQuestion = hint.IdQuestion,
                    Hint1 = hint.HintDescription
                };

                hintRepository.CreateNewHint(newHint);
                hintRepository.SaveChanges();

                return RedirectToAction("ListHints", "Admin", new { idQuestion = hint.IdQuestion });
            }
            else
            {
                return RedirectToAction("AddHint", "Admin");
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditHint(int idHint)
        {
            Hint activeHint = hintRepository.GetHintByID(idHint);

            return View(new HintViewModel()
            {
                HintDescription = activeHint.Hint1,
                IdQuestion = activeHint.IdQuestion
            });
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditHint(HintViewModel hint)
        {
            Hint activeHint = hintRepository.GetHintByID(hint.IdHint);

            if (activeHint != null && activeHint.Hint1 != null)
            {
                activeHint.Hint1 = hint.HintDescription;
                activeHint.IdQuestion = hint.IdQuestion;

                hintRepository.SaveChanges();
            }

            return RedirectToAction("ListHints", "Admin", new { idQuestion = hint.IdQuestion });
        }

        [Authorize]
        [HttpGet]
        public ActionResult DeleteHint(long idHint)
        {
            long id = hintRepository.GetHintByID(idHint).IdQuestion;

            hintRepository.DeleteHint(idHint);
            hintRepository.SaveChanges();

            return RedirectToAction("ListHints", "Admin", new { idQuestion = id });
        }

        #endregion

        #region Infoboxes

        [Authorize]
        [HttpGet]
        public ActionResult ListInfoboxes()
        {
            return View(infoboxRepository.GetAllInfoBoxes());
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddInfobox()
        {
            return View(new InfoboxViewModel() { Categories = GetActiveCategories() });
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddInfobox(InfoboxViewModel infobox)
        {
            if (ModelState.IsValid)
            {
                InfoBox newInfobox = new InfoBox()
                {
                    IdCategory = infobox.IdCategory,
                    InfoBox1 = infobox.InfoBoxDescription
                };

                infoboxRepository.CreateNewInfoBox(newInfobox);
                infoboxRepository.SaveChanges();

                return RedirectToAction("ListInfoboxes", "Admin");
            }
            else
            {
                return RedirectToAction("AddInfobox", "Admin");
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditInfobox(long idInfobox)
        {
            InfoBox activeInfobox = infoboxRepository.GetInfoBoxByID(idInfobox);

            return View(new InfoboxViewModel()
            {
                InfoBoxDescription = activeInfobox.InfoBox1,
                Categories = GetActiveCategories(),
                IdInfoBox = idInfobox
            });
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditInfobox(InfoboxViewModel infobox)
        {
            InfoBox activeInfobox = infoboxRepository.GetInfoBoxByID(infobox.IdInfoBox);

            if (activeInfobox != null && activeInfobox.InfoBox1 != null)
            {
                activeInfobox.IdCategory = infobox.IdCategory;
                activeInfobox.InfoBox1 = infobox.InfoBoxDescription;

                infoboxRepository.SaveChanges();
            }

            return RedirectToAction("ListInfoboxes", "Admin");
        }

        [Authorize]
        [HttpGet]
        public ActionResult DeleteInfobox(long idInfobox)
        {
            infoboxRepository.DeleteInfoBox(idInfobox);
            infoboxRepository.SaveChanges();

            return RedirectToAction("ListInfoboxes", "Admin");
        }

        #endregion
    }
}
