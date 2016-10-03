using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using ZenchenkoProject.Models.Repositories;
using ZenchenkoProject.Models.Repositories.Interfaces;

namespace ZenchenkoProject.Infrastructure
{
    class NinjectResolver : IDependencyResolver
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
            kernel.Bind<ICategory>().To<CategoriesRepository>();
            kernel.Bind<IService>().To<ServiceRepository>();
            kernel.Bind<IWarmFloor>().To<WarmFloorRepository>();
            kernel.Bind<INews>().To<NewsRepository>();
        }
    }
}
