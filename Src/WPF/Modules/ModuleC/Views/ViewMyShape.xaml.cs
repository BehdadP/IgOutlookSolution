using System;
using Microsoft.Maps.MapControl.WPF;
using IgOutlook.Infrastructure;
using Microsoft.Win32;
using ShapeFileLoader.ViewModel;
using System.Windows.Controls;

namespace ShapeFileLoader
{
    /// <summary>
    /// Interaction logic for EarthquakeLayer.xaml
    /// </summary>
    public partial class ViewMyShape : MapLayer
    {
        public ViewMyShape(IFileToLoad FileToLoad)
        {
            InitializeComponent();
            DataContext = new MyShapeViewModel(FileToLoad);
             
        }
         

    }
}
