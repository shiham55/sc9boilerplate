using Glass.Mapper.Sc.Configuration.Attributes;
using scboilerplate.Foundation.SitecoreExtensions.Models;

namespace scboilerplate.Foundation.ContentStore.Models.SitecoreModels
{
    public interface IRoute : ISitecoreItem
    {
        [SitecoreField("Route Value")]
        string RouteValue { get; set; }
    }
}