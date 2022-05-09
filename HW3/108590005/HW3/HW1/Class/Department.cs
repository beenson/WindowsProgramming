using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    public class Department
    {
        public Department(string name, string code)
        {
            this.Name = name;
            this.code = code;
        }

        // 是否相等
        public bool Equals(Department department)
        {
            return code == department.code;
        }

        // To String
        public override string ToString()
        {
            return Name;
        }

        public string Name
        {
            get;
        }

        public string code
        {
            get;
        }
    }
}
