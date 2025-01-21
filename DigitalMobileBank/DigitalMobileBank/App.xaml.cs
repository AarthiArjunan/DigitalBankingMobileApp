namespace DigitalMobileBank
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MDAxQDMyMzgyZTMwMmUzMGFMV081MVlpVnJ5aHJyQzUzMFFBOUJwZ1B0YWkxNC80WnA3SHdvbmdqNzA9");
            MainPage = new AppShell();

        }
    }
}
