using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;

namespace scboilerplate.Foundation.SitecoreExtensions.Models
{
    [SitecoreType]
    public interface ISitecoreItem
    {
        [SitecoreId]
        ID ID { get; set; }

        [SitecoreInfo(Type = SitecoreInfoType.Name)]
        string Name { get; set; }

        [SitecoreInfo(Type = SitecoreInfoType.TemplateId)]
        Guid TemplateID { get; set; }

        [SitecoreInfo(Type = SitecoreInfoType.TemplateName)]
        string TemplateName { get; set; }

        [SitecoreInfo(Type = SitecoreInfoType.Path)]
        string Path { get; set; }

        [SitecoreField("__created")]
        DateTime CreatedDate { get; set; }

        [SitecoreField("__updated")]
        DateTime ModifiedDate { get; set; }

        [SitecoreChildren(InferType = true)]
        IEnumerable<ISitecoreItem> Children { get; set; }

        [SitecoreInfo(Type = SitecoreInfoType.Url)]
        string Url { get; set; }

        [SitecoreItem]
        Item SCItem { get; set; }
    }

}