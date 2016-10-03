using System.Collections.Generic;
using System.Linq;
using ZenchenkoProject.Models.Entities;
using ZenchenkoProject.Models.Repositories.Interfaces;

namespace ZenchenkoProject.Models.Repositories
{
    public class ServiceRepository :IService
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        public List<Service> GetAll()
        {
            return _db.Services.ToList<Service>();
        }
    }
}
