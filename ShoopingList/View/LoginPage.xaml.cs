using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShoopingList.Models;

namespace ShoopingList.View;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    async void Login_OnClicked(object sender, EventArgs e)
    {
        //User Info
        //
        
        var data = JsonConvert.SerializeObject(new UserAccount(txtUser.Text, txtPass.Text));

        var client = new HttpClient();
        var  response = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/login"),
            new StringContent(data, Encoding.UTF8, "application/json"));
        
        var SKey = response.Content.ReadAsStringAsync().Result;

        if (!string.IsNullOrEmpty(SKey) && SKey.Length < 50 )
        {
            App.SessionKey = SKey;
            Navigation.PopModalAsync();
        }
        else
        {
            await DisplayAlert("Error", "Sorry Invalid Username or Password", "OK");
            return;
        }
    }

    private void NewAccount_OnClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewAccountPAge());
    }
}