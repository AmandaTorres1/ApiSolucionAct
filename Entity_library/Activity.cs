using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_library
{
    public class Activity
    {
       private string title;
       private string? description;
       private DateTime date;
        private long id;


        public string Title { get => title; set => title = value; }
        public string? Description { get => description; set => description = value; }
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
