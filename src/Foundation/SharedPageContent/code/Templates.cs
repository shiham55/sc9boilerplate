using Sitecore.Data;

namespace scboilerplate.Foundation.SharedPageContent
{
    public class Templates
    {
        public struct MultipleTitles
        {
            public static readonly ID ID = new ID("{A4A8F367-1129-49B6-9DD8-E1D3569B2BCD}");

            public struct Fields
            {
                public static readonly ID MaiDesktopTitleOne = new ID("{DC959EA6-8B45-4713-A550-CBC9AED9DCBA}");
                public static readonly ID MaiDesktopTitleTwo = new ID("{81FE46C7-AA36-4EB9-A45E-C29769F70904}");
                public static readonly ID MobileTitleOne = new ID("{CDE39339-DE94-46E4-BC02-1B8C5DD2F890}");
                public static readonly ID MobileTitleTwo = new ID("{B51EAFC7-ACFD-4080-AF49-3C252BD485D9}");
                public static readonly ID MobileTitleThree = new ID("{33605FCF-7CD3-4B10-B46B-D5C45707A636}");
            }
        }

        public struct Teaser
        {
            public static readonly ID ID = new ID("{C79C29A6-C921-49E4-ABF5-AF1CADFCBEAF}");

            public struct Fields
            {
                public static readonly ID TeaserTitle = new ID("{5AFA8DEB-1B36-40E4-9B1F-78A1D484C7C0}");
                public static readonly ID TeaserContent = new ID("{70A61DA5-B412-4CAA-8660-691B5C62F636}");
                public static readonly ID TeaserImage = new ID("{4CBA29BE-8FEC-4BB3-ACCF-B4997679BCFF}");
            }
        }

        public struct MetaTags
        {
            public static readonly ID ID = new ID("{8906B507-DAE5-47B2-88FE-AB150A470DF0}");
        }
    }
}