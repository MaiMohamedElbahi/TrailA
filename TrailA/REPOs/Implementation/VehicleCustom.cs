using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrailA.Data;
using TrailA.DTOs;
using TrailA.Models;
using TrailA.REPOs.Interface;

namespace TrailA.REPOs.Implementation
{
    public class VehicleCustom : GenericRepo<Vehicle>, IVehicleCustom
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper mapper;

        public VehicleCustom(AppDbContext appDbContext, IMapper mapper) : base(appDbContext)
        {
            _appDbContext = appDbContext;
            this.mapper = mapper;
        }
        public async Task<bool> existxust(int id)
        {
            var x = await _appDbContext.Customers.FindAsync(id);
            if(x == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task<int> Create(CreateVehicle vehicle)
        {
            if (await existxust(vehicle.CustomeId) == false)
            {
                return 0;
            }
            if (await duplicate(vehicle.PlateNumer) == true)
            {
                return 1;
            }
            var cust = mapper.Map<Vehicle>(vehicle);
            await _appDbContext.Vehicles.AddAsync(cust);
            return 2;
        }
        public async Task<bool> duplicate(string num)
        {
            var x = await _appDbContext.Vehicles.Where(e => e.PlateNumer == num).FirstOrDefaultAsync();
            if(x == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
