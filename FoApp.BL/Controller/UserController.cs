﻿using FoApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Linq;

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
		public List<User> Users { get; }

		public User CurrentUser { get; }

		public bool IsNewUser { get; } = false;

		public UserController(string userName)
		{
			if (string.IsNullOrWhiteSpace(userName))
				throw new ArgumentNullException("Имя Null или пусто", nameof(userName));

			Users = GetUsersData();

			CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

			if (CurrentUser == null)
			{
				CurrentUser = new User(userName);
				Users.Add(CurrentUser);
				IsNewUser = true;
				Save();
			}

		}

		public void SetNewUserData(string genderName, DateTime birthDate, double height = 1, double weight = 1)
		{
			CurrentUser.Gender = new Gender(genderName);
			CurrentUser.BirthDate = birthDate;
			CurrentUser.Weight = weight;
			CurrentUser.Height = height;
			Save();
		}
		/// <summary>
		/// Получить список пользователей
		/// </summary>
		/// <returns></returns>
		private List<User> GetUsersData()
		{
			var formatter = new BinaryFormatter();
			using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
			{
				if (fs.Length >0 && formatter.Deserialize(fs) is List<User> users)
				{
					return users;
				}
				else
				{
					return new List<User>();
				}					
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
				formatter.Serialize(fs, Users);
			}
		}


	}
}
