using System.Collections.Generic;
using System.Web.Mvc;
using ZenchenkoProject.Models.Entities;
using ZenchenkoProject.Models.Repositories;
using System.Linq;
namespace ZenchenkoProject.Helpers.WarmFloorMethods
{
    public enum Border
    {
        Max,
        Min
    }
    public static class GetPrices
    {
        private  static readonly WarmFloorRepository WarmFloorRepo = new WarmFloorRepository();
        public static string GetPriceRange(this HtmlHelper helper,Border border)
        {
            
            List<WarmFloor> warmFloors = WarmFloorRepo.GetAll();
            if (border == Border.Min)
            {
                return warmFloors.Select(x => x.Price).Min().ToString();
            }
            else
            {
                return warmFloors.Select(x => x.Price).Max().ToString();
            }

        }
    }
}