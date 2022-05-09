using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework1.Class;
using HtmlAgilityPack;

namespace homework1
{
    public partial class Course : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public const int DAY_OF_WEEK = 7;
        public const string CLASS_TIME_CODE = "1234N56789ABCD";
        const string BEGIN = "「";
        const string END = "」";
        public const string SPACE = " ";
        public const string REQUIRED_OR_ELECTIVE_CODE = "○△☆●▲★";
        const string OPEN_CLASS = "開課";

        public Course(string name, string number)
        {
            this.SetValueAs(new Course());
            this.Name = name;
            this.Number = number;
        }

        public Course(Department department = null, string name = "", string number = "")
        {
            this.Department = department;
            this.Status = "";
            this.Number = number;
            this.Name = name;
            this.Stage = "";
            this.Credit = "";
            this.Hour = "";
            this.RequiredOrElective = "";
            this.Teacher = "";
            List<string> classTime = new List<string>();
            for (int i = 0; i < DAY_OF_WEEK; i++)
            {
                classTime.Add("");
            }
            this.ClassTime = classTime;
            this.Classroom = "";
            this.NumberOfStudent = "";
            this.NumberOfDropStudent = "";
            this.TeacherAssistant = "";
            this.Language = "";
            this.Syllabus = "";
            this.Note = "";
            this.Audit = "";
            this.Experiment = "";
        }

        public Course(Course course)
        {
            this.Department = course.Department;
            this.Status = course.Status;
            this.Number = course.Number;
            this.Name = course.Name;
            this.Stage = course.Stage;
            this.Credit = course.Credit;
            this.Hour = course.Hour;
            this.RequiredOrElective = course.RequiredOrElective;
            this.Teacher = course.Teacher;
            this.ClassTime = course.ClassTime;
            this.Classroom = course.Classroom;
            this.NumberOfStudent = course.NumberOfStudent;
            this.NumberOfDropStudent = course.NumberOfDropStudent;
            this.TeacherAssistant = course.TeacherAssistant;
            this.Language = course.Language;
            this.Syllabus = course.Syllabus;
            this.Note = course.Note;
            this.Audit = course.Audit;
            this.Experiment = course.Experiment;
        }

        public Course(Department department, HtmlNodeCollection nodeTableDatas)
        {
            this.Department = department;
            this.Status = OPEN_CLASS;
            int index = 1;
            this.Number = nodeTableDatas[index++].InnerText.Trim();
            this.Name = nodeTableDatas[index++].InnerText.Trim();
            this.Stage = nodeTableDatas[index++].InnerText.Trim();
            this.Credit = nodeTableDatas[index++].InnerText.Trim();
            this.Hour = nodeTableDatas[index++].InnerText.Trim();
            this.RequiredOrElective = nodeTableDatas[index++].InnerText.Trim();
            this.Teacher = nodeTableDatas[index++].InnerText.Trim();
            List<string> classTime = new List<string>();
            for (int i = 0; i < DAY_OF_WEEK; i++)
            {
                classTime.Add(nodeTableDatas[index++].InnerText.Trim());
            }
            this.ClassTime = classTime;
            this.Classroom = nodeTableDatas[index++].InnerText.Trim();
            this.NumberOfStudent = nodeTableDatas[index++].InnerText.Trim();
            this.NumberOfDropStudent = nodeTableDatas[index++].InnerText.Trim();
            this.TeacherAssistant = nodeTableDatas[index++].InnerText.Trim();
            this.Language = nodeTableDatas[index++].InnerText.Trim();
            this.Syllabus = nodeTableDatas[index++].InnerText.Trim();
            this.Note = nodeTableDatas[index++].InnerText.Trim();
            this.Audit = nodeTableDatas[index++].InnerText.Trim();
            this.Experiment = nodeTableDatas[index++].InnerText.Trim();
        }

        // 是否相等
        public override bool Equals(object input)
        {
            Course course = input as Course;
            if (course == null)
                return false;
            return course.ToString() == this.ToString();
        }

        // 「number name」
        public override string ToString()
        {
            return BEGIN + Number + SPACE + Name + END;
        }

        // GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
