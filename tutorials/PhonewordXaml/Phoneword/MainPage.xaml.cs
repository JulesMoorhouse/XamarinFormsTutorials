using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        string translatedNumber;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnTranslate(object sender, EventArgs e)
        {
            var enteredNumber = phoneNumberText.Text;
            translatedNumber = PhoneTranslator.ToNumber(enteredNumber);

            if (!string.IsNullOrEmpty(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = string.Format("Call {0}", translatedNumber);
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }

        private async void OnCall(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                "Dial a Number",
                string.Format("Would you like to call {0}?", translatedNumber),
                "Yes",
                "No"))
            {
                var unableToDial = "Unable to dial";

                try
                {
                    PhoneDialer.Open(translatedNumber);
                }
                catch (ArgumentNullException)
                {
                    await DisplayAlert(unableToDial, "Phone number as not valid.", "OK");
                }
                catch (FeatureNotSupportedException)
                {
                    await DisplayAlert(unableToDial, "Phone dialog not supported.", "OK");
                }
                catch (Exception)
                {
                    // Other error occured.
                    await DisplayAlert(unableToDial, "Phone dialing failed.", "OK");
                }
            }
        }
    }
}
