using Kentico.PageBuilder.Web.Mvc;

namespace PageBuilderContainers
{
    public interface IPageBuilderContainerProperties
    {
        string ContainerCSSClass { get; set; }
        string ContainerCustomContent { get; set; }
        string ContainerName { get; set; }
        string ContainerTitle { get; set; }
    }
}