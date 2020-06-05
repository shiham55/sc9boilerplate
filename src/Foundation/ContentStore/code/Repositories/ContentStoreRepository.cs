using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using scboilerplate.Foundation.ContentStore.Models.SitecoreModels;
using Sitecore.Data.Items;
using System.Collections.Generic;

namespace scboilerplate.Foundation.ContentStore.Repositories
{
    public class ContentStoreRepository : IContentStoreRepository
    {
        #region Members
        public Item ContextItem { get; private set; }
        private readonly IMvcContext _sitecoreContext;
        #endregion

        #region Constructor
        public ContentStoreRepository()
        {
            _sitecoreContext = new MvcContext();
        }

        public ContentStoreRepository(Item item) : this()
        {
            this.ContextItem = item;
        }
        #endregion

        #region Methods
        public List<ILogoCategoryFolder> GetFooterTopRowLogoFolders()
        {
            List<ILogoCategoryFolder> topRow = new List<ILogoCategoryFolder>();

            var logosFolder = ContextItem.Database.GetItem(Items.LogosFolder.ID);

            if (logosFolder != null && logosFolder.Children != null)
            {
                foreach (Item logoFolderItem in logosFolder.Children)
                {
                    ILogoCategoryFolder logoCategoryFolder = _sitecoreContext.SitecoreService.GetItem<ILogoCategoryFolder>(this.ContextItem);

                    if (logoCategoryFolder.ShowInFooterTopRow)
                        topRow.Add(logoCategoryFolder);
                }
            }
            return topRow;
        }

        public List<ILogoCategoryFolder> GetFooterBottomRowLogoFolders()
        {
            List<ILogoCategoryFolder> bottomRow = new List<ILogoCategoryFolder>();

            var logosFolder = ContextItem.Database.GetItem(Items.LogosFolder.ID);

            if (logosFolder != null && logosFolder.Children != null)
            {
                foreach (Item logoFolderItem in logosFolder.Children)
                {
                    ILogoCategoryFolder logoCategoryFolder = _sitecoreContext.SitecoreService.GetItem<ILogoCategoryFolder>(this.ContextItem);
                    if (logoCategoryFolder.ShowInFooterSecondRow)
                        bottomRow.Add(logoCategoryFolder);
                }
            }
            return bottomRow;
        }

        public List<ILogoCategoryFolder> GetAllLogoFolders()
        {
            List<ILogoCategoryFolder> allLogoFolders = new List<ILogoCategoryFolder>();

            var logosFolder = ContextItem.Database.GetItem(Items.LogosFolder.ID);

            if (logosFolder != null && logosFolder.Children != null)
            {
                foreach (Item logoFolderItem in logosFolder.Children)
                {
                    ILogoCategoryFolder logoCategoryFolder = _sitecoreContext.SitecoreService.GetItem<ILogoCategoryFolder>(this.ContextItem);
                    allLogoFolders.Add(logoCategoryFolder);
                }
            }

            return allLogoFolders;
        }
        #endregion
    }
}