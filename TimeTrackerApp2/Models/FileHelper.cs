using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.Collections.Generic;
using System;

namespace TimeTrackerApp2.Models
{
    public static class FileHelper
    {
        public static Task CreateCourse(string line)
        {
            return new Task
            {
                //StartTime = line.Split()[0],
                //EndTime = line.Split()[1],
                //TaskDate = line.Split()[2],
                //TaskDetails = line.Split()[3]

            };

        }

        //static List<Task> tasksList = TaskRepository.GetTasks();

        //public static void writeCsvFile(List<Task> tasksList, string filePath)
        //{
        //    using (var writer = new StreamWriter(filePath))
        //    {
        //        // Write header
        //        writer.WriteLine("StartTime,EndTime,TaskDate,TaskDetails");

        //        // Write data rows
        //        foreach (var task in tasksList)
        //        {
        //            writer.WriteLine($"{task.StartTime},{task.EndTime},{task.TaskDate}, {task.TaskDetails}");
        //        }
        //    }

        //}


        //public static List<Task> readFromCSV(string filePath)
        //{
        //    var newTasksList = new List<Task>();

        //    using (var reader = new StreamReader(filePath))
        //    {
        //        // Skip header
        //        reader.ReadLine();

        //        while (!reader.EndOfStream)
        //        {
        //            var line = reader.ReadLine();
        //            var values = line.Split(',');

        //            var task = new Task
        //            {
        //                StartTime = values[0],
        //                EndTime = int.Parse(values[1]),
        //                TaskDate = values[2],
        //                TaskDetails = values[2]

        //            };

        //            newTasksList.Add(task);
        //        }
        //    }

        //    return tasksList;
        //}
    }

    //public static void writeCsvFile(string filePath)
    //{
    //    try
    //    {
    //        if (!File.Exists(filePath))
    //        {
    //            using (File.Create(filePath))
    //            {

    //            }

    //            TaskRepository.GetTasks();

    //            var configTasks = new CsvConfiguration(CultureInfo.InvariantCulture)
    //            {
    //                HasHeaderRecord = true
    //            };

    //            using (StreamWriter streamWriter = new StreamWriter(filePath))
    //            using (CsvWriter csvWriter = new CsvWriter(streamWriter, configTasks))
    //            {
    //                csvWriter.WriteRecords(task);
    //            };


    //        }


    //    }
    //    catch (Exception ex)
    //    {

    //    }
    ////}

}


