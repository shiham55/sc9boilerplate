using scboilerplate.Foundation.ContentStore.Models.SitecoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scboilerplate.Foundation.ContentStore.Repositories
{
    public interface IContentStoreRepository
    {
        List<ILogoCategoryFolder> GetFooterTopRowLogoFolders();
        List<ILogoCategoryFolder> GetFooterBottomRowLogoFolders();
        List<ILogoCategoryFolder> GetAllLogoFolders();
    }
}
