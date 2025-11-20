using ShoopingList.View;

namespace ShoopingList;

public partial class App : Application
{
    public static string SessionKey = "";
    
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage());
    }
}