using Microsoft.AspNetCore.Mvc;
using VoyageCare.Shared;
using System.Linq;

namespace VoyageCare.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CareHomeController : ControllerBase
    { 
        [HttpGet]
        public async Task<IEnumerable<CareHome>> GetAll()
        {
           return (await DataClient.GetAllAsync<CareHome>()).OrderBy(home => home.Name).ToList();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Save(CareHome careHome)
        {
            try
            {
                return await DataClient.UpdateAsync(careHome);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}