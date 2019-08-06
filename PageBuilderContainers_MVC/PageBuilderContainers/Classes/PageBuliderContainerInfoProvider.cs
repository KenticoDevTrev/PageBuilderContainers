using CMS.DataEngine;

namespace CMS
{
    /// <summary>
    /// Class providing <see cref="PageBuilderContainerInfo"/> management.
    /// </summary>
    public partial class PageBuilderContainerInfoProvider : AbstractInfoProvider<PageBuilderContainerInfo, PageBuilderContainerInfoProvider>
    {
        public const string WP_CHAR = "□";

        /// <summary>
        /// Creates an instance of <see cref="PageBuilderContainerInfoProvider"/>.
        /// </summary>
        public PageBuilderContainerInfoProvider()
            : base(PageBuilderContainerInfo.TYPEINFO)
        {
        }


        /// <summary>
        /// Returns a query for all the <see cref="PageBuilderContainerInfo"/> objects.
        /// </summary>
        public static ObjectQuery<PageBuilderContainerInfo> GetPageBuilderContainers()
        {
            return ProviderObject.GetObjectQuery();
        }


        /// <summary>
        /// Returns <see cref="PageBuilderContainerInfo"/> with specified ID.
        /// </summary>
        /// <param name="id"><see cref="PageBuilderContainerInfo"/> ID.</param>
        public static PageBuilderContainerInfo GetPageBuilderContainerInfo(int id)
        {
            return ProviderObject.GetInfoById(id);
        }


        /// <summary>
        /// Returns <see cref="PageBuilderContainerInfo"/> with specified name.
        /// </summary>
        /// <param name="name"><see cref="PageBuilderContainerInfo"/> name.</param>
        public static PageBuilderContainerInfo GetPageBuilderContainerInfo(string name)
        {
            return ProviderObject.GetInfoByCodeName(name);
        }


        /// <summary>
        /// Sets (updates or inserts) specified <see cref="PageBuilderContainerInfo"/>.
        /// </summary>
        /// <param name="infoObj"><see cref="PageBuilderContainerInfo"/> to be set.</param>
        public static void SetPageBuilderContainerInfo(PageBuilderContainerInfo infoObj)
        {
            ProviderObject.SetInfo(infoObj);
        }


        /// <summary>
        /// Deletes specified <see cref="PageBuilderContainerInfo"/>.
        /// </summary>
        /// <param name="infoObj"><see cref="PageBuilderContainerInfo"/> to be deleted.</param>
        public static void DeletePageBuilderContainerInfo(PageBuilderContainerInfo infoObj)
        {
            ProviderObject.DeleteInfo(infoObj);
        }


        /// <summary>
        /// Deletes <see cref="PageBuilderContainerInfo"/> with specified ID.
        /// </summary>
        /// <param name="id"><see cref="PageBuilderContainerInfo"/> ID.</param>
        public static void DeletePageBuilderContainerInfo(int id)
        {
            PageBuilderContainerInfo infoObj = GetPageBuilderContainerInfo(id);
            DeletePageBuilderContainerInfo(infoObj);
        }

    }
}