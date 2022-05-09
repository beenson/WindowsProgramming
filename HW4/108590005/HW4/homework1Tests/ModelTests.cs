using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework1.Class;

namespace homework1.Tests
{
    [TestClass()]
    public class ModelTests
    {
        Model model;
        List<Department> departments = new List<Department>();
        List<Course> courses = new List<Course>();
        PrivateObject privateObject;
        bool eventCalled;

        // Init
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model(false);
            privateObject = new PrivateObject(model);
            Department A = new Department("Dep1", "123");
            Department B = new Department("Dep2", "456");
            Department C = new Department("Dep3", "456");
            departments.Add(A);
            departments.Add(B);
            departments.Add(C);
            courses.Add(new Course(A, "CourseA1", "1231"));
            courses.Add(new Course(A, "CourseA2", "1232"));
            courses.Add(new Course(A, "CourseA3", "1233"));
            courses.Add(new Course(A, "CourseA4", "1234"));
            courses.Add(new Course(A, "CourseA5", "1235"));
            courses.Add(new Course(B, "CourseB1", "4561"));
            courses.Add(new Course(B, "CourseB2", "4562"));
            courses.Add(new Course(B, "CourseB3", "4563"));
            courses.Add(new Course(B, "CourseB4", "4564"));
            courses.Add(new Course(B, "CourseB5", "4565"));
            courses.Add(new Course(C, "ConflictTime1", "7891"));
            courses.Last().ClassTime = new List<string>()
            {
                "", "5 6", "8", "", "", "", ""
            };
            courses.Add(new Course(C, "ConflictTime2", "7892"));
            courses.Last().ClassTime = new List<string>()
            {
                "", "", "8", "3 4", "", "", ""
            };
            courses.Add(new Course(C, "ConflictName", "7893"));
            courses.Add(new Course(C, "ConflictName", "7894"));
            foreach (Course c in courses)
            {
                model.AddCourse(c);
            }
        }

        // Methods Test
        [TestMethod()]
        public void ModelTest()
        {
            Model model = new Model(true);
            PrivateObject privateObject = new PrivateObject(model);
            Assert.IsTrue(((List<string>)privateObject.GetFieldOrProperty("_headers")).Count != 0);
            Assert.IsTrue(((List<Course>)privateObject.GetFieldOrProperty("_courses")).Count != 0);

            // GetNumberOfDepartment
            Assert.AreEqual(((string[])privateObject.GetFieldOrProperty("_codes")).Length, model.GetNumberOfDepartment());
            // GetHeaders
            List<string> headers = model.GetHeaders();
            Assert.AreEqual(23, headers.Count);
            Assert.AreEqual("課號", headers[0]);
            Assert.AreEqual("課程名稱", headers[1]);
            Assert.AreEqual("階段", headers[2]);
            Assert.AreEqual("學分", headers[3]);
            Assert.AreEqual("時數", headers[4]);
            Assert.AreEqual("修", headers[5]);
            Assert.AreEqual("教師", headers[6]);
            Assert.AreEqual("日", headers[7]);
            Assert.AreEqual("一", headers[8]);
            Assert.AreEqual("二", headers[9]);
            Assert.AreEqual("三", headers[10]);
            Assert.AreEqual("四", headers[11]);
            Assert.AreEqual("五", headers[12]);
            Assert.AreEqual("六", headers[13]);
            Assert.AreEqual("教室", headers[14]);
            Assert.AreEqual("人", headers[15]);
            Assert.AreEqual("撤", headers[16]);
            Assert.AreEqual("教學助理", headers[17]);
            Assert.AreEqual("授課語言", headers[18]);
            Assert.AreEqual("教學大綱與進度表", headers[19]);
            Assert.AreEqual("備註", headers[20]);
            Assert.AreEqual("隨班附讀", headers[21]);
            Assert.AreEqual("實驗實習", headers[22]);
        }

        // Departments Test
        [TestMethod]
        public void GetDepartmentTest()
        {
            Assert.AreEqual(departments.Count, model.GetNumberOfDepartment());
            foreach (Department d in model.GetDepartments())
            {
                Assert.IsTrue(departments.Contains(d));
            }
        }

        // Courses Test
        [TestMethod]
        public void GetCoursesTest()
        {
            Assert.AreEqual(courses.Count, model.GetAllCourses().Count);
            foreach (Course d in model.GetAllCourses())
            {
                Assert.IsTrue(courses.Contains(d));
            }
        }

