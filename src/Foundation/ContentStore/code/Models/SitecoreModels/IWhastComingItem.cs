using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using scboilerplate.Foundation.SitecoreExtensions.Models;

namespace scboilerplate.Foundation.ContentStore.Models.SitecoreModels
{
    public interface IWhastComingItem : ISitecoreItem
    {
        [SitecoreField("Whats Coming Title")]
        string WhatsComingTitle { get; set; }

        [SitecoreField("Whats Coming Description")]
        string WhatsComingDescription { get; set; }

        [SitecoreField("Whats Coming Link")]
        Link WhatsComingLink { get; set; }

        [SitecoreField("Whats Coming Image")]
        Image WhatsComingImage { get; set; }
    }
}