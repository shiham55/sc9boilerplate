using scboilerplate.Foundation.Indexing.SearchModels;
using scboilerplate.Foundation.Indexing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scboilerplate.Foundation.Indexing.Services
{
    public interface ISearchResultsService
    {
        PageSearchResults GetResultsBySearchQuery(string query, int numberOfItems, int pageSize);
    }
}
