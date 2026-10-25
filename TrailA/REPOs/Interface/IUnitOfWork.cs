using TrailA.Models;

namespace TrailA.REPOs.Interface
{
    public interface IUnitOfWork
    {
        ICustomerCustom Customers { get; }
        IVehicleCustom Vehicles { get; }
        IServiceCustom Services { get; }
        IAppointmentCustom Appointments { get; }
        IGenericRepo<Mechanic> Mechanics { get; }

        Task Save();
    }
}
