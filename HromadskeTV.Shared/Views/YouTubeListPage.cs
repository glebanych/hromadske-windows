using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.YouTube;
using HromadskeTV;
using HromadskeTV.Sections;
using HromadskeTV.ViewModels;

namespace HromadskeTV.Views
{
    public sealed partial class YouTubeListPage : PageBase
    {
        public ListViewModel<YouTubeSchema> ViewModel { get; set; }

        public YouTubeListPage()
        {
            this.ViewModel = new ListViewModel<YouTubeSchema>(new YouTubeConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
