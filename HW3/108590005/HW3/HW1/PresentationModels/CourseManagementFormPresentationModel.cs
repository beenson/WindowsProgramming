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
        public const string IS_EDIT_ABLE = "isEditAble";
        const string ADD = "新增";
        const string SAVE = "儲存";
        const string EDIT = "編輯";
        const string COURSE = "課程";
        const string IS_ADD_BUTTON_ENABLE = "isAddButtonEnable";
        const string SAVE_BUTTON_TEXT = "saveButtonText";
        const string IS_SAVE_BUTTON_ENABLE = "isSaveButtonEnable";
        const string GROUP_BOX_TEXT = "groupBoxText";
        int _selectedIndex = -1;

        Model _model;
        bool _isAddingNewCourse = false;
        bool _isEditing = false;

        public CourseManagementFormPresentationModel(Model model)
        {
            this._model = model;
            isEditAble = false;
            _editedCourse = new Course();
            _courses = new List<Course>();
            _editedCourse.PropertyChanged += (sender, e) => NotifyPropertyChanged();
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
            _isEditing = false;
            isEditAble = true;
            _selectedIndex = -1;            
            _editedCourse.SetValueAs(new Course((Department)_model.GetDepartments()[0]));
            NotifyPropertyChanged();
        }

        // 通知所有 Property
        private void NotifyPropertyChanged()
        {
            NotifyPropertyChanged(IS_EDIT_ABLE);
            NotifyPropertyChanged(IS_ADD_BUTTON_ENABLE);
            NotifyPropertyChanged(SAVE_BUTTON_TEXT);
            NotifyPropertyChanged(IS_SAVE_BUTTON_ENABLE);
            NotifyPropertyChanged(GROUP_BOX_TEXT);
        }

        // 通知 Property
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        // 取得節次資訊
        public List<object[]> GetSessions()
        {
            return _editedCourse.GetSessions();
        }

        // 取得班級
        public object[] GetDepartments()
        {
            return _model.GetDepartments();
        }

        // 更新課程
        public void UpdateCourses()
        {
            _courses = _model.GetAllCourses();
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
            _isEditing = false;
            _selectedIndex = selectedIndex;
            isEditAble = true;
            NotifyPropertyChanged();
        }
        
        // 編輯過
        public void Edited()
        {
            _isEditing = true;
            NotifyPropertyChanged(IS_SAVE_BUTTON_ENABLE);
        }

        // 儲存
        public void Save()
        {
            _isEditing = false;
            if (!_editedCourse.IsReasonable())
                return;
            if (_isAddingNewCourse)
            {
                _model.AddCourse(new Course(_editedCourse));
                _editedCourse.SetValueAs(new Course());
                isEditAble = false;
            }
            else
            {
                if (_selectedIndex == -1)
                    return;
                _model.ChangeCourseInfo(_courses[_selectedIndex], _editedCourse);
            }
            NotifyPropertyChanged();
        }

        // 變更上課時間
        public void SetCourseSection(int column, int row, bool value)
        {
            _isEditing = true;
            _editedCourse.SetSection(column, row, value);
            NotifyPropertyChanged(IS_SAVE_BUTTON_ENABLE);
        }

        public Course _editedCourse
        {
            get;
            set;
        }

        public List<Course> _courses
        {
            get;
            set;
        }

        public bool isEditAble
        {
            get;
            set;
        }

        public bool isAddButtonEnable
        {
            get
            {
                return !_isAddingNewCourse || !isEditAble;
            }
        }

        public bool isSaveButtonEnable
        {
            get
            {
                return _isEditing && _editedCourse.IsReasonable();
            }
        }

        public string saveButtonText
        {
            get
            {
                if (_isAddingNewCourse)
                    return ADD;
                return SAVE;
            }
        }

        public string groupBoxText
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
