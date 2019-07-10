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
        if (WidgetModel is PageBuilderWidgetProperties)
        {
            PageBuilderWidgetProperties ContainerProps = (PageBuilderWidgetProperties)WidgetModel;
            if (!string.IsNullOrWhiteSpace(ContainerProps.ContainerName))
            {
                var Container = GetPageBuilderContainer(ContainerProps.ContainerName);
                if (Container != null)
                {
                    MacroResolver Resolver = MacroResolver.GetInstance();
                    Resolver.SetNamedSourceData("ContainerTitle", ContainerProps.ContainerTitle);
                    Resolver.SetNamedSourceData("ContainerCustomContent", ContainerProps.ContainerCustomContent);
                    Resolver.SetNamedSourceData("ContainerCSSClass", ContainerProps.ContainerCSSClass);
                    string StyleContent = (!string.IsNullOrWhiteSpace(Container.ContainerCSS) ? string.Format("<style>{0}</style>", Container.ContainerCSS) : "");
                    return new MvcHtmlString(StyleContent+Resolver.ResolveMacros(Container.ContainerTextBefore, new EvaluationContext(Resolver, Container.ContainerTextBefore)));
                }
            }
        }
        return new MvcHtmlString("");
    }

    public static MvcHtmlString PageBuilderContainerAfter(this HtmlHelper helper, object WidgetModel)
    {
        if (WidgetModel is PageBuilderWidgetProperties)
        {
            PageBuilderWidgetProperties ContainerProps = (PageBuilderWidgetProperties)WidgetModel;
            if (!string.IsNullOrWhiteSpace(ContainerProps.ContainerName))
            {
                var Container = GetPageBuilderContainer(ContainerProps.ContainerName);
                if (Container != null)
                {
                    MacroResolver Resolver = MacroResolver.GetInstance();
                    Resolver.SetNamedSourceData("ContainerTitle", ContainerProps.ContainerTitle);
                    Resolver.SetNamedSourceData("ContainerCustomContent", ContainerProps.ContainerCustomContent);
                    Resolver.SetNamedSourceData("ContainerCSSClass", ContainerProps.ContainerCSSClass);
                    return new MvcHtmlString(Resolver.ResolveMacros(Container.ContainerTextAfter, new EvaluationContext(Resolver, Container.ContainerTextAfter)));
                }
            }
        }
        return new MvcHtmlString("");
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
