using System.Collections.Generic;
using ZenchenkoProject.Models.Entities;

namespace ZenchenkoProject.Models.Repositories.Interfaces
{
    public interface IWarmFloor
    {
        List<WarmFloor> GetAll();
        WarmFloor GetById(int Id);
    }
}
