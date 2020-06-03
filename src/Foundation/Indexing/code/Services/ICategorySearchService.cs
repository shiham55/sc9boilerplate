using scboilerplate.Foundation.Indexing.SearchModels;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sitecore.ContentSearch.Linq.Extensions.ReflectionExtensions;

namespace scboilerplate.Foundation.Indexing.Services
{
    public interface ICategorySearchService
    {
        IEnumerable<CategoryDetailIndexItem> GetAllDetailPageItems();

        IEnumerable<CategoryDetailIndexItem> GetAllDetailPagesByParentId(string parentCategoryListingId, string route);

        CategoryDetailIndexItem GetDetailPageById(string categoryId);

        List<CategoryListingIndexItem> GetAllListingPageItems();

        List<CategoryDetailIndexItem> GetUpcomingProgrmmes(int numberOfProgrammesToShow, DateTime showProgrammesFrom, string categoryType);

        List<CategoryDetailIndexItem> GetLastProgrammes(int numberOfProgrammesToShow, string categoryType);
    }
}
