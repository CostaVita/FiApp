using System;
using System.Collections.Generic;
using System.Text;

namespace FoApp.BL.Model
{
	/// <summary>
	/// Пользователь
	/// </summary>
	public class User
	{
		/// <summary>
		/// Имя
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Пол
		/// </summary>
		public Gender Gender { get; }

		/// <summary>
		/// Дата рождения
		/// </summary>
		public DateTime BirthDate { get; }

		/// <summary>
		/// Вес
		/// </summary>
		public double Weight { get; set; }

		/// <summary>
		/// Рост
		/// </summary>
		public double Height { get; set; }

		/// <summary>
		/// Создать нового пользователя
		/// </summary>
		/// <param name="name">Имя</param>
		/// <param name="gender">Пол</param>
		/// <param name="birthDate">Дата рождения</param>
		/// <param name="weight">вес</param>
		/// <param name="height">рост</param>
		public User(string name, Gender gender, DateTime birthDate, double weight, double height)
		{
			#region Проверка условий
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException("Имя пользователя пусто или null", nameof(name));

			if (gender == null)
				throw new ArgumentNullException("Пол не может быть null", nameof(gender));

			if (birthDate < DateTime.Parse("01.01.1900") && birthDate >= DateTime.Now)
				throw new ArgumentNullException("дата рождения не соответствует", nameof(birthDate));

			if (weight <= 0)
				throw new ArgumentNullException("Вес не соответствует", nameof(weight));

			if (height <= 0)
				throw new ArgumentNullException("Рост рождения не соответствует", nameof(height));
			#endregion

			Name = name;
			Gender = gender;
			BirthDate = birthDate;
			Weight = weight;
			Height = height;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
