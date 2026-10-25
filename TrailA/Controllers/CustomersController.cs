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
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomer customer)
        {
            var cust = mapper.Map<Customer>(customer);
            await unitOfWork.Customers.Add(cust);
            await unitOfWork.Save();
            return Ok(cust);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cust = await unitOfWork.Customers.getall(id);
            var customer = await unitOfWork.Customers.Get(id);
            if (cust == null)
            {
                return NotFound();
            }
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<ReadVehicle>>(cust));
        }
    }
}
