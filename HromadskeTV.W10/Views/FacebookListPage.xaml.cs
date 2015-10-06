using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Facebook;
using HromadskeTV;
using HromadskeTV.Sections;
using HromadskeTV.ViewModels;

namespace HromadskeTV.Views
{
    public sealed partial class FacebookListPage : PageBase
    {
        public FacebookListPage()
        {
            this.ViewModel = new ListViewModel<FacebookSchema>(new FacebookConfig());
            this.InitializeComponent();
        }

        public ListViewModel<FacebookSchema> ViewModel { get; set; }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
