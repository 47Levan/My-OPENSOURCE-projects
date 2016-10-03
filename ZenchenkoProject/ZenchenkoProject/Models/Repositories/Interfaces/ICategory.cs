using System.Collections.Generic;
using ZenchenkoProject.Models.Entities;

namespace ZenchenkoProject.Models.Repositories.Interfaces
{
    public interface ICategory
    {
        string ConvertToUnicode(string input);
        List<Category> GetAll();
    }
}
