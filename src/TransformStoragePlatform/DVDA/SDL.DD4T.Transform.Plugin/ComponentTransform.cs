using System;
using System.Collections.Generic;
using System.Text;
using DD4T.ContentModel;
using DVDA.Contracts.Plugins;
using IItem = DVDA.Contracts.Transform.IItem;

namespace SDL.DD4T.Transform.Plugin
{
    public class ComponentTransform : ITransformPlugin<IComponentPresentation>
    {
        public string Id => "DD4T.SDL.COMPONENTPRESENTATION";
        public string Name => "DD4T Component Presentation Transform";
        public IItem Transform(IComponentPresentation sourceData)
        {
            throw new NotImplementedException();
        }
    }
}
