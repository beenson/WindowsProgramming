using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Class
{
    public class Curriculum
    {
        List<Course> _courses = new List<Course>();
        
        public Curriculum(Curriculum curriculum)
        {
            this._courses = curriculum._courses.ToList();
        }

        public Curriculum(List<Course> courses)
        {
            _courses = courses;
        }

        public Curriculum()
        {

        }

        // 取得課程
        public List<Course> GetCourses()
        {
            return _courses;
        }

        // 取得課程
        public Course GetCourse(int index)
        {
            return _courses[index];
        }

        // 加入課程
        public void AddCourse(Course course)
        {
            _courses.Add(course);
        }

        // 加入課程(多個)
        public void AddCourses(List<Course> courses)
        {
            _courses.AddRange(courses);
        }

        // 移除課程
        public bool RemoveCourse(Course course)
        {
            int index = _courses.IndexOf(course);
            if (index == -1)
                return false;
            _courses.RemoveAt(index);
            return true;
        }
    }
}
