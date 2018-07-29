
using IgOutlook.Helper;
using IgOutlook.Infrastructure;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using ShapeFileLoader;

namespace IgOutlook.ViewModels
{
    public class ButtonListUCViewModel 
    {
        public DelegateCommand<string> LoadMapCommand { get; set; }
       
        private readonly IUnityContainer _container;
        private readonly IServiceLocator _svc;
        public ButtonListUCViewModel()
        {
            InitButtons();
            LoadMapCommand = new DelegateCommand<string>(LoadMap, CanExecute);
            _svc = ServiceLocator.Current;
            _container=_svc.GetInstance<IUnityContainer>();
        }
       
        private bool CanExecute(string arg)
        {
            return true;
        }

        private void LoadMap(string map)
        {
           if (map != null)
            {
                
                var file = new FileToLoad();
                file.FileName = map;

                //_container.RegisterInstance(typeof(IFileToLoad), file);
                var moduleManager = _svc.GetInstance<IModuleManager>();
                var regionManager= _svc.GetInstance<IRegionManager>();
                var region = regionManager.Regions[RegionNames.MapRegion];

                region.Add(_container.Resolve<ViewMyShape>(new ParameterOverride("FileToLoad", file)));
               // moduleManager.LoadModule("ShapeFileModule");
                //moduleManager.Run();
                //string msg = string.Format("You Pressed : {0} button", map);
                //MessageBox.Show(msg);
            }
        }
        
        private List<LayerItem> layerbuttonList = new List<LayerItem>();
        public List<LayerItem> LayerButtonList
        {
            get
            {
                return layerbuttonList;
            }
            set
            {
                layerbuttonList = value;
               
            }
        }
        private void InitButtons()
        {
            LayerItem item1 = new LayerItem();
            LayerItem item2 = new LayerItem();
            LayerItem item3 = new LayerItem();


            item1.ButtonContent = ButtonNames.Button1;
            item1.ButtonTag = ButtonTags.Regions;

            item2.ButtonContent = ButtonNames.Button2;
            item2.ButtonTag = ButtonTags.Map1;

            item3.ButtonContent = ButtonNames.Button3;
            item3.ButtonTag = ButtonTags.Map2;



            LayerButtonList = new List<LayerItem>();           // Intialize the button list

            LayerButtonList.Add(item1);
            LayerButtonList.Add(item2);
            LayerButtonList.Add(item3);
        }

    }
       
        
   

    public class LayerItem
    {
        public string ButtonContent { get; set; }
        public string ButtonTag { get; set; }
    }

   
}
