﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RHSkills.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RescueMdpPage : ContentPage
    {
        public RescueMdpPage()
        {
            InitializeComponent();
        }

        private void FermerFenetre_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}