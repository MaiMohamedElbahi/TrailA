using Microsoft.EntityFrameworkCore;
using TrailA.Data;
using TrailA.Models;
using TrailA.REPOs.Interface;

namespace TrailA.REPOs.Implementation
{
    public class CustomerCustom : GenericRepo<Customer>, ICustomerCustom
    {
        private readonly AppDbContext _appDbContext;

        public CustomerCustom(AppDbContext appDbContext) : base(appDbContext) 
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Vehicle>> getall(int id)
        {
            var veh = await _appDbContext.Vehicles.Where(v => v.CustomeId == id).ToListAsync();
            return veh;
        }
    }
}
