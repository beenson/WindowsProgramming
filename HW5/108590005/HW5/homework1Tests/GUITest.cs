using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;

namespace homework1Tests
{
    [TestClass]
    public class GUITest
    {
        private Robot _robot;
        private string targetAppPath;
        private const string START_UP_FORM = "StartUpForm";
        private const string COURSE_SELECTING_FORM = "CourseSelectingForm";
        private const string COURSE_SELECTION_FORM = "CourseSelectionForm";
        private const string COURSE_MANAGEMENT_FORM = "CourseManagementForm";
        private const string IMPORT_COURSE_PROGRESS_FORM = "ImportCourseProgressForm";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "homework1Tests";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            if (Path.GetFileName(solutionPath.TrimEnd('\\')) == "bin")
                solutionPath = Path.Combine(solutionPath, "..\\..\\");
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "homework1.exe");
            _robot = new Robot(targetAppPath, START_UP_FORM);
        }


        /// <summary>
        /// Closes the launched program
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        // Open Course Selection Form
        public void OpenCourseSelection()
        {
            _robot.SwitchTo(START_UP_FORM);
            _robot.ClickButton("Course Selecting System");
            _robot.SwitchTo(COURSE_SELECTING_FORM);
            _robot.ClickButton("查看選課結果");
        }

        // Open All Form
        public void OpenAllForm()
        {
            _robot.SwitchTo(START_UP_FORM);
            _robot.ClickButton("Course Management System");
            _robot.ClickButton("Course Selecting System");
            _robot.SwitchTo(COURSE_SELECTING_FORM);
            _robot.ClickButton("查看選課結果");
        }

        // Course Selection/WithDraw Test
        [TestMethod]
        public void CourseSelectingTest()
        {
            OpenCourseSelection();
            CourseSelectingWithdrawTest();
            CourseSelectingConflictTest();
            CourseSelectingSameNameTest();
        }

        // Course Editing Test
        [TestMethod]
        public void CourseEditingTest()
        {
            _robot.ClickButton("Course Management System");
            _robot.SwitchTo(COURSE_MANAGEMENT_FORM);
            FieldOperateTest();
            EditClassTimeTest();
            OpenCourseSelection();
            _robot.SwitchTo(COURSE_MANAGEMENT_FORM);
        }

        // Edit Course Info Test
        [TestMethod]
        public void EditCourseInfoTest()
        {
            OpenAllForm();
            ChangeCourseInfo();
            _robot.SwitchTo(COURSE_SELECTING_FORM);
            _robot.ClickTabControl("資工三");
            _robot.AssertDataGridViewRowCountBy("資工三Courses", 11);
            _robot.ClickTabControl("電子三甲");
            _robot.AssertDataGridViewRowCountBy("電子三甲Courses", 26);
        }

        // Edit Course Info Test
        [TestMethod]
        public void EditCourseInfoTest2()
        {
            OpenAllForm();
            _robot.SwitchTo(COURSE_SELECTING_FORM);
            _robot.ClickDataGridViewCellBy("資工三Courses", 9, "選");
            _robot.ClickButton("確認送出");
            _robot.CloseMessageBox();
            ChangeCourseInfo();
            _robot.SwitchTo(COURSE_SELECTION_FORM);
            _robot.AssertDataGridViewRowCountBy("_dataGridViewSelectionCourse", 1);
        }

        // Add New Course
        [TestMethod]
        public void AddNewCourseTest()
        {
            _robot.ClickButton("Course Selecting System");
            _robot.ClickButton("Course Management System");
            _robot.SwitchTo(COURSE_MANAGEMENT_FORM);
            _robot.ClickButton("新稱課程");
            _robot.AssertText("_saveCourseButton", "新增");
            _robot.AssertEnable("新增", false);
            _robot.SetText("_classNumberTextBox", "270915");
            _robot.SetText("_classNameTextBox", "物件導向分析與設計" + Keys.Enter);
            _robot.SetText("_classCreditTextBox", "2");
            _robot.SetText("_classStageTextBox", "1");
            _robot.SetText("_classTeacherTextBox", "Teacher");
            _robot.ClickControl("_classHourComboBox");
            _robot.ClickButton("2");
            _robot.ClickDataGridViewCellBy("_classTimeDataGridView", 2, "一");
            _robot.ClickDataGridViewCellBy("_classTimeDataGridView", 2, "二");
            _robot.AssertEnable("新增", true);
            _robot.ClickButton("新增");
            _robot.AssertExists("物件導向分析與設計");
            _robot.SwitchTo(COURSE_SELECTING_FORM);
            _robot.ClickTabControl("資工三");
            _robot.AssertDataGridViewRowCountBy("資工三Courses", 13);
        }

        // Import Course Test
        [TestMethod]
        public void ImportCourseTest()
        {
            _robot.ClickButton("Course Selecting System");
            _robot.ClickButton("Course Management System");
            _robot.SwitchTo(COURSE_MANAGEMENT_FORM);
            _robot.ClickButton("匯入資工系全部課程");
            _robot.Sleep(3.5);
            _robot.CloseWindow();
            _robot.SwitchTo(COURSE_MANAGEMENT_FORM);
            _robot.AssertExists("計算機程式設計(一)");
            _robot.AssertExists("線性代數");
            _robot.AssertExists("校外實務實習(一)");
            _robot.AssertExists("樣式導向軟體設計");
            _robot.SwitchTo(COURSE_SELECTING_FORM);
            _robot.AssertExists("資工一");
            _robot.AssertExists("資工二");
            _robot.AssertExists("資工三");
            _robot.AssertExists("資工四");
            _robot.AssertExists("資工所");
        }

        // DepartmentManagement Test
        [TestMethod]
        public void DepartmentManagementTest()
        {
            OpenAllForm();
            _robot.SwitchTo(COURSE_MANAGEMENT_FORM);
            _robot.ClickTabControl("班級管理");
            _robot.ClickButton("資工三");
            _robot.AssertExists("視窗程式設計");
            _robot.ClickButton("新增班級");
            _robot.SetText("_departmentNameTextBox", "資工二" + Keys.Enter);
            _robot.ClickButton("新增");
            _robot.AssertExists("資工二");
            _robot.SwitchTo(COURSE_SELECTING_FORM);
            _robot.ClickButton("資工二");
            _robot.AssertDataGridViewRowCountBy("資工二Courses", 0);
        }

        // Field Operate Test
        public void FieldOperateTest()
        {
            _robot.ClickButton("訊號與系統");
            _robot.SetText("_classNameTextBox", "ABC");
            _robot.AssertEnable("儲存", true);
            _robot.ClearText("_classNameTextBox");
            _robot.AssertEnable("儲存", false);
        }
        
        // Edit Class Time Test
        public void EditClassTimeTest()
        {
            _robot.ClickButton("視窗程式設計");
            _robot.ClickDataGridViewCellBy("_classTimeDataGridView", 6, "四");
            _robot.ClickDataGridViewCellBy("_classTimeDataGridView", 5, "四");
            _robot.AssertEnable("儲存", true);
            _robot.ClickDataGridViewCellBy("_classTimeDataGridView", 6, "四");
            _robot.AssertEnable("儲存", false);
            _robot.ClickDataGridViewCellBy("_classTimeDataGridView", 5, "四");
        }

        // Change Course 視窗程式設計 to 物件導向分析與設計
        public void ChangeCourseInfo()
        {
            _robot.SwitchTo(COURSE_MANAGEMENT_FORM);
            _robot.ClickButton("視窗程式設計");
            _robot.SetText("_classNumberTextBox", "270915");
            _robot.SetText("_classNameTextBox", "物件導向分析與設計" + OpenQA.Selenium.Keys.Enter);
            _robot.SetText("_classCreditTextBox", "2");
            _robot.ClickControl("_classHourComboBox");
            _robot.ClickButton("2");
            _robot.ClickControl("_classDepartmentComboBox");
            _robot.ClickButton("電子三甲");
            _robot.ClickDataGridViewCellBy("_classTimeDataGridView", 2, "四");
            _robot.ClickDataGridViewCellBy("_classTimeDataGridView", 3, "四");
            _robot.ClickDataGridViewCellBy("_classTimeDataGridView", 6, "四");
            _robot.ClickDataGridViewCellBy("_classTimeDataGridView", 2, "一");
            _robot.ClickDataGridViewCellBy("_classTimeDataGridView", 2, "二");
            _robot.AssertEnable("儲存", true);
            _robot.ClickButton("儲存");
            _robot.AssertExists("物件導向分析與設計");
        }

        // Course Selection/WithDraw Testing
        private void CourseSelectingWithdrawTest()
        {
            _robot.ClickTabControl("資工三");
            _robot.ClickDataGridViewCellBy("資工三Courses", 3, "選");
            _robot.ClickTabControl("電子三甲");
            _robot.ClickDataGridViewCellBy("電子三甲Courses", 3, "選");
            _robot.ClickButton("確認送出");
            _robot.CloseMessageBox();
            _robot.ClickTabControl("資工三");
            _robot.AssertDataGridViewRowCountBy("資工三Courses", 11);
            _robot.ClickTabControl("電子三甲");
            _robot.AssertDataGridViewRowCountBy("電子三甲Courses", 24);
            _robot.SwitchTo(COURSE_SELECTION_FORM);
            _robot.AssertDataGridViewRowCountBy("_dataGridViewSelectionCourse", 2);
            _robot.ClickDataGridViewCellBy("_dataGridViewSelectionCourse", 0, "選");
            _robot.ClickDataGridViewCellBy("_dataGridViewSelectionCourse", 0, "選");
            _robot.AssertDataGridViewRowCountBy("_dataGridViewSelectionCourse", 0);
            _robot.SwitchTo(COURSE_SELECTING_FORM);
            _robot.ClickTabControl("資工三");
            _robot.AssertDataGridViewRowCountBy("資工三Courses", 12);
            _robot.ClickTabControl("電子三甲");
            _robot.AssertDataGridViewRowCountBy("電子三甲Courses", 25);
        }

        // Course Selecting Conflict Test
        private void CourseSelectingConflictTest()
        {
            _robot.ClickTabControl("資工三");
            _robot.ClickDataGridViewCellBy("資工三Courses", 10, "選");
            _robot.ClickTabControl("電子三甲");
            _robot.ClickDataGridViewCellBy("電子三甲Courses", 1, "選");
            _robot.ClickDataGridViewCellBy("電子三甲Courses", 17, "選");
            _robot.ClickButton("確認送出");
            _robot.AssertText("65535", "加選失敗\r\n\r\n衝堂：「294321 巨量資料分析導論」、「290750 數位影像處理」");
            _robot.CloseMessageBox();
        }

        // Course Selecting Same name Test
        private void CourseSelectingSameNameTest()
        {
            _robot.ClickTabControl("資工三");
            _robot.ClickDataGridViewCellBy("資工三Courses", 6, "選");
            _robot.ClickDataGridViewCellBy("資工三Courses", 7, "選");
            _robot.ClickTabControl("電子三甲");
            _robot.ClickDataGridViewCellBy("電子三甲Courses", 5, "選"); ;
            _robot.ClickButton("確認送出");
            _robot.AssertText("65535", "加選失敗\r\n\r\n課程名稱相同：「291707 實務專題(一)」、「291506 實務專題(一)」");
            _robot.CloseMessageBox();
        }
    }
}
