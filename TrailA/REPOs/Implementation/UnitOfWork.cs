using TrailA.Data;
using TrailA.Models;
using TrailA.REPOs.Interface;

namespace TrailA.REPOs.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerCustom Customers { get; set; }
        public IVehicleCustom Vehicles { get; set; }
        public IAppointmentCustom Appointments { get; set; }
        public IServiceCustom Services { get; set; }
        public  IGenericRepo<Mechanic> Mechanics { get; set; }
        private readonly AppDbContext appDbContext;

        public UnitOfWork(ICustomerCustom customers, IVehicleCustom vehicles, IAppointmentCustom appointments, IServiceCustom services, IGenericRepo<Mechanic> mechanics, AppDbContext appDbContext)
        {
            Customers = customers;
            Vehicles = vehicles;
            Appointments = appointments;
            Services = services;
            Mechanics = mechanics;
            this.appDbContext = appDbContext;
        }

        public async Task Save()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}
