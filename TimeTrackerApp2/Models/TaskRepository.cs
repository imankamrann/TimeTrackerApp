using System;
namespace TimeTrackerApp2.Models
{
    public static class TaskRepository
    {
        private static List<Task> _tasksList;

        static TaskRepository()
        {
            _tasksList = new List<Task>();

        }



        public static void AddNewTask(Task task)
        {
            _tasksList.Add(
            new Task
            {
                StartTime = task.StartTime,
                EndTime = task.EndTime,
                TaskDate = task.TaskDate,
                Duration = task.Duration,
                TaskDetails = task.TaskDetails
            }
            );

        }
    }
}

