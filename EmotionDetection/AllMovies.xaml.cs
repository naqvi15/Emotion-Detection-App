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
    public partial class AllMovies : ContentPage
    {
        public AllMovies()
        {
            InitializeComponent();
            getmovie();
        }
        public async void getmovie()
        {
	        var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync("https://emotiondetection.azurewebsites.net/api/DetailMovies1");
        var data = JsonConvert.DeserializeObject<List<DetailMovie>>(response);

        LvMovies.ItemsSource = data;

	    }
}
}