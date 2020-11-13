using CMS.Helpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PageBuilderContainers.Kentico.MVC.Core;
using System.Threading.Tasks;

namespace PageBuilderContainers.TagHelpers
{
    [HtmlTargetElement("containered", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class PageBuilderContainerTagHelper : TagHelper
    {
        public object ContainerModel { get; set; }

        // Manual
        public string ContainerName { get; set; }
        public string ContainerTitle { get; set; }
        public string ContainerCssClass { get; set; }
        public string ContainerCustomContent { get; set; }

        public PageBuilderContainerTagHelper(IPageBuilderContainerHelper pageBuilderContainerHelper)
        {
            PageBuilderContainerHelper = pageBuilderContainerHelper;
        }

        public IPageBuilderContainerHelper PageBuilderContainerHelper { get; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            var ContainerObj = GetContainerObject(ContainerModel);
            // Render
            if(ContainerObj != null)
            {
                output.Content.SetHtmlContent(PageBuilderContainerHelper.GetPageBuilderContainerBefore(ContainerModel) + output.Content.GetContent() + PageBuilderContainerHelper.GetPageBuilderContainerAfter(ContainerModel));
            }
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            var content = await output.GetChildContentAsync();
            var ContainerObj = GetContainerObject(ContainerModel);
            // Render
            if (ContainerObj != null)
            {
                output.Content.SetHtmlContent(PageBuilderContainerHelper.GetPageBuilderContainerBefore(ContainerObj) + content.GetContent() + PageBuilderContainerHelper.GetPageBuilderContainerAfter(ContainerObj));
            }
        }

        private object GetContainerObject(object ContainerModel)
        {
            if (ContainerModel != null)
            {
                return ContainerModel;
            }
            if (!string.IsNullOrWhiteSpace(ContainerName))
            {
                return new ManualContainer()
                {
                    ContainerName = ContainerName,
                    ContainerTitle = ValidationHelper.GetString(ContainerTitle, string.Empty),
                    ContainerCSSClass = ValidationHelper.GetString(ContainerCssClass, string.Empty),
                    ContainerCustomContent = ValidationHelper.GetString(ContainerCustomContent, string.Empty)
                };
            }
            return null;
        }
    }


}
