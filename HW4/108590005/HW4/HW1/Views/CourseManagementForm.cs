using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework1
{
    public partial class CourseManagementForm : Form
    {
        CourseManagementFormPresentationModel _presentationModel;
        const string ENABLED = "Enabled";
        const string TEXT = "Text";

        public CourseManagementForm(CourseManagementFormPresentationModel presentationModel)
        {
            this._presentationModel = presentationModel;
            InitializeComponent();
            _presentationModel.GetModel()._newCourseAdded += AddedNewCourse;
            // textboxes combobox databinding
            _classStatusComboBox.DataBindings.Add(ENABLED, _presentationModel, CourseManagementFormPresentationModel.IS_EDIT_ABLE);
            _classNumberTextBox.DataBindings.Add(ENABLED, _presentationModel, CourseManagementFormPresentationModel.IS_EDIT_ABLE);
            _classNameTextBox.DataBindings.Add(ENABLED, _presentationModel, CourseManagementFormPresentationModel.IS_EDIT_ABLE);
            _classStageTextBox.DataBindings.Add(ENABLED, _presentationModel, CourseManagementFormPresentationModel.IS_EDIT_ABLE);
            _classCreditTextBox.DataBindings.Add(ENABLED, _presentationModel, CourseManagementFormPresentationModel.IS_EDIT_ABLE);
            _classTeacherTextBox.DataBindings.Add(ENABLED, _presentationModel, CourseManagementFormPresentationModel.IS_EDIT_ABLE);
            _classRequiredOrElectiveComboBox.DataBindings.Add(ENABLED, _presentationModel, CourseManagementFormPresentationModel.IS_EDIT_ABLE);
            _classTeacherAssistantTextBox.DataBindings.Add(ENABLED, _presentationModel, CourseManagementFormPresentationModel.IS_EDIT_ABLE);
            _classLanguageTextBox.DataBindings.Add(ENABLED, _presentationModel, CourseManagementFormPresentationModel.IS_EDIT_ABLE);
            _classNoteTextBox.DataBindings.Add(ENABLED, _presentationModel, CourseManagementFormPresentationModel.IS_EDIT_ABLE);
            _classHourComboBox.DataBindings.Add(ENABLED, _presentationModel, CourseManagementFormPresentationModel.IS_EDIT_ABLE);
            _classDepartmentComboBox.DataBindings.Add(ENABLED, _presentationModel, CourseManagementFormPresentationModel.IS_EDIT_ABLE);
            CreateDataBinding(_classStatusComboBox, TEXT, _presentationModel._editedCourse, nameof(Course.Status));
            CreateDataBinding(_classNumberTextBox, TEXT, _presentationModel._editedCourse, nameof(Course.Number));
            CreateDataBinding(_classNameTextBox, TEXT, _presentationModel._editedCourse, nameof(Course.Name));
            CreateDataBinding(_classStageTextBox, TEXT, _presentationModel._editedCourse, nameof(Course.Stage));
            CreateDataBinding(_classCreditTextBox, TEXT, _presentationModel._editedCourse, nameof(Course.Credit));
            CreateDataBinding(_classTeacherTextBox, TEXT, _presentationModel._editedCourse, nameof(Course.Teacher));
            CreateDataBinding(_classTeacherAssistantTextBox, TEXT, _presentationModel._editedCourse, nameof(Course.TeacherAssistant));
            CreateDataBinding(_classLanguageTextBox, TEXT, _presentationModel._editedCourse, nameof(Course.Language));
            CreateDataBinding(_classNoteTextBox, TEXT, _presentationModel._editedCourse, nameof(Course.Note));
            CreateDataBinding(_classHourComboBox, TEXT, _presentationModel._editedCourse, nameof(Course.Hour));
            CreateDataBinding(_classRequiredOrElectiveComboBox, TEXT, _presentationModel._editedCourse, nameof(Course.RequiredOrElective));
            CreateDataBinding(_classDepartmentComboBox, "SelectedItem", _presentationModel._editedCourse, nameof(Course.Department));
            // function button databinding
            _addNewCourseButton.DataBindings.Add(ENABLED, _presentationModel, nameof(CourseManagementFormPresentationModel.isAddButtonEnable));
            _saveButton.DataBindings.Add(TEXT, _presentationModel, nameof(CourseManagementFormPresentationModel.saveButtonText));
            _saveButton.DataBindings.Add(ENABLED, _presentationModel, nameof(CourseManagementFormPresentationModel.isSaveButtonEnable));
            _courseInfoGroupBox.DataBindings.Add(TEXT, _presentationModel, nameof(CourseManagementFormPresentationModel.groupBoxText));
            UpdateCourses();
            UpdateDepartment();
            UpdateClassTime();
        }

        // 新稱databinding關係 (on property changed)
        private void CreateDataBinding(Control item, string propertyName, object dataSource, string dataMember)
        {
            Binding binding = new Binding(propertyName, dataSource, dataMember);
            binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            item.DataBindings.Add(binding);
        }

        // 增加新課程後
        private void AddedNewCourse()
        {
            UpdateCourses();
            UpdateClassTime();
            UpdateDepartment();
            _classStatusComboBox.SelectedIndex = -1;
            _classRequiredOrElectiveComboBox.SelectedIndex = -1;
            _classHourComboBox.SelectedIndex = -1;
            _classDepartmentComboBox.SelectedIndex = -1;
            _classStatusComboBox.SelectedIndex = -1;
        }

        // 更新 _coursesListBox
        private void UpdateCourses()
        {
            _coursesListBox.Items.Clear();
            _coursesListBox.Items.AddRange(_presentationModel.GetAllCoursesName());
        }

        // 更新 Department Combo Box
        private void UpdateDepartment()
        {
            _classDepartmentComboBox.Items.Clear();
            _classDepartmentComboBox.Items.AddRange(_presentationModel.GetDepartments());
        }

        // 按下 _addNewCourseButton
        private void ClickAddNewCourseButton(object sender, EventArgs e)
        {
            _coursesListBox.ClearSelected();
            _presentationModel.AddNewCourseMode();
            _classStatusComboBox.SelectedIndex = 0;
            _classRequiredOrElectiveComboBox.SelectedIndex = 0;
            _classHourComboBox.SelectedIndex = 0;
            _classDepartmentComboBox.SelectedIndex = 0;
            _classStatusComboBox.SelectedIndex = 0;
            UpdateClassTime();
        }

        // 更新課程時間
        private void UpdateClassTime()
        {
            _classTimeDataGridView.Rows.Clear();
            foreach (object[] o in _presentationModel.GetSessions())
            {
                _classTimeDataGridView.Rows.Add(o);
            }
        }

        // ListBox change seleted index
        private void SelectedIndexChangedCoursesListBox(object sender, EventArgs e)
        {
            _presentationModel.SelectCourse(_coursesListBox.SelectedIndex);
            UpdateClassTime();
        }

        // 文字變動
        private void ChangedText(object sender, EventArgs e)
        {
            _presentationModel.Edited();
        }

        // 按下儲存按鈕
        private void ClickSaveButton(object sender, EventArgs e)
        {
            _presentationModel.Save();
            UpdateCourses();
            UpdateClassTime();
        }

        // _classTimeDataGridView 的 Cell 值有變更時
        private void ValueChangedDataGridView(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1)
                return;
            _presentationModel.SetCourseSection(e.ColumnIndex - 1, e.RowIndex, (bool)((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value);
        }

        // _classTimeDataGridView 的 Cell 被點擊時
        private void ContentClickDataGridView(object sender, DataGridViewCellEventArgs e)
        {
            //進一步觸發CellValueChanged
            ((DataGridView)sender).CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // 關閉 Form
        private void ClosedForm(object sender, FormClosedEventArgs e)
        {
            _presentationModel.GetModel()._newCourseAdded -= AddedNewCourse;
        }

        // 匯入資工系課程
        private void ImportComputerScienceCourses(object sender, EventArgs e)
        {
            _importCourseButton.Enabled = false;
            ImportCourseProgressFormPresentationModel presentationModel = _presentationModel.GetImportCourseProgressFormPresentationModel();
            presentationModel._crawlerDone += delegate { _importCourseButton.Enabled = true; };
            ImportCourseProgressForm form = new ImportCourseProgressForm(presentationModel);
            AddedNewCourse();
            form.ShowDialog();
        }
    }
}
