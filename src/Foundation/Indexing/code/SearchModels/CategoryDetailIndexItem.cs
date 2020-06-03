using Sitecore;
using Sitecore.ContentSearch;
using System;

namespace scboilerplate.Foundation.Indexing.SearchModels
{
    public class CategoryDetailIndexItem : IndexBase
    {
        [IndexField("Teaser Title")]
        public string TeaserTitle { get; set; }

        [IndexField("Teaser Content")]
        public string TeaserContent { get; set; }

        [IndexField("Teaser Image")]
        public string TeaserImage { get; set; }

        [IndexField("Artist Name")]
        public string ArtistName { get; set; }

        [IndexField("Location Name")]
        public string LocationName { get; set; }

        [IndexField("Location Latitude")]
        public string LocationLatitude { get; set; }

        [IndexField("Location Longitude")]
        public string LocationLongitude { get; set; }

        [IndexField("Category Name")]
        public string CategoryName { get; set; }

        [IndexField("Category Id")]
        public string CategoryListingId { get; set; }

        [IndexField("Category Parent Type Value")]
        public string CategoryParentTypeValue { get; set; }

        [IndexField("Route")]
        public string Route { get; set; }

        [IndexField("Start Date")]
        public DateTime StartDate { get; set; }

        [IndexField("End Date")]
        public DateTime EndDate { get; set; }

        [IndexField("Map Pin Number")]
        public string MapPinNumber { get; set; }

        
        public float LocationLatitudeNumber
        {
            get
            {
                float result = 0f;
                float.TryParse(this.LocationLatitude, out result);
                return result;
            }
        }

        
        public float LocationLongitudeNumber
        {
            get
            {
                float result = 0f;
                float.TryParse(this.LocationLongitude, out result);
                return result;
            }
        }

        public int MapPinNumberInt
        {
            get
            {
                int result = 0;
                int.TryParse(this.MapPinNumber, out result);
                return result;
            }
        }

        public string StartToEndDateString
        {
            get
            {
                string startDateString = this.StartDate != null && this.StartDate != DateTime.MinValue ? DateUtil.ToServerTime(this.StartDate).ToString("dd MMM yy") : string.Empty;
                string endDateString = this.EndDate != null && this.EndDate != DateTime.MinValue ? DateUtil.ToServerTime(this.EndDate).ToString("dd MMM yy") : string.Empty;

                if (!string.IsNullOrEmpty(startDateString) && !string.IsNullOrEmpty(endDateString))
                    return string.Format("{0} - {1}", startDateString, endDateString);
                if (!string.IsNullOrEmpty(startDateString))
                    return startDateString;
                return string.Empty;
            }
        }
    }
}