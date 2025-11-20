using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoopingList.View;

public partial class NewAccountPAge : ContentPage
{
    public NewAccountPAge()
    {
        InitializeComponent();
    }

    private void CreateAccount_OnClicked(object sender, EventArgs e)
    {
        App.SessionKey = "ASDF";
        Navigation.PopModalAsync();
    }
}