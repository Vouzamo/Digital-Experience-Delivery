using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;
using DD4T.ContentModel;
using DVDA.Contracts.Plugins;
using IItem = DVDA.Contracts.Transform.IItem;

namespace SDL.DD4T.Transform.Plugin
{
    [Export]
    public class PageTransform : ITransformPlugin<IPage>
    {
        public string Id => "DD4T.SDL.PAGE";
        public string Name => "DD4T Page Transform";
        public IItem Transform(IPage sourceData)
        {
            throw new NotImplementedException();
        }
    }
}
