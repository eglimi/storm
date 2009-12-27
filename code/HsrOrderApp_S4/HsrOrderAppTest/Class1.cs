using System;
using Storm.Lib;
using HsrOrderApp.BusinessLayer.DomainModel;

namespace HsrOrderAppTest
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class TestClass
	{
		private Random r = new Random(DateTime.Now.Millisecond);


		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			TestClass tc = new TestClass();
			tc.test();
			Console.ReadLine();
		}

		public void test()
		{
			Registry.Instance.init(this);

			Person person = (Person)((Person.PersonFinder)Registry.Instance.getFinder(typeof(Person))).findByName("megli")[0];
			Console.WriteLine(person);

		
		}
	}
}
