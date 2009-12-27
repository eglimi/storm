using System;
using BusinessLayer.DomainModel;

namespace TestAppConsole
{
	/// <summary>
	/// Summary description for TestAppConsole.
	/// </summary>
	class TestAppConsole
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			start();

			Person person = new Person();
			person.Name = "Winiger";
			person.Password = "test";

			Address address = new Address();
			address.Street = "Reussblickstr. 15";
			address.PostalCode = "5621";
			address.City = "Zufikon";
			address.Email = "marc@winiger.ch";

			//person.AddAddress(address);
			
			Console.WriteLine(person);
			Console.WriteLine(address);

			exit();
		}

		#region Dekoration
		static private void start()
		{
			Console.WriteLine(new String('=', 70));
			Console.WriteLine(new String(' ', 24) + "OOXGen TestAppConsole");
			Console.WriteLine(new String('=', 70));
			Console.WriteLine();
		}

		static private void exit()
		{
			Console.WriteLine(new String('=', 70));
			Console.WriteLine();
			Console.WriteLine("Taste drücken ...");
			Console.ReadLine();
		}
		#endregion
	}
}
