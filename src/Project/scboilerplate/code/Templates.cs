using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scboilerplate.Project.Website
{
    public class Templates
    {
        public struct PageType
        {
            public struct Home
            {
                public static readonly ID ID = new ID("{E847FAF6-5E6E-4E0A-96B6-74FA0065818A}");
            }

            public struct CategoryListing
            {
                public static readonly ID ID = new ID("{D6A5821A-B4C8-42EE-8491-8661E842BAA4}");
            }

            public struct CategoryDetail
            {
                public static readonly ID ID = new ID("{1F63B6B0-2F5F-49E7-8B75-0867FA1D432D}");
            }
        }

        public struct ContentType
        {
            public struct Folder
            {
                public struct Sustainability
                {
                    public static readonly ID ID = new ID("{AFBC5DEE-C215-4F20-8D0E-91382A549D72}");
                }
            }
        }
    }
}