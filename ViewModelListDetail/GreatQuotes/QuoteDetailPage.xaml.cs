using Xamarin.Forms;
using GreatQuotes.ViewModels;

namespace GreatQuotes
{
    public partial class QuoteDetailPage : ContentPage
    {
        public QuoteDetailPage()
        {
            // Remember that the view model is a singleton that's exposed by the App class.
            BindingContext = App.MainViewModel.SelectedQuote;

            // This clears the ListView selection.
            App.MainViewModel.SelectedQuote = null;
            InitializeComponent();
        }
    }
}

