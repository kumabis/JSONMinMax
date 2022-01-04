using JSONMinMax.IServices;
using JSONMinMax.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JSONMinMax.Controllers
{
    [ApiController]
    [Route("minmaxvalue/[Action]")]
    public class MinMaxValueController : ControllerBase
    {
        private readonly IResultService resultService;
        public MinMaxValueController(IResultService resultService)
        {
            this.resultService = resultService;
        }

        [ActionName("result")]
        [HttpGet]
        public ResultValues GetMinMaxValue()
        {
            string url = "https://api.github.com/users/hadley/orgs";
            try
            {
                return resultService.FindMinMaxIds(url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
