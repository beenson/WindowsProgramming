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
    public partial class ImportCourseProgressForm : Form
    {
        ImportCourseProgressFormPresentationModel _presentationModel;

        public ImportCourseProgressForm(ImportCourseProgressFormPresentationModel presentationModel)
        {
            this._presentationModel = presentationModel;
            InitializeComponent();
            _progressBar.DataBindings.Add("Value", _presentationModel, nameof(ImportCourseProgressFormPresentationModel.Percentage));
            _importCourseProgressLable.DataBindings.Add("Text", _presentationModel, nameof(ImportCourseProgressFormPresentationModel.ProgressInfo));
        }

        // Form Shown
        private void ShownForm(object sender, EventArgs e)
        {
            _presentationModel.StartCrawler();
        }
    }
}
