using System.Linq;
using Xamarin.Forms;

namespace SmartHome
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = DeviceManager.Instance.Value.Devices
                .OrderBy(d => d.Name)
                .ToLookup(d => d.Name[0].ToString());
        }
    }
}
