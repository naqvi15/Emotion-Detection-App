using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmotionDetection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private async void createaccound_Clicked(object sender, EventArgs e)
        {
            ca.IsEnabled = true;
            ca.IsRunning = true;
            if (em.Text == null || Pass.Text == null || Cn.Text == null)
            {
                ca.IsEnabled = false;
                ca.IsRunning = false;
                await DisplayAlert("Required", "All fields required", "ok"); }
            else
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync("https://emotiondetection.azurewebsites.net/api/Users1");
                var users = JsonConvert.DeserializeObject<List<User>>(response);
                var person = from c in users where c.Email == em.Text && c.UserName == Cn.Text select c;
                if (person.Any())
                {
                    ca.IsEnabled = false;
                    ca.IsRunning = false;
                    await DisplayAlert("Warning", "User Already Exist", "ok"); }
                else
                {
                    User userss = new User
                    {
                        Role = 0,
                        Email = em.Text,
                        Password = Pass.Text,
                        UserName = Cn.Text
                        

                    };
                    httpClient = new HttpClient();
                    var Json = JsonConvert.SerializeObject(userss);
                    HttpContent httpContent = new StringContent(Json);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    await httpClient.PostAsync("https://emotiondetection.azurewebsites.net/api/Users1", httpContent);
                    ca.IsEnabled = false;
                    ca.IsRunning = false;
                    await DisplayAlert("Added", "Your data has been added", "Ok");
                    await Navigation.PushAsync(new SignIn());

                }
            }
        }
    }
}