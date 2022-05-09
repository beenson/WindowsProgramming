using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace homework1
{
    public class Course
    {
        public Course(HtmlNodeCollection nodeTableDatas)
        {
            const int DAY_OF_WEEK = 7;
            int index = 0;
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

        //取得課程資料
        public List<object> GetData(List<object> add = null)
        {
            List<object> result = new List<object>();
            if (add != null)
                result.AddRange(add);
            result.AddRange(GetInfo());
            result.AddRange(ClassTime);
            result.AddRange(GetMore());
            return result;
        }

        //取得基本資訊
        public List<object> GetInfo()
        {
            List<object> result = new List<object>();
            result.Add(Number);
            result.Add(Name);
            result.Add(Stage);
            result.Add(Credit);
            result.Add(Hour);
            result.Add(RequiredOrElective);
            result.Add(Teacher);
            return result;
        }

        //取得更多
        public List<object> GetMore()
        {
            List<object> result = new List<object>();
            result.Add(Classroom);
            result.Add(NumberOfStudent);
            result.Add(NumberOfDropStudent);
            result.Add(TeacherAssistant);
            result.Add(Language);
            result.Add(Syllabus);
            result.Add(Note);
            result.Add(Audit);
            result.Add(Experiment);
            return result;
        }

        public string Number
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Stage
        {
            get; set;
        }

        public string Credit
        {
            get; set;
        }

        public string Hour
        {
            get; set;
        }

        public string Teacher
        {
            get; set;
        }

        public List<string> ClassTime
        {
            get; set;
        }

        public string Classroom
        {
            get; set;
        }

        public string NumberOfStudent
        {
            get; set;
        }

        public string Note
        {
            get; set;
        }

        public string NumberOfDropStudent
        {
            get; set;
        }

        public string TeacherAssistant
        {
            get; set;
        }

        public string Language
        {
            get; set;
        }

        public string Syllabus
        {
            get; set;
        }

        public string Audit
        {
            get; set;
        }

        public string Experiment
        {
            get; set;
        }

        public string RequiredOrElective
        {
            get; set;
        }
    }
}
