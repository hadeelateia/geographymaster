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
        UserRepository userRepository = new UserRepository();
        QuestionRepository questionRepository = new QuestionRepository();
        CategoryRepository categoryRepository = new CategoryRepository();

        [Authorize]
        [HttpPost]
        public ActionResult AddQuestion(QuestionViewModel question)
        {
            if (ModelState.IsValid)
            {
                Question newQuestion = new Question()
                {
                    IdCategory = question.CategoryId,
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
        public ActionResult AddQuestion()
        {
            return View(new QuestionViewModel() { Categories = categoryRepository.GetAllCategories() });
        }

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

        [HttpGet]
        [Authorize]
        public ViewResult ListQuestions()
        {
            IEnumerable<Question> questions = questionRepository.GetAllQuestions();
            return View(questions);
        }

        [Authorize]
        public ActionResult EditQuestion(int idQuestion)
        {
            Question activeQuestion = questionRepository.GetQuestionByID(idQuestion);
            IEnumerable<Category> activeCategories = categoryRepository.GetAllCategories();

            return View(new QuestionViewModel() { QuestionDetails = activeQuestion, Categories = activeCategories, QuestionId = idQuestion });
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditQuestion(QuestionViewModel question)
        {
            Question activeQuestion = questionRepository.GetQuestionByID(question.QuestionId);

            if (activeQuestion != null && question.QuestionDetails.Question1 != null)
            {
                activeQuestion.IdCategory = question.CategoryId;
                activeQuestion.NoStars = question.QuestionDetails.NoStars;
                activeQuestion.Question1 = question.QuestionDetails.Question1;

                questionRepository.SaveChanges();
            }

            return RedirectToAction("ListQuestions", "Admin");
        }

        [HttpGet]
        [Authorize]
        public ActionResult DetailsQuestion(long idQuestion)
        {
            Question activeQuestion = questionRepository.GetQuestionByID(idQuestion);

            return View(activeQuestion);
        }

        [Authorize]
        public ActionResult DeleteQuestion(long idQuestion)
        {
            questionRepository.DeleteQuestion(idQuestion);
            questionRepository.SaveChanges();

            return RedirectToAction("ListQuestions", "Admin");
        }
    }
}
