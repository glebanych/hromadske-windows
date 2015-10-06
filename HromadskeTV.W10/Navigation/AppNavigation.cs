using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AppStudio.Common.Navigation;
using Windows.UI.Xaml;

namespace HromadskeTV.Navigation
{
    public class AppNavigation
    {
        private NavigationNode _active;

        static AppNavigation()
        {

        }

        public NavigationNode Active
        {
            get
            {
                return _active;
            }
            set
            {
                if (_active != null)
                {
                    _active.IsSelected = false;
                }
                _active = value;
                if (_active != null)
                {
                    _active.IsSelected = true;
                }
            }
        }


        public ObservableCollection<NavigationNode> Nodes { get; private set; }

        public void LoadNavigation()
        {
            Nodes = new ObservableCollection<NavigationNode>();

            Nodes.Add(new ItemNavigationNode
            {
                Title = @"Hromadske TV",
                Label = "Home",
                IsSelected = true,
                NavigationInfo = NavigationInfo.FromPage("HomePage")
            });

            Nodes.Add(new ItemNavigationNode
            {
                Label = "Twitter",
                NavigationInfo = NavigationInfo.FromPage("TwitterListPage")
            });

            Nodes.Add(new ItemNavigationNode
            {
                Label = "YouTube",
                NavigationInfo = NavigationInfo.FromPage("YouTubeListPage")
            });

            Nodes.Add(new ItemNavigationNode
            {
                Label = "Facebook",
                NavigationInfo = NavigationInfo.FromPage("FacebookListPage")
            });

            Nodes.Add(new GroupNavigationNode
            {
                Label = "Інші твіти",
                Visibility = Visibility.Visible,
                Nodes = new ObservableCollection<NavigationNode>()
                {
                    new ItemNavigationNode
                    {
                        Label = "Станко Настя",
                        NavigationInfo = NavigationInfo.FromPage("Section2ListPage")
                    },
                    new ItemNavigationNode
                    {
                        Label = "Cкрипін Роман",
                        NavigationInfo = NavigationInfo.FromPage("CListPage")
                    },
                    new ItemNavigationNode
                    {
                        Label = "Андрушко Сергій",
                        NavigationInfo = NavigationInfo.FromPage("Section3ListPage")
                    },
                    new ItemNavigationNode
                    {
                        Label = "Гуменюк Наталя",
                        NavigationInfo = NavigationInfo.FromPage("Section4ListPage")
                    },
                    new ItemNavigationNode
                    {
                        Label = "Кутєпов Богдан",
                        NavigationInfo = NavigationInfo.FromPage("Section5ListPage")
                    },
                    new ItemNavigationNode
                    {
                        Label = "Баштовий Андрій",
                        NavigationInfo = NavigationInfo.FromPage("Section6ListPage")
                    },
                }
            });

            Nodes.Add(new ItemNavigationNode
            {
                Label = "Про додаток",
                NavigationInfo = NavigationInfo.FromPage("Section7ListPage")
            });

        }

        public NavigationNode FindPage(Type pageType)
        {
            return GetAllItemNodes(Nodes).FirstOrDefault(n => n.NavigationInfo.Type == NavigationType.Page && n.NavigationInfo.TargetPage == pageType.Name);
        }

        private IEnumerable<ItemNavigationNode> GetAllItemNodes(IEnumerable<NavigationNode> nodes)
        {
            foreach (var node in nodes)
            {
                if (node is ItemNavigationNode)
                {
                    yield return node as ItemNavigationNode;
                }
                else if(node is GroupNavigationNode)
                {
                    var gNode = node as GroupNavigationNode;

                    foreach (var innerNode in GetAllItemNodes(gNode.Nodes))
                    {
                        yield return innerNode;
                    }
                }
            }
        }
    }
}
