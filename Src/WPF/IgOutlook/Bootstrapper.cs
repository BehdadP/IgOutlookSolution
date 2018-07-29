using System.Windows;
using Microsoft.Practices.Unity;
using Infragistics.Windows.Ribbon;
using Infragistics.Windows.OutlookBar;
using IgOutlook.Infrastructure;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;

namespace IgOutlook
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();
//#if SILVERLIGHT
//            Application.Current.RootVisual =(UIElement) Shell;
//#else
            Application.Current.MainWindow =(XamRibbonWindow) Shell;
            Application.Current.MainWindow.Show();
//#endif
        }
        protected override IModuleCatalog CreateModuleCatalog()
        {
            ModuleCatalog catalog = new ModuleCatalog();
   
            catalog.AddModule(typeof(ShapeFileLoader.ShapeFileModule),InitializationMode.OnDemand);
            return catalog;
        }
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(XamOutlookBar), Container.Resolve<XamOutlookBarRegionAdapter>());
            mappings.RegisterMapping(typeof(XamRibbon), Container.Resolve<XamRibbonTabRegionAdapter>());
            mappings.RegisterMapping(typeof(Map), Container.Resolve<MapRegionAdapter>());
            return mappings;
        }
       
    }
}
