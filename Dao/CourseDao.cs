using Dao;
using Entity_library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dao_library
{
    public class CourseDao
    {
        public Course GetCourse(Course course)
        {
            return MockDatabase.Courses.FirstOrDefault(c => c.Id == course.Id);
        }
        public Course PostCourse(Course course)
        {
            if (course != null)
            {
                course.Id = MockDatabase.Courses.Count + 1;
                MockDatabase.Courses.Add(course);
                return course;
            }
            return null;
        }
      


    }
}
