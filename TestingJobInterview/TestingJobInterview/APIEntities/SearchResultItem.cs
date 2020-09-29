using System;
using System.Collections.Generic;
using System.Text;

namespace TestingJobInterview
{
    public class SearchResultItem
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public SearchResultItem(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
