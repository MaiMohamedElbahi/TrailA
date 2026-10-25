using TrailA.Models;

namespace TrailA.REPOs.Interface
{
    public interface IServiceCustom : IGenericRepo<Service>
    {
        Task<bool> Deletebyapp(int id);
    }
}
