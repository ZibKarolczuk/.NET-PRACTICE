using System;
using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BLTest
{
	[TestClass]
	public class CustomerTest
	{
		[TestMethod]
		public void FullNameTestValid()
		{
			//Arrange
			var customer = new Customer { FirstName = "Zbigniew", LastName = "Karolczuk" };
			string expected = "Karolczuk, Zbigniew";

			//Act
			string actual = customer.FullName;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void FullNameLastNameEmptyTestValid()
		{
			//Arrange
			var customer = new Customer { FirstName = "Zbigniew" };
			string expected = "Zbigniew";

			//Act
			string actual = customer.FullName;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void FullNameFirstNameEmptyTestValid()
		{
			//Arrange
			var customer = new Customer { LastName = "Karolczuk" };
			string expected = "Karolczuk";

			//Act
			string actual = customer.FullName;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InstanceCountTestValid()
		{
			//Arrange
			var customer1 = new Customer();
			var customer2 = new Customer();
			var customer3 = new Customer();

			int expected = 3;

			//Act
			int actual = Customer.InstanceCount;

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
