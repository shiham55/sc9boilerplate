namespace scboilerplate.Feature.Navigation.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sitecore;
    using Sitecore.Data.Items;
    using scboilerplate.Feature.Navigation.Models;
    using scboilerplate.Foundation.SitecoreExtensions.Extensions;
    using scboilerplate.Feature.Navigation.Models.SitecoreModels;
    using Glass.Mapper.Sc;
    using Glass.Mapper.Sc.Web.Mvc;

    public class NavigationRepository : INavigationRepository
    {
        public Item ContextItem { get; }
        public Item NavigationRoot { get; }

        private readonly IMvcContext _sitecoreContext;

        public NavigationRepository(Item contextItem)
        {
            this._sitecoreContext = new MvcContext();// new SitecoreContext();

            this.ContextItem = contextItem;
            this.NavigationRoot = this.GetNavigationRoot(this.ContextItem);
            if (this.NavigationRoot == null)
            {
                throw new InvalidOperationException($"Cannot determine navigation root from '{this.ContextItem.Paths.FullPath}'");
            }
        }

        public Item GetNavigationRoot(Item contextItem)
        {
            return contextItem.GetAncestorOrSelfOfTemplate(Templates.NavigationRoot.ID) ?? Context.Site.GetContextItem(Templates.NavigationRoot.ID);
        }

        public NavigationItems GetBreadcrumb()
        {
            var items = new NavigationItems
            {
                Items = this.GetNavigationHierarchy(true).Reverse().ToList()
            };

            for (var i = 0; i < items.Items.Count - 1; i++)
            {
                items.Items[i].Level = i;
                items.Items[i].IsActive = i == items.Items.Count - 1;
            }

            return items;
        }

        public NavigationItems GetPrimaryMenu()
        {
            var navItems = this.GetChildNavigationItems(this.NavigationRoot, 0, 3);

            this.AddRootToPrimaryMenu(navItems);

            return navItems;
        }

        private void AddRootToPrimaryMenu(NavigationItems navItems)
        {
            if (!this.IncludeInNavigation(this.NavigationRoot))
            {
                return;
            }

            var navigationItem = this.CreateNavigationItem(this.NavigationRoot, 0, 0);
            //Root navigation item is only active when we are actually on the root item
            navigationItem.IsActive = this.ContextItem.ID == this.NavigationRoot.ID;
            navItems?.Items?.Insert(0, navigationItem);
        }

        private bool IncludeInNavigation(Item item, bool forceShowInMenu = false)
        {
            return item.HasContextLanguage() 
                    && item.IsDerived(Templates.Navigable.ID)
                    && !item.IsDerived(Templates.HiddenTemplatesInMainNavigation.CategoryDetailID)
                    && (forceShowInMenu || MainUtil.GetBool(item[Templates.Navigable.Fields.ShowInNavigation], false));
        }

        public NavigationItem GetSecondaryMenuItem()
        {
            var rootItem = this.GetSecondaryMenuRoot();
            return rootItem == null ? null : this.CreateNavigationItem(rootItem, 0, 3);
        }

        public NavigationItems GetLinkMenuItems(Item menuRoot)
        {
            if (menuRoot == null)
            {
                throw new ArgumentNullException(nameof(menuRoot));
            }
            return this.GetChildNavigationItems(menuRoot, 0, 0);
        }

        public IFooter GetFooter()
        {
            Item navigationRoot = this.GetNavigationRoot(this.ContextItem);

            if (navigationRoot.IsDerived(Templates.Footer.ID))
                return _sitecoreContext.SitecoreService.GetItem<IFooter>(this.GetNavigationRoot(this.ContextItem));

            return null;
        }

        public ILogo GetMainLogo()
        {
            Item navigationRoot = this.GetNavigationRoot(this.ContextItem);
            if (navigationRoot.IsDerived(Templates.Logo.ID))
                return _sitecoreContext.SitecoreService.GetItem<ILogo>(this.GetNavigationRoot(this.ContextItem));
            return null;
        }

        public INotification GetNotifications()
        {
            Item navigationRoot = this.GetNavigationRoot(this.ContextItem);
            if (navigationRoot.IsDerived(Templates.Logo.ID))
                return _sitecoreContext.SitecoreService.GetItem<INotification>(this.GetNavigationRoot(this.ContextItem));
            return null;
        }

        #region Private Methods
        private Item GetSecondaryMenuRoot()
        {
            return this.FindActivePrimaryMenuItem();
        }

        private Item FindActivePrimaryMenuItem()
        {
            var primaryMenuItems = this.GetPrimaryMenu();
            //Find the active primary menu item
            var activePrimaryMenuItem = primaryMenuItems.Items.FirstOrDefault(i => i.Item.ID != this.NavigationRoot.ID && i.IsActive);
            return activePrimaryMenuItem?.Item;
        }

        private IEnumerable<NavigationItem> GetNavigationHierarchy(bool forceShowInMenu = false)
        {
            var item = this.ContextItem;
            while (item != null)
            {
                if (this.IncludeInNavigation(item, forceShowInMenu))
                {
                    yield return this.CreateNavigationItem(item, 0);
                }

                item = item.Parent;
            }
        }

        private NavigationItem CreateNavigationItem(Item item, int level, int maxLevel = -1)
        {
            return new NavigationItem
            {
                Item = item,
                NavigationTitle = item.IsDerived(Templates.Navigable.ID) && item.FieldHasValue(Templates.Navigable.Fields.NavigationTitle) ? item[Templates.Navigable.Fields.NavigationTitle] : string.Empty,
                Url = item.IsDerived(Templates.Link.ID) ? item.LinkFieldUrl(Templates.Link.Fields.Link) : item.Url(),
                Target = item.IsDerived(Templates.Link.ID) ? item.LinkFieldTarget(Templates.Link.Fields.Link) : string.Empty,
                IsActive = this.IsItemActive(item),
                Children = this.GetChildNavigationItems(item, level + 1, maxLevel)
            };
        }
        
        private NavigationItems GetChildNavigationItems(Item parentItem, int level, int maxLevel)
        {
            NavigationItems navigationItems = new NavigationItems();

            //child navigation links
            if (level > maxLevel || !parentItem.HasChildren)
            {
                return null;
            }
            var childItems = parentItem.Children.Where(item => this.IncludeInNavigation(item)).Select(i => this.CreateNavigationItem(i, level, maxLevel));
            navigationItems.Items = childItems.ToList();

            return navigationItems;
        }

        private bool IsItemActive(Item item)
        {
            return this.ContextItem.ID == item.ID || this.ContextItem.Axes.GetAncestors().Any(a => a.ID == item.ID);
        }
        #endregion
    }
}