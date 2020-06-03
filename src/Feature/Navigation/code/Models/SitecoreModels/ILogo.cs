using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using scboilerplate.Foundation.SitecoreExtensions.Models;

namespace scboilerplate.Feature.Navigation.Models
{
    public interface ILogo : ISitecoreItem
    {
        [SitecoreField("iLight Logo")]
        Image iLightLogo { get; set; }

        [SitecoreField("iLight Logo link")]
        Link iLightLogoLink { get; set; }
    }
}