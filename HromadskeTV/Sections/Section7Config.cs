using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.Html;
using AppStudio.DataProviders.LocalStorage;
using HromadskeTV.Config;
using HromadskeTV.ViewModels;

namespace HromadskeTV.Sections
{
    public class Section7Config : SectionConfigBase<HtmlSchema>
    {
        public override DataProviderBase<HtmlSchema> DataProvider
        {
            get
            {
                return new HtmlDataProvider(new LocalStorageDataConfig
                {
                    FilePath = "/Assets/Data/Section7.htm"
                });
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("Section7ListPage");
            }
        }


        public override ListPageConfig<HtmlSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<HtmlSchema>
                {
                    Title = "Про додаток",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Content = item.Content;
                    },
                    NavigationInfo = (item) =>
                    {
                        return null;
                    }
                };
            }
        }

        public override DetailPageConfig<HtmlSchema> DetailPage
        {
            get { return null; }
        }
    }
}
