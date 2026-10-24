using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity_library
{
    public class Activity
    {
       private string title = "";
       private string? description;
       private DateTime date;
        private long id;

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get => title; set => title = value; }

        [StringLength(500)]
        public string? Description { get => description; set => description = value; }

        [Required]
        public DateTime Date { get => date; set => date = value; }
        public List<TypeActivity> typeActivity { get; set; }
        public long Id { get => id; set => id = value; }

        public Activity(string title, string? description, DateTime date, long id)
        {
            Title = title;
            Description = description;
            Date = date;
            Id = id;
            typeActivity = new List<TypeActivity>();
        }
    }
}
