using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrefManager
{
    public class LayerProperties
    {
        public string Name { get; set; }
        public bool freeze { get; set; }
        public bool thaw { get; set; }
        public string Color { get; set; }
        public bool layerOff { get; set; }
        public bool layerOn { get; set; }
    }
}
