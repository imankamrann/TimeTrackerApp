using System.Threading.Tasks;
using TimeTrackerApp2.Models;
namespace TimeTrackerApp2.Views;

public partial class EditTasksPage : ContentPage
{
    private Models.Task _edittedTask;
    private Models.Task _oldTask;

    public EditTasksPage(Models.Task task)
    {
        InitializeComponent();
        _edittedTask = task;
        _oldTask = task;
        TaskDatePicker.Date = task.TaskDate;
        //StartTimePicker.Time = _task.StartTime; 
        //EndTimePicker.Time = _task.EndTime;
        TaskDescriptionEntry.Text = task.TaskDetails;




    }

    async void SaveUpdatedTaskBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        try
        {
            _edittedTask = new Models.Task();

            var startTime = StartTimePicker.Time;
            var endTime = EndTimePicker.Time;
            var taskDate = TaskDatePicker.Date;
            var taskDetails = TaskDescriptionEntry.Text;

            _edittedTask.StartTime = new DateTimeOffset(taskDate.Year, taskDate.Month, taskDate.Day, startTime.Hours, startTime.Minutes, startTime.Seconds, TimeSpan.Zero).DateTime;
            _edittedTask.EndTime = new DateTimeOffset(taskDate.Year, taskDate.Month, taskDate.Day, endTime.Hours, endTime.Minutes, endTime.Seconds, TimeSpan.Zero).DateTime;
            _edittedTask.TaskDate = taskDate;
            _edittedTask.TaskDetails = taskDetails;

            if (taskDetails != null)
            {
                TaskRepository.DeleteTask(_oldTask);
                var doesTaskExist = TaskRepository.CheckNewTask(_edittedTask);

                //await DisplayAlert("new task added:", $"{newTask.StartTime.ToString("h:mm tt")}, {newTask.EndTime.ToString("h:mm tt")}, {newTask.TaskDate.ToString("MMMM d yyyy")} , {newTask.TaskDetails}", "ok");
                if (doesTaskExist)
                {
                    TaskRepository.AddNewTask(_edittedTask);
                    WriteToCsvFileWithAlerts(_edittedTask);
                    await DisplayAlert("Task Updated!", "", "ok");
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

    private async void WriteToCsvFileWithAlerts(Models.Task edittedTask)
    {
        try
        {
            TaskRepository.WriteToCsvFile(edittedTask);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to write task to CSV file. Error: {ex.Message}", "OK");

        }
    }
}
