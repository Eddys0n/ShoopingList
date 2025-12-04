using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShoopingList.Models;

namespace ShoopingList.View;

public partial class NewAccountPAge : ContentPage
{
    public NewAccountPAge()
    {
        InitializeComponent();
    }

    async void CreateAccount_OnClicked(object sender, EventArgs e)
    {
        //Do passwords match
        
        
        //Is valid email address
        
        
        //api stuff
        var data = JsonConvert.SerializeObject(new UserAccount(txtUser.Text, txtPassword1.Text, txtEmail.Text));

        var client = new HttpClient();
        var response = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/createuser"),
            new StringContent(data, Encoding.UTF8, "application/json"));
        
        var AccountStatus = response.Content.ReadAsStringAsync().Result;
        
        
        //does the user exist?
        if (AccountStatus=="user exists")
        {
            await DisplayAlert("Error", "Sorry this username has been taken", "OK");
            return;
        }
        
        //is the email in use?
        if (AccountStatus=="email exists")
        {
            await DisplayAlert("Error", "Sorry this email has been used", "OK");
            return;
        }
        
        if (AccountStatus=="complete")
        {
             response = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/login"),
                new StringContent(data, Encoding.UTF8, "application/json"));
        
            var SKey = response.Content.ReadAsStringAsync().Result;

            if (!string.IsNullOrEmpty(SKey) && SKey.Length < 50 )
            {
                App.SessionKey = SKey;
                 Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Error", "Sorry there was an issue login you in", "OK");
                return;
            }
           
        }
        else
        {
            await DisplayAlert("Error", "Sorry there was an error creating your account", "OK");
            return;
        }
        
        
    }
}