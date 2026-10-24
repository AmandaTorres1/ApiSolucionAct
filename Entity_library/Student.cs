using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity_library
{
    public class Student:Person
    {
        private string file = "";

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string File { get => file; set => file = value; }
        public List<Course> ListaCurso { get; set; }

        //Contructor
        public Student(long id, string name, string? dni, int age, string file) : base(id, name, dni, age)
        {
            File = file;
            ListaCurso = new List<Course>();
        }

    }
}
