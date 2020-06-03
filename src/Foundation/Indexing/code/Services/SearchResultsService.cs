using scboilerplate.Foundation.Indexing.Extensions;
using scboilerplate.Foundation.Indexing.SearchModels;
using scboilerplate.Foundation.Indexing.ViewModels;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.Utilities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace scboilerplate.Foundation.Indexing.Services
{
    public class SearchResultsService : ISearchResultsService
    {
        public PageSearchResults GetResultsBySearchQuery(string searchQuery, int numberOfItems, int page)
        {
            if (string.IsNullOrEmpty(searchQuery))
                return null;

            using (var context = SearchExtensions.GetContextIndex(Index.SearchResult).CreateSearchContext())
            {
                var baseQuery = PredicateBuilder.True<SearchResultIndexItem>().And(n => n.LatestVersion);

                var filterQuery = GetSearchTermPredicate<SearchResultIndexItem>(searchQuery);

                baseQuery = baseQuery.And(filterQuery);

                var query = context.GetQueryable<SearchResultIndexItem>().Filter(baseQuery);

                var searchResults = query.GetResults(GetResultsOptions.GetScores);

                int totalResults = searchResults.Hits.Count();

                int totalPages = (int)Math.Ceiling((double)totalResults / (double)numberOfItems);

                var result = searchResults.Hits.Select(n => n.Document)
                    .Skip((page - 1) * numberOfItems)
                    .Take(numberOfItems)
                    .ToList();

                return new PageSearchResults
                {
                    Results = result,
                    TotalResults = totalResults,
                    Pages = totalPages,
                    SaerchQuery = searchQuery.Replace('+', ' ')
                };
            }
        }

        #region Private Methods
        public static Expression<Func<T, bool>> GetSearchTermPredicate<T>(string searchTerm) where T : SearchResultIndexItem
        {
            var actualPhraseInTeaserTitlePredicate = PredicateBuilder.True<T>()
                .Or(r => r.TeaserTitle.Contains(searchTerm));

            var actualPhraseInTeaserContentPredicate = PredicateBuilder.True<T>()
                .Or(r => r.TeaserContent.Contains(searchTerm));

            var actualPhraseInContentPredicate = PredicateBuilder.True<T>()
                .Or(r => r.Content.Contains(searchTerm));

            var terms = searchTerm.Split(' ');

            var teaserTitleAllTermsContains = PredicateBuilder.True<T>();
            foreach (var term in terms)
                teaserTitleAllTermsContains
                    = teaserTitleAllTermsContains.Or(r => r.TeaserTitle.Contains(term));

            var teaserContentAllTermsContains = PredicateBuilder.True<T>();
            foreach (var term in terms)
                teaserContentAllTermsContains
                    = teaserContentAllTermsContains.Or(r => r.TeaserContent.Contains(term));

            var contentContainsAllTermsPredicate = PredicateBuilder.True<T>();
            foreach (var term in terms)
                contentContainsAllTermsPredicate
                    = contentContainsAllTermsPredicate.Or(r => r.Content.Contains(term));

            var predicate = actualPhraseInTeaserTitlePredicate.Boost(3f)
                .Or(actualPhraseInTeaserContentPredicate.Boost(2.5f))
                .Or(actualPhraseInContentPredicate.Boost(2f))
                .Or(teaserTitleAllTermsContains.Boost(1.5f))
                .Or(teaserContentAllTermsContains.Boost(1.2f))
                .Or(contentContainsAllTermsPredicate.Boost(1.2f));

            return predicate;
        }
        #endregion
    }
}