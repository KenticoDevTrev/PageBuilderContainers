using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace PageBuilderContainers
{
    /// <summary>
    /// Base instance of the IHtmlBeforeAfterContainerProperties, you can have your widget model inherit this instead of implementing yourself.
    /// </summary>
    public class HtmlBeforeAfterWidgetProperties : IHtmlBeforeAfterContainerProperties, IWidgetProperties
    {

        [EditingComponent(TextAreaComponent.IDENTIFIER, Order = 994, Label = "HTML Before")]
        public string HtmlBefore { get; set; }

        [EditingComponent(TextAreaComponent.IDENTIFIER, Order = 995, Label = "HTML After")]
        public string HtmlAfter { get; set; }
    }
}
