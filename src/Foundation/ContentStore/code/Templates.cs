using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scboilerplate.Foundation.ContentStore
{
    public class Templates
    {
        public struct ContentStoreFolder
        {
            public static readonly ID ID = new ID("{C6F107CB-0733-4607-AE42-0CDF9CA70EE9}");
        }

        public struct LogoCategoryFolder
        {
            public static readonly ID ID = new ID("{D4E5880C-F927-48C9-BAC5-D752BAA6B6DF}");

            public struct Fields
            {
                public static readonly ID LogoCategoryName = new ID("{D9197CE4-111A-43E7-B048-3C2A521E583D}");
                public static readonly ID ShowInFooterTopRow = new ID("{0D0C203E-34EF-4C28-8826-1EE1AC32CAEE}");
            }
        }

        public struct LogoItem
        {
            public static readonly ID ID = new ID("{06E22AA5-FEBF-4071-9D5E-EC1FAE63A221}");

            public struct Fields
            {
                public static readonly ID LogoImage = new ID("{68157272-B500-4748-9004-8D2898D42C12}");
                public static readonly ID ShowInFooter = new ID("{587132D3-3C12-4018-AF2A-ABDDF3A0D718}");
            }
        }

        public struct CategoryType
        {
            public static readonly ID ID = new ID("{A5C579F6-2168-49D8-B2A0-E96C33093207}");
        }
    }
}