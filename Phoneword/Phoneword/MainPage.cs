using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Phoneword
{
    public class MainPage : ContentPage
    {
        Entry phoneNumberText;
        Button translateButton;
        Button callButton;

        string translatedNumber;

        public MainPage()
        {
            this.Padding = new Thickness(20, 20, 20, 20);

            var panel = new StackLayout
            {
                Spacing = 15,
            };

            panel.Children.Add(new Label
            {
                Text = "Enter Phoneworld:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            });

            panel.Children.Add(phoneNumberText = new Entry
            {
                Text = "1-855-XAMARIN",
            });

            panel.Children.Add(translateButton = new Button
            {
                Text = "Translate",
            });

            panel.Children.Add(callButton = new Button
            {
                Text = "Call",
                IsEnabled = false,
            });

            translateButton.Clicked += OnTranslate;
            callButton.Clicked += OnCall;
            this.Content = panel;
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
