using DrawingManagerDll.Methods;
using DrawingManagerDll.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingManagerDll.Views
{
    public partial class MoveRevLineView : Form
    {
        private string revisionToMove;
        private bool FitRemainingRevLines;
        private List<string> DirectionList = new List<string>();
        private string SelectedDirection;
        private Settings _settings;
        private MoveRevisionLineCommand MRLC;


        public MoveRevLineView(Settings settings, MoveRevisionLineCommand _MRLC)
        {
            InitializeComponent();

            MRLC = _MRLC;
            _settings = settings;

            DirectionList.Add("Up");
            DirectionList.Add("Down");
            DirectionSelect.DataSource = DirectionList;
        }

        private void RevisionTextBox_TextChanged(object sender, EventArgs e)
        {
            revisionToMove = RevisionToMove.Text;
        }

        private void MoveAttributeButton_Click(object sender, EventArgs e)
        {

            MRLC.ExecuteMove(_settings, revisionToMove, SelectedDirection, FitRemainingRevLines);

            Close();
        }

        private void MoveAboveBellow_CheckedChanged(object sender, EventArgs e)
        {
            FitRemainingRevLines = MoveAboveBellow.Checked;
        }

        private void DirectionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedDirection = DirectionSelect.SelectedValue.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
