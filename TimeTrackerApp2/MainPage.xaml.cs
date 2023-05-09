
using TimeTrackerApp2.Models;
using TimeTrackerApp2.Views;

namespace TimeTrackerApp2;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    async void AddTaskBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new AddNewTaskPage());
    }

    async void ViewTasksBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new ViewTasksPage());
    }
}


