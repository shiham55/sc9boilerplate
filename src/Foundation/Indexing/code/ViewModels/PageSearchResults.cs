using scboilerplate.Foundation.Indexing.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scboilerplate.Foundation.Indexing.ViewModels
{
    public class PageSearchResults
    {
        public IEnumerable<SearchResultIndexItem> Results { get; set; }

        public int TotalResults { get; set; }

        public int Pages { get; set; }

        public string  SaerchQuery { get; set; }
    }
}