using System.Collections.Generic;

namespace ACM.BL
{
	public class Customer
	{
		public Customer() : this(0)
		{
		}

		public Customer(int id)
		{
			CustomerId = id;
			INSTANCE_COUNT++;
		}

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

		public static int INSTANCE_COUNT { get; private set; }

		/// <summary>
		/// Validates the customer data.
		/// </summary>
		/// <returns></returns>
		public bool Validate()
		{
			var isValid = true;

			if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
			if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

			return isValid;
		}
	}
}
