using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Menu;
using HromadskeTV.Config;
using HromadskeTV.ViewModels;

namespace HromadskeTV.Sections
{
    public class Section1Config : SectionConfigBase<MenuSchema>
    {
        public override DataProviderBase<MenuSchema> DataProvider
        {
            get
            {
                return new LocalStorageDataProvider<MenuSchema>(new LocalStorageDataConfig
                {
                    FilePath = "/Assets/Data/Section1.json"
                });
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("Section1ListPage");
            }
        }


        public override ListPageConfig<MenuSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<MenuSchema>
                {
                    Title = "Інші твіти",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title;
                        viewModel.Image = item.Icon;
                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromMenu(item);
                    }
                };
            }
        }

        public override DetailPageConfig<MenuSchema> DetailPage
        {
            get { return null; }
        }
    }
}
