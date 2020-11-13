using CMS;
using CMS.Helpers;
using CMS.MacroEngine;

namespace PageBuilderContainers.Base
{
    public class PageBuilderContainerHelper : IPageBuilderContainerHelper
    {
        public string GetPageBuilderContainerAfter(object ComponentModel)
        {
            string HtmlContainer = "";
            string HtmlWrapper = "";
            if (ComponentModel is IHtmlBeforeAfterContainerProperties HtmlBeforeAfterProps)
            {
                if (!string.IsNullOrWhiteSpace(HtmlBeforeAfterProps.HtmlAfter))
                {
                    HtmlWrapper = HtmlBeforeAfterProps.HtmlAfter;
                    // Apply macro engine if needed 
                    if (HtmlWrapper.IndexOf("{") > -1)
                    {
                        MacroResolver Resolver = MacroResolver.GetInstance();
                        //HtmlWrapper = Resolver.ResolveMacros(HtmlWrapper, new EvaluationContext(Resolver, HtmlWrapper));
                        HtmlWrapper = Resolver.ResolveMacros(HtmlWrapper);
                    }
                }
            }
            if (ComponentModel is IPageBuilderContainerProperties ContainerProps)
            {
                if (!string.IsNullOrWhiteSpace(ContainerProps.ContainerName))
                {
                    var Container = GetPageBuilderContainer(ContainerProps.ContainerName);
                    MacroResolver Resolver = MacroResolver.GetInstance();
                    if (Container != null)
                    {
                        Resolver.SetNamedSourceData("ContainerTitle", ContainerProps.ContainerTitle);
                        Resolver.SetNamedSourceData("ContainerCustomContent", ContainerProps.ContainerCustomContent);
                        Resolver.SetNamedSourceData("ContainerCSSClass", ContainerProps.ContainerCSSClass);
                        HtmlContainer = Resolver.ResolveMacros(Container.ContainerTextAfter);
                    }
                }
            }
            return HtmlContainer + HtmlWrapper;
        }

        public string GetPageBuilderContainerBefore(object ComponentModel)
        {
            string HtmlContainer = "";
            string HtmlWrapper = "";
            if (ComponentModel is IHtmlBeforeAfterContainerProperties HtmlBeforeAfterProps)
            {
                if (!string.IsNullOrWhiteSpace(HtmlBeforeAfterProps.HtmlBefore))
                {
                    HtmlWrapper = HtmlBeforeAfterProps.HtmlBefore;
                    // Apply macro engine if needed
                    if (HtmlWrapper.IndexOf("{") > -1)
                    {
                        MacroResolver Resolver = MacroResolver.GetInstance();
                        HtmlWrapper = Resolver.ResolveMacros(HtmlWrapper);
                    }
                }
            }
            if (ComponentModel is IPageBuilderContainerProperties ContainerProps)
            {
                if (!string.IsNullOrWhiteSpace(ContainerProps.ContainerName))
                {
                    var Container = GetPageBuilderContainer(ContainerProps.ContainerName);
                    MacroResolver Resolver = MacroResolver.GetInstance();
                    if (Container != null)
                    {
                        Resolver.SetNamedSourceData("ContainerTitle", ContainerProps.ContainerTitle);
                        Resolver.SetNamedSourceData("ContainerCustomContent", ContainerProps.ContainerCustomContent);
                        Resolver.SetNamedSourceData("ContainerCSSClass", ContainerProps.ContainerCSSClass);
                        string StyleContent = (!string.IsNullOrWhiteSpace(Container.ContainerCSS) ? string.Format("<style>{0}</style>", Container.ContainerCSS) : "");
                        HtmlContainer = StyleContent + Resolver.ResolveMacros(Container.ContainerTextBefore);
                    }
                }
            }
            return HtmlWrapper + HtmlContainer;
        }

        /// <summary>
        /// Gets the Component Info
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private PageBuilderContainerInfo GetPageBuilderContainer(string Name)
        {
            return CacheHelper.Cache<PageBuilderContainerInfo>(cs =>
            {
                if (cs.Cached)
                {
                    cs.CacheDependency = CacheHelper.GetCacheDependency("cms.pagebuildercontainer|byname|" + Name);
                }
                return PageBuilderContainerInfoProvider.GetPageBuilderContainerInfo(Name);
            }, new CacheSettings(1440, "GetPageBuilderContainerInfo", Name));
        }
    }
}
