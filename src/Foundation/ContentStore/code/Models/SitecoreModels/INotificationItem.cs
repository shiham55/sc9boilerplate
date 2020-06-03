using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using scboilerplate.Foundation.SitecoreExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scboilerplate.Foundation.ContentStore.Models.SitecoreModels
{
    public interface INotificationItem : ISitecoreItem
    {
        [SitecoreField("Notification Text")]
        string NotificationText { get; set; }

        [SitecoreField("Notification Link")]
        Link NotificationLink { get; set; }
    }
}
