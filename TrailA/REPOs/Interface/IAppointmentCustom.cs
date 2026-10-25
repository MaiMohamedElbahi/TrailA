using TrailA.DTOs;
using TrailA.Models;

namespace TrailA.REPOs.Interface
{
    public interface IAppointmentCustom : IGenericRepo<Appointment>
    {

        Task<decimal> totalrev();
        Task<List<countapp>> countby();
        Task<List<Appointment>> upcoming();
    }
}
