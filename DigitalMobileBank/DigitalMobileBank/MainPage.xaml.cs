using CommunityToolkit.Maui.Core.Platform;
using DigitalMobileBank.ViewModel;
using Syncfusion.Maui.Carousel;
using Syncfusion.Maui.Toolkit.BottomSheet;
using KeyboardExtensions = CommunityToolkit.Maui.Core.Platform.KeyboardExtensions;
namespace DigitalMobileBank
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void SfCarousel_SelectionChanged(object sender, Syncfusion.Maui.Core.Carousel.SelectionChangedEventArgs e)
        {
            if(e.NewItem != null && e.NewItem is CardsModel item)
            {
                _viewModel.CurrentAmount = item.CurrentBalance;
                _viewModel.CardNumber = item.CardNumber;
            }
        }

        private void SfButton_Clicked(object sender, EventArgs e)
        {
            bottomSheet.Show();
            bottomSheet.ZIndex = 1;
        }

        private void bottomSheet_StateChanged(object sender, Syncfusion.Maui.Toolkit.BottomSheet.StateChangedEventArgs e)
        {
            if(sender is SfBottomSheet bottomSheet)
            {
                if(e.NewState == BottomSheetState.Collapsed)
                {
                    bottomSheet.State = BottomSheetState.Hidden;
                }
                else if(e.NewState == BottomSheetState.Hidden)
                {
                    bottomSheet.ZIndex = -1;
                    if (entry.IsSoftKeyboardShowing())
                    {
                        entry.HideKeyboardAsync();
                    }

                }
            }
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.FilterContacts(e.NewTextValue);
        }
    }

}
