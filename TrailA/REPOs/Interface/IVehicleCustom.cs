using TrailA.DTOs;
using TrailA.Models;

namespace TrailA.REPOs.Interface
{
    public interface IVehicleCustom : IGenericRepo<Vehicle>
    {
        Task<bool> existxust(int id);
        Task<bool> duplicate(string num);
        Task<int> Create(CreateVehicle vehicle);
    }
}
