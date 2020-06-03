using scboilerplate.Foundation.SharedPageContent.Models;
using scboilerplate.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Data.Items;
using Glass.Mapper.Sc;


namespace scboilerplate.Foundation.SharedPageContent.Repositories
{
    public class SharedPageContentRepository : ISharedPageContentRepository
    {
        public Item ContextItem { get; private set; }

        public SharedPageContentRepository(Item item)
        {
            this.ContextItem = item;
        }

        public IMainContentMultipleTitle GetMultipleTitle()
        {
            if (ContextItem.IsDerived(Templates.MultipleTitles.ID))
                return this.ContextItem.GlassCast<IMainContentMultipleTitle>();
            return null;
        }

        public IMetaTag GetMetaTags()
        {
            if (ContextItem.IsDerived(Templates.MetaTags.ID))
                return this.ContextItem.GlassCast<IMetaTag>();
            return null;
        }
    }
}