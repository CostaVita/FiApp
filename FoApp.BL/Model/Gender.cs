using System;

namespace FoApp.BL.Model
{
	/// <summary>
	/// Пол
	/// </summary>
	[Serializable]
	public class Gender
	{
		/// <summary>
		/// Название
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// СОздать пол
		/// </summary>
		/// <param name="name">имя поля</param>
		public Gender(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("null или пусто", nameof(name));
			}

			Name = name;
		}
	}
}