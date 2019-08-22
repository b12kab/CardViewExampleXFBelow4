using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace testy
{
    public class ViewModel : INotifyPropertyChanged
    {
        INavigation _navigation;

        public ViewModel(INavigation navigation)
        {
            _navigation = navigation;
            PageList = CreateOnboardingList();
        }

        List<PageItem> CreateOnboardingList()
        {
            var retList = new List<PageItem>
            {
                new PageItem
                {
                    Title="One",
                    SubTitle="Search one",
                    LinkTitle="Touch this link to go to Google",
                    LinkCommand = new Command<string>((url) => ShowLink(url)),
                    LinkUri = "https://google.com",
                },
                new PageItem
                {
                    Title="Two",
                    SubTitle="Search two",
                    LinkTitle="Touch this link to go to Dogpile",
                    LinkCommand = new Command<string>((url) => ShowLink(url)),
                    LinkUri = "https://www.dogpile.com",
                },
                new PageItem
                {
                    Title="Three",
                    SubTitle="Search three",
                    LinkTitle="Touch this link to go to Bing",
                    LinkCommand = new Command<string>((url) => ShowLink(url)),
                    LinkUri = "https://bing.com",
                },
                new PageItem
                {
                    Title="Four",
                    SubTitle="Search four",
                    LinkTitle="Touch this link to go to Duck Duck Go",
                    LinkCommand = new Command<string>((url) => ShowLink(url)),
                    LinkUri = "https://duckduckgo.com",
                }
            };

            return retList;
        }

        /// <summary>
        /// Displays the link on a browser on the device
        /// </summary>
        /// <param name="url">URL.</param>
        void ShowLink(string url)
        {
            // Don't do anything, if it's null or empty string.
            // This is unlikely to be triggered, but better safe than sorry.
            if (String.IsNullOrEmpty(url))
                return;

            // If it's somehow bad, exit before the below command blows up
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                return;

            Device.OpenUri(new System.Uri(url));
        }

        private List<PageItem> _pageList;
        public List<PageItem> PageList
        {
            get => _pageList;
            set
            {
                _pageList = value;
                NotifyPropertyChanged("PageList");
            }
        }

        //********************************************************************
        //********************************************************************

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
