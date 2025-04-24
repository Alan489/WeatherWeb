using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Toolbelt.Blazor.SpeechSynthesis;



namespace Weather2EB.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 public class VoiceController : ControllerBase
 {
  private SpeechSynthesis _ss;
  public VoiceController(SpeechSynthesis ss) 
  { 
   _ss = ss;
  }

  private async Task<string> speak(string whatSay)
  {
   Guid guid = Guid.NewGuid();
   string r = guid.ToString();

   await _ss.SpeakAsync("Fuck me");
   
   
   return r;
  }

  [HttpGet]
  public async Task<string> Get(string whatSay)
  {
   return await speak(whatSay);
  }
 }
}
