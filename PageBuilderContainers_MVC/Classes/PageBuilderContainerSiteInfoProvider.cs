using System.Linq;
using CMS.DataEngine;
using CMS.SiteProvider;

namespace CMS
{
    /// <summary>
    /// Class providing <see cref="PageBuilderContainerSiteInfo"/> management.
    /// </summary>
    public partial class PageBuilderContainerSiteInfoProvider : AbstractInfoProvider<PageBuilderContainerSiteInfo, PageBuilderContainerSiteInfoProvider>
    {
        /// <summary>
        /// Returns all <see cref="PageBuilderContainerSiteInfo"/> bindings.
        /// </summary>
        public static ObjectQuery<PageBuilderContainerSiteInfo> GetPageBuilderContainerSites()
        {
            return ProviderObject.GetObjectQuery();
        }


        /// <summary>
        /// Returns <see cref="PageBuilderContainerSiteInfo"/> binding structure.
        /// </summary>
        /// <param name="pagebuildercontainerId">ObjectType.cms_pagebuildercontainer ID.</param>
        /// <param name="siteId">Site ID.</param>
        public static PageBuilderContainerSiteInfo GetPageBuilderContainerSiteInfo(int pagebuildercontainerId, int siteId)
        {
            return ProviderObject.GetObjectQuery().TopN(1)
                .WhereEquals("PageBuilderContainerID", pagebuildercontainerId)
                .WhereEquals("SiteID", siteId)
                .FirstOrDefault();
        }


        /// <summary>
        /// Sets specified <see cref="PageBuilderContainerSiteInfo"/>.
        /// </summary>
        /// <param name="infoObj"><see cref="PageBuilderContainerSiteInfo"/> to set.</param>
        public static void SetPageBuilderContainerSiteInfo(PageBuilderContainerSiteInfo infoObj)
        {
            ProviderObject.SetInfo(infoObj);
        }


        /// <summary>
        /// Deletes specified <see cref="PageBuilderContainerSiteInfo"/> binding.
        /// </summary>
        /// <param name="infoObj"><see cref="PageBuilderContainerSiteInfo"/> object.</param>
        public static void DeletePageBuilderContainerSiteInfo(PageBuilderContainerSiteInfo infoObj)
        {
            ProviderObject.DeleteInfo(infoObj);
        }


        /// <summary>
        /// Deletes <see cref="PageBuilderContainerSiteInfo"/> binding.
        /// </summary>
        /// <param name="pagebuildercontainerId">ObjectType.cms_pagebuildercontainer ID.</param>
        /// <param name="siteId">Site ID.</param>
        public static void RemovePageBuilderContainerFromSite(int pagebuildercontainerId, int siteId)
        {
            var infoObj = GetPageBuilderContainerSiteInfo(pagebuildercontainerId, siteId);
            if (infoObj != null)
            {
                DeletePageBuilderContainerSiteInfo(infoObj);
            }
        }


        /// <summary>
        /// Creates <see cref="PageBuilderContainerSiteInfo"/> binding.
        /// </summary>
        /// <param name="pagebuildercontainerId">ObjectType.cms_pagebuildercontainer ID.</param>
        /// <param name="siteId">Site ID.</param>
        public static void AddPageBuilderContainerToSite(int pagebuildercontainerId, int siteId)
        {
            // Create new binding
            var infoObj = new PageBuilderContainerSiteInfo();
            infoObj.PageBuilderContainerID = pagebuildercontainerId;
            infoObj.SiteID = siteId;

            // Save to the database
            SetPageBuilderContainerSiteInfo(infoObj);
        }


        public static void AddContainerToSite(PageBuilderContainerInfo Container, SiteInfo Site)
        {
            if (PageBuilderContainerSiteInfoProvider.GetPageBuilderContainerSiteInfo(Container.PageBuilderContainerID, Site.SiteID) == null)
            {
                PageBuilderContainerSiteInfoProvider.AddPageBuilderContainerToSite(Container.PageBuilderContainerID, Site.SiteID);
            }
        }
    }
}