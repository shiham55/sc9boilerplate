using scboilerplate.Foundation.SharedPageContent.Models;

namespace scboilerplate.Foundation.SharedPageContent.Repositories
{
    public interface ISharedPageContentRepository
    {
        IMetaTag GetMetaTags();
    }
}
