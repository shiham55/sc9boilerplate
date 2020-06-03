using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using scboilerplate.Foundation.SitecoreExtensions.Models;

namespace scboilerplate.Foundation.SharedPageContent.Models
{
    public interface IMainContentMultipleTitle : ISitecoreItem
    {
        #region Content
        [SitecoreField("Banner Image")]
        Image BannerImage { get; set; }

        [SitecoreField("Desktop Title One")]
        string DesktopTitleOne { get; set; }

        [SitecoreField("Desktop Title Two")]
        string DesktopTitleTwo { get; set; }

        [SitecoreField("Mobile Title One")]
        string MobileTitleOne { get; set; }

        [SitecoreField("Mobile Title Two")]
        string MobileTitleTwo { get; set; }

        [SitecoreField("Mobile Title Three")]
        string MobileTitleThree { get; set; }

        [SitecoreField("Main Content")]
        string MainContent { get; set; }
        #endregion
    }
}