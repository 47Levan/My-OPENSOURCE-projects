using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
namespace OnlineShop.Controllers
{
    public class FileOperController : Controller
    {
        // GET: FileOper
        public ActionResult ShowPicture(byte[] imageData)
        {
            return File(imageData,"image/jpg");
        }
    }
}