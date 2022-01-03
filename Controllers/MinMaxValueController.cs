using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace JSONMinMax.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class MinMaxValueController : ControllerBase
    {
        public MinMaxValueController()
        {
        }

        [HttpGet]
        public string GetMinMaxValue()
        {
            var employeeList = Download_serialized_json_data<Employees>();
            List<int> idList = employeeList.Select(a => Convert.ToInt32(a.id)).ToList();
            int minId = idList[0], maxId = idList[0];
            for(int i = 1; i < idList.Count(); i++)
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
            return string.Concat("Minimum Id : " + minId, "\n", "Maximum Id : " + maxId);
        }
        private static List<Employee> Download_serialized_json_data<T>() where T : new()
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("user-agent", "Only a test!");
                string json = webClient.DownloadString("https://api.github.com/users/hadley/orgs");
                return !string.IsNullOrEmpty(json) ? JsonConvert.DeserializeObject<List<Employee>>(json) : new List<Employee>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
