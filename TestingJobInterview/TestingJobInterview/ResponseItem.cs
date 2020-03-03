using System;
using System.Collections.Generic;
using System.Text;

namespace TestingJobInterview
{
    public class ResponseItem
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public ResponseItem(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
