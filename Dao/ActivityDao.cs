using Dao_library;
using Entity_library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dao_library
{
    public  class ActivityDao
    {
        public Activity GetActivity(Activity activity)
        {
            return MockDatabase.Activities.FirstOrDefault(a => a.Id == activity.Id);
        }
        public Activity PostActivity(Activity activity)
        {
            if (activity != null)
            {
                activity.Id = MockDatabase.Activities.Count + 1;
                MockDatabase.Activities.Add(activity);
                return activity;
            }
            return null;
        }
        public Activity PutActivity(Activity activity)
        {
            var existingActivity = MockDatabase.Activities.Find(a => a.Id == activity.Id);
            if (existingActivity != null)
            {
               
                existingActivity.Title = activity.Title;
                existingActivity.Description = activity.Description;
                existingActivity.Date = activity.Date;
                existingActivity.typeActivity = activity.typeActivity;
                return existingActivity;
            }
            return null;
        }
        public List<Activity> GetActivities()
        {
            return MockDatabase.Activities;
        }
        public bool DeleteActivity(Activity activity)
        {
            var existingActivity = MockDatabase.Activities.Find(a => a.Id == activity.Id);
            if (existingActivity != null)
            {
                MockDatabase.Activities.Remove(existingActivity);
                return true;
            }
            return false;
        }
    }
}
