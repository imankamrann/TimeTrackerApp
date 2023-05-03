
using TimeTrackerApp2.Models;
using TimeTrackerApp2.Views;

namespace TimeTrackerApp2;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    void AddTaskBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new AddNewTaskPage());
    }

    void ViewTasksBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new ViewTasksPage());
    }
}


