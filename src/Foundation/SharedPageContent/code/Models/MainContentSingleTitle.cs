using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using scboilerplate.Foundation.SitecoreExtensions.Models;

namespace scboilerplate.Foundation.SharedPageContent.Models
{
    public interface MainContentSingleTitle : ISitecoreItem
    {
        [SitecoreField("Main Title")]
        string MainTitle { get; set; }

        [SitecoreField("Main Content Text")]
        string MainContentText { get; set; }
    }
}