using Microsoft.AspNetCore.Mvc;

namespace webapi;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class DicomController
    : ControllerBase
{
    private AppSettings config;
    public DicomController(AppSettings config)
    {
        this.config = config;
    }

    [HttpGet("ConfigSample")]
    public Task<string?> GetConfigSample()
    {
        return Task.FromResult(config.Sample);
    }

    [HttpGet("ConfigTest")]
    public Task<string> GetConfigTest()
    {
        return Task.FromResult(config.Test);
    } 
}
