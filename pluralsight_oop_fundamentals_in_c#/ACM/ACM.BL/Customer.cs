namespace ACM.BL
{
	public class Customer
	{
		public int CustomerId { get; private set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }

		public string FullName
		{
			get
			{
				string fullName = LastName;
				if (!string.IsNullOrWhiteSpace(FirstName))
				{
					if (!string.IsNullOrWhiteSpace(fullName))
					{
						fullName += ", ";
					}
					fullName += FirstName;
				}
				return fullName;
			}
		}

		public static int InstanceCount { get; private set; }

		public Customer()
		{
			Customer.InstanceCount++;
		}
	}
}
