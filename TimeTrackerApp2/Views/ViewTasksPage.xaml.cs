using TimeTrackerApp2.Models;

namespace TimeTrackerApp2.Views;

public partial class ViewTasksPage : ContentPage
{
    public ViewTasksPage()
    {
        InitializeComponent();
        ReadTasksFromCsvFile();
        //TasksListView.ItemsSource = TaskRepository.GetTasks();

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        TasksListView.ItemsSource = TaskRepository.GetTasks();
    }


    void TasksListView_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        var selectedTask = (Models.Task)TasksListView.SelectedItem;
        Navigation.PushAsync(new TaskDetailsAndUpdatePage(selectedTask));
    }

    async void addNewTaskBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new AddNewTaskPage());
    }

    async void goToHomeBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void ReadTasksFromCsvFile()
    {
        try
        {
            TaskRepository.ClearTasks();
            Stream filestream = await FileSystem.Current.OpenAppPackageFileAsync("/Users/iman/Documents/Imans_Projects/TimeTrackerApp2/TimeTrackerApp2/Resources/Raw/tasks.csv");
            StreamReader streamReader = new StreamReader(filestream);
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
                    TaskRepository.AddTaskToListFromCSV(startTime, endTime, taskDate, taskDetails);
                }
                else
                {
                    await DisplayAlert("Error", "Error occurred while converting string task info to its type", "OK");
                }
            }
            streamReader.Close();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to read tasks from CSV file. Error: {ex.Message}", "OK");
        }
    }

}
