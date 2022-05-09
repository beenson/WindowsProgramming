using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace homework1
{
    public class CourseManagementFormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        const string ADD = "新增";
        const string SAVE = "儲存";
        const string EDIT = "編輯";
        const string COURSE = "課程";
        const string DEPARTMENT = "班級";
        int _selectedIndex = -1;

        Model _model;
        bool _isAddingNewCourse = false;
        bool _isCourseEditing = false;

        List<Department> _departments = new List<Department>();

        public CourseManagementFormPresentationModel(Model model)
        {
            this._model = model;
            isCourseEditAble = false;
            _editedCourse = new Course();
            _editedDepartment = new Department("", "");
            _courses = model.GetAllCourses();
            departmentGroupBoxText = DEPARTMENT;
            _editedCourse.PropertyChanged += (sender, e) => NotifyPropertyChangedCourse();
            _editedDepartment.PropertyChanged += (sender, e) => NotifyPropertyChangedDepartment();
        }

        // 取得 Model
        public Model GetModel()
        {
            return _model;
        }

        // 新增課程模式
        public void AddNewCourseMode()
        {
            _isAddingNewCourse = true;
            _isCourseEditing = false;
            isCourseEditAble = true;
            _selectedIndex = -1;            
            _editedCourse.SetValueAs(new Course((Department)_model.GetDepartments()[0]));
            NotifyPropertyChangedCourse();
        }

        // 取得節次資訊
        public List<object[]> GetSessions()
        {
            return _editedCourse.GetSessions();
        }

        // 取得班級
        public object[] GetDepartments()
        {
            _departments = _model.GetDepartments();
            return _departments.ToArray();
        }

        // 取得所有課程名稱
        public object[] GetAllCoursesName()
        {
            UpdateCourses();
            return _courses.Select(x => x.Name).ToArray();
        }

        // 選擇課程
        public void SelectCourse(int selectedIndex)
        {
            if (selectedIndex == -1)
                return;
            _editedCourse.SetValueAs(_courses[selectedIndex]);
            _isAddingNewCourse = false;
            _isCourseEditing = false;
            _selectedIndex = selectedIndex;
            isCourseEditAble = true;
            NotifyPropertyChangedCourse();
        }
        
        // 編輯過 Course
        public void CourseEdited()
        {
            _isCourseEditing = true;
            NotifyPropertyChanged(nameof(isCourseSaveButtonEnable));
        }

        // 儲存 Course
        public void CourseSave()
        {
            _isCourseEditing = false;
            if (!_editedCourse.IsAvailable())
                return;
            if (_isAddingNewCourse)
            {
                _model.AddCourse(new Course(_editedCourse));
                _editedCourse.SetValueAs(new Course());
                isCourseEditAble = false;
            }
            else
            {
                _model.ChangeCourseInfo(_courses[_selectedIndex], _editedCourse);
            }
            NotifyPropertyChangedCourse();
        }

        // 變更上課時間
        public void SetCourseSection(int column, int row, bool value)
        {
            _isCourseEditing = true;
            _editedCourse.SetSection(column, row, value);
            NotifyPropertyChanged(nameof(isCourseSaveButtonEnable));
        }

        // 取得 ImportCourseProgressFormPresentationModel
        public ImportCourseProgressFormPresentationModel GetImportCourseProgressFormPresentationModel()
        {
            _selectedIndex = -1;
            isCourseEditAble = false;
            _isAddingNewCourse = false;
            _isCourseEditing = false;
            _editedCourse.SetValueAs(new Course());
            NotifyPropertyChangedCourse();
            return new ImportCourseProgressFormPresentationModel(_model);
        }

        // 更新課程
        private void UpdateCourses()
        {
            _courses = _model.GetAllCourses();
        }

        // 通知所有 Course Property
        private void NotifyPropertyChangedCourse()
        {
            NotifyPropertyChanged(nameof(isCourseEditAble));
            NotifyPropertyChanged(nameof(isCourseAddButtonEnable));
            NotifyPropertyChanged(nameof(courseSaveButtonText));
            NotifyPropertyChanged(nameof(isCourseSaveButtonEnable));
            NotifyPropertyChanged(nameof(courseGroupBoxText));
        }

        // 通知所有 Department Property
        private void NotifyPropertyChangedDepartment()
        {
            NotifyPropertyChanged(nameof(departmentGroupBoxText));
            NotifyPropertyChanged(nameof(isDepartmentEditAble));
            NotifyPropertyChanged(nameof(isDepartmentAddButtonEnable));
            NotifyPropertyChanged(nameof(isDepartmentSaveButtonEnable));
        }

        // 通知 Property
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        // 選擇 Department
        public object[] SelectDepartment(int selectedIndex)
        {
            if (selectedIndex == -1)
                return new object[0];
            _editedDepartment.SetValueAs(_departments[selectedIndex]);
            _isAddingNewDepartment = false;
            isDepartmentEditAble = true;
            departmentGroupBoxText = DEPARTMENT;
            NotifyPropertyChangedDepartment();
            return _model.GetAllCoursesByDepartment(_departments[selectedIndex]).Select(x => x.Name).ToArray();
        }

        // 新增 Department
        public void AddNewDepartmentMode()
        {
            _editedDepartment.SetValueAs(new Department("", ""));
            _isAddingNewDepartment = true;
            isDepartmentEditAble = true;
            departmentGroupBoxText = ADD + DEPARTMENT;
            NotifyPropertyChangedDepartment();
        }

        // 編輯過 Department
        public void DepartmentEdited()
        {
            NotifyPropertyChanged(nameof(isDepartmentSaveButtonEnable));
        }

        // 儲存 Department
        public void DepartmentSave()
        {
            if (!_editedDepartment.IsAvailable() || !_isAddingNewDepartment)
                return;
            _model.AddDepartment(new Department(_editedDepartment));
            _editedDepartment.SetValueAs(new Department("", ""));
            isDepartmentEditAble = false;
            _isAddingNewDepartment = false;
            NotifyPropertyChangedDepartment();
        }

        private bool _isAddingNewDepartment = false;
        public Department _editedDepartment;

        public string departmentGroupBoxText
        {
            get;
            set;
        }

        public bool isDepartmentEditAble
        {
            get;
            set;
        }

        public bool isDepartmentAddButtonEnable
        {
            get
            {
                return !_isAddingNewDepartment;
            }
        }

        public bool isDepartmentSaveButtonEnable
        {
            get
            {
                return _isAddingNewDepartment && _editedDepartment.IsAvailable();
            }
        }

        public Course _editedCourse;
        private List<Course> _courses;

        public bool isCourseEditAble
        {
            get;
            set;
        }

        public bool isCourseAddButtonEnable
        {
            get
            {
                return !_isAddingNewCourse || !isCourseEditAble;
            }
        }

        public bool isCourseSaveButtonEnable
        {
            get
            {
                return _isCourseEditing && _editedCourse.IsAvailable();
            }
        }

        public string courseSaveButtonText
        {
            get
            {
                if (_isAddingNewCourse)
                    return ADD;
                return SAVE;
            }
        }

        public string courseGroupBoxText
        {
            get
            {
                if (_isAddingNewCourse)
                    return ADD + COURSE;
                return EDIT + COURSE;
            }
        }
    }
}
