using System.Web.Mvc;
using PagedList;
using ZenchenkoProject.Models.Entities;
using ZenchenkoProject.Models.Repositories.Interfaces;
namespace ZenchenkoProject.Controllers
{
    public class CategoriesController : Controller
    {
       private readonly IWarmFloor _warmFloorRepo;
        public CategoriesController(IWarmFloor iWarmFloor)
        {
            _warmFloorRepo = iWarmFloor;
        }
        // GET: Categories
        [HttpGet]
        public ActionResult WarmFloor(int? pageNumber)
        {
            if (pageNumber == null)
            {
                return View(_warmFloorRepo.GetAll().ToPagedList(1, 20));
            }
            else
            {
                return View(_warmFloorRepo.GetAll().ToPagedList((int)pageNumber, 20));
            }
        }
        [HttpPost]
        public ActionResult UpdateWarmFloor(WarmFloor model,int? minPrice,int? maxPrice)
        {

            return PartialView("~/Views/Categories/PartialViews/WarmFloor.cshtml");
        }
    }


}