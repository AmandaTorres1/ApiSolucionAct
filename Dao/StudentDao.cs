using Dao;
using Entity_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_library
{
    public class StudentDAO
    {
        public Student GetStudent(Student student)
        {
            return MockDatabase.Students.FirstOrDefault(s => s.Id == student.Id);
        }

        public Student PostStudent (Student student)
        {
           if (student !=null)
            {
               student.Id=MockDatabase.Students.Count + 1;
                MockDatabase.Students.Add(student);
                return student;
           
            }
            return null; 
        }

        public Student PutStudent(Student student) //Eliminar
        {
            var existingStudent = MockDatabase.Students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Age = student.Age;
                existingStudent.File = student.File;
                existingStudent.ListaCurso = student.ListaCurso;
                existingStudent.Dni = student.Dni;
                return existingStudent;


            }
            return null;
        }
        public List<Student> GetStudent()
        {
            return MockDatabase.Students;
        }
        public bool Deletestudent(Student student)
        {
            var existingStudent = MockDatabase.Students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                MockDatabase.Students.Remove(existingStudent);
                return true;
            }
            return false;





        }
    } 
}