using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using scboilerplate.Foundation.SitecoreExtensions.Models;

namespace scboilerplate.Feature.Navigation.Models
{
    public interface IFooter : ISitecoreItem
    {
        #region Footer
        [SitecoreField("Footer Link 1")]
        Link FooterLinkOne { get; set; }

        [SitecoreField("Footer Link 2")]
        Link FooterLinkTwo { get; set; }

        [SitecoreField("Footer Link 3")]
        Link FooterLinkThree { get; set; }

        [SitecoreField("Footer Link 4")]
        Link FooterLinkFour { get; set; }

        [SitecoreField("Contact Us Link")]
        Link ContactUsLink { get; set; }

        [SitecoreField("Copy Right Text")]
        string CopyRightText { get; set; }

        [SitecoreField("Subscribe Info Text")]
        string SubscribeInfoText { get; set; }

        [SitecoreField("Subscribe Button Text")]
        string SubscribeButtonText { get; set; }

        [SitecoreField("Subscribe Link")]
        Link SubscribeLink { get; set; }

        [SitecoreField("Social Links Info Text")]
        string SocialLinksInfoText { get; set; }

        [SitecoreField("Facebook Link")]
        Link FacebookLink { get; set; }

        [SitecoreField("Instagram Link")]
        Link InstagramLink { get; set; }

        [SitecoreField("Youtube Link")]
        Link YoutubeLink { get; set; }
        #endregion

        #region Sitebar
        [SitecoreField("Event Date")]
        string EventDate { get; set; }

        [SitecoreField("Instagram Text")]
        string InstagramText { get; set; }

        [SitecoreField("Instagram Hashtag Link")]
        Link InstagramHashtagLink { get; set; }
        #endregion
    }
}