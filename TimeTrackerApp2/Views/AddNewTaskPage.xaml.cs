﻿using TimeTrackerApp2.Models;
namespace TimeTrackerApp2.Views;

public partial class AddNewTaskPage : ContentPage
{
    public AddNewTaskPage()
    {
        InitializeComponent();
        TaskDatePicker.Date = DateTime.Now;


    }

    async void SaveTaskBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        try
        {
            var newTask = new Models.Task();

            var startTime = StartTimePicker.Time;
            var endTime = EndTimePicker.Time;
            var taskDate = TaskDatePicker.Date;
            var taskDetails = TaskDescriptionEntry.Text;

            newTask.StartTime = new DateTimeOffset(taskDate.Year, taskDate.Month, taskDate.Day, startTime.Hours, startTime.Minutes, startTime.Seconds, TimeSpan.Zero).DateTime;
            newTask.EndTime = new DateTimeOffset(taskDate.Year, taskDate.Month, taskDate.Day, endTime.Hours, endTime.Minutes, endTime.Seconds, TimeSpan.Zero).DateTime;
            newTask.TaskDate = taskDate;
            newTask.TaskDetails = taskDetails;

            if (taskDetails != null)
            {
                var doesTaskExist = TaskRepository.CheckNewTask(newTask);
                //await DisplayAlert("new task added:", $"{newTask.StartTime.ToString("h:mm tt")}, {newTask.EndTime.ToString("h:mm tt")}, {newTask.TaskDate.ToString("MMMM d yyyy")} , {newTask.TaskDetails}", "ok");
                if (doesTaskExist)
                {
                    TaskRepository.AddNewTask(newTask);
                    await DisplayAlert("Task Added!", "", "ok");
                    await Navigation.PushAsync(new ViewTasksPage());

                }
                else
                {
                    await DisplayAlert("Task Exists!", "Enter Unique Task", "ok");
                }
            }
            else
            {
                await DisplayAlert("Unentered Info!", "Enter Task Details", "ok");
            }


        }
        catch (Exception ex)
        {
            await DisplayAlert("Error Occurred", "Please Reopen App", "ok");
        }

    }



}

