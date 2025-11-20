using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoopingList.View;

public partial class MainPage : ContentPage
{
    private LoginPage LP = new LoginPage();
    public MainPage()
    {
        InitializeComponent();
        this.Loaded += OnLoaded;
        LP.Unloaded += LPOnUnloaded;
    }

    private void LPOnUnloaded(object sender, EventArgs e)
    {
        OnAppearing1();
    }

    private void OnLoaded(object sender, EventArgs e)
    {
        OnAppearing1();
    }

    public void OnAppearing1()
    {
        if (string.IsNullOrEmpty(App.SessionKey))
        {
            Navigation.PushModalAsync(new NavigationPage(LP));    
        }
    }

    private void Logout_OnClicked(object sender, EventArgs e)
    {
        App.SessionKey = "";
        OnAppearing1();
    }
}