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
        public ActionResult ShowPicture(int ImageDataId)
        {
            using (GoodsContainer1 goods=new GoodsContainer1())
            {
                byte[] imageData = goods.ProductSet.FirstOrDefault(x=>x.Id==ImageDataId).Picture;
                return File(imageData, "image/jpg");
            }
               
        }
    }
}