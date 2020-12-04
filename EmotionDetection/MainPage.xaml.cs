using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmotionDetection
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var sad = "Sadness".ToString();
            Navigation.PushAsync(new CategoryMovie(sad));

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var disgust = "Disgust".ToString();
            Navigation.PushAsync(new CategoryMovie(disgust));
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            var happy = "Happiness".ToString();
            Navigation.PushAsync(new CategoryMovie(happy));
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            var neutral = "Neutral".ToString();
            Navigation.PushAsync(new CategoryMovie(neutral));
        }
    }
}
