using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace testy
{
    public partial class TouchExample : ContentPage
    {
        public TouchExample()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BindingContext = new ViewModel(Navigation);
        }
    }
}
