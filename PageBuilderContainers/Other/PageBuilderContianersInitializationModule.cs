using CMS;
using CMS.DataEngine;
using CMS.Modules;
using NuGet;
using PageBuilderContainers;
using System.Collections.Generic;
using System.Web;

[assembly: RegisterModule(typeof(PageBuilderContianersInitializationModule))]

namespace PageBuilderContainers
{
    public class PageBuilderContianersInitializationModule : Module
    {
        public PageBuilderContianersInitializationModule()
            : base("PageBuilderContianersInitializationModule")
        {
        }

        // Contains initialization code that is executed when the application starts
        protected override void OnInit()
        {
            base.OnInit();

            ModulePackagingEvents.Instance.BuildNuSpecManifest.After += BuildNuSpecManifest_After;
        }

        private void BuildNuSpecManifest_After(object sender, BuildNuSpecManifestEventArgs e)
        {
            // Change the name
            e.Manifest.Metadata.Title = "Kentico Page Builder Containers";
            e.Manifest.Metadata.ProjectUrl = "https://github.com/KenticoDevTrev/PageBuilderContainers";
            e.Manifest.Metadata.IconUrl = "https://raw.githubusercontent.com/Kentico/devnet.kentico.com/master/marketplace/assets/generic-integration.png";
            e.Manifest.Metadata.Tags = "Kentico MVC Page Builder Containers";
            e.Manifest.Metadata.Id = "PageBuilderContainers.Kentico";
            e.Manifest.Metadata.ReleaseNotes = "Changed Icon and updated assembly";

            // Add in Designer.cs and .cs files since really hard to include these in class library due to depenencies
            string BaseDir = HttpContext.Current.Server.MapPath("~").Trim('\\');
            e.Manifest.Files.AddRange(new ManifestFile[]{
                new ManifestFile()
                {
                    Source=BaseDir+"\\CMSModules\\PageBuilderContainers\\Controls\\PageBuilderContainers\\General.ascx.cs",
                    Target="\\Content\\CMSModules\\PageBuilderContainers\\Controls\\PageBuilderContainers\\General.ascx.cs",
                },
                new ManifestFile()
                {
                    Source=BaseDir+"\\CMSModules\\PageBuilderContainers\\Controls\\PageBuilderContainers\\General.ascx.designer.cs",
                    Target="\\Content\\CMSModules\\PageBuilderContainers\\Controls\\PageBuilderContainers\\General.ascx.designer.cs",
                },
                new ManifestFile()
                {
                    Source=BaseDir+"\\CMSModules\\PageBuilderContainers\\Controls\\PageBuilderContainers\\PageBuilderContainerCode.ascx.cs",
                    Target="\\Content\\CMSModules\\PageBuilderContainers\\Controls\\PageBuilderContainers\\PageBuilderContainerCode.ascx.cs",
                },
                new ManifestFile()
                {
                    Source=BaseDir+"\\CMSModules\\PageBuilderContainers\\Controls\\PageBuilderContainers\\PageBuilderContainerCode.ascx.designer.cs",
                    Target="\\Content\\CMSModules\\PageBuilderContainers\\Controls\\PageBuilderContainers\\PageBuilderContainerCode.ascx.designer.cs",
                },
                new ManifestFile()
                {
                    Source=BaseDir+"\\CMSModules\\PageBuilderContainers\\UI\\PageBuilderContainers\\Container_Edit_General.aspx.cs",
                    Target="\\Content\\CMSModules\\PageBuilderContainers\\UI\\PageBuilderContainers\\Container_Edit_General.aspx.cs",
                },
                new ManifestFile()
                {
                    Source=BaseDir+"\\CMSModules\\PageBuilderContainers\\UI\\PageBuilderContainers\\Container_Edit_General.aspx.designer.cs",
                    Target="\\Content\\CMSModules\\PageBuilderContainers\\UI\\PageBuilderContainers\\Container_Edit_General.aspx.designer.cs",
                },
                new ManifestFile()
                {
                    Source=BaseDir+"\\CMSModules\\PageBuilderContainers\\UI\\PageBuilderContainers\\Container_New.aspx.cs",
                    Target="\\Content\\CMSModules\\PageBuilderContainers\\UI\\PageBuilderContainers\\Container_New.aspx.cs",
                },
                new ManifestFile()
                {
                    Source=BaseDir+"\\CMSModules\\PageBuilderContainers\\UI\\PageBuilderContainers\\Container_New.aspx.designer.cs",
                    Target="\\Content\\CMSModules\\PageBuilderContainers\\UI\\PageBuilderContainers\\Container_New.aspx.designer.cs",
                }
            });
        }
    }
}
