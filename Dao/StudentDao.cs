using Entity_library;

namespace Dao_library
{
    public class StudentDAO
    {
        public Student CreateStudent(Student student)
        {
            student.Id = MockDatabase.Students.Count + 1;
            MockDatabase.Students.Add(student);
            return student;
        }

        public Student? ReadStudentById(long id)
        {
            return MockDatabase.Students.FirstOrDefault(s => s.Id == id);
        }

        public bool UpdateStudent(Student student)
        {
            var existingStudent = MockDatabase.Students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Age = student.Age;
                existingStudent.Dni = student.Dni;
                existingStudent.File = student.File;
                existingStudent.ListaCurso = student.ListaCurso;
                return true;
            }
            return false;
        }

        public bool DeleteStudentById(long id)
        {
            var existingStudent = MockDatabase.Students.FirstOrDefault(s => s.Id == id);
            if (existingStudent != null)
            {
                MockDatabase.Students.Remove(existingStudent);
                return true;
            }
            return false;
        }

        public List<Student> GetAllStudents()
        {
            return MockDatabase.Students;
        }
    }
}