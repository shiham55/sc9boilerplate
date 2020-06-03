namespace scboilerplate.Feature.Navigation.Repositories
{
    using Sitecore.Data.Items;
    using scboilerplate.Feature.Navigation.Models;
    using scboilerplate.Feature.Navigation.Models.SitecoreModels;

    public interface INavigationRepository
    {
        Item GetNavigationRoot(Item contextItem);
        NavigationItems GetBreadcrumb();
        NavigationItems GetPrimaryMenu();
        NavigationItem GetSecondaryMenuItem();
        NavigationItems GetLinkMenuItems(Item menuItem);
        IFooter GetFooter();
        ILogo GetMainLogo();
        INotification GetNotifications();
    }
}