using scboilerplate.Foundation.ContentStore.Models.SitecoreModels;
using scboilerplate.Foundation.SitecoreExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scboilerplate.Feature.Navigation.Models.SitecoreModels
{
    public interface INotification : ISitecoreItem
    {
        IEnumerable<INotificationItem> Notifications { get; set; }
    }
}
