using CMS;
using CMS.Helpers;
using CMS.MacroEngine;
using PageBuilderContainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

public static class PageBuilderContainerExtensions
{
    /// <summary>
    /// Renders any IHtmlBeforeAfterContainerProperties and IPageBuilderContainerProperties
    /// </summary>
    /// <param name="helper">Html Helper</param>
    /// <param name="ComponentModel">The component model object that should inherit IHtmlBeforeAfterContainerProperties and/or IPageBuilderContainerProperties</param>
    /// <returns>The content before the component</returns>
    public static MvcHtmlString PageBuilderContainerBefore(this HtmlHelper helper, object ComponentModel)
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
                    HtmlWrapper = Resolver.ResolveMacros(HtmlWrapper, new EvaluationContext(Resolver, HtmlWrapper));
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
                    HtmlContainer = StyleContent + Resolver.ResolveMacros(Container.ContainerTextBefore, new EvaluationContext(Resolver, Container.ContainerTextBefore));
                }
            }
        }
        return new MvcHtmlString(HtmlWrapper + HtmlContainer);
    }

    /// <summary>
    /// Renders any IHtmlBeforeAfterContainerProperties and IPageBuilderContainerProperties
    /// </summary>
    /// <param name="helper">Html Helper</param>
    /// <param name="ComponentModel">The component model object that should inherit IHtmlBeforeAfterContainerProperties and/or IPageBuilderContainerProperties</param>
    /// <returns>The content after the component</returns>
    public static MvcHtmlString PageBuilderContainerAfter(this HtmlHelper helper, object ComponentModel)
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
                    HtmlWrapper = Resolver.ResolveMacros(HtmlWrapper, new EvaluationContext(Resolver, HtmlWrapper));
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
                    HtmlContainer = StyleContent + Resolver.ResolveMacros(Container.ContainerTextAfter, new EvaluationContext(Resolver, Container.ContainerTextAfter));
                }
            }
        }
        return new MvcHtmlString(HtmlContainer + HtmlWrapper);
    }

    /// <summary>
    /// Gets the Component Info
    /// </summary>
    /// <param name="Name"></param>
    /// <returns></returns>
    private static PageBuilderContainerInfo GetPageBuilderContainer(string Name)
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
