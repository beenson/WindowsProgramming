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
    public partial class CourseSelectionForm : Form
    {
        CourseSelectionFormPresentationModel _model;

        public CourseSelectionForm(CourseSelectionFormPresentationModel model)
        {
            this._model = model;
            _model.GetModel()._selectedCourseChanged += UpdateRow;
            InitializeComponent();
            InitialColumn(_dataGridViewSelectionCourse);
            UpdateRow();
        }

        // 關閉Form
        private void ClosedForm(object sender, FormClosedEventArgs e)
        {
            _model.GetModel()._selectedCourseChanged -= UpdateRow;
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

        // 更新已選課程
        public void UpdateRow()
        {
            _dataGridViewSelectionCourse.Rows.Clear();
            foreach (Course course in _model.GetSelectedCourse())
            {
                List<object> add = new List<object>();
                add.Add("退選");
                _dataGridViewSelectionCourse.Rows.Add(course.GetData(add).ToArray());
            }
        }

        // 點擊_dataGridViewSelectionCourse
        private void ClickDataGridViewContent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex < 0)
                return;
            _model.Withdraw(e.RowIndex);
        }
    }
}
