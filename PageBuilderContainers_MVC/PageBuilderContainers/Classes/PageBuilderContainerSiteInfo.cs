using System;
using System.Data;
using System.Runtime.Serialization;

using CMS;
using CMS.DataEngine;
using CMS.Helpers;

[assembly: RegisterObjectType(typeof(PageBuilderContainerSiteInfo), PageBuilderContainerSiteInfo.OBJECT_TYPE)]

namespace CMS
{
    /// <summary>
    /// Data container class for <see cref="PageBuilderContainerSiteInfo"/>.
    /// </summary>
    [Serializable]
    public partial class PageBuilderContainerSiteInfo : AbstractInfo<PageBuilderContainerSiteInfo>
    {
        /// <summary>
        /// Object type.
        /// </summary>
        public const string OBJECT_TYPE = "cms.pagebuildercontainersite";


        /// <summary>
        /// Type information.
        /// </summary>
        public static readonly ObjectTypeInfo TYPEINFO = new ObjectTypeInfo(typeof(PageBuilderContainerSiteInfoProvider), OBJECT_TYPE, "CMS.PageBuilderContainerSite", "ContainerSiteID", null, null, null, null, null, "SiteID", "PageBuilderContainerID", "cms.pagebuildercontainer")
        {
            ModuleName = "PageBuilderContainers",
            TouchCacheDependencies = true,
            IsBinding = true,
            ImportExportSettings =
            {
                LogExport = false
            },
            ContinuousIntegrationSettings =
            {
                Enabled = true
            },

            LogEvents = false,
            SupportsVersioning = false,
        };


        /// <summary>
        /// Container site ID
        /// </summary>
        [DatabaseField]
        public virtual int ContainerSiteID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("ContainerSiteID"), 0);
            }
            set
            {
                SetValue("ContainerSiteID", value);
            }
        }


        /// <summary>
        /// Page builder container ID
        /// </summary>
        [DatabaseField]
        public virtual int PageBuilderContainerID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("PageBuilderContainerID"), 0);
            }
            set
            {
                SetValue("PageBuilderContainerID", value);
            }
        }


        /// <summary>
        /// Site ID
        /// </summary>
        [DatabaseField]
        public virtual int SiteID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("SiteID"), 0);
            }
            set
            {
                SetValue("SiteID", value);
            }
        }


        /// <summary>
        /// Deletes the object using appropriate provider.
        /// </summary>
        protected override void DeleteObject()
        {
            PageBuilderContainerSiteInfoProvider.DeletePageBuilderContainerSiteInfo(this);
        }


        /// <summary>
        /// Updates the object using appropriate provider.
        /// </summary>
        protected override void SetObject()
        {
            PageBuilderContainerSiteInfoProvider.SetPageBuilderContainerSiteInfo(this);
        }


        /// <summary>
        /// Constructor for de-serialization.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected PageBuilderContainerSiteInfo(SerializationInfo info, StreamingContext context)
            : base(info, context, TYPEINFO)
        {
        }


        /// <summary>
        /// Creates an empty instance of the <see cref="PageBuilderContainerSiteInfo"/> class.
        /// </summary>
        public PageBuilderContainerSiteInfo()
            : base(TYPEINFO)
        {
        }


        /// <summary>
        /// Creates a new instance of the <see cref="PageBuilderContainerSiteInfo"/> class from the given <see cref="DataRow"/>.
        /// </summary>
        /// <param name="dr">DataRow with the object data.</param>
        public PageBuilderContainerSiteInfo(DataRow dr)
            : base(TYPEINFO, dr)
        {
        }
    }
}