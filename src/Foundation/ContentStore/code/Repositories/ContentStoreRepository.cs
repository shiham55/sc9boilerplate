using Glass.Mapper.Sc;
using scboilerplate.Foundation.ContentStore.Models.SitecoreModels;
using Sitecore.Data.Items;
using System.Collections.Generic;

namespace scboilerplate.Foundation.ContentStore.Repositories
{
    public class ContentStoreRepository : IContentStoreRepository
    {
        #region Members
        public Item ContextItem { get; private set; }
        #endregion

        #region Constructor
        public ContentStoreRepository()
        {
        }

        public ContentStoreRepository(Item item)
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
                    ILogoCategoryFolder logoCategoryFolder = logoFolderItem.GlassCast<ILogoCategoryFolder>();
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
                    ILogoCategoryFolder logoCategoryFolder = logoFolderItem.GlassCast<ILogoCategoryFolder>();
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
                    ILogoCategoryFolder logoCategoryFolder = logoFolderItem.GlassCast<ILogoCategoryFolder>();
                    allLogoFolders.Add(logoCategoryFolder);
                }
            }

            return allLogoFolders;
        }
        #endregion
    }
}