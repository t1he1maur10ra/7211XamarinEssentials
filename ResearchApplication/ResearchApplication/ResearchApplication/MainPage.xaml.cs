using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace ResearchApplication
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        static double lat,lng,alt;

        public MainPage()
        {
            InitializeComponent();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //var message = new EmailMessage(EmailSubject.Text, EmailMsg.Text, EmailAddress.Text);
             
            //await Email.ComposeAsync(message);

            await Email.ComposeAsync(EmailSubject.Text, EmailMsg.Text, EmailAddress.Text);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    lat = location.Latitude;
                    lng = location.Longitude;
                    alt = (double)location.Altitude;

                    GeoLat.Text = $"Latitude: {lat}";
                    GeoLong.Text = $"Longitude: {lng}";
                    GeoAlt.Text = $"Altitude: {alt}";
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}
