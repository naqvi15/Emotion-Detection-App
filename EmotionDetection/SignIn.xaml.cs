using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmotionDetection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignIn : ContentPage
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private async void SignIng_Clicked(object sender, EventArgs e)
        {
            ac.IsEnabled = true;
            ac.IsRunning = true;
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://emotiondetection.azurewebsites.net/api/Users1");
            var users = JsonConvert.DeserializeObject<List<User>>(response);
            var users1 = from c in users where c.UserName == un.Text && c.Password == Pass.Text && c.Role== 0 select c;
            var admin = from c in users where c.UserName == un.Text && c.Password == Pass.Text && c.Role== 1 select c;
          
            if (users1.Any())
            {
                ac.IsEnabled = false;
                ac.IsRunning = false;
                await Navigation.PushAsync(new Tab());}
            else if (admin.Any())
            {
                ac.IsEnabled = false;
                ac.IsRunning = false;
                await Navigation.PushAsync(new DataEntry()); }
            else
            {
                ac.IsEnabled = false;
                ac.IsRunning = false;
                await DisplayAlert("Not ", "User Details not Exist", "Cancel"); }

        }
    }
}