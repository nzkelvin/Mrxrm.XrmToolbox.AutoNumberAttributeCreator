using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Mrxrm.XrmToolbox.AutoNumberAttributeCreator
{
    [Export(typeof(IXrmToolBoxPlugin)),
     ExportMetadata("BackgroundColor", "MediumBlue"),
     ExportMetadata("PrimaryFontColor", "White"),
     ExportMetadata("SecondaryFontColor", "LightGray"),
     //ExportMetadata("SmallImageBase64", "a base64 encoded image"),
     //ExportMetadata("BigImageBase64", "a base64 encoded image"),
     ExportMetadata("Name", "My First Plugin name"),
     ExportMetadata("Description", "My First Plugin description")]
    public class SampleToolPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new SampleToolPluginControl();
        }
    }
}
