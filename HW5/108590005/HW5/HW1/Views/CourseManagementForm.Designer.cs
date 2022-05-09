
namespace homework1
{
    partial class CourseManagementForm
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
            this._coursesListBox = new System.Windows.Forms.ListBox();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._courseManagement = new System.Windows.Forms.TabPage();
            this._importCourseButton = new System.Windows.Forms.Button();
            this._saveCourseButton = new System.Windows.Forms.Button();
            this._addNewCourseButton = new System.Windows.Forms.Button();
            this._courseInfoGroupBox = new System.Windows.Forms.GroupBox();
            this._classTimeDataGridView = new System.Windows.Forms.DataGridView();
            this._stageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._sundayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._mondayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._tuesdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._wednesdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._thursdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._fridayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._saturdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._classLanguageTextBox = new System.Windows.Forms.TextBox();
            this._classNoteTextBox = new System.Windows.Forms.TextBox();
            this._classTeacherAssistantTextBox = new System.Windows.Forms.TextBox();
            this._classNameTextBox = new System.Windows.Forms.TextBox();
            this._classTeacherTextBox = new System.Windows.Forms.TextBox();
            this._classCreditTextBox = new System.Windows.Forms.TextBox();
            this._classStageTextBox = new System.Windows.Forms.TextBox();
            this._classNumberTextBox = new System.Windows.Forms.TextBox();
            this._classDepartmentLabel = new System.Windows.Forms.Label();
            this._classHourLabel = new System.Windows.Forms.Label();
            this._classRequiredOrElectiveLabel = new System.Windows.Forms.Label();
            this._classLanguageLabel = new System.Windows.Forms.Label();
            this._classNoteLabel = new System.Windows.Forms.Label();
            this._classTeacherLabel = new System.Windows.Forms.Label();
            this._classTeacherAssistantLabel = new System.Windows.Forms.Label();
            this._classNameLabel = new System.Windows.Forms.Label();
            this._classDepartmentComboBox = new System.Windows.Forms.ComboBox();
            this._classHourComboBox = new System.Windows.Forms.ComboBox();
            this._classCreditLabel = new System.Windows.Forms.Label();
            this._classRequiredOrElectiveComboBox = new System.Windows.Forms.ComboBox();
            this._classStatusComboBox = new System.Windows.Forms.ComboBox();
            this._classStageLabel = new System.Windows.Forms.Label();
            this._classNumberLabel = new System.Windows.Forms.Label();
            this._classManagement = new System.Windows.Forms.TabPage();
            this._saveDepartmentButton = new System.Windows.Forms.Button();
            this._addNewDepartmentButton = new System.Windows.Forms.Button();
            this._departmentGroupBox = new System.Windows.Forms.GroupBox();
            this._coursesOfDepartmentListBox = new System.Windows.Forms.ListBox();
            this._departmentNameTextBox = new System.Windows.Forms.TextBox();
            this._courseOfDepartmentLabel = new System.Windows.Forms.Label();
            this._departmentNameLabel = new System.Windows.Forms.Label();
            this._departmentsListBox = new System.Windows.Forms.ListBox();
            this._tabControl.SuspendLayout();
            this._courseManagement.SuspendLayout();
            this._courseInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._classTimeDataGridView)).BeginInit();
            this._classManagement.SuspendLayout();
            this._departmentGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _coursesListBox
            // 
            this._coursesListBox.FormattingEnabled = true;
            this._coursesListBox.ItemHeight = 15;
            this._coursesListBox.Location = new System.Drawing.Point(8, 6);
            this._coursesListBox.Name = "_coursesListBox";
            this._coursesListBox.Size = new System.Drawing.Size(307, 664);
            this._coursesListBox.TabIndex = 1;
            this._coursesListBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChangedCoursesListBox);
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._courseManagement);
            this._tabControl.Controls.Add(this._classManagement);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(0, 0);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(1255, 794);
            this._tabControl.TabIndex = 2;
            // 
            // _courseManagement
            // 
            this._courseManagement.Controls.Add(this._importCourseButton);
            this._courseManagement.Controls.Add(this._saveCourseButton);
            this._courseManagement.Controls.Add(this._addNewCourseButton);
            this._courseManagement.Controls.Add(this._courseInfoGroupBox);
            this._courseManagement.Controls.Add(this._coursesListBox);
            this._courseManagement.Location = new System.Drawing.Point(4, 25);
            this._courseManagement.Name = "_courseManagement";
            this._courseManagement.Padding = new System.Windows.Forms.Padding(3);
            this._courseManagement.Size = new System.Drawing.Size(1247, 765);
            this._courseManagement.TabIndex = 0;
            this._courseManagement.Text = "課程管理";
            this._courseManagement.UseVisualStyleBackColor = true;
            // 
            // _importCourseButton
            // 
            this._importCourseButton.Location = new System.Drawing.Point(139, 676);
            this._importCourseButton.Name = "_importCourseButton";
            this._importCourseButton.Size = new System.Drawing.Size(178, 81);
            this._importCourseButton.TabIndex = 4;
            this._importCourseButton.Text = "匯入資工系全部課程";
            this._importCourseButton.UseVisualStyleBackColor = true;
            this._importCourseButton.Click += new System.EventHandler(this.ImportComputerScienceCourses);
            // 
            // _saveCourseButton
            // 
            this._saveCourseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._saveCourseButton.Enabled = false;
            this._saveCourseButton.Location = new System.Drawing.Point(1025, 676);
            this._saveCourseButton.Name = "_saveCourseButton";
            this._saveCourseButton.Size = new System.Drawing.Size(210, 81);
            this._saveCourseButton.TabIndex = 3;
            this._saveCourseButton.Text = "儲存";
            this._saveCourseButton.UseVisualStyleBackColor = true;
            this._saveCourseButton.Click += new System.EventHandler(this.ClickSaveButton);
            // 
            // _addNewCourseButton
            // 
            this._addNewCourseButton.Location = new System.Drawing.Point(8, 676);
            this._addNewCourseButton.Name = "_addNewCourseButton";
            this._addNewCourseButton.Size = new System.Drawing.Size(125, 81);
            this._addNewCourseButton.TabIndex = 3;
            this._addNewCourseButton.Text = "新稱課程";
            this._addNewCourseButton.UseVisualStyleBackColor = true;
            this._addNewCourseButton.Click += new System.EventHandler(this.ClickAddNewCourseButton);
            // 
            // _courseInfoGroupBox
            // 
            this._courseInfoGroupBox.Controls.Add(this._classTimeDataGridView);
            this._courseInfoGroupBox.Controls.Add(this._classLanguageTextBox);
            this._courseInfoGroupBox.Controls.Add(this._classNoteTextBox);
            this._courseInfoGroupBox.Controls.Add(this._classTeacherAssistantTextBox);
            this._courseInfoGroupBox.Controls.Add(this._classNameTextBox);
            this._courseInfoGroupBox.Controls.Add(this._classTeacherTextBox);
            this._courseInfoGroupBox.Controls.Add(this._classCreditTextBox);
            this._courseInfoGroupBox.Controls.Add(this._classStageTextBox);
            this._courseInfoGroupBox.Controls.Add(this._classNumberTextBox);
            this._courseInfoGroupBox.Controls.Add(this._classDepartmentLabel);
            this._courseInfoGroupBox.Controls.Add(this._classHourLabel);
            this._courseInfoGroupBox.Controls.Add(this._classRequiredOrElectiveLabel);
            this._courseInfoGroupBox.Controls.Add(this._classLanguageLabel);
            this._courseInfoGroupBox.Controls.Add(this._classNoteLabel);
            this._courseInfoGroupBox.Controls.Add(this._classTeacherLabel);
            this._courseInfoGroupBox.Controls.Add(this._classTeacherAssistantLabel);
            this._courseInfoGroupBox.Controls.Add(this._classNameLabel);
            this._courseInfoGroupBox.Controls.Add(this._classDepartmentComboBox);
            this._courseInfoGroupBox.Controls.Add(this._classHourComboBox);
            this._courseInfoGroupBox.Controls.Add(this._classCreditLabel);
            this._courseInfoGroupBox.Controls.Add(this._classRequiredOrElectiveComboBox);
            this._courseInfoGroupBox.Controls.Add(this._classStatusComboBox);
            this._courseInfoGroupBox.Controls.Add(this._classStageLabel);
            this._courseInfoGroupBox.Controls.Add(this._classNumberLabel);
            this._courseInfoGroupBox.Location = new System.Drawing.Point(321, 6);
            this._courseInfoGroupBox.Name = "_courseInfoGroupBox";
            this._courseInfoGroupBox.Size = new System.Drawing.Size(914, 664);
            this._courseInfoGroupBox.TabIndex = 2;
            this._courseInfoGroupBox.TabStop = false;
            this._courseInfoGroupBox.Text = "編輯課程";
            // 
            // _classTimeDataGridView
            // 
            this._classTimeDataGridView.AllowUserToAddRows = false;
            this._classTimeDataGridView.AllowUserToDeleteRows = false;
            this._classTimeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._classTimeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._classTimeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._stageColumn,
            this._sundayColumn,
            this._mondayColumn,
            this._tuesdayColumn,
            this._wednesdayColumn,
            this._thursdayColumn,
            this._fridayColumn,
            this._saturdayColumn});
            this._classTimeDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._classTimeDataGridView.Location = new System.Drawing.Point(3, 263);
            this._classTimeDataGridView.Name = "_classTimeDataGridView";
            this._classTimeDataGridView.RowHeadersVisible = false;
            this._classTimeDataGridView.RowHeadersWidth = 51;
            this._classTimeDataGridView.RowTemplate.Height = 27;
            this._classTimeDataGridView.Size = new System.Drawing.Size(908, 398);
            this._classTimeDataGridView.TabIndex = 3;
            this._classTimeDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ContentClickDataGridView);
            this._classTimeDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ValueChangedDataGridView);
            // 
            // _stageColumn
            // 
            this._stageColumn.HeaderText = "節數";
            this._stageColumn.MinimumWidth = 6;
            this._stageColumn.Name = "_stageColumn";
            // 
            // _sundayColumn
            // 
            this._sundayColumn.HeaderText = "日";
            this._sundayColumn.MinimumWidth = 6;
            this._sundayColumn.Name = "_sundayColumn";
            this._sundayColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._sundayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _mondayColumn
            // 
            this._mondayColumn.HeaderText = "一";
            this._mondayColumn.MinimumWidth = 6;
            this._mondayColumn.Name = "_mondayColumn";
            this._mondayColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._mondayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _tuesdayColumn
            // 
            this._tuesdayColumn.HeaderText = "二";
            this._tuesdayColumn.MinimumWidth = 6;
            this._tuesdayColumn.Name = "_tuesdayColumn";
            this._tuesdayColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._tuesdayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _wednesdayColumn
            // 
            this._wednesdayColumn.HeaderText = "三";
            this._wednesdayColumn.MinimumWidth = 6;
            this._wednesdayColumn.Name = "_wednesdayColumn";
            this._wednesdayColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._wednesdayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _thursdayColumn
            // 
            this._thursdayColumn.HeaderText = "四";
            this._thursdayColumn.MinimumWidth = 6;
            this._thursdayColumn.Name = "_thursdayColumn";
            // 
            // _fridayColumn
            // 
            this._fridayColumn.HeaderText = "五";
            this._fridayColumn.MinimumWidth = 6;
            this._fridayColumn.Name = "_fridayColumn";
            // 
            // _saturdayColumn
            // 
            this._saturdayColumn.HeaderText = "六";
            this._saturdayColumn.MinimumWidth = 6;
            this._saturdayColumn.Name = "_saturdayColumn";
            // 
            // _classLanguageTextBox
            // 
            this._classLanguageTextBox.Enabled = false;
            this._classLanguageTextBox.Location = new System.Drawing.Point(545, 125);
            this._classLanguageTextBox.Name = "_classLanguageTextBox";
            this._classLanguageTextBox.Size = new System.Drawing.Size(355, 25);
            this._classLanguageTextBox.TabIndex = 2;
            this._classLanguageTextBox.TextChanged += new System.EventHandler(this.ChangedText);
            // 
            // _classNoteTextBox
            // 
            this._classNoteTextBox.Enabled = false;
            this._classNoteTextBox.Location = new System.Drawing.Point(61, 169);
            this._classNoteTextBox.Name = "_classNoteTextBox";
            this._classNoteTextBox.Size = new System.Drawing.Size(650, 25);
            this._classNoteTextBox.TabIndex = 2;
            this._classNoteTextBox.TextChanged += new System.EventHandler(this.ChangedText);
            // 
            // _classTeacherAssistantTextBox
            // 
            this._classTeacherAssistantTextBox.Enabled = false;
            this._classTeacherAssistantTextBox.Location = new System.Drawing.Point(91, 125);
            this._classTeacherAssistantTextBox.Name = "_classTeacherAssistantTextBox";
            this._classTeacherAssistantTextBox.Size = new System.Drawing.Size(355, 25);
            this._classTeacherAssistantTextBox.TabIndex = 2;
            this._classTeacherAssistantTextBox.TextChanged += new System.EventHandler(this.ChangedText);
            // 
            // _classNameTextBox
            // 
            this._classNameTextBox.Enabled = false;
            this._classNameTextBox.Location = new System.Drawing.Point(475, 38);
            this._classNameTextBox.Name = "_classNameTextBox";
            this._classNameTextBox.Size = new System.Drawing.Size(428, 25);
            this._classNameTextBox.TabIndex = 2;
            this._classNameTextBox.TextChanged += new System.EventHandler(this.ChangedText);
            // 
            // _classTeacherTextBox
            // 
            this._classTeacherTextBox.Enabled = false;
            this._classTeacherTextBox.Location = new System.Drawing.Point(532, 80);
            this._classTeacherTextBox.Name = "_classTeacherTextBox";
            this._classTeacherTextBox.Size = new System.Drawing.Size(159, 25);
            this._classTeacherTextBox.TabIndex = 2;
            this._classTeacherTextBox.TextChanged += new System.EventHandler(this.ChangedText);
            // 
            // _classCreditTextBox
            // 
            this._classCreditTextBox.Enabled = false;
            this._classCreditTextBox.Location = new System.Drawing.Point(307, 80);
            this._classCreditTextBox.Name = "_classCreditTextBox";
            this._classCreditTextBox.Size = new System.Drawing.Size(159, 25);
            this._classCreditTextBox.TabIndex = 2;
            this._classCreditTextBox.TextChanged += new System.EventHandler(this.ChangedText);
            // 
            // _classStageTextBox
            // 
            this._classStageTextBox.Enabled = false;
            this._classStageTextBox.Location = new System.Drawing.Point(78, 80);
            this._classStageTextBox.Name = "_classStageTextBox";
            this._classStageTextBox.Size = new System.Drawing.Size(159, 25);
            this._classStageTextBox.TabIndex = 2;
            this._classStageTextBox.TextChanged += new System.EventHandler(this.ChangedText);
            // 
            // _classNumberTextBox
            // 
            this._classNumberTextBox.Enabled = false;
            this._classNumberTextBox.Location = new System.Drawing.Point(217, 38);
            this._classNumberTextBox.Name = "_classNumberTextBox";
            this._classNumberTextBox.Size = new System.Drawing.Size(159, 25);
            this._classNumberTextBox.TabIndex = 2;
            this._classNumberTextBox.TextChanged += new System.EventHandler(this.ChangedText);
            // 
            // _classDepartmentLabel
            // 
            this._classDepartmentLabel.AutoSize = true;
            this._classDepartmentLabel.Location = new System.Drawing.Point(210, 221);
            this._classDepartmentLabel.Name = "_classDepartmentLabel";
            this._classDepartmentLabel.Size = new System.Drawing.Size(54, 15);
            this._classDepartmentLabel.TabIndex = 0;
            this._classDepartmentLabel.Text = "班級(*)";
            // 
            // _classHourLabel
            // 
            this._classHourLabel.AutoSize = true;
            this._classHourLabel.Location = new System.Drawing.Point(16, 221);
            this._classHourLabel.Name = "_classHourLabel";
            this._classHourLabel.Size = new System.Drawing.Size(54, 15);
            this._classHourLabel.TabIndex = 0;
            this._classHourLabel.Text = "時數(*)";
            // 
            // _classRequiredOrElectiveLabel
            // 
            this._classRequiredOrElectiveLabel.AutoSize = true;
            this._classRequiredOrElectiveLabel.Location = new System.Drawing.Point(697, 83);
            this._classRequiredOrElectiveLabel.Name = "_classRequiredOrElectiveLabel";
            this._classRequiredOrElectiveLabel.Size = new System.Drawing.Size(39, 15);
            this._classRequiredOrElectiveLabel.TabIndex = 0;
            this._classRequiredOrElectiveLabel.Text = "修(*)";
            // 
            // _classLanguageLabel
            // 
            this._classLanguageLabel.AutoSize = true;
            this._classLanguageLabel.Location = new System.Drawing.Point(472, 128);
            this._classLanguageLabel.Name = "_classLanguageLabel";
            this._classLanguageLabel.Size = new System.Drawing.Size(67, 15);
            this._classLanguageLabel.TabIndex = 0;
            this._classLanguageLabel.Text = "授課語言";
            // 
            // _classNoteLabel
            // 
            this._classNoteLabel.AutoSize = true;
            this._classNoteLabel.Location = new System.Drawing.Point(18, 172);
            this._classNoteLabel.Name = "_classNoteLabel";
            this._classNoteLabel.Size = new System.Drawing.Size(37, 15);
            this._classNoteLabel.TabIndex = 0;
            this._classNoteLabel.Text = "備註";
            // 
            // _classTeacherLabel
            // 
            this._classTeacherLabel.AutoSize = true;
            this._classTeacherLabel.Location = new System.Drawing.Point(472, 83);
            this._classTeacherLabel.Name = "_classTeacherLabel";
            this._classTeacherLabel.Size = new System.Drawing.Size(54, 15);
            this._classTeacherLabel.TabIndex = 0;
            this._classTeacherLabel.Text = "教師(*)";
            // 
            // _classTeacherAssistantLabel
            // 
            this._classTeacherAssistantLabel.AutoSize = true;
            this._classTeacherAssistantLabel.Location = new System.Drawing.Point(18, 128);
            this._classTeacherAssistantLabel.Name = "_classTeacherAssistantLabel";
            this._classTeacherAssistantLabel.Size = new System.Drawing.Size(67, 15);
            this._classTeacherAssistantLabel.TabIndex = 0;
            this._classTeacherAssistantLabel.Text = "教學助理";
            // 
            // _classNameLabel
            // 
            this._classNameLabel.AutoSize = true;
            this._classNameLabel.Location = new System.Drawing.Point(382, 41);
            this._classNameLabel.Name = "_classNameLabel";
            this._classNameLabel.Size = new System.Drawing.Size(84, 15);
            this._classNameLabel.TabIndex = 0;
            this._classNameLabel.Text = "課程名稱(*)";
            // 
            // _classDepartmentComboBox
            // 
            this._classDepartmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._classDepartmentComboBox.Enabled = false;
            this._classDepartmentComboBox.FormattingEnabled = true;
            this._classDepartmentComboBox.Location = new System.Drawing.Point(270, 218);
            this._classDepartmentComboBox.Name = "_classDepartmentComboBox";
            this._classDepartmentComboBox.Size = new System.Drawing.Size(127, 23);
            this._classDepartmentComboBox.TabIndex = 1;
            this._classDepartmentComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangedText);
            // 
            // _classHourComboBox
            // 
            this._classHourComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._classHourComboBox.Enabled = false;
            this._classHourComboBox.FormattingEnabled = true;
            this._classHourComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this._classHourComboBox.Location = new System.Drawing.Point(76, 218);
            this._classHourComboBox.Name = "_classHourComboBox";
            this._classHourComboBox.Size = new System.Drawing.Size(123, 23);
            this._classHourComboBox.TabIndex = 1;
            this._classHourComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangedText);
            // 
            // _classCreditLabel
            // 
            this._classCreditLabel.AutoSize = true;
            this._classCreditLabel.Location = new System.Drawing.Point(247, 83);
            this._classCreditLabel.Name = "_classCreditLabel";
            this._classCreditLabel.Size = new System.Drawing.Size(54, 15);
            this._classCreditLabel.TabIndex = 0;
            this._classCreditLabel.Text = "學分(*)";
            // 
            // _classRequiredOrElectiveComboBox
            // 
            this._classRequiredOrElectiveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._classRequiredOrElectiveComboBox.Enabled = false;
            this._classRequiredOrElectiveComboBox.FormattingEnabled = true;
            this._classRequiredOrElectiveComboBox.Items.AddRange(new object[] {
            "○",
            "△",
            "☆",
            "●",
            "▲",
            "★"});
            this._classRequiredOrElectiveComboBox.Location = new System.Drawing.Point(742, 80);
            this._classRequiredOrElectiveComboBox.Name = "_classRequiredOrElectiveComboBox";
            this._classRequiredOrElectiveComboBox.Size = new System.Drawing.Size(161, 23);
            this._classRequiredOrElectiveComboBox.TabIndex = 1;
            this._classRequiredOrElectiveComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangedText);
            // 
            // _classStatusComboBox
            // 
            this._classStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._classStatusComboBox.Enabled = false;
            this._classStatusComboBox.FormattingEnabled = true;
            this._classStatusComboBox.Items.AddRange(new object[] {
            "開課",
            "停開"});
            this._classStatusComboBox.Location = new System.Drawing.Point(21, 38);
            this._classStatusComboBox.Name = "_classStatusComboBox";
            this._classStatusComboBox.Size = new System.Drawing.Size(121, 23);
            this._classStatusComboBox.TabIndex = 1;
            this._classStatusComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangedText);
            // 
            // _classStageLabel
            // 
            this._classStageLabel.AutoSize = true;
            this._classStageLabel.Location = new System.Drawing.Point(18, 83);
            this._classStageLabel.Name = "_classStageLabel";
            this._classStageLabel.Size = new System.Drawing.Size(54, 15);
            this._classStageLabel.TabIndex = 0;
            this._classStageLabel.Text = "階段(*)";
            // 
            // _classNumberLabel
            // 
            this._classNumberLabel.AutoSize = true;
            this._classNumberLabel.Location = new System.Drawing.Point(157, 41);
            this._classNumberLabel.Name = "_classNumberLabel";
            this._classNumberLabel.Size = new System.Drawing.Size(54, 15);
            this._classNumberLabel.TabIndex = 0;
            this._classNumberLabel.Text = "課號(*)";
            // 
            // _classManagement
            // 
            this._classManagement.Controls.Add(this._saveDepartmentButton);
            this._classManagement.Controls.Add(this._addNewDepartmentButton);
            this._classManagement.Controls.Add(this._departmentGroupBox);
            this._classManagement.Controls.Add(this._departmentsListBox);
            this._classManagement.Location = new System.Drawing.Point(4, 25);
            this._classManagement.Name = "_classManagement";
            this._classManagement.Padding = new System.Windows.Forms.Padding(3);
            this._classManagement.Size = new System.Drawing.Size(1247, 765);
            this._classManagement.TabIndex = 1;
            this._classManagement.Text = "班級管理";
            this._classManagement.UseVisualStyleBackColor = true;
            // 
            // _saveDepartmentButton
            // 
            this._saveDepartmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._saveDepartmentButton.Enabled = false;
            this._saveDepartmentButton.Location = new System.Drawing.Point(1025, 676);
            this._saveDepartmentButton.Name = "_saveDepartmentButton";
            this._saveDepartmentButton.Size = new System.Drawing.Size(210, 81);
            this._saveDepartmentButton.TabIndex = 5;
            this._saveDepartmentButton.Text = "新增";
            this._saveDepartmentButton.UseVisualStyleBackColor = true;
            this._saveDepartmentButton.Click += new System.EventHandler(this.ClickDepartmentSaveButton);
            // 
            // _addNewDepartmentButton
            // 
            this._addNewDepartmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._addNewDepartmentButton.Enabled = false;
            this._addNewDepartmentButton.Location = new System.Drawing.Point(8, 676);
            this._addNewDepartmentButton.Name = "_addNewDepartmentButton";
            this._addNewDepartmentButton.Size = new System.Drawing.Size(307, 81);
            this._addNewDepartmentButton.TabIndex = 4;
            this._addNewDepartmentButton.Text = "新增班級";
            this._addNewDepartmentButton.UseVisualStyleBackColor = true;
            this._addNewDepartmentButton.Click += new System.EventHandler(this.ClickDepartmentAddButton);
            // 
            // _departmentGroupBox
            // 
            this._departmentGroupBox.Controls.Add(this._coursesOfDepartmentListBox);
            this._departmentGroupBox.Controls.Add(this._departmentNameTextBox);
            this._departmentGroupBox.Controls.Add(this._courseOfDepartmentLabel);
            this._departmentGroupBox.Controls.Add(this._departmentNameLabel);
            this._departmentGroupBox.Location = new System.Drawing.Point(321, 6);
            this._departmentGroupBox.Name = "_departmentGroupBox";
            this._departmentGroupBox.Size = new System.Drawing.Size(914, 664);
            this._departmentGroupBox.TabIndex = 3;
            this._departmentGroupBox.TabStop = false;
            this._departmentGroupBox.Text = "班級";
            // 
            // _coursesOfDepartmentListBox
            // 
            this._coursesOfDepartmentListBox.FormattingEnabled = true;
            this._coursesOfDepartmentListBox.ItemHeight = 15;
            this._coursesOfDepartmentListBox.Location = new System.Drawing.Point(6, 274);
            this._coursesOfDepartmentListBox.Name = "_coursesOfDepartmentListBox";
            this._coursesOfDepartmentListBox.Size = new System.Drawing.Size(902, 379);
            this._coursesOfDepartmentListBox.TabIndex = 3;
            // 
            // _departmentNameTextBox
            // 
            this._departmentNameTextBox.Enabled = false;
            this._departmentNameTextBox.Location = new System.Drawing.Point(96, 99);
            this._departmentNameTextBox.Name = "_departmentNameTextBox";
            this._departmentNameTextBox.Size = new System.Drawing.Size(812, 25);
            this._departmentNameTextBox.TabIndex = 2;
            this._departmentNameTextBox.TextChanged += new System.EventHandler(this.ChangedTextDepartment);
            // 
            // _courseOfDepartmentLabel
            // 
            this._courseOfDepartmentLabel.AutoSize = true;
            this._courseOfDepartmentLabel.Location = new System.Drawing.Point(6, 256);
            this._courseOfDepartmentLabel.Name = "_courseOfDepartmentLabel";
            this._courseOfDepartmentLabel.Size = new System.Drawing.Size(82, 15);
            this._courseOfDepartmentLabel.TabIndex = 0;
            this._courseOfDepartmentLabel.Text = "班級內課程";
            // 
            // _departmentNameLabel
            // 
            this._departmentNameLabel.AutoSize = true;
            this._departmentNameLabel.Location = new System.Drawing.Point(6, 102);
            this._departmentNameLabel.Name = "_departmentNameLabel";
            this._departmentNameLabel.Size = new System.Drawing.Size(84, 15);
            this._departmentNameLabel.TabIndex = 0;
            this._departmentNameLabel.Text = "班級名稱(*)";
            // 
            // _departmentsListBox
            // 
            this._departmentsListBox.FormattingEnabled = true;
            this._departmentsListBox.ItemHeight = 15;
            this._departmentsListBox.Location = new System.Drawing.Point(8, 6);
            this._departmentsListBox.Name = "_departmentsListBox";
            this._departmentsListBox.Size = new System.Drawing.Size(307, 664);
            this._departmentsListBox.TabIndex = 2;
            this._departmentsListBox.SelectedIndexChanged += new System.EventHandler(this.SelectDepartmentListBox);
            // 
            // CourseManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1255, 794);
            this.Controls.Add(this._tabControl);
            this.Name = "CourseManagementForm";
            this.Text = "課程管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClosedForm);
            this._tabControl.ResumeLayout(false);
            this._courseManagement.ResumeLayout(false);
            this._courseInfoGroupBox.ResumeLayout(false);
            this._courseInfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._classTimeDataGridView)).EndInit();
            this._classManagement.ResumeLayout(false);
            this._departmentGroupBox.ResumeLayout(false);
            this._departmentGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox _coursesListBox;
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _courseManagement;
        private System.Windows.Forms.Button _saveCourseButton;
        private System.Windows.Forms.Button _addNewCourseButton;
        private System.Windows.Forms.GroupBox _courseInfoGroupBox;
        private System.Windows.Forms.TextBox _classTeacherAssistantTextBox;
        private System.Windows.Forms.TextBox _classNameTextBox;
        private System.Windows.Forms.TextBox _classTeacherTextBox;
        private System.Windows.Forms.TextBox _classCreditTextBox;
        private System.Windows.Forms.TextBox _classStageTextBox;
        private System.Windows.Forms.TextBox _classNumberTextBox;
        private System.Windows.Forms.Label _classRequiredOrElectiveLabel;
        private System.Windows.Forms.Label _classTeacherLabel;
        private System.Windows.Forms.Label _classTeacherAssistantLabel;
        private System.Windows.Forms.Label _classNameLabel;
        private System.Windows.Forms.Label _classCreditLabel;
        private System.Windows.Forms.ComboBox _classRequiredOrElectiveComboBox;
        private System.Windows.Forms.ComboBox _classStatusComboBox;
        private System.Windows.Forms.Label _classStageLabel;
        private System.Windows.Forms.Label _classNumberLabel;
        private System.Windows.Forms.TextBox _classLanguageTextBox;
        private System.Windows.Forms.Label _classLanguageLabel;
        private System.Windows.Forms.TextBox _classNoteTextBox;
        private System.Windows.Forms.Label _classNoteLabel;
        private System.Windows.Forms.DataGridView _classTimeDataGridView;
        private System.Windows.Forms.Label _classDepartmentLabel;
        private System.Windows.Forms.Label _classHourLabel;
        private System.Windows.Forms.ComboBox _classDepartmentComboBox;
        private System.Windows.Forms.ComboBox _classHourComboBox;
        private System.Windows.Forms.TabPage _classManagement;
        private System.Windows.Forms.DataGridViewTextBoxColumn _stageColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _sundayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _mondayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _tuesdayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _wednesdayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _thursdayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _fridayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _saturdayColumn;
        private System.Windows.Forms.Button _importCourseButton;
        private System.Windows.Forms.Button _saveDepartmentButton;
        private System.Windows.Forms.Button _addNewDepartmentButton;
        private System.Windows.Forms.GroupBox _departmentGroupBox;
        private System.Windows.Forms.ListBox _coursesOfDepartmentListBox;
        private System.Windows.Forms.TextBox _departmentNameTextBox;
        private System.Windows.Forms.Label _courseOfDepartmentLabel;
        private System.Windows.Forms.Label _departmentNameLabel;
        private System.Windows.Forms.ListBox _departmentsListBox;
    }
}