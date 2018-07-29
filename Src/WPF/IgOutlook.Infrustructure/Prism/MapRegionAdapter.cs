using System;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Maps.MapControl.WPF;
using System.Windows;

namespace IgOutlook.Infrastructure
{
    public class MapRegionAdapter : RegionAdapterBase<Map>
    {
        public MapRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, Map regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement element in e.NewItems)
                        regionTarget.Children.Add(element);
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (FrameworkElement element in e.OldItems)
                        if (regionTarget.Children.Contains(element))
                            regionTarget.Children.Remove(element);
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
