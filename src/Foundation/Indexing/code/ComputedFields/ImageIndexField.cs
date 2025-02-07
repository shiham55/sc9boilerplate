﻿using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Diagnostics;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scboilerplate.Foundation.Indexing.ComputedFields
{
    public class ImageIndexField : IComputedIndexField
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

            ImageField img = indexableItem.Item.Fields[FieldName];

            if (img != null)
            {
                if (img.MediaItem != null)
                {
                    return MediaManager.GetMediaUrl(img.MediaItem).Replace("/sitecore/shell", "");
                }
            }

            return img == null || img.MediaItem == null ? null : MediaManager.GetMediaUrl(img.MediaItem);
        }
    }
}