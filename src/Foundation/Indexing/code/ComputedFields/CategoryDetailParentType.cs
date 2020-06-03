using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace scboilerplate.Foundation.Indexing.ComputedFields
{
    public class CategoryDetailParentType : IComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Assert.ArgumentNotNull(indexable, "indexable");
            var indexableItem = indexable as SitecoreIndexableItem;

            if (indexableItem == null)
            {
                Log.Warn(string.Format("{0} : unsupported IIndexable type : {1}", this, indexable.GetType()), this);
                return null;
            }

            Item parent = indexableItem.Item.Parent;
            if (parent != null && parent.Fields != null && parent.Fields["Category Type"] != null)
            {
                return parent.Fields["Category Type"].Value;
            }
            return string.Empty;
        }
    }
}