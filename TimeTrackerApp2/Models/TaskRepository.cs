using System;
using System.IO;
using System.Threading.Tasks;

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

        public static void AddTaskToListFromCSV(DateTime startTime, DateTime endTime, DateTime taskDate, string taskDetails)
        {
            _tasksList.Add(
                 new Task
                 {
                     StartTime = startTime,
                     EndTime = endTime,
                     TaskDate = taskDate,
                     TaskDetails = taskDetails

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
        //todo: delete task from csv file aswell after deleting from list
        //go thru file
        //if task in file is teh same as the newly added/editted task then delete that line


        public static void DeleteTaskFromCSV(Task task)
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

        public static void ClearTasks()
        {
            _tasksList.Clear();
        }

        public static void WriteToCsvFile(Models.Task newTask)
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "/Users/iman/Documents/Imans_Projects/TimeTrackerApp2/TimeTrackerApp2/Resources/Raw/tasks.csv");

            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLineAsync($"{newTask.StartTime};{newTask.EndTime};{newTask.TaskDate};{newTask.TaskDetails}");

            }

        }

        public static void ReadFromCSVFile()
        {
            try
            {
                ClearTasks();
                using (Stream filestream = FileSystem.Current.OpenAppPackageFileAsync("/Users/iman/Documents/Imans_Projects/TimeTrackerApp2/TimeTrackerApp2/Resources/Raw/tasks.csv").Result)
                {
                    using (StreamReader streamReader = new StreamReader(filestream))
                    {
                        string l;
                        while ((l = streamReader.ReadLine()) != null)
                        {
                            var result = l.Split(';');

                            var startTimeString = result[0];
                            var endTimeString = result[1];
                            var taskDateString = result[2];
                            var taskDetails = result[3];

                            DateTime startTime;
                            DateTime endTime;
                            DateTime taskDate;

                            if (DateTime.TryParse(startTimeString, out startTime) &&
                                DateTime.TryParse(endTimeString, out endTime) &&
                                DateTime.TryParse(taskDateString, out taskDate))
                            {
                                AddTaskToListFromCSV(startTime, endTime, taskDate, taskDetails);
                            }
                            else
                            {
                                Console.WriteLine("Error occurred while converting string task info to its type");
                            }
                        }
                        streamReader.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to read tasks from CSV file. Error: {ex.Message}");
            }
        }

    }

}

