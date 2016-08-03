using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using OnlineShop.Models;
namespace OnlineShop.Infrastucture
{
    class NinjectResolver :IDependencyResolver
    {
        private IKernel kernel;
        public NinjectResolver(IKernel userKernel)
        {
            kernel = userKernel;
            AddBindings();
        }
        public object GetService(Type ServiceType)
        {
            return kernel.TryGet(ServiceType);
        }
        public IEnumerable<object> GetServices(Type ServiceType)
        {
            return kernel.GetAll(ServiceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IProductOperations>().To<ProductOperations>();
        }
    }
}
