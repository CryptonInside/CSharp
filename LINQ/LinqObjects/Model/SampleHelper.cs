using System;
using System.Collections.Generic;
using System.Text;

namespace LinqObjects.Model
{
    class SampleHelper
    {
		public static List<Person> CreatePersons()
		{
			List<Person> result = new List<Person>();
			result.Add(new Person()
			{
				FirstName = "Иван",
				LastName = "Иванов",
				City = "Ростов",
				Age = 13
			});
			result.Add(new Person()
			{
				FirstName = "Иван",
				LastName = "Сидоров",
				City = "Ростов",
				Age = 78
			});
			result.Add(new Person()
			{
				FirstName = "Сергей",
				LastName = "Петров",
				City = "Сочи",
				Age = 78
			});
			result.Add(new Person()
			{
				FirstName = "Александр",
				LastName = "Пушкин",
				City = "Сочи",
				Age = 93
			});
			result.Add(new Person()
			{
				FirstName = "Антон",
				LastName = "Пушкин",
				City = "Сочи",
				Age = 78
			});
			return result;
		}
	}
}
