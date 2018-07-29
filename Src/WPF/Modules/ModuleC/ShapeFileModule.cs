using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;
using IgOutlook.Infrastructure;

namespace ShapeFileLoader
{
    public class ShapeFileModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
      private readonly IFileToLoad _filetoLoad;
        public ShapeFileModule(IUnityContainer container, IRegionManager regionManager, IFileToLoad filetoLoad)//IFileToLoad filetoLoad)
        {
            _regionManager = regionManager;
            _container = container;
            _filetoLoad = filetoLoad;
        }
        
        public void Initialize()
        {
            //IRegion region = _regionManager.Regions[RegionNames.MapRegion];

            //region.Add(_container.Resolve<ViewMyShape>(new ParameterOverride("FileToLoad", _filetoLoad)));
        }
        
        
    }
}
