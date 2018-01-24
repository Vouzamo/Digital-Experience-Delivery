using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;
using DD4T.ContentModel;
using DVDA.Data.Contracts.Plugins;
using DVDA.Data.Contracts.Transform;
using IItem = DVDA.Data.Contracts.Transform.IItem;

namespace SDL.DD4T.Transform.Plugin
{
    [Export]
    public class PageTransform : ITransformPlugin<IPage>
    {
        public string Id => "DD4T.SDL.PAGE";
        public string Name => "DD4T Page TransformItem";

        public TransformType TransformType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IItem TransformItem(IPage sourceData)
        {
            throw new NotImplementedException();
        }

        public IRenderingItem TransformRendering(IPage sourceData)
        {
            throw new NotImplementedException();
        }
    }
}
