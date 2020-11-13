
# Installation
## Part 1 - Kentico Application ("Mother"):

1. Install `PageBuilderContainers.Kentico` Nuget Package on your Kentico Application
1. Rebuild your web application
1. Log into Kentico as a Global Administrator
1. Go to Modules
1. Search and edit `Page Builder Containers`
1. Go to `Sites` and add to your site.

## Part 2 - Install on MVC Site

### For MVC.Net Framework

1. Install the `PageBuilderContainers.Kentico.MVC` NuGet package on your MVC Site and rebuild

### For MVC.Net Core

* Open your MVC.Net core web app, and install this nuget package.
* In your `_ViewImports.cshtml` file, add `@addTagHelper *, PageBuilderContainers.Kentico.MVC.Core`
* In your Startup.ConfigureServices, add this implementation: `            services.AddSingleton(typeof(IPageBuilderContainerHelper), typeof(PageBuilderContainerHelper));
`

# Add to Widgets
Have your Widget Properties Model class implement `IPageBuilderContainerProperties`, `IHtmlBeforeAfterContainerProperties` or both.  

You can also inherit from the base classes of `PageBuilderContainers.PageBuilderWidgetProperties` or `PageBuilderContainers.PageBuilderWithHtmlBeforeAfterWidgetProperties` if you wish as these already have the proper `[EditingFormComponent]` Attributes for each field

This tool includes a Form Component for selecting the Container Name:
       `[EditingComponent(PageBuilderContainerSelectorComponent.IDENTIFIER, Order = 990, Label = "Container Name")]`
       
# Add to Models
You can also have models inherit the `IPageBuilderContainerProperties` and/or `IHtmlBeforeAfterContainerProperties` and leverate containers for other objects, you just won't be able to use the Widget configurations.

# Usage

## For MVC.Net Framework
In your Widget's View, add `@Html.PageBuilderContainerBefore(Model)` at the beginning of your rendering, and `@Html.PageBuilderContainerAfter(Model)` at the end
- Note: "Model" must be the Widget Property Class object, if using a model of `ComponentViewModel<YourWidgetModelClass>`, then your property may be `Model.Properties` instead of `Model`

Additionally you can pass any Model that inherites from either `IPageBuilderContainerProperties` or `IHtmlBeforeAfterContainerProperties`

## For MVC.Net Core
.Net Core leverages TagHelpers and includes a custom containered class.

In your razor views, use the `<containered></containered>` tag as such:

```html
<!-- Example of manually setting container, title, class, and custom content -->
<containered container-name="TestContainer" container-title="Test Title" container-css-class="SomeClass" container-custom-content="Custom Content">
	The Stuff that is to be wrapped
</containered>

<!-- Example of passing a model that inherits either IPageBuilderContainerProperties and/or IHtmlBeforeAfterContainerProperties -->
<containered container-name="TestContainer" container-model="Model.ContainerModelItem">
	The Stuff that is to be wrapped
</containered>
```

# Create Containers
1. Go to the Page Builder Containers UI element in Kentico
1. Create your Containers or edit existing. 
1. You can use `{% ContainerTitle %}`, `{% ContainerCSSClass %}`, and `{% ContainerCustomContent %}` as part of the default Container Properties

# Add Widget and Configure Container
1. Add your widget to a Page Builder Area in Kentico, you will see the Containers Name, Title, CSS Class, and Custom Content properties in the Widget's configuration dialog (cogwheel icon)

# Acknowledgement, Contributions, bug fixes and License

This tool is free for all to use.

# Compatability
Can be used on any Kentico 12 SP site (hotfix 29 or above), and Kentico 13 (both .Net Core and .Net)
