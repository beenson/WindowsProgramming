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
    public partial class StartUpForm : Form
    {
        StartUpFormPresentationModel _model;
        public StartUpForm(StartUpFormPresentationModel model)
        {
            this._model = model;
            InitializeComponent();
        }

        // 離開
        private void ClickExitButton(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 開啟 CourseSelectingForm
        private void ClickCourseSelectingSystemButton(object sender, EventArgs e)
        {
            _courseSelectingSystemButton.Enabled = false;
            CourseSelectingForm form = new CourseSelectingForm(_model.GetCourseSelectingPresentationModel());
            form.FormClosed += EnableCourseSelectingSystemButton;
            form.Show();
        }

        // 將 _courseSelectingSystemButton 的 Enabled 設為 True
        public void EnableCourseSelectingSystemButton(object sender, EventArgs e)
        {
            _courseSelectingSystemButton.Enabled = true;
        }

        // 開啟 CourseManagementForm
        private void ClickCourseManagementSystemButton(object sender, EventArgs e)
        {
            CourseManagementForm form = new CourseManagementForm();
            form.FormClosed += EnableCourseManagementSystemButton;
            form.Show();
            _courseManagementSystemButton.Enabled = false;
        }

        // 將 _courseManagementSystemButton 的 Enabled 設為 True
        public void EnableCourseManagementSystemButton(object sender, EventArgs e)
        {
            _courseManagementSystemButton.Enabled = true;
        }
    }
}
