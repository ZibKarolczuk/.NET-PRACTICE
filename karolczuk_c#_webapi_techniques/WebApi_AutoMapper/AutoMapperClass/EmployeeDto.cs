using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_AutoMapper.AutoMapperClass
{
	public class EmployeeDto
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string InsuranceNumber { get; set; }
		public string CurrentCity { get; set; }
	}
}
