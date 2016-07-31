namespace XrefManager.Forms
{
    partial class AddXrefForm
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
            this.AddxRefBrowse_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AddXref_textBox = new System.Windows.Forms.TextBox();
            this.AddXrefBrowseDrawings_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.AddXrefStart_button = new System.Windows.Forms.Button();
            this.AddXref_listBox = new System.Windows.Forms.ListBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.Add_tab = new System.Windows.Forms.TabPage();
            this.Unload_tab = new System.Windows.Forms.TabPage();
            this.UnloadXrefStart_button = new System.Windows.Forms.Button();
            this.UnloadXref_listBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UnloadXrefBrowse_button = new System.Windows.Forms.Button();
            this.Detach_tab = new System.Windows.Forms.TabPage();
            this.DetachXrefBrowse_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DetachXref_listBox = new System.Windows.Forms.ListBox();
            this.DetachXrefStart_button = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.Add_tab.SuspendLayout();
            this.Unload_tab.SuspendLayout();
            this.Detach_tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddxRefBrowse_button
            // 
            this.AddxRefBrowse_button.Location = new System.Drawing.Point(6, 37);
            this.AddxRefBrowse_button.Name = "AddxRefBrowse_button";
            this.AddxRefBrowse_button.Size = new System.Drawing.Size(75, 23);
            this.AddxRefBrowse_button.TabIndex = 0;
            this.AddxRefBrowse_button.Text = "Browse";
            this.AddxRefBrowse_button.UseVisualStyleBackColor = true;
            this.AddxRefBrowse_button.Click += new System.EventHandler(this.AddxRefBrowse_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the drawing you want to xref";
            // 
            // AddXref_textBox
            // 
            this.AddXref_textBox.Location = new System.Drawing.Point(97, 39);
            this.AddXref_textBox.Name = "AddXref_textBox";
            this.AddXref_textBox.ReadOnly = true;
            this.AddXref_textBox.Size = new System.Drawing.Size(235, 20);
            this.AddXref_textBox.TabIndex = 2;
            // 
            // AddXrefBrowseDrawings_button
            // 
            this.AddXrefBrowseDrawings_button.Location = new System.Drawing.Point(6, 97);
            this.AddXrefBrowseDrawings_button.Name = "AddXrefBrowseDrawings_button";
            this.AddXrefBrowseDrawings_button.Size = new System.Drawing.Size(75, 23);
            this.AddXrefBrowseDrawings_button.TabIndex = 3;
            this.AddXrefBrowseDrawings_button.Text = "Browse";
            this.AddXrefBrowseDrawings_button.UseVisualStyleBackColor = true;
            this.AddXrefBrowseDrawings_button.Click += new System.EventHandler(this.AddXrefBrowseDrawings_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select the drawings you want to add the selected xref to";
            // 
            // AddXrefStart_button
            // 
            this.AddXrefStart_button.Location = new System.Drawing.Point(10, 265);
            this.AddXrefStart_button.Name = "AddXrefStart_button";
            this.AddXrefStart_button.Size = new System.Drawing.Size(322, 23);
            this.AddXrefStart_button.TabIndex = 7;
            this.AddXrefStart_button.Text = "Add xref to drawings";
            this.AddXrefStart_button.UseVisualStyleBackColor = true;
            this.AddXrefStart_button.Click += new System.EventHandler(this.AddXrefStart_button_Click);
            // 
            // AddXref_listBox
            // 
            this.AddXref_listBox.FormattingEnabled = true;
            this.AddXref_listBox.Location = new System.Drawing.Point(10, 126);
            this.AddXref_listBox.Name = "AddXref_listBox";
            this.AddXref_listBox.Size = new System.Drawing.Size(322, 134);
            this.AddXref_listBox.TabIndex = 9;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.Add_tab);
            this.TabControl.Controls.Add(this.Unload_tab);
            this.TabControl.Controls.Add(this.Detach_tab);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(365, 320);
            this.TabControl.TabIndex = 10;
            // 
            // Add_tab
            // 
            this.Add_tab.Controls.Add(this.AddxRefBrowse_button);
            this.Add_tab.Controls.Add(this.AddXref_listBox);
            this.Add_tab.Controls.Add(this.label1);
            this.Add_tab.Controls.Add(this.AddXrefStart_button);
            this.Add_tab.Controls.Add(this.AddXref_textBox);
            this.Add_tab.Controls.Add(this.label2);
            this.Add_tab.Controls.Add(this.AddXrefBrowseDrawings_button);
            this.Add_tab.Location = new System.Drawing.Point(4, 22);
            this.Add_tab.Name = "Add_tab";
            this.Add_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Add_tab.Size = new System.Drawing.Size(357, 294);
            this.Add_tab.TabIndex = 0;
            this.Add_tab.Text = "Add";
            this.Add_tab.UseVisualStyleBackColor = true;
            // 
            // Unload_tab
            // 
            this.Unload_tab.Controls.Add(this.UnloadXrefStart_button);
            this.Unload_tab.Controls.Add(this.UnloadXref_listBox);
            this.Unload_tab.Controls.Add(this.label3);
            this.Unload_tab.Controls.Add(this.UnloadXrefBrowse_button);
            this.Unload_tab.Location = new System.Drawing.Point(4, 22);
            this.Unload_tab.Name = "Unload_tab";
            this.Unload_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Unload_tab.Size = new System.Drawing.Size(357, 294);
            this.Unload_tab.TabIndex = 1;
            this.Unload_tab.Text = "Unload";
            this.Unload_tab.UseVisualStyleBackColor = true;
            // 
            // UnloadXrefStart_button
            // 
            this.UnloadXrefStart_button.Location = new System.Drawing.Point(3, 263);
            this.UnloadXrefStart_button.Name = "UnloadXrefStart_button";
            this.UnloadXrefStart_button.Size = new System.Drawing.Size(351, 23);
            this.UnloadXrefStart_button.TabIndex = 3;
            this.UnloadXrefStart_button.Text = "Unload xrefs";
            this.UnloadXrefStart_button.UseVisualStyleBackColor = true;
            this.UnloadXrefStart_button.Click += new System.EventHandler(this.UnloadXrefStart_button_Click);
            // 
            // UnloadXref_listBox
            // 
            this.UnloadXref_listBox.FormattingEnabled = true;
            this.UnloadXref_listBox.Location = new System.Drawing.Point(3, 32);
            this.UnloadXref_listBox.Name = "UnloadXref_listBox";
            this.UnloadXref_listBox.Size = new System.Drawing.Size(351, 225);
            this.UnloadXref_listBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Select drawings you want to unload all xrefs in";
            // 
            // UnloadXrefBrowse_button
            // 
            this.UnloadXrefBrowse_button.Location = new System.Drawing.Point(3, 3);
            this.UnloadXrefBrowse_button.Name = "UnloadXrefBrowse_button";
            this.UnloadXrefBrowse_button.Size = new System.Drawing.Size(75, 23);
            this.UnloadXrefBrowse_button.TabIndex = 0;
            this.UnloadXrefBrowse_button.Text = "Browse";
            this.UnloadXrefBrowse_button.UseVisualStyleBackColor = true;
            this.UnloadXrefBrowse_button.Click += new System.EventHandler(this.UnloadXrefBrowse_button_Click);
            // 
            // Detach_tab
            // 
            this.Detach_tab.Controls.Add(this.DetachXrefStart_button);
            this.Detach_tab.Controls.Add(this.DetachXref_listBox);
            this.Detach_tab.Controls.Add(this.label4);
            this.Detach_tab.Controls.Add(this.DetachXrefBrowse_button);
            this.Detach_tab.Location = new System.Drawing.Point(4, 22);
            this.Detach_tab.Name = "Detach_tab";
            this.Detach_tab.Size = new System.Drawing.Size(357, 294);
            this.Detach_tab.TabIndex = 2;
            this.Detach_tab.Text = "Detach";
            this.Detach_tab.UseVisualStyleBackColor = true;
            // 
            // DetachXrefBrowse_button
            // 
            this.DetachXrefBrowse_button.Location = new System.Drawing.Point(3, 3);
            this.DetachXrefBrowse_button.Name = "DetachXrefBrowse_button";
            this.DetachXrefBrowse_button.Size = new System.Drawing.Size(75, 23);
            this.DetachXrefBrowse_button.TabIndex = 0;
            this.DetachXrefBrowse_button.Text = "Browse";
            this.DetachXrefBrowse_button.UseVisualStyleBackColor = true;
            this.DetachXrefBrowse_button.Click += new System.EventHandler(this.DetachXrefBrowse_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Select drawings you want to detach all xrefs in";
            // 
            // DetachXref_listBox
            // 
            this.DetachXref_listBox.FormattingEnabled = true;
            this.DetachXref_listBox.Location = new System.Drawing.Point(3, 32);
            this.DetachXref_listBox.Name = "DetachXref_listBox";
            this.DetachXref_listBox.Size = new System.Drawing.Size(351, 225);
            this.DetachXref_listBox.TabIndex = 2;
            // 
            // DetachXrefStart_button
            // 
            this.DetachXrefStart_button.Location = new System.Drawing.Point(4, 264);
            this.DetachXrefStart_button.Name = "DetachXrefStart_button";
            this.DetachXrefStart_button.Size = new System.Drawing.Size(350, 23);
            this.DetachXrefStart_button.TabIndex = 3;
            this.DetachXrefStart_button.Text = "Detach";
            this.DetachXrefStart_button.UseVisualStyleBackColor = true;
            this.DetachXrefStart_button.Click += new System.EventHandler(this.DetachXrefStart_button_Click);
            // 
            // AddXrefForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 337);
            this.Controls.Add(this.TabControl);
            this.Name = "AddXrefForm";
            this.Text = "AddXrefForm";
            this.Load += new System.EventHandler(this.AddXrefForm_Load);
            this.TabControl.ResumeLayout(false);
            this.Add_tab.ResumeLayout(false);
            this.Add_tab.PerformLayout();
            this.Unload_tab.ResumeLayout(false);
            this.Unload_tab.PerformLayout();
            this.Detach_tab.ResumeLayout(false);
            this.Detach_tab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddxRefBrowse_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AddXref_textBox;
        private System.Windows.Forms.Button AddXrefBrowseDrawings_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddXrefStart_button;
        private System.Windows.Forms.ListBox AddXref_listBox;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage Add_tab;
        private System.Windows.Forms.TabPage Unload_tab;
        private System.Windows.Forms.Button UnloadXrefBrowse_button;
        private System.Windows.Forms.Button UnloadXrefStart_button;
        private System.Windows.Forms.ListBox UnloadXref_listBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage Detach_tab;
        private System.Windows.Forms.Button DetachXrefStart_button;
        private System.Windows.Forms.ListBox DetachXref_listBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button DetachXrefBrowse_button;
    }
}