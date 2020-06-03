using Glass.Mapper.Sc.Configuration.Attributes;
using scboilerplate.Foundation.SitecoreExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scboilerplate.Foundation.ContentStore.Models.SitecoreModels
{
    public interface ICategoryType : ISitecoreItem
    {
        [SitecoreField("Category Type Value")]
        string CategoryTypeValue { get; set; }
    }
}