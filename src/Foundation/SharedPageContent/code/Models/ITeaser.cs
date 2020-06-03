using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using scboilerplate.Foundation.SitecoreExtensions.Models;

namespace scboilerplate.Foundation.SharedPageContent.Models
{
    public interface ITeaser : ISitecoreItem
    {
        [SitecoreField("Teaser Title")]
        string TeaserTitle { get; set; }

        [SitecoreField("Teaser Content")]
        string TeaserContent { get; set; }

        [SitecoreField("Teaser Image")]
        Image TeaserImage { get; set; }
    }
}