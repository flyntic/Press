namespace AppPressa
{
    partial class FormPress
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tableFilterComboBox = new System.Windows.Forms.ComboBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxExample = new System.Windows.Forms.CheckBox();
            this.example_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.addNewFilter = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.calcPartPanel = new System.Windows.Forms.Panel();
            this.partFilterLabel = new System.Windows.Forms.Label();
            this.partFilterСomboBox = new System.Windows.Forms.ComboBox();
            this.calcPartButton = new System.Windows.Forms.Button();
            this.partPanel = new System.Windows.Forms.Panel();
            this.saveFilterButton = new System.Windows.Forms.Button();
            this.removeFilterButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rstButton = new System.Windows.Forms.Button();
            this.partCalcPanel2 = new System.Windows.Forms.Panel();
            this.partCalcListBox = new System.Windows.Forms.ListBox();
            this.averLessCheckBox = new System.Windows.Forms.CheckBox();
            this.averMoreCheckBox = new System.Windows.Forms.CheckBox();
            this.averCheckBox = new System.Windows.Forms.CheckBox();
            this.minCheckBox = new System.Windows.Forms.CheckBox();
            this.calcPartCheckBox = new System.Windows.Forms.CheckBox();
            this.maxCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.editDataGridView = new System.Windows.Forms.DataGridView();
            this.editCountLabel = new System.Windows.Forms.Label();
            this.tableEditComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.calcPartPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.partCalcPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(347, 71);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1325, 434);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1503, 510);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableFilterComboBox
            // 
            this.tableFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tableFilterComboBox.FormattingEnabled = true;
            this.tableFilterComboBox.Items.AddRange(new object[] {
            "Издания",
            "Выпуски"});
            this.tableFilterComboBox.Location = new System.Drawing.Point(347, 38);
            this.tableFilterComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableFilterComboBox.Name = "tableFilterComboBox";
            this.tableFilterComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableFilterComboBox.Size = new System.Drawing.Size(1320, 24);
            this.tableFilterComboBox.TabIndex = 4;
            this.tableFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.tableFilterComboBox_SelectedIndexChanged);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(15, 478);
            this.resetButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(169, 28);
            this.resetButton.TabIndex = 5;
            this.resetButton.Text = "Сбросить";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1059, 223);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(263, 28);
            this.button3.TabIndex = 6;
            this.button3.Text = "Печать";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.checkBoxExample);
            this.panel1.Controls.Add(this.example_checkedListBox);
            this.panel1.Location = new System.Drawing.Point(19, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(316, 434);
            this.panel1.TabIndex = 31;
            // 
            // checkBoxExample
            // 
            this.checkBoxExample.Location = new System.Drawing.Point(17, 12);
            this.checkBoxExample.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxExample.Name = "checkBoxExample";
            this.checkBoxExample.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxExample.Size = new System.Drawing.Size(228, 30);
            this.checkBoxExample.TabIndex = 31;
            this.checkBoxExample.Text = "checkBox2";
            this.checkBoxExample.UseVisualStyleBackColor = true;
            this.checkBoxExample.Visible = false;
            // 
            // example_checkedListBox
            // 
            this.example_checkedListBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.example_checkedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.example_checkedListBox.FormattingEnabled = true;
            this.example_checkedListBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.example_checkedListBox.Location = new System.Drawing.Point(32, 46);
            this.example_checkedListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.example_checkedListBox.Name = "example_checkedListBox";
            this.example_checkedListBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.example_checkedListBox.Size = new System.Drawing.Size(213, 17);
            this.example_checkedListBox.TabIndex = 32;
            this.example_checkedListBox.Visible = false;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(191, 478);
            this.applyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(149, 28);
            this.applyButton.TabIndex = 32;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // filterComboBox
            // 
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Location = new System.Drawing.Point(17, 6);
            this.filterComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.filterComboBox.Size = new System.Drawing.Size(1369, 24);
            this.filterComboBox.TabIndex = 33;
            // 
            // addNewFilter
            // 
            this.addNewFilter.Location = new System.Drawing.Point(1393, 2);
            this.addNewFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addNewFilter.Name = "addNewFilter";
            this.addNewFilter.Size = new System.Drawing.Size(63, 31);
            this.addNewFilter.TabIndex = 35;
            this.addNewFilter.Text = "+";
            this.addNewFilter.UseVisualStyleBackColor = true;
            this.addNewFilter.Click += new System.EventHandler(this.addNewFilter_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1704, 28);
            this.menuStrip1.TabIndex = 39;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(257, 4);
            this.editButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(172, 28);
            this.editButton.TabIndex = 40;
            this.editButton.Text = "Редактировать";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(83, 4);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(167, 28);
            this.addButton.TabIndex = 41;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(435, 4);
            this.removeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(167, 28);
            this.removeButton.TabIndex = 42;
            this.removeButton.Text = "Удалить";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.addButton);
            this.panel2.Controls.Add(this.removeButton);
            this.panel2.Controls.Add(this.editButton);
            this.panel2.Location = new System.Drawing.Point(1057, 708);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(605, 34);
            this.panel2.TabIndex = 43;
            // 
            // calcPartPanel
            // 
            this.calcPartPanel.AutoScroll = true;
            this.calcPartPanel.Controls.Add(this.partFilterLabel);
            this.calcPartPanel.Controls.Add(this.partFilterСomboBox);
            this.calcPartPanel.Controls.Add(this.calcPartButton);
            this.calcPartPanel.Controls.Add(this.partPanel);
            this.calcPartPanel.Location = new System.Drawing.Point(17, 545);
            this.calcPartPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.calcPartPanel.Name = "calcPartPanel";
            this.calcPartPanel.Size = new System.Drawing.Size(317, 257);
            this.calcPartPanel.TabIndex = 45;
            this.calcPartPanel.Visible = false;
            // 
            // partFilterLabel
            // 
            this.partFilterLabel.Location = new System.Drawing.Point(4, 0);
            this.partFilterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.partFilterLabel.Name = "partFilterLabel";
            this.partFilterLabel.Size = new System.Drawing.Size(313, 28);
            this.partFilterLabel.TabIndex = 49;
            this.partFilterLabel.Text = "Параметр ";
            this.partFilterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // partFilterСomboBox
            // 
            this.partFilterСomboBox.FormattingEnabled = true;
            this.partFilterСomboBox.Location = new System.Drawing.Point(0, 32);
            this.partFilterСomboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.partFilterСomboBox.Name = "partFilterСomboBox";
            this.partFilterСomboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.partFilterСomboBox.Size = new System.Drawing.Size(316, 24);
            this.partFilterСomboBox.TabIndex = 0;
            // 
            // calcPartButton
            // 
            this.calcPartButton.Location = new System.Drawing.Point(0, 223);
            this.calcPartButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.calcPartButton.Name = "calcPartButton";
            this.calcPartButton.Size = new System.Drawing.Size(315, 28);
            this.calcPartButton.TabIndex = 48;
            this.calcPartButton.Text = "Посчитать";
            this.calcPartButton.UseVisualStyleBackColor = true;
            this.calcPartButton.Click += new System.EventHandler(this.calcPartButton_Click);
            // 
            // partPanel
            // 
            this.partPanel.AutoScroll = true;
            this.partPanel.Location = new System.Drawing.Point(1, 65);
            this.partPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.partPanel.Name = "partPanel";
            this.partPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.partPanel.Size = new System.Drawing.Size(316, 151);
            this.partPanel.TabIndex = 50;
            // 
            // saveFilterButton
            // 
            this.saveFilterButton.Location = new System.Drawing.Point(1529, 2);
            this.saveFilterButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveFilterButton.Name = "saveFilterButton";
            this.saveFilterButton.Size = new System.Drawing.Size(139, 31);
            this.saveFilterButton.TabIndex = 46;
            this.saveFilterButton.Text = "Сохранить";
            this.saveFilterButton.UseVisualStyleBackColor = true;
            this.saveFilterButton.Click += new System.EventHandler(this.saveFilterButton_Click);
            // 
            // removeFilterButton
            // 
            this.removeFilterButton.Location = new System.Drawing.Point(1461, 2);
            this.removeFilterButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.removeFilterButton.Name = "removeFilterButton";
            this.removeFilterButton.Size = new System.Drawing.Size(63, 31);
            this.removeFilterButton.TabIndex = 47;
            this.removeFilterButton.Text = "-";
            this.removeFilterButton.UseVisualStyleBackColor = true;
            this.removeFilterButton.Click += new System.EventHandler(this.removeFilterButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1697, 850);
            this.tabControl1.TabIndex = 48;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rstButton);
            this.tabPage1.Controls.Add(this.calcPartPanel);
            this.tabPage1.Controls.Add(this.partCalcPanel2);
            this.tabPage1.Controls.Add(this.averLessCheckBox);
            this.tabPage1.Controls.Add(this.averMoreCheckBox);
            this.tabPage1.Controls.Add(this.averCheckBox);
            this.tabPage1.Controls.Add(this.minCheckBox);
            this.tabPage1.Controls.Add(this.calcPartCheckBox);
            this.tabPage1.Controls.Add(this.maxCheckBox);
            this.tabPage1.Controls.Add(this.filterComboBox);
            this.tabPage1.Controls.Add(this.removeFilterButton);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.saveFilterButton);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.resetButton);
            this.tabPage1.Controls.Add(this.tableFilterComboBox);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.applyButton);
            this.tabPage1.Controls.Add(this.addNewFilter);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1689, 821);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Фильтры                     ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rstButton
            // 
            this.rstButton.Location = new System.Drawing.Point(277, 513);
            this.rstButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rstButton.Name = "rstButton";
            this.rstButton.Size = new System.Drawing.Size(61, 28);
            this.rstButton.TabIndex = 57;
            this.rstButton.Text = "Сброс";
            this.rstButton.UseVisualStyleBackColor = true;
            this.rstButton.Click += new System.EventHandler(this.rstButton_Click);
            // 
            // partCalcPanel2
            // 
            this.partCalcPanel2.Controls.Add(this.partCalcListBox);
            this.partCalcPanel2.Controls.Add(this.button3);
            this.partCalcPanel2.Location = new System.Drawing.Point(347, 543);
            this.partCalcPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.partCalcPanel2.Name = "partCalcPanel2";
            this.partCalcPanel2.Size = new System.Drawing.Size(1325, 257);
            this.partCalcPanel2.TabIndex = 55;
            // 
            // partCalcListBox
            // 
            this.partCalcListBox.FormattingEnabled = true;
            this.partCalcListBox.HorizontalScrollbar = true;
            this.partCalcListBox.ItemHeight = 16;
            this.partCalcListBox.Location = new System.Drawing.Point(4, 2);
            this.partCalcListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.partCalcListBox.Name = "partCalcListBox";
            this.partCalcListBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.partCalcListBox.Size = new System.Drawing.Size(1313, 212);
            this.partCalcListBox.TabIndex = 57;
            // 
            // averLessCheckBox
            // 
            this.averLessCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.averLessCheckBox.AutoSize = true;
            this.averLessCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.averLessCheckBox.Location = new System.Drawing.Point(231, 511);
            this.averLessCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.averLessCheckBox.Name = "averLessCheckBox";
            this.averLessCheckBox.Size = new System.Drawing.Size(34, 27);
            this.averLessCheckBox.TabIndex = 53;
            this.averLessCheckBox.Text = "=<";
            this.averLessCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.averLessCheckBox.UseVisualStyleBackColor = true;
            this.averLessCheckBox.CheckedChanged += new System.EventHandler(this.averLessCheckBox_CheckedChanged);
            // 
            // averMoreCheckBox
            // 
            this.averMoreCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.averMoreCheckBox.AutoSize = true;
            this.averMoreCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.averMoreCheckBox.Location = new System.Drawing.Point(191, 511);
            this.averMoreCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.averMoreCheckBox.Name = "averMoreCheckBox";
            this.averMoreCheckBox.Size = new System.Drawing.Size(34, 27);
            this.averMoreCheckBox.TabIndex = 52;
            this.averMoreCheckBox.Text = "=>";
            this.averMoreCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.averMoreCheckBox.UseVisualStyleBackColor = true;
            this.averMoreCheckBox.CheckedChanged += new System.EventHandler(this.averMoreCheckBox_CheckedChanged);
            // 
            // averCheckBox
            // 
            this.averCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.averCheckBox.AutoSize = true;
            this.averCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.averCheckBox.Location = new System.Drawing.Point(149, 511);
            this.averCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.averCheckBox.Name = "averCheckBox";
            this.averCheckBox.Size = new System.Drawing.Size(35, 27);
            this.averCheckBox.TabIndex = 51;
            this.averCheckBox.Text = "Ср";
            this.averCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.averCheckBox.UseVisualStyleBackColor = true;
            this.averCheckBox.CheckedChanged += new System.EventHandler(this.averCheckBox_CheckedChanged);
            // 
            // minCheckBox
            // 
            this.minCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.minCheckBox.AutoSize = true;
            this.minCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.minCheckBox.Location = new System.Drawing.Point(68, 511);
            this.minCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.minCheckBox.Name = "minCheckBox";
            this.minCheckBox.Size = new System.Drawing.Size(40, 27);
            this.minCheckBox.TabIndex = 50;
            this.minCheckBox.Text = "Min";
            this.minCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.minCheckBox.UseVisualStyleBackColor = true;
            this.minCheckBox.CheckedChanged += new System.EventHandler(this.minCheckBox_CheckedChanged);
            // 
            // calcPartCheckBox
            // 
            this.calcPartCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.calcPartCheckBox.AutoSize = true;
            this.calcPartCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.calcPartCheckBox.Location = new System.Drawing.Point(115, 511);
            this.calcPartCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.calcPartCheckBox.Name = "calcPartCheckBox";
            this.calcPartCheckBox.Size = new System.Drawing.Size(30, 27);
            this.calcPartCheckBox.TabIndex = 48;
            this.calcPartCheckBox.Text = "%";
            this.calcPartCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.calcPartCheckBox.UseVisualStyleBackColor = true;
            this.calcPartCheckBox.CheckedChanged += new System.EventHandler(this.calcPartCheckBox_CheckedChanged);
            // 
            // maxCheckBox
            // 
            this.maxCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.maxCheckBox.AutoSize = true;
            this.maxCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.maxCheckBox.Location = new System.Drawing.Point(17, 511);
            this.maxCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.maxCheckBox.Name = "maxCheckBox";
            this.maxCheckBox.Size = new System.Drawing.Size(43, 27);
            this.maxCheckBox.TabIndex = 49;
            this.maxCheckBox.Text = "Max";
            this.maxCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maxCheckBox.UseVisualStyleBackColor = true;
            this.maxCheckBox.CheckedChanged += new System.EventHandler(this.maxCheckBox_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.editDataGridView);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.editCountLabel);
            this.tabPage2.Controls.Add(this.tableEditComboBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(1689, 821);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Редактирование            ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // editDataGridView
            // 
            this.editDataGridView.AllowUserToAddRows = false;
            this.editDataGridView.AllowUserToDeleteRows = false;
            this.editDataGridView.AllowUserToOrderColumns = true;
            this.editDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.editDataGridView.ColumnHeadersHeight = 29;
            this.editDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.editDataGridView.Location = new System.Drawing.Point(43, 62);
            this.editDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.editDataGridView.Name = "editDataGridView";
            this.editDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.editDataGridView.RowHeadersWidth = 51;
            this.editDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.editDataGridView.Size = new System.Drawing.Size(1620, 636);
            this.editDataGridView.TabIndex = 5;
            // 
            // editCountLabel
            // 
            this.editCountLabel.Location = new System.Drawing.Point(52, 708);
            this.editCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editCountLabel.Name = "editCountLabel";
            this.editCountLabel.Size = new System.Drawing.Size(469, 28);
            this.editCountLabel.TabIndex = 6;
            this.editCountLabel.Text = "label3";
            this.editCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableEditComboBox
            // 
            this.tableEditComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tableEditComboBox.FormattingEnabled = true;
            this.tableEditComboBox.Items.AddRange(new object[] {
            "Издания",
            "Выпуски"});
            this.tableEditComboBox.Location = new System.Drawing.Point(43, 28);
            this.tableEditComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableEditComboBox.Name = "tableEditComboBox";
            this.tableEditComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableEditComboBox.Size = new System.Drawing.Size(1619, 24);
            this.tableEditComboBox.TabIndex = 7;
            // 
            // FormPress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1704, 898);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormPress";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник прессы";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.calcPartPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.partCalcPanel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tableFilterComboBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.ComboBox filterComboBox;
        private System.Windows.Forms.Button addNewFilter;
        private System.Windows.Forms.CheckBox checkBoxExample;
        private System.Windows.Forms.CheckedListBox example_checkedListBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel calcPartPanel;
        private System.Windows.Forms.ComboBox partFilterСomboBox;
        private System.Windows.Forms.Button saveFilterButton;
        private System.Windows.Forms.Button removeFilterButton;
        private System.Windows.Forms.Button calcPartButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView editDataGridView;
        private System.Windows.Forms.Label editCountLabel;
        private System.Windows.Forms.ComboBox tableEditComboBox;
        private System.Windows.Forms.CheckBox calcPartCheckBox;
        private System.Windows.Forms.Label partFilterLabel;
        private System.Windows.Forms.Panel partPanel;
        private System.Windows.Forms.Panel partCalcPanel2;
        private System.Windows.Forms.CheckBox averLessCheckBox;
        private System.Windows.Forms.CheckBox averMoreCheckBox;
        private System.Windows.Forms.CheckBox averCheckBox;
        private System.Windows.Forms.CheckBox minCheckBox;
        private System.Windows.Forms.CheckBox maxCheckBox;
        private System.Windows.Forms.ListBox partCalcListBox;
        private System.Windows.Forms.Button rstButton;
    }
}

