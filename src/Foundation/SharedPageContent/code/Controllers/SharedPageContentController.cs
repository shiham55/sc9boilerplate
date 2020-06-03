﻿using scboilerplate.Foundation.SharedPageContent.Repositories;
using scboilerplate.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace scboilerplate.Foundation.SharedPageContent.Controllers
{
    public class SharedPageContentController : SitecoreController
    {
        private ISharedPageContentRepository _mainContentRepository;

        public SharedPageContentController() : this(new SharedPageContentRepository(RenderingContext.Current.Rendering.Item))
        {
        }

        public SharedPageContentController(ISharedPageContentRepository mainContentRepository)
        {
            this._mainContentRepository = mainContentRepository;
        }

        public ActionResult MultipleTitles()
        {
            return View("~/Views/scboilerplate/SharedPageContent/MultipleTitles.cshtml", this._mainContentRepository.GetMultipleTitle());
        }

        public ActionResult MetaTags()
        {
            var metaTags = this._mainContentRepository.GetMetaTags();
            if (metaTags != null)
            {
                var ogImage = (ImageField)metaTags.SCItem.Fields["OG Image"];
                var twitterImage = (ImageField)metaTags.SCItem.Fields["Twitter Image"];
                metaTags.OGImageUrl = (ogImage == null) ? string.Empty : ogImage.ImageAbsoluteUrl();
                metaTags.TwitterImageUrl = (twitterImage == null) ? string.Empty : twitterImage.ImageAbsoluteUrl();
            }

            return View("~/Views/scboilerplate/SharedPageContent/MetaTags.cshtml", metaTags);
        }
    }
}