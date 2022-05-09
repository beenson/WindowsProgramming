using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    public partial class Course
    {
        private Department _department;
        public Department Department
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
                this.NotifyPropertyChanged(nameof(this.Department));
            }
        }

        private string _status;
        public string Status
        {
            get
            {
                return this._status;
            }
            set
            {
                _status = value;
                this.NotifyPropertyChanged(nameof(this.Status));
            }
        }

        private string _number;
        public string Number
        {
            get
            {
                return this._number;
            }
            set
            {
                _number = value;
                this.NotifyPropertyChanged(nameof(this.Number));
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                _name = value;
                this.NotifyPropertyChanged(nameof(this.Name));
            }
        }

        private string _stage;
        public string Stage
        {
            get
            {
                return this._stage;
            }
            set
            {
                _stage = value;
                this.NotifyPropertyChanged(nameof(this.Stage));
            }
        }

        private string _credit;
        public string Credit
        {
            get
            {
                return this._credit;
            }
            set
            {
                _credit = value;
                this.NotifyPropertyChanged(nameof(this.Credit));
            }
        }

        private string _hour;
        public string Hour
        {
            get
            {
                return this._hour;
            }
            set
            {
                _hour = value;
                this.NotifyPropertyChanged(nameof(this.Hour));
            }
        }

        private string _teacher;
        public string Teacher
        {
            get
            {
                return this._teacher;
            }
            set
            {
                _teacher = value;
                this.NotifyPropertyChanged(nameof(this.Teacher));
            }
        }

        private List<string> _classTime;
        public List<string> ClassTime
        {
            get
            {
                return this._classTime;
            }
            set
            {
                _classTime = value;
                this.NotifyPropertyChanged(nameof(this.ClassTime));
            }
        }

        private string _classroom;
        public string Classroom
        {
            get
            {
                return this._classroom;
            }
            set
            {
                _classroom = value;
                this.NotifyPropertyChanged(nameof(this.Classroom));
            }
        }

        private string _numberOfStudent;
        public string NumberOfStudent
        {
            get
            {
                return this._numberOfStudent;
            }
            set
            {
                _numberOfStudent = value;
                this.NotifyPropertyChanged(nameof(this.NumberOfStudent));
            }
        }

        private string _note;
        public string Note
        {
            get
            {
                return this._note;
            }
            set
            {
                _note = value;
                this.NotifyPropertyChanged(nameof(this.Note));
            }
        }

        private string _numberOfDropStudent;
        public string NumberOfDropStudent
        {
            get
            {
                return this._numberOfDropStudent;
            }
            set
            {
                _numberOfDropStudent = value;
                this.NotifyPropertyChanged(nameof(this.NumberOfDropStudent));
            }
        }

        private string _teacherAssistant;
        public string TeacherAssistant
        {
            get
            {
                return this._teacherAssistant;
            }
            set
            {
                _teacherAssistant = value;
                this.NotifyPropertyChanged(nameof(this.TeacherAssistant));
            }
        }

        private string _language;
        public string Language
        {
            get
            {
                return this._language;
            }
            set
            {
                _language = value;
                this.NotifyPropertyChanged(nameof(this.Language));
            }
        }

        private string _syllabus;
        public string Syllabus
        {
            get
            {
                return this._syllabus;
            }
            set
            {
                _syllabus = value;
                this.NotifyPropertyChanged(nameof(this.Syllabus));
            }
        }

        private string _audit;
        public string Audit
        {
            get
            {
                return _audit;
            }
            set
            {
                _audit = value;
                this.NotifyPropertyChanged(nameof(this.Audit));
            }
        }

        private string _experiment;
        public string Experiment
        {
            get
            {
                return _experiment;
            }
            set
            {
                _experiment = value;
                this.NotifyPropertyChanged(nameof(this.Experiment));
            }
        }

        private string _requiredOrElective;
        public string RequiredOrElective
        {
            get
            {
                return _requiredOrElective;
            }
            set
            {
                _requiredOrElective = value;
                this.NotifyPropertyChanged(nameof(this.RequiredOrElective));
            }
        }
    }
}
