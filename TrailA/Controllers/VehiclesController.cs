using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrailA.DTOs;
using TrailA.Models;
using TrailA.REPOs.Interface;

namespace TrailA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public VehiclesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicle vehicle)
        {
            var x = await unitOfWork.Vehicles.Create(vehicle);
            if(x == 0)
            {
                return NotFound();
            }
            if(x == 1)
            {
                return BadRequest("Can't insert duplicate platenumber");
            }
            await unitOfWork.Save();
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Get(int id, int mileage)
        {
            var cust = await unitOfWork.Vehicles.Get(id);
            if(cust == null)
            {
                return NotFound();
            }
            if(mileage > 0 && mileage < 2000000)
            {
                cust.Mileage = mileage;
            }
            else
            {
                return BadRequest("Mileage should be between 0 and 2000000");
            }
            await unitOfWork.Vehicles.Update(cust);
            await unitOfWork.Save();
            return Ok();
        }
    }
}
