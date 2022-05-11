using Microsoft.AspNetCore.Mvc;
using VoyageCare.Shared;
using System.Linq;

namespace VoyageCare.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QualificationController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<CareQualification>> GetAll()
        {
            return (await DataClient.GetAllAsync<CareQualification>()).OrderBy(qual => qual.Type).ToList();
        }

        [HttpGet("{qualID}")]
        public async Task<CareQualification> Get(int qualID)
        {
            return await DataClient.Get<CareQualification>(qualID);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Save(CareQualification qual)
        {
            try
            {
                return await DataClient.UpdateAsync(qual);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{qualID}")]
        public async Task<bool> Delete(int qualID)
        {
            var qual = await DataClient.Get<CareQualification>(qualID);

            return await DataClient.DeleteAsync(qual);
        }
    }
}