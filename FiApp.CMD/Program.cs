using FoApp.BL.Controller;
using System;

namespace FiApp.CMD
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Имя пользователя:");
			var name = Console.ReadLine();

			Console.WriteLine("Пол:");
			var gender = Console.ReadLine();

			Console.WriteLine("Дата рождения:");
			var birthDate = DateTime.Parse(Console.ReadLine()); //todo в try parse

			Console.WriteLine("Вес:");
			var weight = double.Parse(Console.ReadLine()); 

			Console.WriteLine("Рост:");
			var height = double.Parse(Console.ReadLine());

			var userController = new UserController(name, gender, birthDate, weight, height);
			userController.Save();
		}
	}
}
