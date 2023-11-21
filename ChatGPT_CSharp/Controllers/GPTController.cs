using ChatGPT_CSharp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatGPT_CSharp.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class GPTController : ControllerBase
    {
        private readonly IGPTService _gptService;

        public GPTController(IGPTService gptService)
        {
            _gptService = gptService;
        }

        [HttpGet]
        [Route("useChatGPT")]
        public async Task<IActionResult> UseChatGPT(string query)
        {
            try
            {
                var result = await _gptService.GetGPTAnswer(Environment.GetEnvironmentVariable("ChatGPTApiKey"), query);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
