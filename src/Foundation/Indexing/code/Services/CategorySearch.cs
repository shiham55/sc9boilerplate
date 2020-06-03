using scboilerplate.Foundation.Indexing.Extensions;
using scboilerplate.Foundation.Indexing.SearchModels;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace scboilerplate.Foundation.Indexing.Services
{
    public class CategorySearch : ICategorySearchService
    {
        public IEnumerable<CategoryDetailIndexItem> GetAllDetailPageItems()
        {
            using (var context = SearchExtensions.GetContextIndex(Index.CategoryDetail).CreateSearchContext())
            {
                var predicate = PredicateBuilder.True<CategoryDetailIndexItem>();

                predicate = predicate.And(n => n.LatestVersion);

                var query = context.GetQueryable<CategoryDetailIndexItem>().Filter(predicate);
                
                var searchResults = query.GetResults(GetResultsOptions.Default);

                var result = searchResults.Hits.Select(n => n.Document).ToList();

                return result;
            }
        }

        public CategoryDetailIndexItem GetDetailPageById(string categoryId)
        {
            using (var context = SearchExtensions.GetContextIndex(Index.CategoryDetail).CreateSearchContext())
            {
                var predicate = PredicateBuilder.True<CategoryDetailIndexItem>();

                predicate = predicate.And(n => n.LatestVersion);

                if (!string.IsNullOrEmpty(categoryId))
                {
                    ID category = new ID(new Guid(categoryId));
                    predicate = predicate.And(n => n.ItemId == category);
                }

                var query = context.GetQueryable<CategoryDetailIndexItem>().Filter(predicate);

                var searchResults = query.GetResults(GetResultsOptions.Default);

                var result = searchResults.Hits.Select(n => n.Document).FirstOrDefault();

                return result;
            }
        }

        public IEnumerable<CategoryDetailIndexItem> GetAllDetailPagesByParentId(string parentCategoryListingId, string route)
        {
            using (var context = SearchExtensions.GetContextIndex(Index.CategoryDetail).CreateSearchContext())
            {
                var predicate = PredicateBuilder.True<CategoryDetailIndexItem>();

                predicate = predicate.And(n => n.LatestVersion);                

                if (!string.IsNullOrEmpty(parentCategoryListingId))
                {
                    Guid parentCategory = new Guid(parentCategoryListingId);
                    predicate = predicate.And(a => a.ParentShortID == parentCategory.ToString("N"));
                }

                var query = context.GetQueryable<CategoryDetailIndexItem>().Filter(predicate);

                var searchResults = query.GetResults(GetResultsOptions.Default);

                var result = searchResults.Hits.Select(n => n.Document).ToList().OrderBy(x => x.SortOrder);

                if (!string.IsNullOrEmpty(route) && !route.ToLower().Equals(route))
                {
                    return result.Where(x => x.Route.Contains(route)).ToList();
                }

                return result;
            }
        }

        public List<CategoryListingIndexItem> GetAllListingPageItems()
        {
            using (var context = SearchExtensions.GetContextIndex(Index.CategoryListing).CreateSearchContext())
            {
                var predicate = PredicateBuilder.True<CategoryListingIndexItem>();

                predicate = predicate.And(n => n.LatestVersion);

                var query = context.GetQueryable<CategoryListingIndexItem>().Filter(predicate);

                var searchResults = query.GetResults(GetResultsOptions.Default);

                var result = searchResults.Hits.Select(n => n.Document).OrderBy(x => x.SortOrder).ToList();

                return result;
            }
        }

        public List<CategoryDetailIndexItem> GetUpcomingProgrmmes(int numberOfProgrammesToShow, DateTime showProgrammesFrom, string categoryType)
        {
            using (var context = SearchExtensions.GetContextIndex(Index.CategoryDetail).CreateSearchContext())
            {
                var predicate = PredicateBuilder.True<CategoryDetailIndexItem>();

                predicate = predicate.And(n => n.LatestVersion);

                predicate = predicate.And(n => n.LatestVersion)
                                        .And(n => n.CategoryParentTypeValue == categoryType);

                var query = context.GetQueryable<CategoryDetailIndexItem>().Filter(predicate);

                var searchResults = query.GetResults(GetResultsOptions.Default);

                var allResult = searchResults.Hits.Select(n => n.Document).OrderBy(x => x.StartDate).ToList();

                var filteredResult = allResult.Where(x => (x.StartDate != null ? x.StartDate.Date >= showProgrammesFrom.Date : true)).OrderBy(x => x.StartDate).Take(numberOfProgrammesToShow).ToList();

                return filteredResult;
            }
        }

        public List<CategoryDetailIndexItem> GetLastProgrammes(int numberOfProgrammesToShow, string categoryType)
        {
            using (var context = SearchExtensions.GetContextIndex(Index.CategoryDetail).CreateSearchContext())
            {
                var predicate = PredicateBuilder.True<CategoryDetailIndexItem>();

                predicate = predicate.And(n => n.LatestVersion);

                predicate = predicate.And(n => n.LatestVersion)
                                        .And(n => n.CategoryParentTypeValue == categoryType);

                var query = context.GetQueryable<CategoryDetailIndexItem>().Filter(predicate);

                var searchResults = query.GetResults(GetResultsOptions.Default);

                var allResult = searchResults.Hits.Select(n => n.Document).OrderByDescending(x => x.StartDate).ToList();

                var filteredResult = allResult.Take(numberOfProgrammesToShow).OrderBy(x => x.StartDate).ToList();

                return filteredResult;
            }
        }
    }
}