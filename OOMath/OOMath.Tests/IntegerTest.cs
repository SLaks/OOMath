using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOMath.Tests {


	/// <summary>
	///This is a test class for IntegerTest and is intended
	///to contain all IntegerTest Unit Tests
	///</summary>
	[TestClass()]
	public class IntegerTest {
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
		public void NegativeTest() {
			Assert.IsFalse(Integer.Negative(Natural.Five).IsPositive);

			Assert.AreEqual(Integer.Zero, Integer.Negative(Natural.Zero));
		}
		[TestMethod]
		public void PositiveTest() {
			Assert.IsTrue(Integer.Positive(Natural.Five).IsPositive);

			Assert.AreEqual(Integer.Zero, Integer.Positive(Natural.Zero));
		}
		[TestMethod]
		public void NegationTest() {
			Assert.AreEqual(-Integer.Positive(Natural.Five), Integer.Negative(Natural.Five));

			Assert.AreEqual(Integer.Zero, -Integer.Zero);
		}

		[TestMethod]
		public void AdditionTest() {
			Assert.AreEqual(Integer.Positive(Natural.Five), Integer.Positive(Natural.Three) + Integer.Positive(Natural.Two));
			Assert.AreEqual(Integer.Positive(Natural.Five), Integer.Positive(Natural.Two) + Integer.Positive(Natural.Three));

			Assert.AreEqual(Integer.Positive(Natural.Five), Integer.Positive(Natural.Six) + Integer.Negative(Natural.One));
			Assert.AreEqual(Integer.Positive(Natural.Five), Integer.Negative(Natural.One) + Integer.Positive(Natural.Six));

			Assert.AreEqual(Integer.Negative(Natural.Two), Integer.Negative(Natural.Three) + Integer.Positive(Natural.One));
			Assert.AreEqual(Integer.Negative(Natural.Two), Integer.Positive(Natural.One) + Integer.Negative(Natural.Three));

			Assert.AreEqual(Integer.Negative(Natural.Two), Integer.Positive(Natural.Four) + Integer.Negative(Natural.Six));
			Assert.AreEqual(Integer.Negative(Natural.Two), Integer.Negative(Natural.Six) + Integer.Positive(Natural.Four));

			Assert.AreEqual(Integer.Positive(Natural.Three), Integer.Zero + Integer.Positive(Natural.Three));
			Assert.AreEqual(Integer.Positive(Natural.Three), Integer.Positive(Natural.Three) + Integer.Zero);
		}

		[TestMethod]
		public void SubtractionTest() {
			Assert.AreEqual(Integer.MinusOne, Integer.Positive(Natural.Three) - Integer.Positive(Natural.Four));
			Assert.AreEqual(Integer.One, Integer.Positive(Natural.Four) - Integer.Positive(Natural.Three));

			Assert.AreEqual(Integer.Negative(Natural.Three), Integer.Zero - Integer.Positive(Natural.Three));
			Assert.AreEqual(Integer.Positive(Natural.Three), Integer.Positive(Natural.Three) - Integer.Zero);
		}

		[TestMethod]
		public void MultiplicationTest() {
			Assert.AreEqual(Integer.Positive(Natural.Six), Integer.Positive(Natural.Three) * Integer.Positive(Natural.Two));
			Assert.AreEqual(Integer.Positive(Natural.Six), Integer.Positive(Natural.Two) * Integer.Positive(Natural.Three));

			Assert.AreEqual(Integer.Negative(Natural.Five), Integer.Positive(Natural.Five) * Integer.Negative(Natural.One));
			Assert.AreEqual(Integer.Negative(Natural.Five), Integer.Negative(Natural.One) * Integer.Positive(Natural.Five));

			Assert.AreEqual(Integer.Positive(Natural.Six), Integer.Negative(Natural.Three) * Integer.Negative(Natural.Two));
			Assert.AreEqual(Integer.Positive(Natural.Six), Integer.Negative(Natural.Two) * Integer.Negative(Natural.Three));

			Assert.AreEqual(Integer.Zero, Integer.Negative(Natural.Three) * Integer.Zero);
			Assert.AreEqual(Integer.Zero, Integer.Zero * Integer.Positive(Natural.Three));
		}

		static readonly Random rand = new Random();
		[TestMethod]
		public void ThoroughArithmeticTest() {
			for (int i = 0; i < 100; i++) {
				int b1 = rand.Next(-123, 123), b2 = rand.Next(-321, 321);
				Integer m1 = Conversion.ToInteger(b1), m2 = Conversion.ToInteger(b2);

				Assert.AreEqual(b1 + b2, Conversion.ToInt32(m1 + m2));
				Assert.AreEqual(-b1 + b2, Conversion.ToInt32(-m1 + m2));
				Assert.AreEqual(b1 - b2, Conversion.ToInt32(m1 - m2));
				Assert.AreEqual(b1 * b2, Conversion.ToInt32(m1 * m2));
			}
		}
	}
}