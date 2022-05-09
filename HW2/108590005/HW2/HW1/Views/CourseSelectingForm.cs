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
    public partial class CourseSelectingForm : Form
    {
        CourseSelectingFormPresentationModel _model;
        List<DataGridView> _dataGridViews = new List<DataGridView>();
        CourseSelectionForm _selectionForm;

        public CourseSelectingForm(CourseSelectingFormPresentationModel model)
        {
            this._model = model;
            _model.GetModel()._selectedCourseChanged += UpdateDataGridView;
            InitializeComponent();

            _model.GetHeaders();

            for (int i = 0; i < _model.GetCurriculumsCount(); i++)
            {
                // Create DataGridView
                DataGridView _newDataGridView = new DataGridView();
                _newDataGridView.Dock = DockStyle.Fill;
                _newDataGridView.AllowUserToAddRows = false;
                _newDataGridView.AllowUserToDeleteRows = false;
                _newDataGridView.RowHeadersVisible = false;
                _newDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // Create DataGridViewCheckBoxColumn
                DataGridViewCheckBoxColumn _dataGridViewCheckBox = new DataGridViewCheckBoxColumn();
                _dataGridViewCheckBox.HeaderText = "選";
                _newDataGridView.Columns.Add(_dataGridViewCheckBox);
                // Initialize
                InitialColumn(_newDataGridView);
                string className = InitialRow(_newDataGridView, i);
                // Add To _tabControl
                _tabControl.TabPages.Add(className);
                (_tabControl.TabPages[i]).Controls.Add(_newDataGridView);
                // DataGridView Event
                _newDataGridView.CellContentClick += ContentClickDataGridViewCourse;
                _newDataGridView.CellValueChanged += ValueChangedDataGridViewCourse;
                _dataGridViews.Add(_newDataGridView);
            }
        }

        // 關閉Form
        private void ClosedForm(object sender, FormClosedEventArgs e)
        {
            _model.GetModel()._selectedCourseChanged -= UpdateDataGridView;

            if (!_buttonCheckResult.Enabled)
                _selectionForm.Close();
        }

        // 開啟 CourseSelectionForm
        private void ClickCheckResultButton(object sender, EventArgs e)
        {
            _selectionForm = new CourseSelectionForm(_model.GetCourseSelectionPresentationModel());
            _selectionForm.FormClosed += EnableCheckResultButton;
            _selectionForm.Show();
            _buttonCheckResult.Enabled = false;
        }

        // 將 _buttonCheckResult 的 Enabled 設為 True
        public void EnableCheckResultButton(object sender, EventArgs e)
        {
            _buttonCheckResult.Enabled = true;
        }

        // 初始化 DataGridView 的 Columns
        public void InitialColumn(DataGridView dataGridView)
        {
            List<string> headers = _model.GetHeaders();
            foreach (string header in headers)
            {
                dataGridView.Columns.Add(header, header);
                dataGridView.Columns[dataGridView.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        // 將資料放入 DataGridView
        private string InitialRow(DataGridView dataGridView, int index)
        {
            string department = "";
            foreach (Course _course in _model.GetCourses(index).GetCourses())
            {
                List<object> add = new List<object>();
                add.Add(false);
                dataGridView.Rows.Add(_course.GetData(add).ToArray());
                department = _course.Department.Name;
            }
            return department;
        }

        // _dataGridViewCourse 的 Cell 值有變更時
        private void ValueChangedDataGridViewCourse(object sender, DataGridViewCellEventArgs e)
        {
            // 狀態存至 PresentationModel
            DataGridView dataGridView = (DataGridView)sender;
            int index = _dataGridViews.IndexOf(dataGridView);
            if (e.RowIndex >= 0 && index >= 0)
                _model.ChangeValue(index, e.RowIndex, (bool)dataGridView[0, e.RowIndex].Value);

            // 變更 _btnConfirm Enable
            _buttonConfirm.Enabled = _model.IsSelected();
        }

        // _dataGridViewCourse 的 Cell 被點擊時
        private void ContentClickDataGridViewCourse(object sender, DataGridViewCellEventArgs e)
        {
            //進一步觸發CellValueChanged
            ((DataGridView)sender).CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // 按下 _buttonConfirm
        private void ClickButtonConfirm(object sender, EventArgs e)
        {
            string result = _model.GetCourseConfirm();
            MessageBox.Show(result);
        }

        // 更新課表
        private void UpdateDataGridView()
        {
            _model.UpdateCurriculum();
            for (int i = 0; i < _dataGridViews.Count; i++)
            {
                _dataGridViews[i].Rows.Clear();
                InitialRow(_dataGridViews[i], i);
            }
            _model.ClearSelection();
            _buttonConfirm.Enabled = false;
        }
    }
}
