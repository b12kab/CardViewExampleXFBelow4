using System;
using System.Windows.Input;

namespace testy
{
    public class PageItem
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string LinkTitle { get; set; }
        public string LinkUri { get; set; }
        public ICommand LinkCommand { get; set; }
    }
}
