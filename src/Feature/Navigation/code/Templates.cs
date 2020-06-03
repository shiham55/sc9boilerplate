namespace scboilerplate.Feature.Navigation
{
    using Sitecore.Data;

    public struct Templates
    {
        public struct NavigationRoot
        {
            public static readonly ID ID = new ID("{AFEC9DE6-75A6-4CC4-812C-E9F5DBC12086}");
        }

        public struct Folder
        {
            public static readonly ID ID = new ID("{AFBC5DEE-C215-4F20-8D0E-91382A549D72}");
        }

        public struct Navigable
        {
            public static readonly ID ID = new ID("{A42597C5-A827-4282-95FB-BA489686A3E5}");

            public struct Fields
            {
                public static readonly ID ShowInNavigation = new ID("{AB1C8DD9-ECE9-48B7-A477-CAAD3175EF9E}");
                public static readonly ID NavigationTitle = new ID("{906C903F-43EC-4261-8E84-B38F67FF3C06}");
                public static readonly ID ShowInSiteMap = new ID("{24A5771D-8C10-4C24-8105-F3F202BD5A08}");
            }
        }

        public struct Link
        {
            public static readonly ID ID = new ID("{90969DF0-503A-493D-8AB9-F26134157CAA}");

            public struct Fields
            {
                public static readonly ID Link = new ID("{3EA372CA-8D39-41C4-809F-E686804C05DE}");
            }
        }

        public struct LinkMenuItem
        {
            public static readonly ID ID = new ID("{93AB91FD-BC28-45C8-8884-BAE4D1A40005}");

            public struct Fields
            {
                public static readonly ID Icon = new ID("{BA48F483-C5A3-430E-BF1B-FFBAAF5E207E}");
                public static readonly ID DividerBefore = new ID("{964CF365-3012-4EFF-A357-CA5C66CEFEC8}");
            }
        }

        public struct Footer
        {
            public static readonly ID ID = new ID("{E7C7C48B-2EB0-461C-AC08-16F074FE544C}");

            public struct Fields
            {
                public static readonly ID FooterLink1 = new ID("{423386CA-1764-4B57-8F52-30723CB82505}");
                public static readonly ID FooterLink2 = new ID("{A4CDE9FA-0C62-4575-8783-F7BEADE52B20}");
                public static readonly ID FooterLink3 = new ID("{81417D27-1D4E-4A85-8093-63C2FC02384A}");
                public static readonly ID FooterLink4 = new ID("{4039C68E-C4A1-45A5-816C-24E27CD88673}");
                public static readonly ID ContactUs = new ID("{419285A2-A1B0-4BA2-984A-8E217CF73AE0}");
                public static readonly ID CopyRightText = new ID("{4E493518-ABCC-4F4F-82F7-A046947DFCE1}");
                public static readonly ID SubscribeText = new ID("{1C214DFA-459F-482C-81CF-C69DFD90E8C6}");
                public static readonly ID SubscribeLink = new ID("{BF020A79-AD8D-4F40-B71F-7A09126911ED}");
                public static readonly ID FacebookIcon = new ID("{AFDF26C7-97AF-4784-92D8-E948FD6ED38D}");
                public static readonly ID TwitterIcon = new ID("{2DD342B5-AF2E-4423-A4D1-37E8A8689A05}");
                public static readonly ID EmailIcon = new ID("{BB12E9A4-9EFF-40F9-AE20-CFF18E9508E1}");
            }
        }

        public struct Logo
        {
            public static readonly ID ID = new ID("{7C028025-8F6F-4A3D-84B3-0609260DC0F2}");

            public struct Fields
            {
                public static readonly ID iLightLogo = new ID("{880CD131-4781-437A-BDA2-A87609BBB551}");
                public static readonly ID iLightLogolink = new ID("{2507AE69-CD75-41F4-9192-186711103958}");
            }
        }

        public struct Notification
        {
            public static readonly ID ID = new ID("");
        }

        public struct HiddenTemplatesInMainNavigation
        {
            public static readonly ID CategoryDetailID = new ID("{F291C03F-1329-49C3-8FB4-1F4AEBA6B355}");
        }
    }
}