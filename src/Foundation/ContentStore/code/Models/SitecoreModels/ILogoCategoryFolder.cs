using Glass.Mapper.Sc.Configuration.Attributes;
using scboilerplate.Foundation.SitecoreExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scboilerplate.Foundation.ContentStore.Models.SitecoreModels
{
    public interface ILogoCategoryFolder : ISitecoreItem
    {
        [SitecoreField("Logo Category Name")]
        string LogoCategoryName { get; set; }

        [SitecoreField("Show in Footer Top Row")]
        bool ShowInFooterTopRow { get; set; }

        [SitecoreField("Show in Footer Second Row")]
        bool ShowInFooterSecondRow { get; set; }        

        [SitecoreChildren]
        IEnumerable<ILogoItem> Logos { get; set; }
    }
}