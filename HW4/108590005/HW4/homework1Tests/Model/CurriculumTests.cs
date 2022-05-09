using homework1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework1.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Class.Tests
{
    [TestClass()]
    public class CurriculumTests
    {
        Curriculum A, B, C;
        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            List<Course> courses = new List<Course>()
            {
                new Course("ABC", "123"),
                new Course("DEF", "321")
            };
            A = new Curriculum();
            B = new Curriculum(courses);
            C = new Curriculum(B);
        }

        // 測試GetCourses
        [TestMethod()]
        public void GetCoursesTest()
        {
            Assert.AreEqual(A.GetCourses().Count, 0);
            Assert.AreEqual(B.GetCourses().Count, 2);
            Assert.AreEqual(C.GetCourses().Count, 2);
        }

        // 測試GetCourse
        [TestMethod()]
        public void GetCourseTest()
        {
            Course course = A.GetCourse(0);
            Assert.AreEqual(course, null);
            course = B.GetCourse(0);
            Assert.AreEqual(course.Name, "ABC");
            course = B.GetCourse(1);
            Assert.AreEqual(course.Name, "DEF");
            course = C.GetCourse(0);
            Assert.AreEqual(course.Name, "ABC");
            course = C.GetCourse(1);
            Assert.AreEqual(course.Name, "DEF");
        }

        // 測試AddCourse
        [TestMethod()]
        public void AddCourseTest()
        {
            A.AddCourse(new Course());
            Assert.AreEqual(A.GetCourses().Count, 1);
            B.AddCourse(new Course());
            Assert.AreEqual(B.GetCourses().Count, 3);
            Assert.AreEqual(C.GetCourses().Count, 2);
        }

        // 測試AddCourses
        [TestMethod()]
        public void AddCoursesTest()
        {
            List<Course> courses = new List<Course>();
            A.AddCourses(courses);
            Assert.AreEqual(A.GetCourses().Count, 0);
            courses.Add(new Course());
            courses.Add(new Course());
            courses.Add(new Course());
            B.AddCourses(courses);
            Assert.AreEqual(A.GetCourses().Count, 0);
            Assert.AreEqual(B.GetCourses().Count, 5);
            Assert.AreEqual(C.GetCourses().Count, 2);
        }

        // 測試RemoveCourses
        [TestMethod()]
        public void RemoveCourseTest()
        {
            Assert.IsFalse(A.RemoveCourse(new Course()));
            Assert.AreEqual(A.GetCourses().Count, 0);
            Assert.IsFalse(B.RemoveCourse(new Course()));
            Assert.AreEqual(B.GetCourses().Count, 2);
            Assert.IsFalse(B.RemoveCourse(new Course("DEF", "123")));
            Assert.AreEqual(B.GetCourses().Count, 2);
            Assert.IsTrue(B.RemoveCourse(new Course("DEF", "321")));
            Assert.AreEqual(B.GetCourses().Count, 1);
            Course course = B.GetCourse(0);
            Assert.AreEqual(course.Name, "ABC");
            Assert.AreEqual(course.Number, "123");
            Assert.AreEqual(C.GetCourses().Count, 2);
        }
    }
}