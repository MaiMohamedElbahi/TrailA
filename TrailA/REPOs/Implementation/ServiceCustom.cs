using Microsoft.EntityFrameworkCore;
using TrailA.Data;
using TrailA.Models;
using TrailA.REPOs.Interface;

namespace TrailA.REPOs.Implementation
{
   public class ServiceCustom : GenericRepo<Service>, IServiceCustom
    {
        private readonly AppDbContext _appDbContext;

        public ServiceCustom(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> Deletebyapp(int id)
        {
            var appo = await _appDbContext.AppointmentServices.Where(e => e.ServiceId == id).ToListAsync();
            if (appo == null || appo.Count() == 0)
            {
                var ser = await _appDbContext.Services.FindAsync(id);
                 _appDbContext.Services.Remove(ser);
                return true;
            }
            return false;
        }
    
    }
}
