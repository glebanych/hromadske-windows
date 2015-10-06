using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Twitter;
using HromadskeTV;
using HromadskeTV.Sections;
using HromadskeTV.ViewModels;

namespace HromadskeTV.Views
{
    public sealed partial class Section2ListPage : PageBase
    {
        public ListViewModel<TwitterSchema> ViewModel { get; set; }

        public Section2ListPage()
        {
            this.ViewModel = new ListViewModel<TwitterSchema>(new Section2Config());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
