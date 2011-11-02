using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOMath.Tests {


	/// <summary>
	///This is a test class for NaturalTest and is intended
	///to contain all NaturalTest Unit Tests
	///</summary>
	[TestClass()]
	public class NaturalTest {
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
		public void EqualityTest() {
			Assert.IsTrue(Natural.Four.Equals(Natural.Four));
			Assert.IsFalse(Natural.Four.Equals(null));
			Assert.IsTrue(Natural.Four.Equals(new Natural(Natural.Three)));

			Assert.IsTrue((Natural)null == null);
			Assert.IsTrue((Natural)null != Natural.Four);
			Assert.IsTrue(Natural.Four != null);
		}

		[TestMethod]
		public void AdditionTest() {
			Assert.IsNull(Natural.Five + null);
			Assert.IsNull(null + Natural.Five);

			Assert.AreEqual(Natural.Five, Natural.Two + Natural.Three);
			Assert.AreEqual(Natural.Five, Natural.Three + Natural.Two);

			Assert.AreEqual(Natural.Four, Natural.Zero + Natural.Four);
			Assert.AreEqual(Natural.Four, Natural.Four + Natural.Zero);
		}

		[TestMethod]
		public void ComparisonTest() {
			Assert.IsTrue(Natural.Five >= null);
			Assert.IsFalse(null >= Natural.Five);

			Assert.IsTrue(Natural.Three < Natural.Five);
			Assert.IsTrue(Natural.Five > Natural.Three);

			Assert.IsTrue(Natural.Four <= Natural.Five);
			Assert.IsTrue(Natural.Five >= Natural.Four);

			Assert.IsTrue(Natural.Five >= new Natural(Natural.Four));
			Assert.IsTrue(Natural.Five <= new Natural(Natural.Four));

			Assert.IsFalse(Natural.Three > Natural.Five);
			Assert.IsFalse(Natural.Five < Natural.Three);

			Assert.IsTrue(Natural.Three > Natural.Zero);
			Assert.IsTrue(Natural.Zero < Natural.Three);
		}

		[TestMethod]
		public void MultiplicationTest() {
			Assert.IsNull(Natural.Five * null);
			Assert.IsNull(null * Natural.Five);

			Assert.AreEqual(Natural.Six, Natural.Two * Natural.Three);
			Assert.AreEqual(Natural.Six, Natural.Three * Natural.Two);

			Assert.AreEqual(Natural.Four, Natural.Four * Natural.One);
			Assert.AreEqual(Natural.Four, Natural.One * Natural.Four);

			Assert.AreEqual(Natural.Zero, Natural.Zero * Natural.Two);
			Assert.AreEqual(Natural.Zero, Natural.Two * Natural.Zero);
		}
	}
}