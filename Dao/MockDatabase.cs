using Entity_library;
namespace Dao
{
    public static class MockDatabase
    {
        public static List<Course> Courses { get; set; } = new();
        public static List<Student> Students { get; set; } = new();
        public static List<Team> Teams { get; set; }
        public static List<Player> Players { get; set; }
        public static List<Activity> Activities { get; set; }
        public static List<Person> Persons { get; set; }
        public static List<Trainer> Trainers { get; set; }

        static MockDatabase()
        {
            var Person1=new Person(1, "Juana", "31456345", 20);
            Persons.Add(Person1);
            var person2 = new Person(2, "Pedro", "31456345", 25);
            Persons.Add(person2);
            var course1 = new Course("Mathematics");
            Courses.Add(course1);
            var course2 = new Course("English");
            Courses.Add(course2);
            var student1 = new Student(1, "Ulises", "4356560", 26, "15");
            Students.Add(student1);
            var student2 = new Student(2, "Maria", "4356560", 22, "16");
            Students.Add(student2);
            var team1 = new Team("Team A", "Category 1");
            Teams.Add(team1);
            var team2 = new Team("Team B", "Category 2");
            var player1 = new Player(1, "Carlos", "12345678", 30, 10);
            Players.Add(player1);
            var player2 = new Player(2, "Ana", "87654321", 28, 7);
            Players.Add(player2);
            var activity1 = new Activity("Parcial", "Evaluacion practica", DateTime.Now);
            Activities.Add(activity1);
            var trainer1 = new Trainer(1, "Amanda", "43926349", 24);
            Trainers.Add(trainer1);
            var trainer2 = new Trainer(2, "Jorge", "43926588", 29);
            Trainers.Add(trainer2);
         

        }

    }
}
