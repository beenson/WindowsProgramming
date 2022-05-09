using System.Collections.Generic;

namespace HTMLParser
{
    class CourseInfoDto
    {
        public CourseInfoDto(string number, string name, string stage, string credit, string hour, 
            string requiredOrElective, string teacher, List<string> classTime, string classroom, 
            string numberOfStudent, string numberOfDropStudent, string TA, string language, 
            string note, string syllabus, string audit, string experiment)
        {
            this.Number = number;
            this.Name = name;
            this.Stage = stage;
            this.Credit = credit;
            this.Hour = hour;
            this.RequiredOrElective = requiredOrElective;
            this.Teacher = teacher;
            this.ClassTime = classTime;
            this.Classroom = classroom;
            this.NumberOfStudent = numberOfStudent;
            this.NumberOfDropStudent = numberOfDropStudent;
            this.TA = TA;
            this.Language = language;
            this.Syllabus = syllabus;
            this.Note = note;
            this.Audit = audit;
            this.Experiment = experiment;
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

        public string TA
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
