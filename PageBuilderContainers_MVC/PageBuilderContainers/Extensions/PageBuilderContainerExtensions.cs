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
    public static MvcHtmlString PageBuilderContainerBefore(this HtmlHelper helper, object WidgetModel)
    {
        string Html = "";
        string HtmlBefore = "";
        if (WidgetModel is PageBuilderWidgetProperties)
        {
            if (WidgetModel is PageBuilderWithHtmlBeforeAfterWidgetProperties)
            {
                HtmlBefore = ((PageBuilderWithHtmlBeforeAfterWidgetProperties)WidgetModel).HtmlBefore;
            }

            PageBuilderWidgetProperties ContainerProps = (PageBuilderWidgetProperties)WidgetModel;
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
                    Html = StyleContent + Resolver.ResolveMacros(HtmlBefore+Container.ContainerTextBefore, new EvaluationContext(Resolver, HtmlBefore + Container.ContainerTextBefore));
                } else
                {
                    Html = Resolver.ResolveMacros(HtmlBefore, new EvaluationContext(Resolver, HtmlBefore));
                }
            }
        }
        return new MvcHtmlString(Html);
    }

    public static MvcHtmlString PageBuilderContainerAfter(this HtmlHelper helper, object WidgetModel)
    {
        string Html = "";
        string HtmlAfter = "";
        if (WidgetModel is PageBuilderWidgetProperties)
        {
            if (WidgetModel is PageBuilderWithHtmlBeforeAfterWidgetProperties)
            {
                HtmlAfter = ((PageBuilderWithHtmlBeforeAfterWidgetProperties)WidgetModel).HtmlAfter;
            }

            PageBuilderWidgetProperties ContainerProps = (PageBuilderWidgetProperties)WidgetModel;
            if (!string.IsNullOrWhiteSpace(ContainerProps.ContainerName))
            {
                var Container = GetPageBuilderContainer(ContainerProps.ContainerName);
                MacroResolver Resolver = MacroResolver.GetInstance();
                if (Container != null)
                {
                    Resolver.SetNamedSourceData("ContainerTitle", ContainerProps.ContainerTitle);
                    Resolver.SetNamedSourceData("ContainerCustomContent", ContainerProps.ContainerCustomContent);
                    Resolver.SetNamedSourceData("ContainerCSSClass", ContainerProps.ContainerCSSClass);
                    Html = Resolver.ResolveMacros(Container.ContainerTextAfter+HtmlAfter, new EvaluationContext(Resolver, Container.ContainerTextAfter + HtmlAfter));
                } else
                {
                    Html = Resolver.ResolveMacros(HtmlAfter, new EvaluationContext(Resolver, HtmlAfter));
                }
            }
        }
        return new MvcHtmlString(Html);
    }

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