        // GetCurriculums Test
        [TestMethod]
        public void GetCurriculumsTest()
        {
            List<Curriculum> expect = model.GetAllCourses().GroupBy(x => x.Department).Select(x => new Curriculum(x.ToList())).ToList();
            List<Curriculum> result = model.GetCurriculums();
            Assert.AreEqual(expect.Count, result.Count);
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i].GetCourses().Count, result[i].GetCourses().Count);
                for (int j = 0; j < expect[i].GetCourses().Count; j++)
                {
                    Assert.AreEqual(expect[i].GetCourse(j), result[i].GetCourse(j));
                }
            }
        }

        // CourseCrawler Test
        [TestMethod()]
        public void CourseCrawlerTest()
        {
            Model model = new Model(false);
            model.AddCourse(new Course(new Department("資工三", "2433")));
            Assert.AreEqual(1, model.GetNumberOfDepartment());
            model.CourseCrawler("2433");
            Assert.AreEqual(1, model.GetAllCourses().Count);
        }

        // AddCourse Test
        [TestMethod]
        public void AddCourseTest()
        {
            Assert.AreEqual(14, model.GetAllCourses().Count);
            model.AddCourse(new Course("CourseB6", "4566"));
            Assert.AreEqual(15, model.GetAllCourses().Count);
            model.AddCourse(new Course("CourseB6", "4566"));
            Assert.AreEqual(15, model.GetAllCourses().Count);
            model.AddCourse(new Course("CourseTest", "4566"));
            Assert.AreEqual(15, model.GetAllCourses().Count);
        }

        // Course Selection Test
        [TestMethod]
        public void CourseSelectionTest()
        {
            List<Course> select = new List<Course>();
            select.Add(courses[0]);
            select.Add(courses[2]);
            select.Add(courses[5]);
            select.Add(courses[6]);
            Assert.AreEqual(Model.SUCCESS, model.SelectCourse(select));
            Assert.AreEqual(4, model.GetSelectedCourse().Count);
            foreach (Course c in select)
            {
                Assert.IsTrue(model.GetSelectedCourse().Contains(c));
            }
            select.Clear();
            select.Add(courses[10]);
            select.Add(courses[11]);
            Assert.AreEqual(Model.FAIL + Model.NEXT_LINE + Model.CONFLICT + courses[10].ToString() + Model.SPLITER + courses[11].ToString(), model.SelectCourse(select));
            select.Clear();
            select.Add(courses[12]);
            select.Add(courses[13]);
            Assert.AreEqual(Model.FAIL + Model.NEXT_LINE + Model.SAME_NAME + courses[12].ToString() + Model.SPLITER + courses[13].ToString(), model.SelectCourse(select));
            select.Clear();
            select.Add(courses[10]);
            select.Add(courses[11]);
            select.Add(courses[12]);
            select.Add(courses[13]);
            Assert.AreEqual(Model.FAIL + Model.NEXT_LINE + Model.CONFLICT + courses[10].ToString() + Model.SPLITER + courses[11].ToString() + Model.NEXT_LINE + Model.SAME_NAME + courses[12].ToString() + Model.SPLITER + courses[13].ToString(), model.SelectCourse(select));
        }

        // Withdraw Test
        [TestMethod]
        public void WithDrawTest()
        {
            List<Course> select = new List<Course>();
            select.Add(courses[0]);
            select.Add(courses[2]);
            select.Add(courses[5]);
            select.Add(courses[6]);
            model.SelectCourse(select);
            model.Withdraw(courses[0]);
            Assert.AreEqual(3, model.GetSelectedCourse().Count);
            Assert.IsFalse(model.GetSelectedCourse().Contains(courses[0]));
        }

        // ChangeCourseInfo Test
        [TestMethod]
        public void ChangeCourseInfoTest()
        {
            model.ChangeCourseInfo(courses[0], new Course(departments[1], "newCourse", "5678"));
            Assert.AreEqual(courses.Count, model.GetAllCourses().Count);
            Assert.AreEqual(departments[1], model.GetAllCourses()[0].Department);
            Assert.AreEqual("newCourse", model.GetAllCourses()[0].Name);
            Assert.AreEqual("5678", model.GetAllCourses()[0].Number);
            for (int i = 1; i < courses.Count; i++)
            {
                Assert.AreEqual(courses[i].Department, model.GetAllCourses()[i].Department);
                Assert.AreEqual(courses[i].Name, model.GetAllCourses()[i].Name);
                Assert.AreEqual(courses[i].Number, model.GetAllCourses()[i].Number);
            }
        }

        // Delegate Event Test
        [TestMethod]
        public void DelegateEventTest()
        {
            model._newCourseAdded += EventCalled;
            eventCalled = false;
            model.AddCourse(new Course());
            Assert.IsTrue(eventCalled);
            model._newCourseAdded -= EventCalled;

            model._selectedCourseChanged += EventCalled;
            eventCalled = false;
            model.ChangeCourseInfo(courses[0], new Course());
            Assert.IsTrue(eventCalled);
            eventCalled = false;
            model.SelectCourse(new List<Course>() { courses[0] });
            Assert.IsTrue(eventCalled);
            eventCalled = false;
            model.Withdraw(courses[0]);
            Assert.IsTrue(eventCalled);
            model._selectedCourseChanged -= EventCalled;
        }

        // Event Called
        private void EventCalled()
        {
            eventCalled = true;
        }
    }
}