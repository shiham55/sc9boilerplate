using scboilerplate.Feature.Navigation.Models.SitecoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scboilerplate.Feature.Navigation.Models.ViewModels
{
    public class PrimaryMenuViewModel
    {
        public NavigationItems NavigationItems { get; set; }

        public ILogo Logo { get; set; }

        public INotification NotificationItem { get; set; }

        public IFooter FooterItem { get; set; }

        public bool ShowNotifications
        {
            get
            {
                return this.NotificationItem != null 
                        && ( this.NotificationItem.Notifications != null && this.NotificationItem.Notifications.Count() > 0);
            }
        }
    }
}