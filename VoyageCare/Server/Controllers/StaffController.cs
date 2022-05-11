using Microsoft.AspNetCore.Mvc;
using VoyageCare.Shared;
using System.Linq;

namespace VoyageCare.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<CareHomeStaff>> GetAll()
        {
            return (await DataClient.GetAllAsync<CareHomeStaff>()).OrderBy(staff => $"{staff.Surname}{staff.Forename}").ToList();
        }

        [HttpGet("{staffID}")]
        public async Task<CareHomeStaff> Get(int staffID)
        {
            return await DataClient.Get<CareHomeStaff>(staffID);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Save(CareHomeStaff staff)
        {
            try
            {
                return await DataClient.UpdateAsync(staff);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{staffID}")]
        public async Task<bool> Delete(int staffID)
        {
            var staff = await DataClient.Get<CareHomeStaff>(staffID);

            return await DataClient.DeleteAsync(staff);
        }
    }
}