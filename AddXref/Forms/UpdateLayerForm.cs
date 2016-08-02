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
    public partial class UpdateLayerForm : Form
    {
        public UpdateLayerForm()
        {
            InitializeComponent();
        }

        private void AddProject_button_Click(object sender, EventArgs e)
        {
            using (var AddProjectForm = new UpdateLayerAddProjectForm())
            {
                AddProjectForm.ShowDialog();

            }
            
        }
    }
}
    