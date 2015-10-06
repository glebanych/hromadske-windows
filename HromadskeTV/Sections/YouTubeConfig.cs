using System;
using System.Collections.Generic;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.YouTube;
using HromadskeTV.Config;
using HromadskeTV.OAuth;
using HromadskeTV.ViewModels;

namespace HromadskeTV.Sections
{
    public class YouTubeConfig : SectionConfigBase<YouTubeSchema>
    {
        public override DataProviderBase<YouTubeSchema> DataProvider
        {
            get
            {
                return new YouTubeDataProvider(new YouTubeDataConfig
                {
                    QueryType = "channels",
                    Query = @"HromadskeTV",
                    Tokens = OAuthTokensRepository.GetTokens(26666)
                });
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("YouTubeListPage");
            }
        }

        public override ListPageConfig<YouTubeSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<YouTubeSchema>
                {
                    Title = "YouTube",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Summary.ToSafeString();
                        viewModel.Description = "";
                        viewModel.Image = item.ImageUrl.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("YouTubeDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<YouTubeSchema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, YouTubeSchema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "Detail";
                    viewModel.Title = null;
                    viewModel.Description = item.Summary.ToSafeString();
                    viewModel.Image = null;
                    viewModel.Content = item.EmbedHtmlFragment;
                });

				var actions = new List<ActionConfig<YouTubeSchema>>
				{
                    ActionConfig<YouTubeSchema>.Link("Go To Source", (item) => item.ExternalUrl.ToSafeString()),
				};

                return new DetailPageConfig<YouTubeSchema>
                {
                    Title = "YouTube",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

    }
}
