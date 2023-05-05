using TimeTrackerApp2.Models;
namespace TimeTrackerApp2.Views;

public partial class AddNewTaskPage : ContentPage
{
    public AddNewTaskPage()
    {
        InitializeComponent();
        TaskDatePicker.Date = DateTime.Now;

    }

    void SaveTaskBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        var newTask = new Models.Task();

        var startTime = StartTimePicker.Time;
        var endTime = EndTimePicker.Time;
        var taskDate = TaskDatePicker.Date;
        var taskDetails = TaskDescriptionEntry.Text;

        newTask.StartTime = startTime;
        newTask.EndTime = endTime;
        newTask.TaskDate = taskDate;
        newTask.TaskDetails = taskDetails;


        TaskRepository.AddNewTask(newTask);

        //TimeSpan taskStartTime = StartTimePicker.Time ?? TimeSpan.Zero;
        //DisplayAlert("update", "Selected Time: " + taskStartTime.ToString(), "ok");
    }

    //void StartTimePicker_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
    //{
    //}

    //void EndTimePicker_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
    //{
    //}

    //void TaskDatePicker_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
    //{
    //}
}

