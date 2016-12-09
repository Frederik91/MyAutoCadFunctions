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
            this.PurgeStart_button = new System.Windows.Forms.Button();
            this.Purge_listBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PurgeBrowse_button = new System.Windows.Forms.Button();
            this.Attribute_tab = new System.Windows.Forms.TabPage();
            this.ChangeAttribute_comboBox = new System.Windows.Forms.ComboBox();
            this.ChangeAttributeName_textBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SelectBlock_button = new System.Windows.Forms.Button();
            this.LinkAttributes_comboBox = new System.Windows.Forms.ComboBox();
            this.attributeDrawingList_listBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.attributeBrowse_button = new System.Windows.Forms.Button();
            this.attributeStart_button = new System.Windows.Forms.Button();
            this.ChangeAttributeValue_textBox = new System.Windows.Forms.TextBox();
            this.LinkAttributeValue_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.attributeLinkAttributeName_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.attributeBlockname_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.tabControl.Size = new System.Drawing.Size(355, 361);
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
            this.Puge_tab.Size = new System.Drawing.Size(347, 335);
            this.Puge_tab.TabIndex = 0;
            this.Puge_tab.Text = "Purge";
            this.Puge_tab.UseVisualStyleBackColor = true;
            // 
            // PurgeStart_button
            // 
            this.PurgeStart_button.Location = new System.Drawing.Point(7, 306);
            this.PurgeStart_button.Name = "PurgeStart_button";
            this.PurgeStart_button.Size = new System.Drawing.Size(334, 23);
            this.PurgeStart_button.TabIndex = 3;
            this.PurgeStart_button.Text = "Purge";
            this.PurgeStart_button.UseVisualStyleBackColor = true;
            this.PurgeStart_button.Click += new System.EventHandler(this.PurgeStart_button_Click);
            // 
            // Purge_listBox
            // 
            this.Purge_listBox.FormattingEnabled = true;
            this.Purge_listBox.Location = new System.Drawing.Point(7, 37);
            this.Purge_listBox.Name = "Purge_listBox";
            this.Purge_listBox.Size = new System.Drawing.Size(334, 264);
            this.Purge_listBox.TabIndex = 2;
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
            // Attribute_tab
            // 
            this.Attribute_tab.Controls.Add(this.ChangeAttribute_comboBox);
            this.Attribute_tab.Controls.Add(this.ChangeAttributeName_textBox);
            this.Attribute_tab.Controls.Add(this.label9);
            this.Attribute_tab.Controls.Add(this.label8);
            this.Attribute_tab.Controls.Add(this.label7);
            this.Attribute_tab.Controls.Add(this.SelectBlock_button);
            this.Attribute_tab.Controls.Add(this.LinkAttributes_comboBox);
            this.Attribute_tab.Controls.Add(this.attributeDrawingList_listBox);
            this.Attribute_tab.Controls.Add(this.label6);
            this.Attribute_tab.Controls.Add(this.attributeBrowse_button);
            this.Attribute_tab.Controls.Add(this.attributeStart_button);
            this.Attribute_tab.Controls.Add(this.ChangeAttributeValue_textBox);
            this.Attribute_tab.Controls.Add(this.LinkAttributeValue_textBox);
            this.Attribute_tab.Controls.Add(this.label4);
            this.Attribute_tab.Controls.Add(this.attributeLinkAttributeName_textBox);
            this.Attribute_tab.Controls.Add(this.label3);
            this.Attribute_tab.Controls.Add(this.attributeBlockname_textBox);
            this.Attribute_tab.Controls.Add(this.label2);
            this.Attribute_tab.Location = new System.Drawing.Point(4, 22);
            this.Attribute_tab.Name = "Attribute_tab";
            this.Attribute_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Attribute_tab.Size = new System.Drawing.Size(347, 335);
            this.Attribute_tab.TabIndex = 1;
            this.Attribute_tab.Text = "Attribute";
            this.Attribute_tab.UseVisualStyleBackColor = true;
            // 
            // ChangeAttribute_comboBox
            // 
            this.ChangeAttribute_comboBox.FormattingEnabled = true;
            this.ChangeAttribute_comboBox.Location = new System.Drawing.Point(232, 137);
            this.ChangeAttribute_comboBox.Name = "ChangeAttribute_comboBox";
            this.ChangeAttribute_comboBox.Size = new System.Drawing.Size(106, 21);
            this.ChangeAttribute_comboBox.TabIndex = 20;
            this.ChangeAttribute_comboBox.SelectedIndexChanged += new System.EventHandler(this.ChangeAttribute_comboBox_SelectedIndexChanged);
            // 
            // ChangeAttributeName_textBox
            // 
            this.ChangeAttributeName_textBox.Location = new System.Drawing.Point(107, 137);
            this.ChangeAttributeName_textBox.Name = "ChangeAttributeName_textBox";
            this.ChangeAttributeName_textBox.Size = new System.Drawing.Size(119, 20);
            this.ChangeAttributeName_textBox.TabIndex = 19;
            this.ChangeAttributeName_textBox.TextChanged += new System.EventHandler(this.ChangeAttributeName_textBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Change attribute:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(109, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Select block in drawing";
            // 
            // SelectBlock_button
            // 
            this.SelectBlock_button.Location = new System.Drawing.Point(9, 6);
            this.SelectBlock_button.Name = "SelectBlock_button";
            this.SelectBlock_button.Size = new System.Drawing.Size(75, 23);
            this.SelectBlock_button.TabIndex = 14;
            this.SelectBlock_button.Text = "Select";
            this.SelectBlock_button.UseVisualStyleBackColor = true;
            this.SelectBlock_button.Click += new System.EventHandler(this.SelectBlock_button_Click_1);
            // 
            // LinkAttributes_comboBox
            // 
            this.LinkAttributes_comboBox.FormattingEnabled = true;
            this.LinkAttributes_comboBox.Location = new System.Drawing.Point(233, 57);
            this.LinkAttributes_comboBox.Name = "LinkAttributes_comboBox";
            this.LinkAttributes_comboBox.Size = new System.Drawing.Size(106, 21);
            this.LinkAttributes_comboBox.TabIndex = 13;
            this.LinkAttributes_comboBox.SelectedIndexChanged += new System.EventHandler(this.LinkAttributes_comboBox_SelectedIndexChanged);
            // 
            // attributeDrawingList_listBox
            // 
            this.attributeDrawingList_listBox.FormattingEnabled = true;
            this.attributeDrawingList_listBox.Location = new System.Drawing.Point(6, 218);
            this.attributeDrawingList_listBox.Name = "attributeDrawingList_listBox";
            this.attributeDrawingList_listBox.Size = new System.Drawing.Size(332, 82);
            this.attributeDrawingList_listBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Select drawings to update attribute";
            // 
            // attributeBrowse_button
            // 
            this.attributeBrowse_button.Location = new System.Drawing.Point(6, 189);
            this.attributeBrowse_button.Name = "attributeBrowse_button";
            this.attributeBrowse_button.Size = new System.Drawing.Size(75, 23);
            this.attributeBrowse_button.TabIndex = 10;
            this.attributeBrowse_button.Text = "Browse";
            this.attributeBrowse_button.UseVisualStyleBackColor = true;
            this.attributeBrowse_button.Click += new System.EventHandler(this.AttributeBrowse_button_Click);
            // 
            // attributeStart_button
            // 
            this.attributeStart_button.Location = new System.Drawing.Point(3, 306);
            this.attributeStart_button.Name = "attributeStart_button";
            this.attributeStart_button.Size = new System.Drawing.Size(332, 23);
            this.attributeStart_button.TabIndex = 9;
            this.attributeStart_button.Text = "Update attribute value";
            this.attributeStart_button.UseVisualStyleBackColor = true;
            this.attributeStart_button.Click += new System.EventHandler(this.AttributeStart_button_Click);
            // 
            // ChangeAttributeValue_textBox
            // 
            this.ChangeAttributeValue_textBox.Location = new System.Drawing.Point(107, 163);
            this.ChangeAttributeValue_textBox.Name = "ChangeAttributeValue_textBox";
            this.ChangeAttributeValue_textBox.Size = new System.Drawing.Size(232, 20);
            this.ChangeAttributeValue_textBox.TabIndex = 8;
            this.ChangeAttributeValue_textBox.TextChanged += new System.EventHandler(this.ChangeAttributeValue_textBox_TextChanged);
            // 
            // LinkAttributeValue_textBox
            // 
            this.LinkAttributeValue_textBox.Location = new System.Drawing.Point(107, 85);
            this.LinkAttributeValue_textBox.Name = "LinkAttributeValue_textBox";
            this.LinkAttributeValue_textBox.Size = new System.Drawing.Size(232, 20);
            this.LinkAttributeValue_textBox.TabIndex = 6;
            this.LinkAttributeValue_textBox.TextChanged += new System.EventHandler(this.LinkattributeOldValue_textBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Value:";
            // 
            // attributeLinkAttributeName_textBox
            // 
            this.attributeLinkAttributeName_textBox.Location = new System.Drawing.Point(107, 59);
            this.attributeLinkAttributeName_textBox.Name = "attributeLinkAttributeName_textBox";
            this.attributeLinkAttributeName_textBox.Size = new System.Drawing.Size(119, 20);
            this.attributeLinkAttributeName_textBox.TabIndex = 4;
            this.attributeLinkAttributeName_textBox.TextChanged += new System.EventHandler(this.AttributeLinkAttributeName_textBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Attribute name:";
            // 
            // attributeBlockname_textBox
            // 
            this.attributeBlockname_textBox.Location = new System.Drawing.Point(107, 33);
            this.attributeBlockname_textBox.Name = "attributeBlockname_textBox";
            this.attributeBlockname_textBox.Size = new System.Drawing.Size(231, 20);
            this.attributeBlockname_textBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Block name:";
            // 
            // PurgeAttributeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 385);
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
        private System.Windows.Forms.TextBox attributeLinkAttributeName_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox attributeBlockname_textBox;
        private System.Windows.Forms.TextBox ChangeAttributeValue_textBox;
        private System.Windows.Forms.TextBox LinkAttributeValue_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button attributeStart_button;
        private System.Windows.Forms.ListBox attributeDrawingList_listBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button attributeBrowse_button;
        private System.Windows.Forms.Button SelectBlock_button;
        private System.Windows.Forms.ComboBox LinkAttributes_comboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ChangeAttribute_comboBox;
        private System.Windows.Forms.TextBox ChangeAttributeName_textBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}