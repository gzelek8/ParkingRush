using AutoMapper;
using ParkingRush.Application.DTO;
using ParkingRush.Domain;
using Point = System.Drawing.Point;
using Type = System.Type;

namespace ParkingRush.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Point, PointDto>().ReverseMap();
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<Type, TypeDto>().ReverseMap();
        CreateMap<Parking, ParkingDto>().ReverseMap();
        CreateMap<Parking, CreateParkingDto>().ReverseMap();
        CreateMap<Parking, UpdateParkingDto>().ReverseMap();

    }
}