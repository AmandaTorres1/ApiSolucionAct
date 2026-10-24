using Entity_library;

namespace Dao_library
{
    public class ActivityDao
    {
        public Activity CreateActivity(Activity activity)
        {
            activity.Id = MockDatabase.Activities.Count + 1;
            MockDatabase.Activities.Add(activity);
            return activity;
        }

        public Activity? ReadActivityById(long id)
        {
            return MockDatabase.Activities.FirstOrDefault(a => a.Id == id);
        }

        public bool UpdateActivity(Activity activity)
        {
            var existingActivity = MockDatabase.Activities.FirstOrDefault(a => a.Id == activity.Id);
            if (existingActivity != null)
            {
                existingActivity.Title = activity.Title;
                existingActivity.Description = activity.Description;
                existingActivity.Date = activity.Date;
                existingActivity.typeActivity = activity.typeActivity;
                return true;
            }
            return false;
        }

        public bool DeleteActivityById(long id)
        {
            var existingActivity = MockDatabase.Activities.FirstOrDefault(a => a.Id == id);
            if (existingActivity != null)
            {
                MockDatabase.Activities.Remove(existingActivity);
                return true;
            }
            return false;
        }

        public List<Activity> GetAllActivities()
        {
            return MockDatabase.Activities;
        }
    }
}
