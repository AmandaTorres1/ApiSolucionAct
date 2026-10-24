using Entity_library;

namespace Dao_library
{
    public class TrainerDao
    {
        public Trainer CreateTrainer(Trainer trainer)
        {
            trainer.Id = MockDatabase.Trainers.Count + 1;
            MockDatabase.Trainers.Add(trainer);
            return trainer;
        }

        public Trainer? ReadTrainerById(long id)
        {
            return MockDatabase.Trainers.FirstOrDefault(t => t.Id == id);
        }

        public bool UpdateTrainer(Trainer trainer)
        {
            var existingTrainer = MockDatabase.Trainers.FirstOrDefault(t => t.Id == trainer.Id);
            if (existingTrainer != null)
            {
                existingTrainer.Name = trainer.Name;
                existingTrainer.Dni = trainer.Dni;
                existingTrainer.Age = trainer.Age;
                return true;
            }
            return false;
        }

        public bool DeleteTrainerById(long id)
        {
            var existingTrainer = MockDatabase.Trainers.FirstOrDefault(t => t.Id == id);
            if (existingTrainer != null)
            {
                MockDatabase.Trainers.Remove(existingTrainer);
                return true;
            }
            return false;
        }

        public List<Trainer> GetAllTrainers()
        {
            return MockDatabase.Trainers;
        }
    }
}
