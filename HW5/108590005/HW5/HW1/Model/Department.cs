using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    public class Department : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public Department(string name, string code)
        {
            this.name = name;
            this.code = code;
        }

        public Department(Department department)
        {
            this.name = department.name;
            this.code = department.code;
        }

        // 複製數值
        public void SetValueAs(Department department)
        {
            this.name = department.name;
            this.code = department.code;
        }

        // 是否合法
        public bool IsAvailable()
        {
            return name != "";
        }

        // 是否相等
        public bool Equals(Department department)
        {
            return code == department.code;
        }

        // To String
        public override string ToString()
        {
            return name;
        }

        // 通知屬性變更
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(name));
            }
        }

        private string _code;
        public string code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                NotifyPropertyChanged(nameof(code));
            }
        }
    }
}
