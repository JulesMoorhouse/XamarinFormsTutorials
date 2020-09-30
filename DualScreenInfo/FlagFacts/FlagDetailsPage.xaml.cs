using FlagData;
using Xamarin.Forms;
using System;
using Xamarin.Essentials;
using Xamarin.Forms.DualScreen;
using System.ComponentModel;

namespace FlagFacts
{
    public partial class FlagDetailsPage : ContentPage
    {
        bool DeviceIsSpanned => DualScreenInfo.Current.SpanMode != TwoPaneViewMode.SinglePane;

        private readonly FlagDetailsViewModel vm;

        public FlagDetailsPage()
        {
            vm = DependencyService.Get<FlagDetailsViewModel>();

            InitializeComponent();
            BindingContext = vm;
        }

        private async void OnShow(object sender, EventArgs e)
        {
            vm.CurrentFlag.DateAdopted = vm.CurrentFlag.DateAdopted.AddYears(1);
            await DisplayAlert(vm.CurrentFlag.Country,
                $"{vm.CurrentFlag.DateAdopted:D} - {vm.CurrentFlag.IncludesShield}: {vm.CurrentFlag.MoreInformationUrl}",
                "OK");
        }

        private void OnPrevious(object sender, EventArgs e)
        {
            vm.MoveToPreviousFlag();
        }

        private void OnNext(object sender, EventArgs e)
        {
            vm.MoveToNextFlag();
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

        async void UpdateLayouts()
        {
            if (DeviceIsSpanned)
            {   // the detail view should never be showing when spanned
                if (Navigation.NavigationStack.Count > 1)
                {
                    await Navigation.PopToRootAsync();
                }
            }
        }
    }
}
