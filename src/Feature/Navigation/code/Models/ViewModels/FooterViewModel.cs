using scboilerplate.Foundation.ContentStore.Models.SitecoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scboilerplate.Feature.Navigation.Models.ViewModels
{
    public class FooterViewModel
    {
        public IFooter Footer { get; set; }

        public List<ILogoCategoryFolder> TopRowLogoCategoryFolders { get; set; }

        public List<ILogoCategoryFolder> BottomRowLogoCategoryFolders { get; set; }

        public string LastUpdatedDate { get; set; }
    }
}