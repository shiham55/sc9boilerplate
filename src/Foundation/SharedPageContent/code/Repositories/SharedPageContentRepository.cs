using scboilerplate.Foundation.SharedPageContent.Models;
using scboilerplate.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Data.Items;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;

namespace scboilerplate.Foundation.SharedPageContent.Repositories
{
    public class SharedPageContentRepository : ISharedPageContentRepository
    {
        public Item ContextItem { get; private set; }
        private readonly IMvcContext _sitecoreContext;

        public SharedPageContentRepository(Item item)
        {
            this.ContextItem = item;
            _sitecoreContext = new MvcContext();
        }

        public IMainContentMultipleTitle GetMultipleTitle()
        {
            if (ContextItem.IsDerived(Templates.MultipleTitles.ID))
                return _sitecoreContext.SitecoreService.GetItem<IMainContentMultipleTitle>(this.ContextItem);
            return null;
        }

        public IMetaTag GetMetaTags()
        {
            if (ContextItem.IsDerived(Templates.MetaTags.ID))
                return _sitecoreContext.SitecoreService.GetItem<IMetaTag>(this.ContextItem);
            return null;
        }
    }
}