namespace XrefManager.Forms
{
    partial class UnloadXrefsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.Drawings_listBox = new System.Windows.Forms.ListBox();
            this.BrowseDrawings_button = new System.Windows.Forms.Button();
            this.StartUnload_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select drawings you want to un load all xrefs in";
            // 
            // Drawings_listBox
            // 
            this.Drawings_listBox.FormattingEnabled = true;
            this.Drawings_listBox.Location = new System.Drawing.Point(12, 41);
            this.Drawings_listBox.Name = "Drawings_listBox";
            this.Drawings_listBox.Size = new System.Drawing.Size(333, 212);
            this.Drawings_listBox.TabIndex = 1;
            // 
            // BrowseDrawings_button
            // 
            this.BrowseDrawings_button.Location = new System.Drawing.Point(12, 12);
            this.BrowseDrawings_button.Name = "BrowseDrawings_button";
            this.BrowseDrawings_button.Size = new System.Drawing.Size(75, 23);
            this.BrowseDrawings_button.TabIndex = 2;
            this.BrowseDrawings_button.Text = "Browse";
            this.BrowseDrawings_button.UseVisualStyleBackColor = true;
            this.BrowseDrawings_button.Click += new System.EventHandler(this.BrowseDrawings_button_Click);
            // 
            // StartUnload_button
            // 
            this.StartUnload_button.Location = new System.Drawing.Point(12, 262);
            this.StartUnload_button.Name = "StartUnload_button";
            this.StartUnload_button.Size = new System.Drawing.Size(333, 23);
            this.StartUnload_button.TabIndex = 3;
            this.StartUnload_button.Text = "Unload xrefs";
            this.StartUnload_button.UseVisualStyleBackColor = true;
            this.StartUnload_button.Click += new System.EventHandler(this.StartUnload_button_Click);
            // 
            // UnloadXrefsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 297);
            this.Controls.Add(this.StartUnload_button);
            this.Controls.Add(this.BrowseDrawings_button);
            this.Controls.Add(this.Drawings_listBox);
            this.Controls.Add(this.label1);
            this.Name = "UnloadXrefsForm";
            this.Text = "UnloadXrefsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox Drawings_listBox;
        private System.Windows.Forms.Button BrowseDrawings_button;
        private System.Windows.Forms.Button StartUnload_button;
    }
}