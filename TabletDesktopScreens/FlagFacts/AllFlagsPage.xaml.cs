using System;
using System.ComponentModel;
using FlagData;
using Xamarin.Forms;
using Xamarin.Forms.DualScreen;

namespace FlagFacts
{
    public partial class AllFlagsPage : ContentPage
    {
        bool DeviceIsSpanned => DualScreenInfo.Current.SpanMode != TwoPaneViewMode.SinglePane;

        bool DeviceIsBigScreen => (Device.Idiom == TargetIdiom.Tablet) || (Device.Idiom == TargetIdiom.Desktop);

        // Is not spanned when first viewed...
        bool wasSpanned = false;

        public AllFlagsPage()
        {
            BindingContext = DependencyService.Get<FlagDetailsViewModel>();
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            DualScreenInfo.Current.PropertyChanged += DualScreen_PropertyChanged;
        }

        protected override void OnDisappearing()
        {
            DualScreenInfo.Current.PropertyChanged -= DualScreen_PropertyChanged;
            base.OnDisappearing();
        }

        private void DualScreen_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateLayouts();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!DeviceIsSpanned && !DeviceIsBigScreen)
            {
                // Use Navigation only on phone-size single-screens
                await this.Navigation.PushAsync(new FlagDetailsPage());
            }
        }

        async void UpdateLayouts()
        {
            if (DeviceIsSpanned || DeviceIsBigScreen)
            {
                // Two screens: side by side
                twoPaneView.TallModeConfiguration = TwoPaneViewTallModeConfiguration.TopBottom;
                twoPaneView.WideModeConfiguration = TwoPaneViewWideModeConfiguration.LeftRight;
                wasSpanned = true;
            }
            else
            {
                // Single-screen: only list is shown
                twoPaneView.PanePriority = TwoPaneViewPriority.Pane1;
                twoPaneView.TallModeConfiguration = TwoPaneViewTallModeConfiguration.SinglePane;
                twoPaneView.WideModeConfiguration = TwoPaneViewWideModeConfiguration.SinglePane;

                // wasSpanned check is needed, or will open on first-run or rotation
                // stack count is needed, or we might push multiple on rotation
                if (wasSpanned && Navigation.NavigationStack.Count == 1)
                {
                    // Open the detail page
                    await Navigation.PushAsync(new FlagDetailsPage());
                }
                wasSpanned = false;
            }
        }
    }
}