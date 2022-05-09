using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    public class CourseSelectionFormPresentationModel
    {
        private Model _model;
        private List<Course> _courses = new List<Course>();

        public CourseSelectionFormPresentationModel(Model model)
        {
            this._model = model;
        }

        // 取得header
        public List<string> GetHeaders()
        {
            return _model.GetHeaders();
        }

        // 取得model
        public Model GetModel()
        {
            return _model;
        }

        // 取得已選課程
        public List<Course> GetSelectedCourse()
        {
            _courses = _model.GetSelectedCourse();
            return _courses;
        }

        // 退選
        public void Withdraw(int index)
        {
            _model.Withdraw(_courses[index]);
        }
    }
}
