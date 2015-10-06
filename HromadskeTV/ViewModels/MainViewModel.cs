using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AppStudio.Common;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Twitter;
using AppStudio.DataProviders.YouTube;
using AppStudio.DataProviders.Facebook;
using AppStudio.DataProviders.Menu;
using AppStudio.DataProviders.Html;
using AppStudio.DataProviders.LocalStorage;
using HromadskeTV.Sections;


namespace HromadskeTV.ViewModels
{
    public class MainViewModel : ObservableBase
    {
        public MainViewModel(int visibleItems)
        {
            this.Twitter = new ListViewModel<TwitterSchema>(new TwitterConfig(), visibleItems);
            this.YouTube = new ListViewModel<YouTubeSchema>(new YouTubeConfig(), visibleItems);
            this.Facebook = new ListViewModel<FacebookSchema>(new FacebookConfig(), visibleItems);
            this.Section1 = new ListViewModel<MenuSchema>(new Section1Config());
            this.Section7 = new ListViewModel<HtmlSchema>(new Section7Config(), visibleItems);
            Actions = new List<ActionInfo>();

            if (GetViewModels().Any(vm => !vm.HasLocalData))
            {
                Actions.Add(new ActionInfo
                {
                    Command = new RelayCommand(Refresh),
                    Style = ActionKnownStyles.Refresh,
                    Name = "RefreshButton",
                    Type = ActionType.Primary
                });
            }
        }

        public ListViewModel<TwitterSchema> Twitter { get; private set; }
        public ListViewModel<YouTubeSchema> YouTube { get; private set; }
        public ListViewModel<FacebookSchema> Facebook { get; private set; }
        public ListViewModel<MenuSchema> Section1 { get; private set; }
        public ListViewModel<HtmlSchema> Section7 { get; private set; }

        public RelayCommand<INavigable> SectionHeaderClickCommand
        {
            get
            {
                return new RelayCommand<INavigable>(item =>
                    {
                        NavigationService.NavigateTo(item);
                    });
            }
        }

        public string LastUpdated
        {
            get 
            { 
                return GetViewModels().Select(vm => vm.LastUpdated)
                            .OrderByDescending(d => d).FirstOrDefault(); 
            }
        }

        public List<ActionInfo> Actions { get; private set; }

        public bool HasActions
        {
            get
            {
                return Actions != null && Actions.Count > 0;
            }
        }

        public async Task LoadDataAsync()
        {
            var loadDataTasks = GetViewModels().Select(vm => vm.LoadDataAsync());

            await Task.WhenAll(loadDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private async void Refresh()
        {
            var refreshDataTasks = GetViewModels()
                                        .Where(vm => !vm.HasLocalData)
                                        .Select(vm => vm.LoadDataAsync(true));

            await Task.WhenAll(refreshDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private IEnumerable<DataViewModelBase> GetViewModels()
        {
            yield return Twitter;
            yield return YouTube;
            yield return Facebook;
            yield return Section1;
            yield return Section7;
        }
    }
}
