using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_AutoMapper.AutoMapperClass;

namespace WebApi_AutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;

		public EmployeeController(IMapper mapper)
		{
			_mapper = mapper;
		}

		[HttpGet]
		public Employee GetEmployee() {
			EmployeeDto employeeDto = new EmployeeDto()
			{
				Name = "Zbigniew",
				Surname = "Karolczuk",
				InsuranceNumber = "ER998313004",
				CurrentCity = "Krakow"
			};

			return _mapper.Map<Employee>(employeeDto);
		}
	}

}