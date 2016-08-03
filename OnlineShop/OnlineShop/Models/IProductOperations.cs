using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public interface IProductOperations
    {
        void GetByFilter(GoodsContainer1 goods,string filter);
    }
}
