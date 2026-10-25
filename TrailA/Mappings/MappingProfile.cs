using AutoMapper;
using TrailA.DTOs;
using TrailA.Models;

namespace TrailA.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomer, Customer>().ReverseMap();
            CreateMap<ReadCustomer, Customer>().ReverseMap();

            CreateMap<CreateVehicle, Vehicle>().ReverseMap();
            CreateMap<ReadVehicle, Vehicle>().ReverseMap();

            CreateMap<ReadAppointment, Appointment>().ReverseMap();
            CreateMap<UpdateMechanic, Mechanic>().ReverseMap();

            CreateMap<UpdateMechanic, Mechanic>().ReverseMap();
        }
    }
}
