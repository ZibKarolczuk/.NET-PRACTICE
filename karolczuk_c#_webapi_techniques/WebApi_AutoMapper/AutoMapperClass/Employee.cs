using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_AutoMapper.AutoMapperClass
{
	public class Employee
	{
		public int Id { get; set; }
		//public string Name { get; set; }
		//public string Surname { get; set; }
		//public string City { get; set; }
		public string FullName { get; set; }
		public string InsuranceNumber { get; set; }
		public Address ShippingAddress { get; set; }
	}
}
