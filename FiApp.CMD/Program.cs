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

			var userController = new UserController(name);
			if (userController.IsNewUser)
			{
				Console.WriteLine("Вы новый пользователь");
				Console.WriteLine("Пол: ");
				var gender = Console.ReadLine();

				DateTime birthDate = ParseDate();
				double weight = ParseDouble("Вес");
				double height = ParseDouble("Рост");

				userController.SetNewUserData(gender, birthDate, weight, height);
			}

			Console.WriteLine(userController.CurrentUser.ToString());
			Console.ReadKey();
		}

		private static DateTime ParseDate()
		{
			DateTime birthDate;
			while (true)
			{
				Console.WriteLine("Дата рождения:");
				if (DateTime.TryParse(Console.ReadLine(), out birthDate))
				{
					break;
				}
				else
				{
					Console.WriteLine("Кривая дата");
				}
			}

			return birthDate;
		}

		public static double ParseDouble(string name)
		{
			double value;
			while (true)
			{
				Console.WriteLine($"Введите {name}:");
				if (double.TryParse(Console.ReadLine(), out value))
				{
					break;
				}
				else
				{
					Console.WriteLine($"Кривые данные для {name}");
				}
			}

			return value;
		}
	}
}
