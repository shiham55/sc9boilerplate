using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace scboilerplate.Foundation.Indexing.ComputedFields
{
    public class CategoryDetailRoute : IComputedIndexField
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

            Item item = indexableItem.Item;
            Field routeField = item.Fields["Route"];

            if (routeField != null && !string.IsNullOrWhiteSpace(item.Fields["Route"].Value))
            {
                string[] ids = routeField.Value.Split('|');
                List<string> results = new List<string>();

                foreach (string id in ids)
                {
                    Item relatedItem = item.Database.GetItem(id);
                    if (relatedItem != null)
                    {
                        results.Add(relatedItem.DisplayName);
                    }
                }
                return results.ToArray();
            }
            return string.Empty;
        }
    }
}