using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_AutoMapper.AutoMapperClass
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<EmployeeDto, Employee>().ForMember(dest => dest.City, opt => opt.MapFrom(src => src.CurrentCity)) ;
		}
	}
}
