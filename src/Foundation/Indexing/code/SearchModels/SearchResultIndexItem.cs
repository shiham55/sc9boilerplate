using Sitecore.ContentSearch;

namespace scboilerplate.Foundation.Indexing.SearchModels
{
    public class SearchResultIndexItem : IndexBase
    {
        [IndexField("Teaser Title")]
        public string TeaserTitle { get; set; }

        [IndexField("Teaser Content")]
        public string TeaserContent { get; set; }

        [IndexField("Teaser Image")]
        public string TeaserImage { get; set; }

        [IndexField("Main Content")]
        public string MainContent { get; set; }
    }
}