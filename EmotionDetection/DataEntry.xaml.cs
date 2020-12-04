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
    public partial class DataEntry : ContentPage
    {
        public DataEntry()
        {
            InitializeComponent();
        }

        private void Post_Clicked(object sender, EventArgs e)
        {
			if (Name.Text == null && Cat.ToString() == null && description.Text == null && url.Text == null)
			{
				DisplayAlert("Missing value", "You leave an empty row", "ok");
			}
			else
			{



				DetailMovie Ca = new DetailMovie 
				{

					Name = Name.Text,
					EmbeddedVedio = url.Text,
					Category = Cat.SelectedItem.ToString(),
					Date =System.DateTime.Now.ToString(),

					Description = description.Text
				};
				var HttpClient = new HttpClient();
				var json = JsonConvert.SerializeObject(Ca);
				HttpContent httpContent = new StringContent(json);
				httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
				HttpClient.PostAsync("https://emotiondetection.azurewebsites.net/api/DetailMovies1", httpContent);
				DisplayAlert("Data ADDED", "Your data has been sumitted", "Ok");

			}
		

	}

        private void Logout_Clicked(object sender, EventArgs e)
        {
			Navigation.PushAsync(new SignIn());
        }
    }
}