using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingManagerDll.Models
{
    public class DrawingData
    {
        public bool ToBeUpdated { get; set; }
        public string DrawingName { get; set; }
        public string FolderPath { get; set; }
        public string Layout { get; set; }
        public List<string> PropertyValueList { get; set; }
    }
}
