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
    public class CourseSelectionFormPresentationModelTests
    {
        Model model;
        CourseSelectionFormPresentationModel presentationModel;
        List<Course> courses = new List<Course>();

        // Initialize
        [TestInitialize()]
        public void CourseSelectionFormPresentationModelTest()
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
            presentationModel = new CourseSelectionFormPresentationModel(model);
        }

        // GetHeaders Test
        [TestMethod()]
        public void GetHeadersTest()
        {
            PrivateObject privateObject = new PrivateObject(model);
            List<string> _headers = new List<string>() { "test1", "test2", "test3" };
            privateObject.SetFieldOrProperty("_headers", _headers);
            List<string> expect = model.GetHeaders(), result = presentationModel.GetHeaders();
            Assert.AreEqual(expect.Count, result.Count);
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i], result[i]);
            }
        }

        // GetModel Test
        [TestMethod()]
        public void GetModelTest()
        {
            Assert.AreEqual(model, presentationModel.GetModel());
        }

        // GetSelectedCourse Test
        [TestMethod()]
        public void GetSelectedCourseTest()
        {
            model.SelectCourse(new List<Course>() { courses[1] });
            Assert.AreEqual(1, presentationModel.GetSelectedCourse().Count);
            Assert.AreEqual(courses[1], presentationModel.GetSelectedCourse()[0]);
        }

        // Withdraw Test
        [TestMethod()]
        public void WithdrawTest()
        {
            model.SelectCourse(new List<Course>() { courses[1] });
            Assert.AreEqual(1, presentationModel.GetSelectedCourse().Count);
            presentationModel.Withdraw(0);
            Assert.AreEqual(0, presentationModel.GetSelectedCourse().Count);
        }
    }
}