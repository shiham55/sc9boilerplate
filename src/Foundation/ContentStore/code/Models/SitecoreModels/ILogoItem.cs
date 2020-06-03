using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using scboilerplate.Foundation.SitecoreExtensions.Models;

namespace scboilerplate.Foundation.ContentStore.Models.SitecoreModels
{
    public interface ILogoItem : ISitecoreItem
    {
        [SitecoreField("Show in Footer")]
        bool ShowInFooter { get; set; }

        [SitecoreField("Logo Image")]
        Image LogoImage { get; set; }

        [SitecoreField("Logo Url")]
        Link LogoUrl { get; set; }
    }
}