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

        public static bool CheckNewTask(Task task)
        {
            foreach (var t in _tasksList)
            {
                if (t.StartTime == task.StartTime && t.EndTime == task.EndTime && t.TaskDate == task.TaskDate && t.TaskDetails == task.TaskDetails)
                {
                    return false; // Task already exists/not unique
                }
            }
            return true; // Task is unique
        }

        public static List<Task> GetTasks()
        {
            return _tasksList;
        }

        public static void DeleteTask(Task task)
        {
            for (int t = 0; t < _tasksList.Count; t++)
            {
                if (_tasksList[t].StartTime == task.StartTime && _tasksList[t].EndTime == task.EndTime && _tasksList[t].TaskDate == task.TaskDate && _tasksList[t].TaskDetails == task.TaskDetails)
                {
                    _tasksList.RemoveAt(t);
                    break;
                }
            }
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

