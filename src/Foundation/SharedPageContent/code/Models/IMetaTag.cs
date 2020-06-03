using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using scboilerplate.Foundation.SitecoreExtensions.Models;

namespace scboilerplate.Foundation.SharedPageContent.Models
{
    public interface IMetaTag : ISitecoreItem
    {
        #region Meta Tags
        [SitecoreField("Meta Title")]
        string MetaTitle { get; set; }

        [SitecoreField("Favicon")]
        Link Favicon { get; set; }

        [SitecoreField("Meta Description")]
        string MetaDescription { get; set; }

        [SitecoreField("Meta Keywords")]
        string MetaKeywords { get; set; }

        [SitecoreField("OG Title")]
        string OGTitle { get; set; }

        [SitecoreField("OG Description")]
        string OGDescription { get; set; }

        [SitecoreField("OG Image")]
        Image OGImage { get; set; }

        [SitecoreField("OG Type")]
        string OGType { get; set; }

        [SitecoreField("OG Sitename")]
        string OGSitename { get; set; }

        [SitecoreField("Twitter Title")]
        string TwitterTitle { get; set; }

        [SitecoreField("Twitter Decription")]
        string TwitterDecription { get; set; }

        [SitecoreField("Twitter Image")]
        Image TwitterImage { get; set; }

        [SitecoreField("Twitter Card")]
        string TwitterCard { get; set; }

        [SitecoreField("Twitter Site")]
        string TwitterSite { get; set; }

        [SitecoreField("Twitter Creator")]
        string TwitterCreator { get; set; }
        #endregion

        string OGImageUrl { get; set; }

        string TwitterImageUrl { get; set; }
    }
}
