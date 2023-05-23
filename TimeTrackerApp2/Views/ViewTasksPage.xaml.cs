using TimeTrackerApp2.Models;

namespace TimeTrackerApp2.Views;

public partial class ViewTasksPage : ContentPage
{
    public ViewTasksPage()
    {
        InitializeComponent();
        TasksListView.ItemsSource = TaskRepository.GetTasks();
        //OnAppearing();


    }
    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();


    //}


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
}
