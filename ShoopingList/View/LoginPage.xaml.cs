using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoopingList.View;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void Login_OnClicked(object sender, EventArgs e)
    {
        App.SessionKey = "HolaMundo";
        Navigation.PopModalAsync();
    }

    private void NewAccount_OnClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewAccountPAge());
    }
}