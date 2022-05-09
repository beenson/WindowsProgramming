using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    public partial class Course : INotifyPropertyChanged
    {
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

        // 取得節次資訊
        public List<object[]> GetSessions()
        {
            List<object[]> result = new List<object[]>();
            for (int i = 0; i < CLASS_TIME_CODE.Length; i++)
            {
                object[] session = new object[DAY_OF_WEEK + 1];
                char sessionCode = CLASS_TIME_CODE[i];
                session[0] = sessionCode;
                for (int j = 0; j < DAY_OF_WEEK; j++)
                {
                    session[j + 1] = ClassTime[j].Contains(sessionCode);
                }
                result.Add(session);
            }
            return result;
        }

        // 變更上課時間
        public void SetSection(int column, int row, bool value)
        {
            List<string> newClassTime = ClassTime[column].Split(Model.SPACE).ToList();
            if (value)
            {
                if (ClassTime[column].Contains(CLASS_TIME_CODE[row]))
                    return;
                newClassTime.Add(CLASS_TIME_CODE[row].ToString());
            }
            else
            {
                newClassTime.Remove(CLASS_TIME_CODE[row].ToString());
            }
            newClassTime = newClassTime.OrderBy(x => CLASS_TIME_CODE.IndexOf(x)).ToList();
            ClassTime[column] = String.Join(Model.SPACE.ToString(), newClassTime);
        }

        // 通知屬性變更
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
