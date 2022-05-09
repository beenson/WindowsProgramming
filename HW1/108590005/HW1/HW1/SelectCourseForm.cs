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
    public partial class SelectCourseForm : Form
    {
        Model _model;
        public SelectCourseForm(Model model)
        {
            this._model = model;
            InitializeComponent();
            model.GetHeaders();
        }

        // 當Form在Load時執行
        private void LoadSelectCourseForm(object sender, EventArgs e)
        {
            InitialColumn();
            InitialRow();
        }

        // 初始化 _dgvCourse 的 Columns
        private void InitialColumn()
        {
            List<string> headers = _model.GetHeaders();
            foreach (string header in headers)
            {
                _dataGridViewCourse.Columns.Add(header, header);
            }
        }

        // 將資料放入 _dgvCourse
        private void InitialRow()
        {
            foreach (Course _course in _model.GetCourses())
            {
                List<object> add = new List<object>();
                add.Add(false);
                List<object> tmp = _course.GetData(add);
                _dataGridViewCourse.Rows.Add(tmp.ToArray());
            }
        }

        // _dataGridViewCourse 的 Cell 值有變更時
        private void ValueChangedDataGridViewCourse(object sender, DataGridViewCellEventArgs e)
        {
            // 取得第1 Column 值
            List<bool> selectState = new List<bool>();
            for (int i = 0; i < _dataGridViewCourse.Rows.Count; i++)
            {
                selectState.Add((bool)_dataGridViewCourse[0, i].Value);
            }

            // 變更 _btnConfirm Enable
            _buttonConfirm.Enabled = _model.EnableConfirm(selectState);
        }

        // _dataGridViewCourse 的 Cell 被點擊時
        private void ContentClickDataGridViewCourse(object sender, DataGridViewCellEventArgs e)
        {
            //進一步觸發CellValueChanged
            _dataGridViewCourse.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
