using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace scboilerplate.Foundation.Indexing.ComputedFields
{
    public class CategoryDetailParentName : IComputedIndexField
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
            if (parent != null)
            {
                return parent.Name == parent.DisplayName ? parent.Name : parent.DisplayName;
            }
            return string.Empty;
        }
    }
}