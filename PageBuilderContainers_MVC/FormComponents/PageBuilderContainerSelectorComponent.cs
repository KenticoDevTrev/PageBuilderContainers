using Kentico.Forms.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;
using CMS;
using CMS.SiteProvider;
using CMS.Helpers;
using PageBuilderContainers;

[assembly: RegisterFormComponent(PageBuilderContainerSelectorComponent.IDENTIFIER, typeof(PageBuilderContainerSelectorComponent), "Drop-down with custom data", IconClass = "icon-menu")]
namespace PageBuilderContainers
{
    public class PageBuilderContainerSelectorComponent : SelectorFormComponent<PageBuilderContainerSelectorProperties>
    {
        public const string IDENTIFIER = "PageBuilderContainerSelectorComponent";


        // Retrieves data to be displayed in the selector
        protected override IEnumerable<SelectListItem> GetItems()
        {
            // Perform data retrieval operations here
            // The following example retrieves all pages of the 'DancingGoatMvc.Article' page type
            // located under the 'Articles' section of the Dancing Goat sample website
            return CacheHelper.Cache<IEnumerable<SelectListItem>>(cs =>
            {
                if (cs.Cached)
                {
                    cs.CacheDependency = CacheHelper.GetCacheDependency(new string[] { "cms.pagebuildercontainer|all", "cms.pagebuildercontainersite|all" });
                }
                var Containers = PageBuilderContainerInfoProvider.GetPageBuilderContainers()
                .WhereIn("PageBuilderContainerID",
                PageBuilderContainerSiteInfoProvider.GetPageBuilderContainerSites().WhereEquals("SiteID", SiteContext.CurrentSiteID).Select(x => x.PageBuilderContainerID).ToArray())
                .OrderBy("ContainerDisplayName")
                .Select(x =>
                    new SelectListItem()
                    {
                        Value = x.ContainerName,
                        Text = x.ContainerDisplayName
                    }
                ).ToList();
                Containers.Insert(0, new SelectListItem()
                {
                    Value = "",
                    Text = "(No Container)"
                });
                return Containers;
            }, new CacheSettings(1440, "GetContainerSelectors", SiteContext.CurrentSiteID));
        }
    }

    public class PageBuilderContainerSelectorProperties : SelectorProperties
    {
        // Implement any required custom properties here
    }
}