namespace XrefManager.Forms
{
    partial class UpdateLayerForm
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
            this.Projects_comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddProject_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Drawings_listBox = new System.Windows.Forms.ListBox();
            this.BrowseDrawings_button = new System.Windows.Forms.Button();
            this.StartLayerUpdate_button = new System.Windows.Forms.Button();
            this.EditProject_button = new System.Windows.Forms.Button();
            this.DeleteProject_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Projects_comboBox
            // 
            this.Projects_comboBox.FormattingEnabled = true;
            this.Projects_comboBox.Location = new System.Drawing.Point(12, 29);
            this.Projects_comboBox.Name = "Projects_comboBox";
            this.Projects_comboBox.Size = new System.Drawing.Size(121, 21);
            this.Projects_comboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Saved projects";
            // 
            // AddProject_button
            // 
            this.AddProject_button.Location = new System.Drawing.Point(140, 26);
            this.AddProject_button.Name = "AddProject_button";
            this.AddProject_button.Size = new System.Drawing.Size(38, 23);
            this.AddProject_button.TabIndex = 2;
            this.AddProject_button.Text = "Add";
            this.AddProject_button.UseVisualStyleBackColor = true;
            this.AddProject_button.Click += new System.EventHandler(this.AddProject_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // Drawings_listBox
            // 
            this.Drawings_listBox.FormattingEnabled = true;
            this.Drawings_listBox.Location = new System.Drawing.Point(12, 85);
            this.Drawings_listBox.Name = "Drawings_listBox";
            this.Drawings_listBox.Size = new System.Drawing.Size(259, 134);
            this.Drawings_listBox.TabIndex = 5;
            // 
            // BrowseDrawings_button
            // 
            this.BrowseDrawings_button.Location = new System.Drawing.Point(12, 56);
            this.BrowseDrawings_button.Name = "BrowseDrawings_button";
            this.BrowseDrawings_button.Size = new System.Drawing.Size(75, 23);
            this.BrowseDrawings_button.TabIndex = 6;
            this.BrowseDrawings_button.Text = "Browse";
            this.BrowseDrawings_button.UseVisualStyleBackColor = true;
            this.BrowseDrawings_button.Click += new System.EventHandler(this.BrowseDrawings_button_Click);
            // 
            // StartLayerUpdate_button
            // 
            this.StartLayerUpdate_button.Location = new System.Drawing.Point(12, 225);
            this.StartLayerUpdate_button.Name = "StartLayerUpdate_button";
            this.StartLayerUpdate_button.Size = new System.Drawing.Size(259, 23);
            this.StartLayerUpdate_button.TabIndex = 7;
            this.StartLayerUpdate_button.Text = "Update layers";
            this.StartLayerUpdate_button.UseVisualStyleBackColor = true;
            this.StartLayerUpdate_button.Click += new System.EventHandler(this.StartLayerUpdate_button_Click);
            // 
            // EditProject_button
            // 
            this.EditProject_button.Location = new System.Drawing.Point(184, 26);
            this.EditProject_button.Name = "EditProject_button";
            this.EditProject_button.Size = new System.Drawing.Size(37, 23);
            this.EditProject_button.TabIndex = 8;
            this.EditProject_button.Text = "Edit";
            this.EditProject_button.UseVisualStyleBackColor = true;
            this.EditProject_button.Click += new System.EventHandler(this.EditProject_button_Click);
            // 
            // DeleteProject_button
            // 
            this.DeleteProject_button.Location = new System.Drawing.Point(227, 26);
            this.DeleteProject_button.Name = "DeleteProject_button";
            this.DeleteProject_button.Size = new System.Drawing.Size(44, 23);
            this.DeleteProject_button.TabIndex = 9;
            this.DeleteProject_button.Text = "Del";
            this.DeleteProject_button.UseVisualStyleBackColor = true;
            this.DeleteProject_button.Click += new System.EventHandler(this.DeleteProject_button_Click);
            // 
            // UpdateLayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 255);
            this.Controls.Add(this.DeleteProject_button);
            this.Controls.Add(this.EditProject_button);
            this.Controls.Add(this.StartLayerUpdate_button);
            this.Controls.Add(this.BrowseDrawings_button);
            this.Controls.Add(this.Drawings_listBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddProject_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Projects_comboBox);
            this.Name = "UpdateLayerForm";
            this.Text = "Update layers";
            this.Load += new System.EventHandler(this.UpdateLayerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Projects_comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddProject_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Drawings_listBox;
        private System.Windows.Forms.Button BrowseDrawings_button;
        private System.Windows.Forms.Button StartLayerUpdate_button;
        private System.Windows.Forms.Button EditProject_button;
        private System.Windows.Forms.Button DeleteProject_button;
    }
}