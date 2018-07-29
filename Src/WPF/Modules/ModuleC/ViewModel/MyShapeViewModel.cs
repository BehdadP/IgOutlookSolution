using IgOutlook.Infrastructure;
using Microsoft.Maps.MapControl.WPF;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace ShapeFileLoader.ViewModel
{
    public class MyShapeViewModel : INotifyPropertyChanged
    {

  

        private Collection<LocationCollection> _polygons;
        public Collection<LocationCollection> Polygons
        {
            get { return _polygons; }
            set
            {
                _polygons = value;
                OnPropertyChanged("Polygons");
            }
        }

        public MyShapeViewModel(IFileToLoad FileToLoad)
        {
            Polygons = new Collection<LocationCollection>();
            
            using (Shapefile shapefile = new Shapefile(FileToLoad.FileName))
            {
                foreach(Shape s in shapefile)
                {
                    var mapPloygon = Helper.ConvertShapePolygonToMapPolygon(s);
                    foreach (MapPolygon m in mapPloygon)
                    {
                        Polygons.Add(m.Locations);
                    }
                  
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
