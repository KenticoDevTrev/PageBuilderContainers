namespace PageBuilderContainers
{
    /// <summary>
    /// Adds the Html content before and after the component.  View must use @Html.PageBuilderContainerBefore(Model) and @Html.PageBuilderContainerAfter(Model) (or Model.Properties if using ComponentViewModel)
    /// </summary>
    public interface IHtmlBeforeAfterContainerProperties
    {
        /// <summary>
        /// Html content before the component
        /// </summary>
        string HtmlBefore { get; set; }

        /// <summary>
        /// Html content after the component
        /// </summary>
        string HtmlAfter { get; set; }
    }
}
