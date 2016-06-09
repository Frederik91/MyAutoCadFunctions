using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingManagerDll.Models
{
    public class Settings
    {
        public List<DrawingData> DrawingData { get; set; }
        public string TitleBlockName { get; set; }
        public string RevBlockName { get; set; }
        public List<string> PropertyNameList { get; set; }
        public int StartMerkeskilt { get; set; }
        public int StartRevlinje { get; set; }
    }
}
