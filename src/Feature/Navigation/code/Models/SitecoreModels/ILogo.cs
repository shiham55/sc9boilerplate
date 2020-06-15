﻿using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using scboilerplate.Foundation.SitecoreExtensions.Models;

namespace scboilerplate.Feature.Navigation.Models.SitecoreModels
{
    public interface ILogo : ISitecoreItem
    {
        [SitecoreField("Logo")]
        Image Logo { get; set; }

        [SitecoreField("Logo link")]
        Link LogoLink { get; set; }
    }
}