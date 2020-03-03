﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TestingJobInterview.APIEntities
{
    public static class DeserializeHelper
    {
        public static List<ResponseItem> Deserialize(string responseContent)
        {
            var results = new List<ResponseItem>();
            dynamic deser = JsonConvert.DeserializeObject(responseContent);
            foreach (dynamic resultItem in deser.results)
            {
                string contents = "";
                foreach (dynamic descr in resultItem.descriptions)
                {
                    contents += descr.content + Environment.NewLine;
                }
                string title = resultItem.title;
                results.Add(new ResponseItem(title, contents));
            }
            return results;
        }
    }
}