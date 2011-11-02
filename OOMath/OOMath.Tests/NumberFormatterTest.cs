using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOMath.Tests {


	/// <summary>
	///This is a test class for NumberFormatterTest and is intended
	///to contain all NumberFormatterTest Unit Tests
	///</summary>
	[TestClass()]
	public class NumberFormatterTest {
		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext { get; set; }

		#region Additional test attributes
		//
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion

		[TestMethod]
		public void BasicNaturalToStringTest() {
			Assert.AreEqual("6", NumberFormatter.Base10.ToString(Natural.Six));
			Assert.AreEqual("0", NumberFormatter.Base10.ToString(Natural.Zero));
		}

		static readonly Random rand = new Random();
		static readonly int[] bases = new[] { 2, 8, 10, 16 };
		[TestMethod]
		public void ThoroughNaturalToStringTest() {
			for (int i = 0; i < 200; i++) {
				var num = rand.Next(4321);
				var toBase = bases[rand.Next(bases.Length)];

				Assert.AreEqual(
					Convert.ToString(num, toBase),
					NumberFormatter.ForBase(toBase).ToString(Conversion.ToNatural(num)),
					ignoreCase: true
				);
			}
		}
	}
}