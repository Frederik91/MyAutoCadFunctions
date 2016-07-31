namespace XrefManager.Forms
{
    partial class PurgeAttributeForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Puge_tab = new System.Windows.Forms.TabPage();
            this.Attribute_tab = new System.Windows.Forms.TabPage();
            this.PurgeBrowse_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Purge_listBox = new System.Windows.Forms.ListBox();
            this.PurgeStart_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.attributeBlockname_textBox = new System.Windows.Forms.TextBox();
            this.attributeAttributeName_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.attributeOldValue_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.attributeNewValue_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.attributeStart_button = new System.Windows.Forms.Button();
            this.attributeBrowse_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.attributeDrawingList_listBox = new System.Windows.Forms.ListBox();
            this.tabControl.SuspendLayout();
            this.Puge_tab.SuspendLayout();
            this.Attribute_tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Puge_tab);
            this.tabControl.Controls.Add(this.Attribute_tab);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(355, 308);
            this.tabControl.TabIndex = 0;
            // 
            // Puge_tab
            // 
            this.Puge_tab.Controls.Add(this.PurgeStart_button);
            this.Puge_tab.Controls.Add(this.Purge_listBox);
            this.Puge_tab.Controls.Add(this.label1);
            this.Puge_tab.Controls.Add(this.PurgeBrowse_button);
            this.Puge_tab.Location = new System.Drawing.Point(4, 22);
            this.Puge_tab.Name = "Puge_tab";
            this.Puge_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Puge_tab.Size = new System.Drawing.Size(347, 282);
            this.Puge_tab.TabIndex = 0;
            this.Puge_tab.Text = "Purge";
            this.Puge_tab.UseVisualStyleBackColor = true;
            // 
            // Attribute_tab
            // 
            this.Attribute_tab.Controls.Add(this.attributeDrawingList_listBox);
            this.Attribute_tab.Controls.Add(this.label6);
            this.Attribute_tab.Controls.Add(this.attributeBrowse_button);
            this.Attribute_tab.Controls.Add(this.attributeStart_button);
            this.Attribute_tab.Controls.Add(this.attributeNewValue_textBox);
            this.Attribute_tab.Controls.Add(this.label5);
            this.Attribute_tab.Controls.Add(this.attributeOldValue_textBox);
            this.Attribute_tab.Controls.Add(this.label4);
            this.Attribute_tab.Controls.Add(this.attributeAttributeName_textBox);
            this.Attribute_tab.Controls.Add(this.label3);
            this.Attribute_tab.Controls.Add(this.attributeBlockname_textBox);
            this.Attribute_tab.Controls.Add(this.label2);
            this.Attribute_tab.Location = new System.Drawing.Point(4, 22);
            this.Attribute_tab.Name = "Attribute_tab";
            this.Attribute_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Attribute_tab.Size = new System.Drawing.Size(347, 282);
            this.Attribute_tab.TabIndex = 1;
            this.Attribute_tab.Text = "Attribute";
            this.Attribute_tab.UseVisualStyleBackColor = true;
            // 
            // PurgeBrowse_button
            // 
            this.PurgeBrowse_button.Location = new System.Drawing.Point(7, 7);
            this.PurgeBrowse_button.Name = "PurgeBrowse_button";
            this.PurgeBrowse_button.Size = new System.Drawing.Size(75, 23);
            this.PurgeBrowse_button.TabIndex = 0;
            this.PurgeBrowse_button.Text = "Browse";
            this.PurgeBrowse_button.UseVisualStyleBackColor = true;
            this.PurgeBrowse_button.Click += new System.EventHandler(this.PurgeBrowse_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select drawings to purge";
            // 
            // Purge_listBox
            // 
            this.Purge_listBox.FormattingEnabled = true;
            this.Purge_listBox.Location = new System.Drawing.Point(7, 37);
            this.Purge_listBox.Name = "Purge_listBox";
            this.Purge_listBox.Size = new System.Drawing.Size(334, 212);
            this.Purge_listBox.TabIndex = 2;
            // 
            // PurgeStart_button
            // 
            this.PurgeStart_button.Location = new System.Drawing.Point(7, 255);
            this.PurgeStart_button.Name = "PurgeStart_button";
            this.PurgeStart_button.Size = new System.Drawing.Size(334, 23);
            this.PurgeStart_button.TabIndex = 3;
            this.PurgeStart_button.Text = "Purge";
            this.PurgeStart_button.UseVisualStyleBackColor = true;
            this.PurgeStart_button.Click += new System.EventHandler(this.PurgeStart_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Block name:";
            // 
            // attributeBlockname_textBox
            // 
            this.attributeBlockname_textBox.Location = new System.Drawing.Point(109, 9);
            this.attributeBlockname_textBox.Name = "attributeBlockname_textBox";
            this.attributeBlockname_textBox.Size = new System.Drawing.Size(232, 20);
            this.attributeBlockname_textBox.TabIndex = 2;
            // 
            // attributeAttributeName_textBox
            // 
            this.attributeAttributeName_textBox.Location = new System.Drawing.Point(109, 35);
            this.attributeAttributeName_textBox.Name = "attributeAttributeName_textBox";
            this.attributeAttributeName_textBox.Size = new System.Drawing.Size(232, 20);
            this.attributeAttributeName_textBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Attribute name:";
            // 
            // attributeOldValue_textBox
            // 
            this.attributeOldValue_textBox.Location = new System.Drawing.Point(109, 61);
            this.attributeOldValue_textBox.Name = "attributeOldValue_textBox";
            this.attributeOldValue_textBox.Size = new System.Drawing.Size(232, 20);
            this.attributeOldValue_textBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Old value:";
            // 
            // attributeNewValue_textBox
            // 
            this.attributeNewValue_textBox.Location = new System.Drawing.Point(109, 87);
            this.attributeNewValue_textBox.Name = "attributeNewValue_textBox";
            this.attributeNewValue_textBox.Size = new System.Drawing.Size(232, 20);
            this.attributeNewValue_textBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "New value:";
            // 
            // attributeStart_button
            // 
            this.attributeStart_button.Location = new System.Drawing.Point(9, 253);
            this.attributeStart_button.Name = "attributeStart_button";
            this.attributeStart_button.Size = new System.Drawing.Size(332, 23);
            this.attributeStart_button.TabIndex = 9;
            this.attributeStart_button.Text = "Update attribute value";
            this.attributeStart_button.UseVisualStyleBackColor = true;
            this.attributeStart_button.Click += new System.EventHandler(this.attributeStart_button_Click);
            // 
            // attributeBrowse_button
            // 
            this.attributeBrowse_button.Location = new System.Drawing.Point(9, 111);
            this.attributeBrowse_button.Name = "attributeBrowse_button";
            this.attributeBrowse_button.Size = new System.Drawing.Size(75, 23);
            this.attributeBrowse_button.TabIndex = 10;
            this.attributeBrowse_button.Text = "Browse";
            this.attributeBrowse_button.UseVisualStyleBackColor = true;
            this.attributeBrowse_button.Click += new System.EventHandler(this.attributeBrowse_button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(109, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Select drawings to update attribute";
            // 
            // attributeDrawingList_listBox
            // 
            this.attributeDrawingList_listBox.FormattingEnabled = true;
            this.attributeDrawingList_listBox.Location = new System.Drawing.Point(9, 141);
            this.attributeDrawingList_listBox.Name = "attributeDrawingList_listBox";
            this.attributeDrawingList_listBox.Size = new System.Drawing.Size(332, 108);
            this.attributeDrawingList_listBox.TabIndex = 12;
            // 
            // PurgeAttributeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 332);
            this.Controls.Add(this.tabControl);
            this.Name = "PurgeAttributeForm";
            this.Text = "PurgeAttributeForm";
            this.tabControl.ResumeLayout(false);
            this.Puge_tab.ResumeLayout(false);
            this.Puge_tab.PerformLayout();
            this.Attribute_tab.ResumeLayout(false);
            this.Attribute_tab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Puge_tab;
        private System.Windows.Forms.TabPage Attribute_tab;
        private System.Windows.Forms.Button PurgeStart_button;
        private System.Windows.Forms.ListBox Purge_listBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PurgeBrowse_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox attributeAttributeName_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox attributeBlockname_textBox;
        private System.Windows.Forms.TextBox attributeNewValue_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox attributeOldValue_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button attributeStart_button;
        private System.Windows.Forms.ListBox attributeDrawingList_listBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button attributeBrowse_button;
    }
}