using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework1.Class;
using HtmlAgilityPack;

namespace homework1
{
    public class Model
    {
        public event SelectCourseChangedEventHandler _selectedCourseChanged;
        public delegate void SelectCourseChangedEventHandler();
        public event NewCourseAddedEventHandler _newCourseAdded;
        public delegate void NewCourseAddedEventHandler();

        public const char SPACE = ' ';
        public const string SPLITER = "、";
        public const string CONFLICT = "衝堂：";
        public const string SAME_NAME = "課程名稱相同：";
        public const string SUCCESS = "加選成功";
        public const string FAIL = "加選失敗";
        public const string NEXT_LINE = "\r\n\r\n";

        const string LINK = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=";
        const string X_PATH = "//body/table";
        const int DATA_START = 3;
        readonly string[] _codes = { "2433", "2423" };

        private List<Course> _courses = new List<Course>();
        private List<string> _headers = new List<string>();
        private List<Course> _selectedCourse = new List<Course>();

        public Model(bool crawler)
        {
            if (crawler)
            {
                HtmlWeb webClient = new HtmlWeb();
                webClient.OverrideEncoding = Encoding.Default;
                HtmlDocument document = webClient.Load(LINK + _codes[0]);

                HtmlNode nodeTable = document.DocumentNode.SelectSingleNode(X_PATH);
                HtmlNodeCollection nodeTableRow = nodeTable.ChildNodes;

                // 移除 tbody
                nodeTableRow.RemoveAt(0);
                // 移除 <tr>資工三
                nodeTableRow.RemoveAt(0);
                foreach (var node in nodeTableRow[0].ChildNodes)
                {
                    _headers.Add(node.InnerText.Trim());
                }

                foreach (string code in _codes)
                {
                    CourseCrawler(code);
                }
            }
        }

        // 取得course
        public void CourseCrawler(string code)
        {
            HtmlWeb webClient = new HtmlWeb();
            webClient.OverrideEncoding = Encoding.Default;
            HtmlDocument document = webClient.Load(LINK + code);

            HtmlNode nodeTable = document.DocumentNode.SelectSingleNode(X_PATH);
            HtmlNodeCollection nodeTableRow = nodeTable.ChildNodes;

            Department department = new Department(nodeTableRow[1].InnerText.Trim(), code);
            if (_courses.Select(x => x.Department.Name).Contains(department.Name))
                return;
            for (int i = DATA_START; i < nodeTableRow.Count - 1; i++)
            {
                AddCourse(new Course(department, nodeTableRow[i].ChildNodes));
            }
        }

        // 加新課程
        public void AddCourse(Course course)
        {
            if (_courses.Select(x => x.Number).Contains(course.Number) && course.Number != "")
                return;
            _courses.Add(course);
            NotifyNewCourseAdded();
        }

        // 取得課表header
        public List<string> GetHeaders()
        {
            return _headers.ToList();
        }

        // 取得班級
        public object[] GetDepartments()
        {
            return _courses.Select(x => x.Department).Distinct().ToArray();
        }

        // Number of Department
        public int GetNumberOfDepartment()
        {
            return _courses.Select(x => x.Department.Name).Distinct().Count();
        }

        // 取得curriculums
        public List<Curriculum> GetCurriculums()
        {
            return _courses.GroupBy(x => x.Department).Select(x => new Curriculum(x.ToList())).ToList();
        }

        // 取得所有課程
        public List<Course> GetAllCourses()
        {
            return _courses.ToList();
        }

        // 確認課程選課有無問題
        public string SelectCourse(List<Course> courses)
        {
            List<string> errorMessages = new List<string>();
            courses.AddRange(_selectedCourse);
            errorMessages.Add(GetErrorMessage(CONFLICT, GetConflictCourse(courses)));
            errorMessages.Add(GetErrorMessage(SAME_NAME, GetSameNameCourse(courses)));
            errorMessages = errorMessages.Where(x => x.Length != 0).ToList();
            if (errorMessages.Count != 0)
            {
                errorMessages.Insert(0, FAIL);
                return string.Join(NEXT_LINE, errorMessages);
            }
            _selectedCourse = courses.ToList();
            NotifySelectedCourseChanged();
            return SUCCESS;
        }

        // 退選
        public void Withdraw(Course course)
        {
            _selectedCourse.Remove(course);
            NotifySelectedCourseChanged();
        }

        // 取得已選課表
        public List<Course> GetSelectedCourse()
        {
            return _selectedCourse.ToList();
        }

        // 邊更課程資訊
        public void ChangeCourseInfo(Course course, Course newCourseInfo)
        {
            course.SetValueAs(newCourseInfo);
            NotifySelectedCourseChanged();
        }

        // 轉換為錯誤訊息
        private string GetErrorMessage(string start, List<Course> courses)
        {
            if (courses.Count == 0)
                return "";
            return start + string.Join(SPLITER, courses.Select(x => x.ToString()));
        }

        // 取得同名課程
        private List<Course> GetSameNameCourse(List<Course> courses)
        {
            List<Course> result = new List<Course>();
            List<string> sameName = courses.GroupBy(x => x.Name).Where(x => x.Count() > 1).Select(x => x.Key).ToList();
            foreach (string name in sameName)
            {
                result.AddRange(courses.Where(x => x.Name == name).ToList());
            }
            return result;
        }

        // 檢查有無衝堂
        private List<Course> GetConflictCourse(List<Course> courses)
        {
            const int DAY_OF_WEEK = 7;
            List<Course> result = new List<Course>();
            for (int i = 0; i < DAY_OF_WEEK; i++)
            {
                List<string> confiltTime = GetConflictTime(i, courses);
                result.AddRange(courses.Where(x => confiltTime.Any(t => x.ClassTime[i].Contains(t))));
            }
            return result;
        }

        // 取得衝堂時間
        private List<string> GetConflictTime(int weekday, List<Course> courses)
        {
            const char SPLITER = ' ';
            return courses.SelectMany(x => x.ClassTime[weekday].Split(SPLITER)).GroupBy(x => x).Where(x => x.Key.Length > 0 && x.Count() > 1).Select(x => x.Key).ToList();
        }

        // 觸發事件
        private void NotifySelectedCourseChanged()
        {
            if (_selectedCourseChanged != null)
                _selectedCourseChanged();
        }

        // 觸發事件
        private void NotifyNewCourseAdded()
        {
            if (_newCourseAdded != null)
                _newCourseAdded();
        }
    }
}
