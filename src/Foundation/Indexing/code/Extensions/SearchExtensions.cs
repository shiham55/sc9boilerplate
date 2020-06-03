using Sitecore.ContentSearch;
using Sitecore.Data.Items;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scboilerplate.Foundation.Indexing.Extensions
{
    public static class SearchExtensions
    {
        public static ISearchIndex GetContextIndex(string name, string dbName = null)
        {
            if (string.IsNullOrEmpty(dbName))
            {
                dbName = Sitecore.Context.Database.Name != null ? Sitecore.Context.Database.Name : "web";
            }
            var indexName = $"scboilerplate_{name}_{dbName}_index";

            return Sitecore.ContentSearch.ContentSearchManager.GetIndex(indexName);
        }

        public static SiteInfo GetSite(this Item item)
        {
            var siteInfoList = Sitecore.Configuration.Factory.GetSiteInfoList();

            SiteInfo currentSiteinfo = null;
            var matchLength = 0;
            foreach (var siteInfo in siteInfoList)
            {
                if (item.Paths.FullPath.StartsWith(siteInfo.RootPath, StringComparison.OrdinalIgnoreCase) && siteInfo.RootPath.Length > matchLength)
                {
                    matchLength = siteInfo.RootPath.Length;
                    currentSiteinfo = siteInfo;
                }
            }
            return currentSiteinfo;
        }
    }
}