using scboilerplate.Foundation.Indexing.Extensions;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Links;
using Sitecore.Resources.Media;
using Sitecore.Sites;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scboilerplate.Foundation.Indexing.ComputedFields
{
    public class ItemUrlIndexField : IComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Item item = (Item)(indexable as SitecoreIndexableItem);

            if (item == null)
                return (object)null;

            if (item.Paths.IsMediaItem)
                return (object)MediaManager.GetMediaUrl((MediaItem)item);

            UrlOptions defaultUrlOptions = LinkManager.GetDefaultUrlOptions();

            defaultUrlOptions.Site = Sitecore.Configuration.Factory.GetSite("ilightsingapore2019");
            defaultUrlOptions.AlwaysIncludeServerUrl = false;
            defaultUrlOptions.LanguageEmbedding = LanguageEmbedding.Never;


            string url = LinkManager.GetItemUrl(item, defaultUrlOptions);

            //hack: last minute fix, not the best thing to do
            if (url.ToLower().StartsWith("://"+ defaultUrlOptions.Site.HostName))
            {
                url = url.ToLower().Replace("://" + defaultUrlOptions.Site.HostName, "");
            }

            return url;
        }
    }

   
}