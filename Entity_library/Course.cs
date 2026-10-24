using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity_library
{
    public class Course
    {
        private string name = "";
        private long id;

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get => name; set => name = value; }
        public long Id { get => id; set => id = value; }
        public List<Student> ListaEstudiante { get; set; }
        public List<Activity> ListaActividad { get; set; }

        public Course(string name, long id)
        {
            Name = name;
            Id = id;
            ListaEstudiante = new List<Student>();
            ListaActividad = new List<Activity>();
        }   
    }
}
