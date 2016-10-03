using System.Web.Mvc;
using PagedList;
using ZenchenkoProject.Models.Repositories.Interfaces;

namespace ZenchenkoProject.Controllers
{
    public class HomeController : Controller
    {
        INews NewsRepo;
        ICategory CategoryRepo;
        public HomeController(ICategory iCategory, INews iNews)
        {
            NewsRepo = iNews;
            CategoryRepo = iCategory;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult News(int? pageNumber)
        {
            if (pageNumber != null)
            {
                return View(NewsRepo.GetAll().ToPagedList((int)pageNumber, 5));
            }
            else
            {
                return View(NewsRepo.GetAll().ToPagedList(1, 5));
            }
        }
        [HttpGet]
        public ActionResult GetNews(string pageLink)
        {
            return PartialView(pageLink);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult MethodsOfDelivery()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}