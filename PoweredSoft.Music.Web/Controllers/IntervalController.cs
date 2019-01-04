using Microsoft.AspNetCore.Mvc;
using PoweredSoft.Music.Theory;
using PoweredSoft.Music.Theory.Core;
using System.Collections.Generic;

namespace PoweredSoft.Music.Web.Controllers
{
    [ApiController]
    public class IntervalController : Controller
    {
        [HttpGet, Route("api/[controller]s")]
        public IEnumerable<IInterval> GetIntervals([FromServices]IIntervalService intervalService) => intervalService.GetIntervals();


    }
}
