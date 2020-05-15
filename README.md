# Installation
## Part 1 - Kentico Application ("Mother"):

1. Install `PageBuilderContainers.Kentico` Nuget Package on your Kentico Application
1. Rebuild your web application
1. Log into Kentico as a Global Administrator
1. Go to Modules
1. Search and edit `Page Builder Containers`
1. Go to `Sites` and add to your site.

### Note for WebSite vs. WebApp
If you are upgrading from a previous version of Kentico and your Admin is a WebSite vs. WebApp, you will need to change the following files's top Control tag attribute from "CodeBehind" to "CodeFile" in order for it to work

* CMSModules/PageBuilderContainers/Controls/PageBuilderContainers/General.ascx
* CMSModules/PageBuilderContainers/Controls/PageBuilderContainers/PageBuilderContainerCode.ascx
* CMSModules/PageBuilderContainers/UI/PageBuilderContainers/Container_Edit_General.aspx
* CMSModules/PageBuilderContainers/UI/PageBuilderContainers/Container_Edit_New.aspx

## Part 2 - MVC Site

1. Install the `PageBuilderContainers.Kentico.MVC` NuGet package on your MVC Site and rebuild

## Part 3 - Add to Widgets
1. Have your Widget Properties Model class implement `IPageBuilderContainerProperties`, `IHtmlBeforeAfterContainerProperties` or both.  You can also inherit from the base classes of `PageBuilderContainers.PageBuilderWidgetProperties` or `PageBuilderContainers.PageBuilderWithHtmlBeforeAfterWidgetProperties` if you wish. 
1. In your Widget's View, add `@Html.PageBuilderContainerBefore(Model)` at the beginning of your rendering, and `@Html.PageBuilderContainerAfter(Model)` at the end
- Note: "Model" must be the Widget Property Class object, if using a model of `ComponentViewModel<YourWidgetModelClass>`, then your property may be `Model.Properties` instead of `Model`

# Usage
## Create Containers
1. Go to the Page Builder Containers UI element in Kentico
1. Create your Containers or edit existing. 
1. You can use `{% ContainerTitle %}`, `{% ContainerCSSClass %}`, and `{% ContainerCustomContent %}` as part of the default Container Properties

## Add Widget and configure Container
1. Add your widget to a Page Builder Area in Kentico, you will see the Containers Name, Title, CSS Class, and Custom Content properties in the Widget's configuration dialog (cogwheel icon)
