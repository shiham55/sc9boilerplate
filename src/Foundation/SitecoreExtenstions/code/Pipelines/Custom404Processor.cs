using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scboilerplate.Foundation.SitecoreExtensions.Pipelines
{
    public class Custom404Processor : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            if (Sitecore.Context.Item != null || Sitecore.Context.Site == null)
            {
                return;
            }

            if (!Sitecore.Context.Site.Name.Equals("ilightSingapore2019", StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            if (string.Equals(Sitecore.Context.Site.Properties["enableCustomErrors"], "true", StringComparison.OrdinalIgnoreCase) == false)
            {
                return;
            }

            var pageNotFound = this.Get404PageItem();
            args.ProcessorItem = pageNotFound;
            Sitecore.Context.Item = pageNotFound;
        }

        protected Item Get404PageItem()
        {
            var path = Sitecore.Context.Site.StartPath + "/" + Settings.GetSetting("ilightItemNotFoundUrl", "/404");
            var item = Sitecore.Context.Database.GetItem(path);

            return item;
        }
    }
}