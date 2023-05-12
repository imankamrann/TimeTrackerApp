using System.Threading.Tasks;
using TimeTrackerApp2.Models;
namespace TimeTrackerApp2.Views;

public partial class EditTasksPage : ContentPage
{
    private Models.Task _edittedTask;
    public EditTasksPage(Models.Task _task)
    {
        InitializeComponent();
        _edittedTask = _task;
        TaskDatePicker.Date = _task.TaskDate;
        //StartTimePicker.Time = _task.StartTime; 
        //EndTimePicker.Time = _task.EndTime;
        TaskDescriptionEntry.Text = _task.TaskDetails;




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
                TaskRepository.DeleteTask(_edittedTask);
                var doesTaskExist = TaskRepository.CheckNewTask(_edittedTask);
                //await DisplayAlert("new task added:", $"{newTask.StartTime.ToString("h:mm tt")}, {newTask.EndTime.ToString("h:mm tt")}, {newTask.TaskDate.ToString("MMMM d yyyy")} , {newTask.TaskDetails}", "ok");
                if (doesTaskExist)
                {

                    TaskRepository.AddNewTask(_edittedTask);
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
