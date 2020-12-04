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
    public partial class CategoryMovie : ContentPage
    {
        public CategoryMovie(string a)
        {
            InitializeComponent();
            getmovie(a);
        }
        public async void getmovie(string d)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://emotiondetection.azurewebsites.net/api/DetailMovies1");
            var data = JsonConvert.DeserializeObject<List<DetailMovie>>(response);
            var cat = from c in data where c.Category==d select c; 
            LvMovies.ItemsSource = cat;

        }
    }
}