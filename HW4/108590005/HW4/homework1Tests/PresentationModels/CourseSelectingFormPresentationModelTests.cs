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
    public class CourseSelectingFormPresentationModelTests
    {
        Model model;
        CourseSelectingFormPresentationModel presentationModel;
        List<Course> courses = new List<Course>();
        PrivateObject privateObject;

        // Initialize
        [TestInitialize()]
        public void CourseSelectingFormPresentationModelTest()
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
            foreach (Course c in courses)
            {
                model.AddCourse(c);
            }
            presentationModel = new CourseSelectingFormPresentationModel(model);
            privateObject = new PrivateObject(presentationModel);
        }

        // GetModel Test
        [TestMethod()]
        public void GetModelTest()
        {
            Assert.AreEqual(model, presentationModel.GetModel());
        }

        // GetHeaders Test
        [TestMethod()]
        public void GetHeadersTest()
        {
            PrivateObject privateObject = new PrivateObject(model);
            List<string> headers = new List<string>() { "h1", "h2", "3h" };
            privateObject.SetFieldOrProperty("_headers", headers);
            List<string> expect = model.GetHeaders(), result = presentationModel.GetHeaders();
            Assert.AreEqual(expect.Count, result.Count);
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i], result[i]);
            }
        }

        // GetDepartmentCountTest
        [TestMethod()]
        public void GetDepartmentCountTest()
        {
            Assert.AreEqual(2, presentationModel.GetDepartmentCount());
        }

        // GetCourses Test
        [TestMethod()]
        public void GetCoursesTest()
        {
            Assert.AreEqual(null, presentationModel.GetCourses(-1));
            Assert.AreEqual(null, presentationModel.GetCourses(10));

            Assert.AreEqual(5, presentationModel.GetCourses(0).GetCourses().Count);
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(courses[i], presentationModel.GetCourses(0).GetCourse(i));
            }
        }

        // ChangeValue Test
        [TestMethod()]
        public void ChangeValueTest()
        {
            presentationModel.ChangeValue(0, 0, true);
            List<Course> selected = (List<Course>)privateObject.GetFieldOrProperty("_selected");
            Assert.AreEqual(1, selected.Count);
            Assert.AreEqual(courses[0], selected[0]);

            presentationModel.ChangeValue(0, 2, true);
            selected = (List<Course>)privateObject.GetFieldOrProperty("_selected");
            Assert.AreEqual(2, selected.Count);
            Assert.AreEqual(courses[2], selected[1]);

            presentationModel.ChangeValue(1, 0, true);
            selected = (List<Course>)privateObject.GetFieldOrProperty("_selected");
            Assert.AreEqual(3, selected.Count);
            Assert.AreEqual(courses[5], selected[2]);

            presentationModel.ChangeValue(0, 2, false);
            selected = (List<Course>)privateObject.GetFieldOrProperty("_selected");
            Assert.AreEqual(2, selected.Count);
        }

        // ClearSelection Test
        [TestMethod()]
        public void ClearSelectionTest()
        {
            List<Course> selected = new List<Course>();
            presentationModel.ChangeValue(0, 2, true);
            selected = (List<Course>)privateObject.GetFieldOrProperty("_selected");
            Assert.AreEqual(1, selected.Count);
            presentationModel.ChangeValue(0, 3, true);
            selected = (List<Course>)privateObject.GetFieldOrProperty("_selected");
            Assert.AreEqual(2, selected.Count);

            presentationModel.ClearSelection();
            selected = (List<Course>)privateObject.GetFieldOrProperty("_selected");
            Assert.AreEqual(0, selected.Count);

        }

        // IsSelected Test
        [TestMethod()]
        public void IsSelectedTest()
        {
            presentationModel.ChangeValue(0, 2, true);
            Assert.IsTrue(presentationModel.IsSelected());
            presentationModel.ChangeValue(0, 3, true);
            Assert.IsTrue(presentationModel.IsSelected());

            presentationModel.ClearSelection();
            Assert.IsFalse(presentationModel.IsSelected());
        }

        // GetCourseConfirm Test
        [TestMethod()]
        public void GetCourseConfirmTest()
        {
            presentationModel.ChangeValue(0, 0, true);
            presentationModel.ChangeValue(0, 2, true);
            presentationModel.ChangeValue(1, 0, true);
            presentationModel.GetCourseConfirm();
            Assert.IsFalse(presentationModel.IsSelected());
            Assert.AreEqual(3, model.GetSelectedCourse().Count);
        }

        // UpdateCurriculum Test
        [TestMethod()]
        public void UpdateCurriculumTest()
        {
            presentationModel.ChangeValue(0, 0, true);
            presentationModel.ChangeValue(0, 2, true);
            presentationModel.ChangeValue(1, 0, true);
            presentationModel.GetCourseConfirm();
            presentationModel.UpdateCurriculum();
            Assert.AreEqual(3, presentationModel.GetCourses(0).GetCourses().Count);
            Assert.AreEqual(4, presentationModel.GetCourses(1).GetCourses().Count);
        }

        // GetCourseSelectionPresentationModel Test
        [TestMethod()]
        public void GetCourseSelectionPresentationModelTest()
        {
            object m = presentationModel.GetCourseSelectionPresentationModel();
            Assert.AreEqual(typeof(CourseSelectionFormPresentationModel), m.GetType());
            Assert.AreEqual(model, ((CourseSelectionFormPresentationModel)m).GetModel());
        }
    }
}