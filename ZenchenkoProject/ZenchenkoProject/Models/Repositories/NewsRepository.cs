using System.Collections.Generic;
using System.Linq;
using ZenchenkoProject.Models.Entities;
using ZenchenkoProject.Models.Repositories.Interfaces;

namespace ZenchenkoProject.Models.Repositories
{
    public class NewsRepository : INews
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        public List<News> GetAll()
        {
            return _db.NewsList.ToList();
        }
    }
}
