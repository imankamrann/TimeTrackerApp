using TimeTrackerApp2.Models;

namespace TimeTrackerApp2.Views;

public partial class ViewTasksPage : ContentPage
{
    public ViewTasksPage()
    {
        InitializeComponent();
        OnAppearing();


    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        TasksListView.ItemsSource = TaskRepository.GetTasks();

    }


    void TasksListView_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
    }

    async void AddTaskBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new AddNewTaskPage());
    }

}
