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
    public class CourseTests
    {
        Course A, B, C;
        // Init
        [TestInitialize]
        public void Initialize()
        {
            A = new Course("CourseName", "1234");
            B = new Course(new Department("DepName", "4321"));
            B.Status = "Status";
            B.Number = "Number";
            B.Name = "Name";
            B.Stage = "Stage";
            B.Credit = "Credit";
            B.Hour = "Hour";
            B.RequiredOrElective = "RequiredOrElective";
            B.Teacher = "Teacher";
            B.ClassTime = new List<string>()
            {
                "7", "1", "2", "3", "4", "5", "6"
            };
            B.Classroom = "Classroom";
            B.NumberOfStudent = "NumberOfStudent";
            B.NumberOfDropStudent = "NumberOfDropStudent";
            B.TeacherAssistant = "TeacherAssistant";
            B.Language = "Language";
            B.Syllabus = "Syllabus";
            B.Note = "Note";
            B.Audit = "Audit";
            B.Experiment = "Experiment";
            C = new Course(B);
            C.Number = "123456";
            C.Stage = "1";
            C.Credit = "3.0";
            C.Hour = "3";
            C.ClassTime = new List<string>()
            {
                "", "4", "", "6 7", "", "", ""
            };
        }

        // Contstructor 1
        [TestMethod()]
        public void CourseConstructor1()
        {
            Course course = new Course("NAME", "123456");
            Assert.AreEqual(course.Name, "NAME");
            Assert.AreEqual(course.Number, "123456");
        }

        // Contstructor 2
        [TestMethod()]
        public void CourseConstructor2()
        {
            Course course = new Course();
            Assert.AreEqual(course.Department, null);
        }

        // Contstructor 3
        [TestMethod()]
        public void CourseConstructor3()
        {
            Department department = new Department("DName", "789");
            Course course = new Course(department);
            Assert.AreEqual(course.Department, department);
        }

        // Contstructor 4
        [TestMethod()]
        public void CourseConstructor4()
        {
            C.Name = "Test";
            Assert.AreEqual("Name", B.Name);
            Assert.AreEqual("Test", C.Name);
        }

        // Property Changed Test
        [TestMethod()]
        public void PropertyChangedTest()
        {
            string changedPropertyName = string.Empty;
            A.PropertyChanged += (sender, args) => changedPropertyName = args.PropertyName;
            A.Department = new Department("Test", "1234");
            Assert.AreEqual("Department", changedPropertyName);
            A.Status = "Test";
            Assert.AreEqual("Status", changedPropertyName);
            A.Number = "Test";
            Assert.AreEqual("Number", changedPropertyName);
            A.Name = "Test";
            Assert.AreEqual("Name", changedPropertyName);
            A.Stage = "Test";
            Assert.AreEqual("Stage", changedPropertyName);
            A.Credit = "Test";
            Assert.AreEqual("Credit", changedPropertyName);
            A.Hour = "Test";
            Assert.AreEqual("Hour", changedPropertyName);
            A.Teacher = "Test";
            Assert.AreEqual("Teacher", changedPropertyName);
            A.ClassTime = new List<string>();
            Assert.AreEqual("ClassTime", changedPropertyName);
            A.Classroom = "Test";
            Assert.AreEqual("Classroom", changedPropertyName);
            A.NumberOfStudent = "Test";
            Assert.AreEqual("NumberOfStudent", changedPropertyName);
            A.Note = "Test";
            Assert.AreEqual("Note", changedPropertyName);
            A.NumberOfDropStudent = "Test";
            Assert.AreEqual("NumberOfDropStudent", changedPropertyName);
            A.TeacherAssistant = "Test";
            Assert.AreEqual("TeacherAssistant", changedPropertyName);
            A.Language = "Test";
            Assert.AreEqual("Language", changedPropertyName);
            A.Syllabus = "Test";
            Assert.AreEqual("Syllabus", changedPropertyName);
            A.Audit = "Test";
            Assert.AreEqual("Audit", changedPropertyName);
            A.Experiment = "Test";
            Assert.AreEqual("Experiment", changedPropertyName);
            A.RequiredOrElective = "Test";
            Assert.AreEqual("RequiredOrElective", changedPropertyName);
        }

        // Equals Test
        [TestMethod]
        public void EqualsTest()
        {
            Assert.IsFalse(A.Equals(new object()));
            Assert.IsTrue(A.Equals(A));
            Assert.IsTrue(A.Equals(new Course("CourseName", "1234")));
        }

        // ToString Test
        [TestMethod]
        public void MyTestMethod()
        {
            Assert.AreEqual("「1234 CourseName」", A.ToString());
            Assert.AreEqual("「 」", (new Course()).ToString());
        }

        // GetHashCode Test
        [TestMethod]
        public void GetHashCodeTest()
        {
            Assert.AreEqual(A.GetHashCode(), A.GetHashCode());
        }

        // IsAvailable Test
        [TestMethod]
        public void IsAvailableTest()
        {
            Assert.IsFalse(B.IsAvailable());
            Assert.IsTrue(C.IsAvailable());
            // Number
            C.Number = "Number";
            Assert.IsFalse(C.IsAvailable());
            C.Number = "";
            Assert.IsFalse(C.IsAvailable());
            C.Number = "123456";
            // Name
            C.Name = "";
            Assert.IsFalse(C.IsAvailable());
            C.Name = "Name";
            // Stage
            C.Stage = "Stage";
            Assert.IsFalse(C.IsAvailable());
            C.Stage = "1";
            // Credit
            C.Credit = "Credit";
            Assert.IsFalse(C.IsAvailable());
            C.Credit = "3.0";
            // Teacher
            C.Teacher = "";
            Assert.IsFalse(C.IsAvailable());
            C.Teacher = "Teacher";
            // RequiredOrElective
            C.RequiredOrElective = "";
            Assert.IsFalse(C.IsAvailable());
            C.RequiredOrElective = "RequiredOrElective";
            // Hour
            C.Hour = "4";
            Assert.IsFalse(C.IsAvailable());
            C.Hour = "Hour";
            Assert.IsFalse(C.IsAvailable());
            C.Hour = "3";
            //ClassTime
            C.ClassTime[0] = "1";
            Assert.IsFalse(C.IsAvailable());
            C.ClassTime.RemoveAt(0);
            Assert.IsFalse(C.IsAvailable());
        }

        // GetData Test
        [TestMethod]
        public void GetDataTest()
        {
            List<object> result = B.GetData();
            Assert.AreEqual(23, result.Count);
            Assert.AreEqual("Number", result[0]);
            Assert.AreEqual("Name", result[1]);
            Assert.AreEqual("Stage", result[2]);
            Assert.AreEqual("Credit", result[3]);
            Assert.AreEqual("Hour", result[4]);
            Assert.AreEqual("RequiredOrElective", result[5]);
            Assert.AreEqual("Teacher", result[6]);
            Assert.AreEqual("7", result[7]);
            Assert.AreEqual("1", result[8]);
            Assert.AreEqual("2", result[9]);
            Assert.AreEqual("3", result[10]);
            Assert.AreEqual("4", result[11]);
            Assert.AreEqual("5", result[12]);
            Assert.AreEqual("6", result[13]);
            Assert.AreEqual("Classroom", result[14]);
            Assert.AreEqual("NumberOfStudent", result[15]);
            Assert.AreEqual("NumberOfDropStudent", result[16]);
            Assert.AreEqual("TeacherAssistant", result[17]);
            Assert.AreEqual("Language", result[18]);
            Assert.AreEqual("Syllabus", result[19]);
            Assert.AreEqual("Note", result[20]);
            Assert.AreEqual("Audit", result[21]);
            Assert.AreEqual("Experiment", result[22]);
            List<object> add = new List<object>() { false };
            result = B.GetData(add);
            Assert.AreEqual(24, result.Count);
            Assert.AreEqual(false, result[0]);
        }

        // GetSession Test
        [TestMethod]
        public void GetSessionTest()
        {
            List<object[]> result = C.GetSessions();
            Assert.AreEqual(14, result.Count);
            for (int i = 0; i < 14; i++)
            {
                Assert.AreEqual(8, result[i].Length);
                Assert.AreEqual(Course.CLASS_TIME_CODE[i], result[i][0]);
                for(int j = 1; j < 8; j++)
                {
                    object session = result[i][j];
                    if ((i == 3 && j == 2) || ((i == 6 || i == 7) && j == 4))
                    {
                        Assert.AreEqual(true, session);
                    }
                    else
                    {
                        Assert.AreEqual(false, session);
                    }
                }
            }
        }

        //SetSession Test
        [TestMethod]
        public void SetSessionTest()
        {
            C.SetSection(1, 3, false);
            Assert.AreEqual("", C.ClassTime[1]);
            C.SetSection(2, 4, true);
            Assert.AreEqual("N", C.ClassTime[2]);
            C.SetSection(3, 5, true);
            Assert.AreEqual("5 6 7", C.ClassTime[3]);
            C.SetSection(3, 9, true);
            Assert.AreEqual("5 6 7 9", C.ClassTime[3]);
            C.SetSection(3, 6, true);
            Assert.AreEqual("5 6 7 9", C.ClassTime[3]);
            C.SetSection(3, 6, false);
            Assert.AreEqual("5 7 9", C.ClassTime[3]);
            C.SetSection(3, 7, false);
            Assert.AreEqual("5 9", C.ClassTime[3]);
        }
    }
}