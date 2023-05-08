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
                //Duration = task.Duration,
                TaskDetails = task.TaskDetails
            }
            );
        }

        public static List<Task> GetTasks()
        {
            return _tasksList;
        }

        //public static string formattedStartTime()
        //{
        //    foreach (var task in _tasksList)
        //    {
        //        return $"{task.StartTime.ToString("h:mm tt")}";
        //    }
        //    return "test 1";

        //}

        //public static string formattedEndTime()
        //{
        //    foreach (var task in _tasksList)
        //    {
        //        return $"{task.EndTime.ToString("h:mm tt")}";
        //    }
        //    return "test 2";
        //}

        //public static string formattedDate()
        //{
        //    foreach (var task in _tasksList)
        //    {
        //        return $"{task.TaskDate.ToString("MMMM d yyyy")}";
        //    }
        //    return "test 3";
        //}



        //public string formatStartTime()
        //{
        //    return $"{StartTime.ToString("h:mm tt")}";
        //}

        //public string formatEndTime()
        //{
        //    return $"{EndTime.ToString("h:mm tt")}";
        //}

        //public string formatDate()
        //{
        //    return $"{TaskDate.ToString("MMMM d yyyy")}";
        //}
    }
}

