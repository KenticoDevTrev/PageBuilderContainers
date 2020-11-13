using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageBuilderContainers
{
    /// <summary>
    /// Renders the Page Builder Container around your component.  View must use @Html.PageBuilderContainerBefore(Model) and @Html.PageBuilderContainerAfter(Model) (or Model.Properties if using ComponentViewModel)
    /// </summary>
    public interface IPageBuilderContainerProperties
    {
        /// <summary>
        /// The Page Builder Container Code name
        /// </summary>
        string ContainerName { get; set; }

        /// <summary>
        /// The Container Title.  The page builder container renders this in the {% ContainerTitle %} macro
        /// </summary>
        string ContainerTitle { get; set; }

        /// <summary>
        /// The Container CSS class.  The page builder container renders this in the {% COntainerCSSClass %} macro
        /// </summary>
        string ContainerCSSClass { get; set; }

        /// <summary>
        /// THe Container Custom Content.  The page builder container renders this in the {% ContainerCustomContent %} macro
        /// </summary>
        string ContainerCustomContent { get; set; }
    }
}