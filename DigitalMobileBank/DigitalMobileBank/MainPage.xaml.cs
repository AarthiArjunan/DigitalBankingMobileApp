using DigitalMobileBank.ViewModel;

namespace DigitalMobileBank
{
    public partial class MainPage : ContentPage
    {
        private CardsViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
        }

        private void SfCarousel_SelectionChanged(object sender, Syncfusion.Maui.Core.Carousel.SelectionChangedEventArgs e)
        {

        }

        private void SfButton_Clicked(object sender, EventArgs e)
        {
            bottomSheet.Show();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.FilterContacts(e.NewTextValue);
        }
    }

}
