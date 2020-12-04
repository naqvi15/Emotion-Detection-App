using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using Plugin.Media;
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
    public partial class EmotionDetection : ContentPage
    {
        public EmotionDetection()
        {
            InitializeComponent();
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
			await CrossMedia.Current.Initialize();
			await Task.Delay(2000);
			// var file = await CrossMedia.Current.PickPhotoAsync();
			var file = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { SaveToAlbum = false });
			ca.IsEnabled = true;
			ca.IsRunning = true;
			if (file != null)
			{
				var faceServiceClient = new FaceServiceClient("335020ac2a784a208590ce7ed98ae263", "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/");
				var faceAttributes = new FaceAttributeType[] { FaceAttributeType.Emotion };
				PhotoImage.Source = ImageSource.FromStream(() => file.GetStream());
				Face[] faces = await faceServiceClient.DetectAsync(file.GetStream(), true, false, faceAttributes);

				if (faces.Any())
				{
					// Emotions detected are happiness, sadness, surprise, anger, fear, contempt, disgust, or neutral.
				var j= faces.FirstOrDefault().FaceAttributes.Emotion.ToRankedList().FirstOrDefault().Key;
					ca.IsEnabled = false;
					ca.IsRunning = false;
					LblResult.Text = "You emotion describes	"+""+j.ToString()+""+"	now....!";
					file.Dispose();
				await Task.Delay(2000);
					await Navigation.PushAsync(new CategoryMovie(j.ToString()));

				}
			}
		}
	}
    }
