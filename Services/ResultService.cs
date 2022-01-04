using JSONMinMax.IServices;
using JSONMinMax.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace JSONMinMax.Services
{
    public class ResultService : IResultService
    {
        public ResultValues FindMinMaxIds(string url)
        {
            var employeeList = Download_Serialized_Json_Data(url);
            List<int> idList = employeeList.Select(a => Convert.ToInt32(a.id)).ToList();
            int minId = idList[0], maxId = idList[0];
            for (int i = 1; i < idList.Count(); i++)
            {
                if (idList[i] >= maxId)
                {
                    maxId = idList[i];
                }
                if (idList[i] <= minId)
                {
                    minId = idList[i];
                }
            }
            return new ResultValues()
            {
                MaximumId = maxId,
                MinimumId = minId
            };
        }

        //fetches data from url and converts into object
        private static List<User> Download_Serialized_Json_Data(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("user-agent", "Only a test!");
                string json = webClient.DownloadString(url);
                return !string.IsNullOrEmpty(json) ? JsonConvert.DeserializeObject<List<User>>(json) : new List<User>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
