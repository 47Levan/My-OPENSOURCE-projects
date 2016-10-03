using System.Collections.Generic;
using ZenchenkoProject.Models.Entities;

namespace ZenchenkoProject.Models.Repositories.Interfaces
{
    public interface IService
    {
        List<Service> GetAll();
    }
}
