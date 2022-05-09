using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Tests
{
    [TestClass()]
    public class CourseManagementFormPresentationModelTests
    {
        Model model;
        CourseManagementFormPresentationModel presentationModel;
        List<Course> courses = new List<Course>();
        PrivateObject privateObject;

        // Initialize
        [TestInitialize()]
        public void CourseManagementFormPresentationModelTest()
        {
            model = new Model(false);
            Department A = new Department("Dep1", "123");
            Department B = new Department("Dep2", "456");
            Department C = new Department("Dep3", "456");
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
            courses[0].Status = "開課";
            courses[0].Number = "123456";
            courses[0].Name = "Name";
            courses[0].Stage = "2";
            courses[0].Credit = "3.0";
            courses[0].Teacher = "Teacher";
            courses[0].RequiredOrElective = "★";
            courses[0].Hour = "3";
            courses[0].ClassTime = new List<string>()
            {
                "", "", "8", "3 4", "", "", ""
            };
            foreach (Course c in courses)
            {
                model.AddCourse(c);
            }
            presentationModel = new CourseManagementFormPresentationModel(model);
            privateObject = new PrivateObject(presentationModel);
            presentationModel.GetDepartments();
            presentationModel.PropertyChanged += delegate { };
        }

        // GetModel Test
        [TestMethod()]
        public void GetModelTest()
        {
            Assert.AreEqual(model, presentationModel.GetModel());
        }

        // AddNewCourseMode Test
        [TestMethod()]
        public void AddNewCourseModeTest()
        {
            presentationModel.AddNewCourseMode();
            Assert.IsTrue((bool)privateObject.GetFieldOrProperty("_isAddingNewCourse"));
            Assert.AreEqual("新增課程", presentationModel.courseGroupBoxText);
            Assert.AreEqual("新增", presentationModel.courseSaveButtonText);
            Assert.IsFalse(presentationModel.isCourseAddButtonEnable);
            Assert.IsFalse(presentationModel.isCourseSaveButtonEnable);
            Assert.IsTrue(presentationModel.isCourseEditAble);
        }

        // SelectCourse Test
        [TestMethod()]
        public void SelectCourseTest()
        {
            presentationModel.SelectCourse(-1);
            presentationModel.SelectCourse(0);
            Assert.IsFalse((bool)privateObject.GetFieldOrProperty("_isAddingNewCourse"));
            Assert.AreEqual("編輯課程", presentationModel.courseGroupBoxText);
            Assert.AreEqual("儲存", presentationModel.courseSaveButtonText);
            Assert.IsTrue(presentationModel.isCourseAddButtonEnable);
            Assert.IsFalse(presentationModel.isCourseSaveButtonEnable);
            Assert.IsTrue(presentationModel.isCourseEditAble);
        }

        // GetSessions Test
        [TestMethod()]
        public void GetSessionsTest()
        {
            presentationModel.SelectCourse(0);
            List<object[]> expect = courses[0].GetSessions(), result = presentationModel.GetSessions();
            Assert.AreEqual(expect.Count, result.Count);
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i].Length, result[i].Length);
                for (int j = 0; j < expect[i].Length; j++)
                {
                    Assert.AreEqual(expect[i][j], result[i][j]);
                }
            }
        }

        // GetDepartments Test
        [TestMethod()]
        public void GetDepartmentsTest()
        {
            List<Department> expect = model.GetDepartments();
            object[] result = presentationModel.GetDepartments();
            Assert.AreEqual(expect.Count, result.Length);
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i], result[i]);
            }
        }

        // GetAllCoursesName Test
        [TestMethod()]
        public void GetAllCoursesNameTest()
        {
            object[] expect = courses.Select(x => x.Name).ToArray(), result = presentationModel.GetAllCoursesName();
            Assert.AreEqual(expect.Length, result.Length);
            for (int i = 0; i < expect.Length; i++)
            {
                Assert.AreEqual(expect[i], result[i]);
            }
        }

        // Edited Test
        [TestMethod()]
        public void EditedTest()
        {
            presentationModel.SelectCourse(0);
            presentationModel.CourseEdited();
            Assert.IsTrue(presentationModel.isCourseSaveButtonEnable);
            presentationModel.SelectCourse(1);
            presentationModel.CourseEdited();
            Assert.IsFalse(presentationModel.isCourseSaveButtonEnable);
        }

        // Save Test
        [TestMethod()]
        public void SaveTest()
        {
            // selected course
            presentationModel.CourseSave();
            presentationModel.SelectCourse(0);
            presentationModel.CourseEdited();
            presentationModel.CourseSave();
            Assert.AreEqual("編輯課程", presentationModel.courseGroupBoxText);
            Assert.AreEqual("儲存", presentationModel.courseSaveButtonText);
            Assert.IsTrue(presentationModel.isCourseAddButtonEnable);
            Assert.IsFalse(presentationModel.isCourseSaveButtonEnable);
            Assert.IsTrue(presentationModel.isCourseEditAble);
            // add new course
            presentationModel.AddNewCourseMode();
            Assert.IsTrue((bool)privateObject.GetFieldOrProperty("_isAddingNewCourse"));
            presentationModel._editedCourse.SetValueAs(courses[0]);
            presentationModel.CourseSave();
            Assert.AreEqual("新增課程", presentationModel.courseGroupBoxText);
            Assert.AreEqual("新增", presentationModel.courseSaveButtonText);
            Assert.IsTrue(presentationModel.isCourseAddButtonEnable);
            Assert.IsFalse(presentationModel.isCourseSaveButtonEnable);
            Assert.IsFalse(presentationModel.isCourseEditAble);
        }

        // SetCourseSection Test
        [TestMethod()]
        public void SetCourseSectionTest()
        {
            presentationModel.SelectCourse(0);
            presentationModel.SetCourseSection(2, 8, false);
            Assert.AreEqual("", courses[0].ClassTime[2]);
            presentationModel.SetCourseSection(2, 7, true);
            Assert.AreEqual("7", courses[0].ClassTime[2]);
        }

        // GetImportCourseProgressFormPresentationModel Test
        [TestMethod()]
        public void GetImportCourseProgressFormPresentationModelTest()
        {
            object m = presentationModel.GetImportCourseProgressFormPresentationModel();
            Assert.AreEqual(typeof(ImportCourseProgressFormPresentationModel), m.GetType());
            Assert.AreEqual(model, ((ImportCourseProgressFormPresentationModel)m).GetModel());
        }

        // SelectDepartment Test
        [TestMethod()]
        public void SelectDepartmentTest()
        {
            Assert.AreEqual(0, presentationModel.SelectDepartment(-1).Length);
            object[] coursesOfDepartment = presentationModel.SelectDepartment(0);
            Assert.AreEqual("班級", presentationModel.departmentGroupBoxText);
            Assert.IsTrue(presentationModel.isDepartmentEditAble);
            Assert.IsTrue(presentationModel.isDepartmentAddButtonEnable);
            Assert.IsFalse(presentationModel.isDepartmentSaveButtonEnable);
            Assert.AreEqual(5, coursesOfDepartment.Length);
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(courses[i].Name, coursesOfDepartment[i]);
            }
        }

        // AddNewDepartmentMode Test
        [TestMethod()]
        public void AddNewDepartmentModeTest()
        {
            presentationModel.AddNewDepartmentMode();
            Assert.AreEqual("新增班級", presentationModel.departmentGroupBoxText);
            Assert.IsTrue(presentationModel.isDepartmentEditAble);
            Assert.IsFalse(presentationModel.isDepartmentAddButtonEnable);
            Assert.IsFalse(presentationModel.isDepartmentSaveButtonEnable);
            presentationModel._editedDepartment.SetValueAs(new Department("Test", ""));
            Assert.IsTrue(presentationModel.isDepartmentSaveButtonEnable);
        }

        // DepartmentEdited Test
        [TestMethod()]
        public void DepartmentEditedTest()
        {
            presentationModel.SelectDepartment(0);
            presentationModel.DepartmentEdited();
            Assert.IsFalse(presentationModel.isDepartmentSaveButtonEnable);
            presentationModel.AddNewDepartmentMode();
            presentationModel._editedDepartment.SetValueAs(new Department("Test", ""));
            presentationModel.DepartmentEdited();
            Assert.IsTrue(presentationModel.isDepartmentSaveButtonEnable);
        }

        // DepartmentSave Test
        [TestMethod()]
        public void DepartmentSaveTest()
        {
            presentationModel.AddNewDepartmentMode();
            presentationModel._editedDepartment.SetValueAs(new Department("", ""));
            presentationModel.DepartmentSave();
            presentationModel.GetDepartments();
            Assert.AreEqual(2, presentationModel.GetDepartments().Length);
            presentationModel.AddNewDepartmentMode();
            presentationModel._editedDepartment.SetValueAs(new Department("Test", ""));
            presentationModel.DepartmentSave();
            presentationModel.GetDepartments();
            Assert.AreEqual(3, presentationModel.GetDepartments().Length);
        }
    }
}