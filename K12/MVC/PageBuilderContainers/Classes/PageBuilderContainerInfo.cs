using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

using CMS;
using CMS.DataEngine;
using CMS.Helpers;

[assembly: RegisterObjectType(typeof(PageBuilderContainerInfo), PageBuilderContainerInfo.OBJECT_TYPE)]

namespace CMS
{
    /// <summary>
    /// Data container class for <see cref="PageBuilderContainerInfo"/>.
    /// </summary>
    [Serializable]
    public partial class PageBuilderContainerInfo : AbstractInfo<PageBuilderContainerInfo>
    {
        /// <summary>
        /// Object type.
        /// </summary>
        public const string OBJECT_TYPE = "cms.pagebuildercontainer";


        /// <summary>
        /// Type information.
        /// </summary>
        public static readonly ObjectTypeInfo TYPEINFO = new ObjectTypeInfo(typeof(PageBuilderContainerInfoProvider), OBJECT_TYPE, "CMS.PageBuilderContainer", "PageBuilderContainerID", "PageBuilderContainerLastModified", "PageBuilderContainerGuid", "ContainerName", "ContainerDisplayName", null, null, null, null)
        {
            ModuleName = "PageBuilderContainers",
            TouchCacheDependencies = true,
            LogEvents = true,
            SupportsCloning = true,
            SupportsCloneToOtherSite = true,
            SupportsVersioning=true,
            ImportExportSettings =
            {
                IsExportable = true,
                ObjectTreeLocations = new List<ObjectTreeLocation>()
                {
                    new ObjectTreeLocation(GLOBAL, "##DEVELOPMENT##")
                }
            },
            SynchronizationSettings =
            {
                LogSynchronization = SynchronizationTypeEnum.LogSynchronization,
                ObjectTreeLocations = new List<ObjectTreeLocation>()
                {
                    // Adds the custom class into a new category in the Global objects section of the staging tree
                    new ObjectTreeLocation(GLOBAL,"##DEVELOPMENT##")
                },
            },
            ContinuousIntegrationSettings =
            {
                Enabled = true
            },
            ContainsMacros = true,
            CheckPermissions = true
        };


        /// <summary>
        /// Page builder container ID.
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
        /// Container display name.
        /// </summary>
        [DatabaseField]
        public virtual string ContainerDisplayName
        {
            get
            {
                return ValidationHelper.GetString(GetValue("ContainerDisplayName"), String.Empty);
            }
            set
            {
                SetValue("ContainerDisplayName", value);
            }
        }


        /// <summary>
        /// Container name.
        /// </summary>
        [DatabaseField]
        public virtual string ContainerName
        {
            get
            {
                return ValidationHelper.GetString(GetValue("ContainerName"), String.Empty);
            }
            set
            {
                SetValue("ContainerName", value);
            }
        }


        /// <summary>
        /// Container text before.
        /// </summary>
        [DatabaseField]
        public virtual string ContainerTextBefore
        {
            get
            {
                return ValidationHelper.GetString(GetValue("ContainerTextBefore"), String.Empty);
            }
            set
            {
                SetValue("ContainerTextBefore", value, String.Empty);
            }
        }


        /// <summary>
        /// Container text after.
        /// </summary>
        [DatabaseField]
        public virtual string ContainerTextAfter
        {
            get
            {
                return ValidationHelper.GetString(GetValue("ContainerTextAfter"), String.Empty);
            }
            set
            {
                SetValue("ContainerTextAfter", value, String.Empty);
            }
        }


        /// <summary>
        /// Container CSS.
        /// </summary>
        [DatabaseField]
        public virtual string ContainerCSS
        {
            get
            {
                return ValidationHelper.GetString(GetValue("ContainerCSS"), String.Empty);
            }
            set
            {
                SetValue("ContainerCSS", value, String.Empty);
            }
        }


        /// <summary>
        /// Page builder container guid.
        /// </summary>
        [DatabaseField]
        public virtual Guid PageBuilderContainerGuid
        {
            get
            {
                return ValidationHelper.GetGuid(GetValue("PageBuilderContainerGuid"), Guid.Empty);
            }
            set
            {
                SetValue("PageBuilderContainerGuid", value);
            }
        }


        /// <summary>
        /// Page builder container last modified.
        /// </summary>
        [DatabaseField]
        public virtual DateTime PageBuilderContainerLastModified
        {
            get
            {
                return ValidationHelper.GetDateTime(GetValue("PageBuilderContainerLastModified"), DateTimeHelper.ZERO_TIME);
            }
            set
            {
                SetValue("PageBuilderContainerLastModified", value);
            }
        }


        /// <summary>
        /// Deletes the object using appropriate provider.
        /// </summary>
        protected override void DeleteObject()
        {
            PageBuilderContainerInfoProvider.DeletePageBuilderContainerInfo(this);
        }


        /// <summary>
        /// Updates the object using appropriate provider.
        /// </summary>
        protected override void SetObject()
        {
            PageBuilderContainerInfoProvider.SetPageBuilderContainerInfo(this);
        }


        /// <summary>
        /// Constructor for de-serialization.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected PageBuilderContainerInfo(SerializationInfo info, StreamingContext context)
            : base(info, context, TYPEINFO)
        {
        }


        /// <summary>
        /// Creates an empty instance of the <see cref="PageBuilderContainerInfo"/> class.
        /// </summary>
        public PageBuilderContainerInfo()
            : base(TYPEINFO)
        {
        }


        /// <summary>
        /// Creates a new instances of the <see cref="PageBuilderContainerInfo"/> class from the given <see cref="DataRow"/>.
        /// </summary>
        /// <param name="dr">DataRow with the object data.</param>
        public PageBuilderContainerInfo(DataRow dr)
            : base(TYPEINFO, dr)
        {
        }
    }
}