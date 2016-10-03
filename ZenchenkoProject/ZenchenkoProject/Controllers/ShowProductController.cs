using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenchenkoProject.Models.Repositories.Interfaces;

namespace ZenchenkoProject.Controllers
{
    public class ShowProductController : Controller
    {
        public ShowProductController(IWarmFloor iWarmFloor)
        {
            warmFloorRepo = iWarmFloor;
        }
        IWarmFloor warmFloorRepo;
        // GET: ShowProduct
        public ActionResult WarmFloor(int? WarmFloorId)
        {
            if (WarmFloorId != null)
            {
                return View(warmFloorRepo.GetById((int) WarmFloorId));
            }
            else
            {
                return RedirectToAction("WarmFloor", "Categories",new { pageNumber=1});
            }
        }
        public ActionResult ShowCharacteristics(int? WarmFloorId)
        {
            if (WarmFloorId != null)
            {
                return PartialView(warmFloorRepo.GetById((int)WarmFloorId));
            }
            else
            {
                return RedirectToAction("WarmFloor", "Categories", new { pageNumber = 1 });
            }
        }
    }
}