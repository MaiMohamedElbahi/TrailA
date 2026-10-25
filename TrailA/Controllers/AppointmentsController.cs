using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrailA.DTOs;
using TrailA.REPOs.Interface;

namespace TrailA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AppointmentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("Upcoming")]
        public async Task<IActionResult> Upcooming()
        {
            var app = await unitOfWork.Appointments.upcoming();
            return Ok(mapper.Map<List<ReadAppointment>>(app));
        }

        [HttpGet("CountByStatus")]
        public async Task<IActionResult> CountByStatus()
        {
            var app = await unitOfWork.Appointments.countby();
            return Ok(app);
        }
        [HttpGet("TotalRevenue")]
        public async Task<IActionResult> TotalRevenue()
        {
            var app = await unitOfWork.Appointments.totalrev();
            return Ok(app);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> patch(int id, string status)
        {
            var cust = await unitOfWork.Appointments.Get(id);
            if (cust == null)
            {
                return NotFound();
            }
            if (status == "Pending" || status == "Cancelled" || status == "Completed" )
            {
                cust.Status = status;
            }
            else
            {
                return BadRequest("Invalid Status");
            }
            await unitOfWork.Appointments.Update(cust);
            await unitOfWork.Save();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, int mechanicId)
        {
            var app = await unitOfWork.Appointments.Get(id);
            if (app == null)
            {
                return NotFound();
            }
            var mech = await unitOfWork.Mechanics.Get(mechanicId);
            if (mech == null)
            {
                return NotFound();
            }
            app.MechanicId = mechanicId; 
            await unitOfWork.Appointments.Update(app);
            await unitOfWork.Save();
            return Ok();
        }
    }
}
