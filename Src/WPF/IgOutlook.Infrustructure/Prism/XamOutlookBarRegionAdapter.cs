using Microsoft.Practices.Prism.Regions;
using Infragistics.Windows.OutlookBar;

namespace IgOutlook.Infrastructure
{
    public class XamOutlookBarRegionAdapter : RegionAdapterBase<XamOutlookBar>
    {

        public XamOutlookBarRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, XamOutlookBar regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (OutlookBarGroup element in e.NewItems)
                        regionTarget.Groups.Add(element);
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (OutlookBarGroup element in e.OldItems)
                        if (regionTarget.Groups.Contains(element))
                            regionTarget.Groups.Remove(element);
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
