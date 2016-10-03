using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ZenchenkoProject.Models.Entities;
using ZenchenkoProject.Models.Repositories.Interfaces;

namespace ZenchenkoProject.Models.Repositories
{
    public class CategoriesRepository :ICategory
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        public string ConvertToUnicode(string input)
        {
            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
                Encoding inputIncoding = Encoding.GetEncoding(input);
                Encoding utf8 = Encoding.UTF8;
                byte[] inputBytes = inputIncoding.GetBytes(input);
                byte[] outputBytes = Encoding.Convert(inputIncoding, utf8, inputBytes);
                string output = utf8.GetString(outputBytes);
                return output;
            }
            return null;
        }
        public List<Category> GetAll()
        {
            return _db.Categories.ToList<Category>();
        }
    }
}
