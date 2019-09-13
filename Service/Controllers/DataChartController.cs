using Microsoft.AspNetCore.Mvc;
using Repository.Contract;
using Repository.Domain;
using System;
using System.Collections.Generic;
using System.Net;

namespace Service.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/data-chart")]
    public class DataChartController : ControllerBase
    {
        private readonly IChartService _service;

        public DataChartController(IChartService service)
        {
            _service = service;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ndata"></param>
        /// <param name="amount"></param>
        /// 
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ChartModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Get(int ndata, int amount)
        {
            if (ndata > 0 && amount == 0)
                return Ok(_service.Get(ndata));
            else
            if (ndata > 0 && amount > 0)
                return Ok(_service.GetVarious(ndata, amount));
            else
                return Ok(_service.GetOne(ndata));
        }
    }
}