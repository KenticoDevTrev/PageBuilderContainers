using System;
using System.Collections.Generic;
using System.Text;

namespace PageBuilderContainers
{
    public interface IPageBuilderContainerHelper
    {
        string GetPageBuilderContainerBefore(object ComponentModel);

            string GetPageBuilderContainerAfter(object ComponentModel);
    }
}
