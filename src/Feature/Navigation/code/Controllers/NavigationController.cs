namespace scboilerplate.Feature.Navigation.Controllers
{
    using System.Web.Mvc;
    using System.Collections;
    using Glass.Mapper.Sc;
    using scboilerplate.Feature.Navigation.Models;
    using scboilerplate.Feature.Navigation.Models.ViewModels;
    using scboilerplate.Feature.Navigation.Repositories;
    using scboilerplate.Foundation.ContentStore.Repositories;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Mvc.Controllers;

    public class NavigationController : SitecoreController
    {
        #region Members
        private readonly INavigationRepository _navigationRepository;
        private readonly IContentStoreRepository _contentStoreRepository;
        #endregion

        #region Constructor
        public NavigationController() : this(new NavigationRepository(RenderingContext.Current.Rendering.Item),
                                        new ContentStoreRepository(RenderingContext.Current.Rendering.Item))
        {
        }

        public NavigationController(INavigationRepository navigationRepository, IContentStoreRepository contentStoreRepository)
        {
            this._navigationRepository = navigationRepository;
            this._contentStoreRepository = contentStoreRepository;
        }

        public NavigationController(INavigationRepository navigationRepository)
        {
            this._navigationRepository = navigationRepository;
        }
        #endregion

        #region Action Results
        public ActionResult Breadcrumb()
        {
            var items = this._navigationRepository.GetBreadcrumb();
            return this.View("~/Views/scboilerplate/Navigation/Breadcrumb.cshtml", items);
        }

        public ActionResult PrimaryMenu()
        {
            PrimaryMenuViewModel primaryMenuViewModel = new PrimaryMenuViewModel
            {
                NavigationItems = this._navigationRepository.GetPrimaryMenu(),
                Logo = this._navigationRepository.GetMainLogo(),
                FooterItem = this._navigationRepository.GetFooter(),
                NotificationItem = this._navigationRepository.GetNotifications()
            };

            return this.View("~/Views/scboilerplate/Navigation/PrimaryMenu.cshtml", primaryMenuViewModel);
        }

        public ActionResult SecondaryMenu()
        {
            var item = this._navigationRepository.GetSecondaryMenuItem();
            return this.View("~/Views/scboilerplate/Navigation/SecondaryMenu.cshtml", item);
        }

        public ActionResult NavigationLinks()
        {
            if (string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                return null;
            }
            var item = RenderingContext.Current.Rendering.Item;
            var items = this._navigationRepository.GetLinkMenuItems(item);
            return this.View("~/Views/scboilerplate/Navigation/NavigationLinks.cshtml", items);
        }

        public ActionResult Footer()
        {
            FooterViewModel footerViewModel = new FooterViewModel
            {
                Footer = this._navigationRepository.GetFooter(),
                TopRowLogoCategoryFolders = this._contentStoreRepository.GetFooterTopRowLogoFolders(),
                BottomRowLogoCategoryFolders = this._contentStoreRepository.GetFooterBottomRowLogoFolders(),
                LastUpdatedDate = RenderingContext.Current.Rendering.Item.Statistics.Updated.ToString("dd MMMM yyyy")
            };

            return this.View("~/Views/scboilerplate/Navigation/Footer.cshtml", footerViewModel);
        }
        #endregion
    }
}