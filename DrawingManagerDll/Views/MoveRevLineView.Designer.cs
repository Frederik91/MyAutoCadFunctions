namespace DrawingManagerDll.Views
{
    partial class MoveRevLineView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MoveAttributeButton = new System.Windows.Forms.Button();
            this.MoveAboveBellow = new System.Windows.Forms.CheckBox();
            this.DirectionSelect = new System.Windows.Forms.ComboBox();
            this.RevisionToMove = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MoveAttributeButton
            // 
            this.MoveAttributeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.MoveAttributeButton.Location = new System.Drawing.Point(184, 60);
            this.MoveAttributeButton.Name = "MoveAttributeButton";
            this.MoveAttributeButton.Size = new System.Drawing.Size(75, 23);
            this.MoveAttributeButton.TabIndex = 0;
            this.MoveAttributeButton.Text = "Run";
            this.MoveAttributeButton.UseVisualStyleBackColor = true;
            this.MoveAttributeButton.Click += new System.EventHandler(this.MoveAttributeButton_Click);
            // 
            // MoveAboveBellow
            // 
            this.MoveAboveBellow.AutoSize = true;
            this.MoveAboveBellow.Location = new System.Drawing.Point(15, 64);
            this.MoveAboveBellow.Name = "MoveAboveBellow";
            this.MoveAboveBellow.Size = new System.Drawing.Size(149, 17);
            this.MoveAboveBellow.TabIndex = 1;
            this.MoveAboveBellow.Text = "Adjust remaining attributes";
            this.MoveAboveBellow.UseVisualStyleBackColor = true;
            this.MoveAboveBellow.CheckedChanged += new System.EventHandler(this.MoveAboveBellow_CheckedChanged);
            // 
            // DirectionSelect
            // 
            this.DirectionSelect.FormattingEnabled = true;
            this.DirectionSelect.Location = new System.Drawing.Point(170, 24);
            this.DirectionSelect.Name = "DirectionSelect";
            this.DirectionSelect.Size = new System.Drawing.Size(89, 21);
            this.DirectionSelect.TabIndex = 2;
            this.DirectionSelect.SelectedIndexChanged += new System.EventHandler(this.DirectionSelect_SelectedIndexChanged);
            // 
            // RevisionToMove
            // 
            this.RevisionToMove.HideSelection = false;
            this.RevisionToMove.Location = new System.Drawing.Point(15, 25);
            this.RevisionToMove.Name = "RevisionToMove";
            this.RevisionToMove.Size = new System.Drawing.Size(89, 20);
            this.RevisionToMove.TabIndex = 3;
            this.RevisionToMove.TextChanged += new System.EventHandler(this.RevisionTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Revision to move:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Direction to move:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // MoveRevLineView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 97);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RevisionToMove);
            this.Controls.Add(this.DirectionSelect);
            this.Controls.Add(this.MoveAboveBellow);
            this.Controls.Add(this.MoveAttributeButton);
            this.Name = "MoveRevLineView";
            this.Text = "MoveRevLineView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MoveAttributeButton;
        private System.Windows.Forms.CheckBox MoveAboveBellow;
        private System.Windows.Forms.ComboBox DirectionSelect;
        private System.Windows.Forms.TextBox RevisionToMove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}