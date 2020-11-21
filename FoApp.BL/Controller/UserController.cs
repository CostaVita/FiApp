﻿using FoApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FoApp.BL.Controller
{
	/// <summary>
	/// Контроллер пользователяя
	/// </summary>
	public class UserController
	{
		/// <summary>
		/// Пользователь приложения
		/// </summary>
		public User User { get; }

		public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
		{
			var gender = new Gender(genderName);
			User = new User(userName, gender, birthDate, weight, height);
		}

		public UserController()
		{
			var formatter = new BinaryFormatter();
			using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
			{
				if (formatter.Deserialize(fs) is User user)
				{
					User = user;
				}

				// TODO: Что делать если пользователя не прочитали
			}

		}

		/// <summary>
		/// Получить данные пользователя
		/// </summary>
		public void Save()
		{
			var formatter = new BinaryFormatter();
			using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, User);
			}
		}


	}
}
