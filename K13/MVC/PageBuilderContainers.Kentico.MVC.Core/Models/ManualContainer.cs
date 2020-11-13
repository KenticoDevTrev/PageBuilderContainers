using System;
using System.Collections.Generic;
using System.Text;

namespace PageBuilderContainers.Kentico.MVC.Core
{
    public class ManualContainer : IPageBuilderContainerProperties
    {
        public ManualContainer()
        {

        }

        public string ContainerName { get; set; }
        public string ContainerTitle { get; set; }
        public string ContainerCSSClass { get; set; }
        public string ContainerCustomContent { get; set; }
    }
}
