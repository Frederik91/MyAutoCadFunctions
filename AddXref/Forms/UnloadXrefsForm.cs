using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XrefManager.Forms
{
    public partial class UnloadXrefsForm : Form
    {
        public List<string> drawings { get; set; }

        public UnloadXrefsForm()
        {
            InitializeComponent();
        }

        private void BrowseDrawings_button_Click(object sender, EventArgs e)
        {
            var UX = new UnloadXref();
            UX.getDrawingList();
        }

        private void StartUnload_button_Click(object sender, EventArgs e)
        {

        }
    }
}
