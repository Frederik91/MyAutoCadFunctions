﻿using Autodesk.AutoCAD.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerConfigEditor.Models
{
    public class LayerFilter
    {
        public string LayerName { get; set; }
        public bool Freeze { get; set; }
        public bool Thaw { get; set; }
        public Color Color { get; set; }
        public bool LayerOn { get; set; }
        public bool LayerOff { get; set; }
        public int Priority { get; set; }
    }
}
