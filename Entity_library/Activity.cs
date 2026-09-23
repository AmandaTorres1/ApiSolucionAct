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
       

        public string Title { get => title; set => title = value; }
        public string? Description { get => description; set => description = value; }
        public DateTime Date { get => date; set => date = value; }
        public List<TypeActivity> typeActivity { get; set; }
        public Activity(string title, string? description, DateTime date)
        {
            Title = title;
            Description = description;
            Date = date;
            typeActivity = new List<TypeActivity>();
        }
    }
}
