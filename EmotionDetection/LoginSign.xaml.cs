using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmotionDetection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginSign : ContentPage
    {
        public LoginSign()
        {
            InitializeComponent();
        }

        private void signin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignIn());
        }

        private void signup_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUp());
        }
    }
}