using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_AutoMapper.AutoMapperClass
{
	public class AutoMapperProfile : Profile
	{
		public static AddressDto reserveArrdess = new AddressDto() {
			Street = "Katowicka 16",
			ZipCode = "43-400",
			City = "Cieszyn"
		};

		public AutoMapperProfile()
		{
			CreateMap<EmployeeDto, Employee>()
				.ForMember(dest => dest.City, opt => opt.MapFrom(src => src.CurrentCity))
				.ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.CurrentCity == reserveArrdess.City ? reserveArrdess : src.Address))
				.ReverseMap();
			CreateMap<AddressDto, Address>().ReverseMap();
		}
	}
}
