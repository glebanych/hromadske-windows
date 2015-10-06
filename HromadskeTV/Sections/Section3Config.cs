using System;
using System.Collections.Generic;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.Twitter;
using HromadskeTV.Config;
using HromadskeTV.OAuth;
using HromadskeTV.ViewModels;

namespace HromadskeTV.Sections
{
    public class Section3Config : SectionConfigBase<TwitterSchema>
    {
        public override DataProviderBase<TwitterSchema> DataProvider
        {
            get
            {
                return new TwitterDataProvider(new TwitterDataConfig
                {
                    QueryType = "usertimeline",
                    Query = @"S_Andrushko",
                    Tokens = OAuthTokensRepository.GetTokens(1429)
                });
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("Section3ListPage");
            }
        }


        public override ListPageConfig<TwitterSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<TwitterSchema>
                {
                    Title = "Андрушко Сергій",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.UserName.ToSafeString();
                        viewModel.SubTitle = item.Text.ToSafeString();
                        viewModel.Description = "";
                        viewModel.Image = item.UserProfileImageUrl.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return new NavigationInfo
                        {
                            Type = NavigationType.DeepLink,
                            TargetUri = new Uri(item.Url)
                        };
                    }
                };
            }
        }

        public override DetailPageConfig<TwitterSchema> DetailPage
        {
            get { return null; }
        }
    }
}
