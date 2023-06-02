using TimeTrackerApp2.Models;
namespace TimeTrackerApp2.Views;

public partial class TaskDetailsAndUpdatePage : ContentPage
{
    private Models.Task _task;
    public TaskDetailsAndUpdatePage(Models.Task task)
    {
        InitializeComponent();

        _task = task;
        TaskDateLbl.Text = task.TaskDate.ToString("MMMM d yyyy");
        StartTimeLbl.Text = task.StartTime.ToString("h:mm tt");
        EndTimeLbl.Text = task.EndTime.ToString("h:mm tt");
        TaskDetailsLbl.Text = task.TaskDetails;
    }

    void editTaskBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new EditTasksPage(_task));
    }



    async void deleteTaskBtn2_Clicked(System.Object sender, System.EventArgs e)
    {
        try
        {
            TaskRepository.DeleteTask(_task);
            deleteTaskFromCSV(_task);
            var doesTaskExist = TaskRepository.CheckNewTask(_task);

            if (doesTaskExist)
            {
                await DisplayAlert("Task Deleted!", "", "ok");
                await Navigation.PushAsync(new ViewTasksPage());
            }

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error Occurred", "Please Reopen App", "ok");
        }
    }


    void deleteTaskFromCSV(Models.Task _task)
    {

    }

}
