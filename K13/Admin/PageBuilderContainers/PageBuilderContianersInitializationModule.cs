﻿using CMS;
using CMS.DataEngine;
using CMS.Modules;
using NuGet;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Versioning;
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
            if (e.ResourceName.Equals("PageBuilderContainers", System.StringComparison.InvariantCultureIgnoreCase))
            {
                // Change the name
                e.Manifest.Metadata.Title = "Kentico Page Builder Containers";
                e.Manifest.Metadata.SetProjectUrl("https://github.com/KenticoDevTrev/PageBuilderContainers");
                e.Manifest.Metadata.SetIconUrl("https://www.hbs.net/HBS/media/Favicon/favicon-96x96.png");
                e.Manifest.Metadata.Tags = "Kentico MVC Page Builder Containers";
                e.Manifest.Metadata.Id = "PageBuilderContainers.Kentico";
                e.Manifest.Metadata.ReleaseNotes = "Fixed admin NuSpect Manifest Overwrite so it would only adjust packages for this PageBuilderContainer, was affecting any other modules.";
                // Add nuget dependencies

                // Add dependencies
                List<PackageDependency> NetStandardDependencies = new List<PackageDependency>()
                {
                    new PackageDependency("Kentico.Xperience.Libraries", new VersionRange(new NuGetVersion("13.0.0")), new string[] { }, new string[] {"Build","Analyzers"}),
                    new PackageDependency("PageBuilderContainers.Kentico.Base", new VersionRange(new NuGetVersion("13.0.1")), new string[] { }, new string[] {"Build","Analyzers"})
                };
                PackageDependencyGroup PackageGroup = new PackageDependencyGroup(new NuGet.Frameworks.NuGetFramework(".NETStandard2.0"), NetStandardDependencies);
                e.Manifest.Metadata.DependencyGroups = new PackageDependencyGroup[] { PackageGroup };
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
}
