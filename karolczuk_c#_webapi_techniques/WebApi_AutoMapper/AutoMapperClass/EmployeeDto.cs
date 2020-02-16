using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApi_AutoMapper.AutoMapperClass
{
	[DataContract]
	public class EmployeeDto
	{
		[DataMember]
		public int Id { get; set; }
		//[DataMember]
		public string Name { get; set; }
		//[DataMember]
		public string Surname { get; set; }
		[DataMember]
		public string InsuranceNumber { get; set; }
		//[DataMember]
		public string CurrentCity { get; set; }
		[DataMember]
		public AddressDto Address { get; set; }
	}
}
