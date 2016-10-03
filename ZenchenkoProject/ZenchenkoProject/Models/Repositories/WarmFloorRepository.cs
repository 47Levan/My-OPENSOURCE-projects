using System.Collections.Generic;
using System.Linq;
using ZenchenkoProject.Models.Entities;
using ZenchenkoProject.Models.Repositories.Interfaces;

namespace ZenchenkoProject.Models.Repositories
{
    public class WarmFloorRepository : IWarmFloor
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        public List<WarmFloor> GetAll()
        {
            return _db.WarmFloors.ToList<WarmFloor>();
        }

        public WarmFloor GetById(int Id)
        {
            return _db.WarmFloors.FirstOrDefault(x=>x.Id==Id);
        }
    }
}
