using Sample1.Views;
using Xamarin.Forms;

namespace Sample1
{
    public partial class App : Application
    {
        #region Public Constructors

        public App()
        {
            Device.SetFlags(new string[] { "Markup_Experimental", "CarouselView_Experimental", "Expander_Experimental", "Brush_Experimental", "Shapes_Experimental", "AppTheme_Experimental" });
            InitializeComponent();
            MainPage = new MainPage();
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override void OnResume()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnStart()
        {
        }

        #endregion Protected Methods
    }
}