using Sitecore.ContentSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scboilerplate.Foundation.Indexing.SearchModels
{
    public class CategoryListingIndexItem : IndexBase
    {
        [IndexField("Navigation Title")]
        public string NavigationTitle { get; set; }

        [IndexField("Show on Map Top Row")]
        public bool ShowOnMapTopRow { get; set; }

        [IndexField("Show In Navigation")]
        public bool ShowInNavigation { get; set; }

        [IndexField("Icon Class")]
        public string IconClass { get; set; }

        [IndexField("Child Item Count")]
        public string ChildItemCount { get; set; }
    }
}