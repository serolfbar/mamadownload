using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using api.Interfaces;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MamaDownloadController : ControllerBase
    {
        private readonly ILogger<MamaDownloadController> _logger;
        private readonly IDownloadService _downloadService;

        public MamaDownloadController(
                ILogger<MamaDownloadController> logger,
                IDownloadService downloadService)
        {
            _logger = logger;
            _downloadService = downloadService;
        }

        [HttpPost("Download")]
        public IActionResult Download([FromBody] BodyParameters body)
        {
            try 
            {   
                _logger.Log(LogLevel.Debug, body.YoutubeLink);
                Console.WriteLine(body.YoutubeLink);
                _downloadService.Download(body.YoutubeLink);
                return Ok();
            }
            catch(Exception exception) 
            {
                Console.WriteLine(exception.Message);
                return BadRequest(exception.Message);
            }
        }
    }

    public class BodyParameters 
    {
        public string YoutubeLink { get; set; }
    }
}
