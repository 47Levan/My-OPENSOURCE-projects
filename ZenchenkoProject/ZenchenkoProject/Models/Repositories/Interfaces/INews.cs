using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenchenkoProject.Models.Entities;

namespace ZenchenkoProject.Models.Repositories.Interfaces
{
    public interface INews
    {
        List<News> GetAll();
    }
}
