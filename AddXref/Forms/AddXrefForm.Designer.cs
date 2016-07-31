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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.UnloadXrefBrowse_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.UnloadXref_listBox = new System.Windows.Forms.ListBox();
            this.UnloadXrefStart_button = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.AddxRefBrowse_button.Click += new System.EventHandler(this.xRef_Browse_button_Click);
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
            this.AddXref_textBox.TextChanged += new System.EventHandler(this.AddXref_textBox_TextChanged);
            // 
            // AddXrefBrowseDrawings_button
            // 
            this.AddXrefBrowseDrawings_button.Location = new System.Drawing.Point(6, 97);
            this.AddXrefBrowseDrawings_button.Name = "AddXrefBrowseDrawings_button";
            this.AddXrefBrowseDrawings_button.Size = new System.Drawing.Size(75, 23);
            this.AddXrefBrowseDrawings_button.TabIndex = 3;
            this.AddXrefBrowseDrawings_button.Text = "Browse";
            this.AddXrefBrowseDrawings_button.UseVisualStyleBackColor = true;
            this.AddXrefBrowseDrawings_button.Click += new System.EventHandler(this.Browse_drawings_button_Click);
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
            this.AddXrefStart_button.Click += new System.EventHandler(this.button2_Click);
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
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(365, 320);
            this.TabControl.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.AddxRefBrowse_button);
            this.tabPage1.Controls.Add(this.AddXref_listBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.AddXrefStart_button);
            this.tabPage1.Controls.Add(this.AddXref_textBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.AddXrefBrowseDrawings_button);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(357, 294);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.UnloadXrefStart_button);
            this.tabPage2.Controls.Add(this.UnloadXref_listBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.UnloadXrefBrowse_button);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(357, 294);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // UnloadXrefBrowse_button
            // 
            this.UnloadXrefBrowse_button.Location = new System.Drawing.Point(7, 7);
            this.UnloadXrefBrowse_button.Name = "UnloadXrefBrowse_button";
            this.UnloadXrefBrowse_button.Size = new System.Drawing.Size(75, 23);
            this.UnloadXrefBrowse_button.TabIndex = 0;
            this.UnloadXrefBrowse_button.Text = "Browse";
            this.UnloadXrefBrowse_button.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Select drawings you want to un load all xrefs in";
            // 
            // UnloadXref_listBox
            // 
            this.UnloadXref_listBox.FormattingEnabled = true;
            this.UnloadXref_listBox.Location = new System.Drawing.Point(7, 37);
            this.UnloadXref_listBox.Name = "UnloadXref_listBox";
            this.UnloadXref_listBox.Size = new System.Drawing.Size(336, 225);
            this.UnloadXref_listBox.TabIndex = 2;
            // 
            // UnloadXrefStart_button
            // 
            this.UnloadXrefStart_button.Location = new System.Drawing.Point(7, 265);
            this.UnloadXrefStart_button.Name = "UnloadXrefStart_button";
            this.UnloadXrefStart_button.Size = new System.Drawing.Size(336, 23);
            this.UnloadXrefStart_button.TabIndex = 3;
            this.UnloadXrefStart_button.Text = "Unload xrefs";
            this.UnloadXrefStart_button.UseVisualStyleBackColor = true;
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button UnloadXrefBrowse_button;
        private System.Windows.Forms.Button UnloadXrefStart_button;
        private System.Windows.Forms.ListBox UnloadXref_listBox;
        private System.Windows.Forms.Label label3;
    }
}