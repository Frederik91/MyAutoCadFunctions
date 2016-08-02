namespace XrefManager.Forms
{
    partial class UpdateLayerAddProjectForm
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
            this.ProjectName_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConfigPath_textBox = new System.Windows.Forms.TextBox();
            this.ConfigPath_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RootFolder_listBox = new System.Windows.Forms.TextBox();
            this.RootFolder_button = new System.Windows.Forms.Button();
            this.AddProject_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project name:";
            // 
            // ProjectName_textBox
            // 
            this.ProjectName_textBox.Location = new System.Drawing.Point(89, 10);
            this.ProjectName_textBox.Name = "ProjectName_textBox";
            this.ProjectName_textBox.Size = new System.Drawing.Size(235, 20);
            this.ProjectName_textBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Config path:";
            // 
            // ConfigPath_textBox
            // 
            this.ConfigPath_textBox.Location = new System.Drawing.Point(89, 36);
            this.ConfigPath_textBox.Name = "ConfigPath_textBox";
            this.ConfigPath_textBox.Size = new System.Drawing.Size(235, 20);
            this.ConfigPath_textBox.TabIndex = 3;
            // 
            // ConfigPath_button
            // 
            this.ConfigPath_button.Location = new System.Drawing.Point(330, 37);
            this.ConfigPath_button.Name = "ConfigPath_button";
            this.ConfigPath_button.Size = new System.Drawing.Size(75, 23);
            this.ConfigPath_button.TabIndex = 4;
            this.ConfigPath_button.Text = "Browse";
            this.ConfigPath_button.UseVisualStyleBackColor = true;
            this.ConfigPath_button.Click += new System.EventHandler(this.ConfigPath_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Root folder:";
            // 
            // RootFolder_listBox
            // 
            this.RootFolder_listBox.Location = new System.Drawing.Point(89, 62);
            this.RootFolder_listBox.Name = "RootFolder_listBox";
            this.RootFolder_listBox.Size = new System.Drawing.Size(235, 20);
            this.RootFolder_listBox.TabIndex = 6;
            // 
            // RootFolder_button
            // 
            this.RootFolder_button.Location = new System.Drawing.Point(330, 60);
            this.RootFolder_button.Name = "RootFolder_button";
            this.RootFolder_button.Size = new System.Drawing.Size(75, 23);
            this.RootFolder_button.TabIndex = 7;
            this.RootFolder_button.Text = "Browse";
            this.RootFolder_button.UseVisualStyleBackColor = true;
            this.RootFolder_button.Click += new System.EventHandler(this.RootFolder_button_Click);
            // 
            // AddProject_button
            // 
            this.AddProject_button.Location = new System.Drawing.Point(15, 89);
            this.AddProject_button.Name = "AddProject_button";
            this.AddProject_button.Size = new System.Drawing.Size(390, 23);
            this.AddProject_button.TabIndex = 8;
            this.AddProject_button.Text = "Save";
            this.AddProject_button.UseVisualStyleBackColor = true;
            this.AddProject_button.Click += new System.EventHandler(this.AddProject_button_Click);
            // 
            // UpdateLayerAddProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 122);
            this.Controls.Add(this.AddProject_button);
            this.Controls.Add(this.RootFolder_button);
            this.Controls.Add(this.RootFolder_listBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ConfigPath_button);
            this.Controls.Add(this.ConfigPath_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProjectName_textBox);
            this.Controls.Add(this.label1);
            this.Name = "UpdateLayerAddProjectForm";
            this.Text = "Add new project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ProjectName_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ConfigPath_textBox;
        private System.Windows.Forms.Button ConfigPath_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RootFolder_listBox;
        private System.Windows.Forms.Button RootFolder_button;
        private System.Windows.Forms.Button AddProject_button;
    }
}