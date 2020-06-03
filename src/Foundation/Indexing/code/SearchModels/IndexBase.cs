using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;

namespace scboilerplate.Foundation.Indexing.SearchModels
{
    public class IndexBase : SearchResultItem
    {
        public virtual ID GlassScMappingID
        {
            get
            {
                return this.ItemId;
            }
        }

        [IndexField("_latestversion")]
        public virtual bool LatestVersion { get; set; }

        [IndexField("_group")]
        public virtual string ItemIdStr { get; set; }

        [IndexField("_parent")]
        public virtual string ParentShortID { get; set; }

        [IndexField("__sortorder")]
        public int SortOrder { get; internal set; }

        [IndexField("ItemUrl")]
        public string ItemUrl { get; set; }
    }
}