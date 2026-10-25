using TrailA.Models;

namespace TrailA.REPOs.Interface
{
    public interface ICustomerCustom : IGenericRepo<Customer>
    {
        Task<List<Vehicle>> getall(int id);
    }
}
