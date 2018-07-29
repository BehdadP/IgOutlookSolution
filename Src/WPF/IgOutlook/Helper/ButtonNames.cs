using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgOutlook.Helper
{
    public class ButtonNames
    {
        public static string Button1 = "Regions";
        public static string Button2 = "Map1";
        public static string Button3 = "Map2";
        public static string Button4 = "Map3";
    }
    public class ButtonTags
    {
        private static string pathtoLoad = AppDomain.CurrentDomain.BaseDirectory+@"shapes\"; //@"C:\shapes\";
        private static string shapefileExtension=".shp";
        public static string Regions = pathtoLoad + "regions" + shapefileExtension;
        public static string Map1 = pathtoLoad + "map1"+ shapefileExtension;
        public static string Map2 = pathtoLoad + "map2" + shapefileExtension;
        public static string Map3 = pathtoLoad + "map3" + shapefileExtension;
    }
   
}
