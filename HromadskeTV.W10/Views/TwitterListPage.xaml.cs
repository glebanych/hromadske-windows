using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Twitter;
using HromadskeTV;
using HromadskeTV.Sections;
using HromadskeTV.ViewModels;

namespace HromadskeTV.Views
{
    public sealed partial class TwitterListPage : PageBase
    {
        public TwitterListPage()
        {
            this.ViewModel = new ListViewModel<TwitterSchema>(new TwitterConfig());
            this.InitializeComponent();
        }

        public ListViewModel<TwitterSchema> ViewModel { get; set; }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
