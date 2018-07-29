using Microsoft.Practices.Prism.Regions;
using Infragistics.Windows.OutlookBar;
using Infragistics.Windows.Ribbon;
using System;

namespace IgOutlook.Infrastructure
{
    public class XamRibbonTabRegionAdapter : RegionAdapterBase<XamRibbon>
    {

        public XamRibbonTabRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, XamRibbon regionTarget)
        {
            if (region == null) throw new ArgumentNullException("region");
            if (regionTarget == null) throw new ArgumentNullException("regionTarget");
            region.ActiveViews.CollectionChanged += (s, args) =>
            {
                if (args.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (object view in args.NewItems)
                        AddViewToRegion(view, regionTarget);
                }
                else if (args.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (object view in args.OldItems)
                        RemoveViewFromRegion(view, regionTarget);
                }
            };
        }

        private void RemoveViewFromRegion(object view, XamRibbon regionTarget)
        {
           
        }

        private void AddViewToRegion(object view, XamRibbon regionTarget)
        {
           
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
