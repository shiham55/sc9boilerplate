using System;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data.Items;
using Sitecore.Data;

[SitecoreType]
public interface ISitecoreItem
{
    [SitecoreId]
    ID ID { get; set; }

    [SitecoreInfo(Type = SitecoreInfoType.TemplateId)]
    Guid TemplateID { get; set; }

    [SitecoreInfo(Type = SitecoreInfoType.TemplateName)]
    string TemplateName { get; set; }

    [SitecoreInfo(Type = SitecoreInfoType.Path)]
    string Path { get; set; }

    [SitecoreField("{BA3F86A2-4A1C-4D78-B63D-91C2779C1B5E}")]
    int? SortOrder { get; set; }

    [SitecoreParent]
    IPageBase Parent { get; set; }

    [SitecoreField("__created")]
    DateTime CreatedDate { get; set; }

    [SitecoreField("__updated")]
    DateTime ModifiedDate { get; set; }

    [SitecoreChildren(InferType = true, IsLazy = false)]
    IEnumerable<ISitecoreItem> Children { get; set; }

    [SitecoreInfo(Type = SitecoreInfoType.Url)]
    string Url { get; set; }

    [SitecoreItem]
    Item SCItem { get; set; }
}
