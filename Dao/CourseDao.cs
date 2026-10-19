using Dao_library;
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
      public Course PutCourse(Course course)
        {
            var existingCourse = MockDatabase.Courses.Find(c => c.Id == course.Id);
            if (existingCourse != null)
            {
                existingCourse.Name = course.Name;
                existingCourse.ListaActividad = course.ListaActividad;
                existingCourse.ListaEstudiante = course.ListaEstudiante;
                return existingCourse;
            }
            return null;
        }
        public List<Course> GetCourses()
        {
            return MockDatabase.Courses;
        }
        public bool DeleteCourse(Course course)
        {
            var existingCourse = MockDatabase.Courses.Find(c => c.Id == course.Id);
            if (existingCourse != null)
            {
                MockDatabase.Courses.Remove(existingCourse);
                return true;
            }
            return false;
        }

    }
}
