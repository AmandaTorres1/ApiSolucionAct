using Entity_library;

namespace Dao_library
{
    public class CourseDao
    {
        public Course CreateCourse(Course course)
        {
            course.Id = MockDatabase.Courses.Count + 1;
            MockDatabase.Courses.Add(course);
            return course;
        }

        public Course? ReadCourseById(long id)
        {
            return MockDatabase.Courses.FirstOrDefault(c => c.Id == id);
        }

        public bool UpdateCourse(Course course)
        {
            var existingCourse = MockDatabase.Courses.FirstOrDefault(c => c.Id == course.Id);
            if (existingCourse != null)
            {
                existingCourse.Name = course.Name;
                existingCourse.ListaActividad = course.ListaActividad;
                existingCourse.ListaEstudiante = course.ListaEstudiante;
                return true;
            }
            return false;
        }

        public bool DeleteCourseById(long id)
        {
            var existingCourse = MockDatabase.Courses.FirstOrDefault(c => c.Id == id);
            if (existingCourse != null)
            {
                MockDatabase.Courses.Remove(existingCourse);
                return true;
            }
            return false;
        }

        public List<Course> GetAllCourses()
        {
            return MockDatabase.Courses;
        }
    }
}
