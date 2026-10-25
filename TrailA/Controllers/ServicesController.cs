using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrailA.REPOs.Interface;

namespace TrailA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ServicesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var service = await unitOfWork.Services.Get(id);
            if (service == null)
            {
                return NotFound();
            }
            var flag = await unitOfWork.Services.Deletebyapp(id);

            if (!flag)
            {
                return Conflict();
            }
            return NoContent();
        }

    }
}
