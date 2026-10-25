using Microsoft.EntityFrameworkCore;
using TrailA.Data;
using TrailA.DTOs;
using TrailA.Models;
using TrailA.REPOs.Interface;

namespace TrailA.REPOs.Implementation
{
    public class AppointmentCustom : GenericRepo<Appointment>, IAppointmentCustom
    {
        private readonly AppDbContext _appDbContext;

        public AppointmentCustom(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Appointment>> upcoming()
        {
            var currenctdate = DateTime.Now;
            var appointments = await _appDbContext.Appointments.Where(e => e.AppointmentDate > currenctdate).ToListAsync();
            return appointments;
        }
        public async Task<List<countapp>> countby()
        {
            var appointments = await _appDbContext.Appointments.GroupBy(e=>e.Status).Select(g => new countapp
            {
                count = g.Count(),
                status = g.Key
            }).ToListAsync();
            return appointments;
        }
        public async Task<decimal> totalrev()
        {
            if(await _appDbContext.Appointments.Where(e => e.Status == "Completed").ToListAsync() == null)
            {
                return 0;
            }
            var appointments =  _appDbContext.Appointments.Where(e => e.Status == "Completed").Select(e => e.ActualPrice).Sum();
            return appointments;
        }

    }
}
