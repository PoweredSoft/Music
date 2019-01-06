using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class ScaleController : Controller
{
    [HttpGet, Route("api/[controller]s/definitions")]
    public IEnumerable<IScaleDefinition> Definitions([FromServices]IScaleService scaleService) => scaleService.GetDefinitions();

    [HttpGet, Route("api/[controller]s/{note}")]
    public IEnumerable<IScale> Scales([FromServices]IScaleService scaleService, string note) => scaleService.GetScales(note);

    [HttpGet, Route("api/[controller]s/{note}/{type}")]
    public IScale Scale([FromServices]IScaleService scaleService, string note, Scales type) => scaleService.GetScale(note, type); 
}