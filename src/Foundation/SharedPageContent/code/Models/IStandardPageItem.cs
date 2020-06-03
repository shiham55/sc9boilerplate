using scboilerplate.Foundation.SitecoreExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scboilerplate.Foundation.SharedPageContent.Models
{
    public interface IStandardPageItem : ISitecoreItem, ITeaser, IMetaTag
    {
    }
}