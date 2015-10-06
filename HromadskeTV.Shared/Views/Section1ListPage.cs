using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Menu;
using HromadskeTV;
using HromadskeTV.Sections;
using HromadskeTV.ViewModels;

namespace HromadskeTV.Views
{
    public sealed partial class Section1ListPage : PageBase
    {
        public ListViewModel<MenuSchema> ViewModel { get; set; }

        public Section1ListPage()
        {
            this.ViewModel = new ListViewModel<MenuSchema>(new Section1Config());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
