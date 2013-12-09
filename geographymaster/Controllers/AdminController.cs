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
        CategoryRepository questionCategory = new CategoryRepository();

        [Authorize]
        [HttpPost]
        public ActionResult AddQuestion(Question question)
        {
            questionRepository.CreateNewQuestion(question);
            questionRepository.SaveChanges();

            return RedirectToAction("ListQuestions", "Admin");
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddQuestion()
        {
            return View(new Question());
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
            
            return View(activeQuestion);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditQuestion(Question question, long idCategory)
        {
            Question activeQuestion = questionRepository.GetQuestionByID(question.IdQuestion);

            activeQuestion.IdCategory = idCategory;
            activeQuestion.NoStars = question.NoStars;
            activeQuestion.Question1 = question.Question1;

            questionRepository.SaveChanges();

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
