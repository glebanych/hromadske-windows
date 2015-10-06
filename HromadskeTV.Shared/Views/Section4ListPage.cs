using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Twitter;
using HromadskeTV;
using HromadskeTV.Sections;
using HromadskeTV.ViewModels;

namespace HromadskeTV.Views
{
    public sealed partial class Section4ListPage : PageBase
    {
        public ListViewModel<TwitterSchema> ViewModel { get; set; }

        public Section4ListPage()
        {
            this.ViewModel = new ListViewModel<TwitterSchema>(new Section4Config());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
