using TimeTrackerApp2.Models;

namespace TimeTrackerApp2.Views;

public partial class ViewTasksPage : ContentPage
{
    public ViewTasksPage()
    {
        InitializeComponent();
        TasksListView.ItemsSource = TaskRepository.GetTasks();

    }

    void TasksListView_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
    }
}
