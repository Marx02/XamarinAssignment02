using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace XamarinAssignment02
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ttsbutton.Clicked += TtsButton_Clicked;

            mapbutton.Clicked += Mapbutton_Clicked;

            vibrateButton.Clicked += VibrateButton_Clicked;

            flButton.Clicked += FlButton_Clicked;

        }

        private async void FlButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Turn On
                await Flashlight.TurnOnAsync();

                // Turn Off
                await Flashlight.TurnOffAsync();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                await DisplayAlert("Alert!", "Not supported on this device", "OK");
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to turn on/off flashlight
                await DisplayAlert("Alert!", "Was unable to do so", "OK");
            }
        }

        private void VibrateButton_Clicked(object sender, EventArgs e)
        {
            
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }

        private async void Mapbutton_Clicked(object sender, EventArgs e)
        {
            
                var location = await Geolocation.GetLastKnownLocationAsync();

            if (location != null)
            {
                await Map.OpenAsync(location);
            }
            else await DisplayAlert("Error!", "Couldn't get your current location", "OK");
            }
      

        private async void TtsButton_Clicked(object sender, EventArgs e)
        {
            String ttstext = Ttsentry.Text;
            if(ttstext == null)
            {
              await DisplayAlert("You have to insert some text, for using Text-to-speech", "", "OK");
            }
            else await TextToSpeech.SpeakAsync(ttstext);
        }

      
    }
}
