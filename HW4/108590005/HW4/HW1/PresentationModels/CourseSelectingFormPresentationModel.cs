using homework1.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    public class CourseSelectingFormPresentationModel
    {
        private List<Curriculum> _curriculums = new List<Curriculum>();
        private List<Course> _selected = new List<Course>();
        private Model _model;

        public CourseSelectingFormPresentationModel(Model model)
        {
            this._model = model;
            UpdateCurriculum();
        }

        // 取得model
        public Model GetModel()
        {
            return _model;
        }

        // 取得課表header
        public List<string> GetHeaders()
        {
            return _model.GetHeaders();
        }

        // 取得課表數
        public int GetDepartmentCount()
        {
            return _model.GetNumberOfDepartment();
        }

        // 取得curriculum
        public Curriculum GetCourses(int index)
        {
            if (index < 0 || index >= _curriculums.Count)
                return null;
            return _curriculums[index];
        }

        // 變更勾選
        public void ChangeValue(int curriculumIndex, int rowIndex, bool value)
        {
            Course course = _curriculums[curriculumIndex].GetCourse(rowIndex);
            if (value)
                _selected.Add(course);
            else
                _selected.Remove(course);
        }

        // 清除所選課程
        public void ClearSelection()
        {
            _selected.Clear();
        }

        // 是否有選課
        public bool IsSelected()
        {
            return _selected.Count != 0;
        }

        // 確認課程有無問題
        public string GetCourseConfirm()
        {
            string result = _model.SelectCourse(_selected);
            ClearSelection();
            return result;
        }

        // 更新課表
        public void UpdateCurriculum()
        {
            List<Course> selected = _model.GetSelectedCourse();
            _curriculums = _model.GetCurriculums().Select(x => new Curriculum(x)).ToList();
            foreach (Curriculum c in _curriculums)
            {
                foreach (Course course in selected)
                {
                    c.RemoveCourse(course);
                }
            }
        }

        // 創建 CourseSelectionFormPresentationModel
        public CourseSelectionFormPresentationModel GetCourseSelectionPresentationModel()
        {
            return new CourseSelectionFormPresentationModel(_model);
        }
    }
}
