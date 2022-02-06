using System;
using System.Collections.Generic;
using LinqObjects.Model;
using System.Linq;

namespace LinqObjects
{
	class Program
	{
		static void Main(string[] args)
		{
			SQLStyleQuery();

			MethodStyleQuery();

			IEnumerableTest();

			IEnumerableTest2();

			TakeSample();

			Console.ReadLine();

		}

		static void SQLStyleQuery()
		{
			Console.WriteLine("SQL стиль запроса поиска людей до 16 лет");
			List<Person> people = SampleHelper.CreatePersons();

			var results = from p in people
						  where p.Age < 16
						  select new { p.FirstName, p.LastName, p.Age };
			foreach (var p in results)
			{
				Console.WriteLine(p.FirstName + " " + p.LastName + ": " + p.Age);
			}

			PrintDiv();
		}

		static void MethodStyleQuery()
		{
			Console.WriteLine("Методы - поиск людей до 16 лет");
			List<Person> people = SampleHelper.CreatePersons();

			IEnumerable<Person> results = people.Where(r => r.Age < 16);

			foreach (var p in results)
			{
				Console.WriteLine(p.FirstName + " " + p.LastName + ": " + p.Age);
			}

			PrintDiv();
		}

		static void IEnumerableTest()
		{
			Console.WriteLine("Пример с IEnumerable");
			List<Person> people = SampleHelper.CreatePersons();

			IEnumerable<Person> results = people.Where(r => r.Age < 16);

			foreach (var p in results)
			{
				Console.WriteLine(p.FirstName + " " + p.LastName + ": " + p.Age);
			}

			Console.WriteLine("Добавим значение:");
			people.Add(new Person() { FirstName = "Михаил", LastName = "Сергеев", Age = 10 });

			foreach (var p in results)
			{
				Console.WriteLine(p.FirstName + " " + p.LastName + ": " + p.Age);
			}

			PrintDiv();
		}

		static void IEnumerableTest2()
		{
			Console.WriteLine("Пример с двумя IEnumerable");
			List<Person> people = SampleHelper.CreatePersons();

			IEnumerable<Person> byAge = people.Where(r => r.Age < 16);
			IEnumerable<Person> byCityAndAge = byAge.Where(r => r.City == "Ростов");
			foreach (var p in byCityAndAge)
			{
				Console.WriteLine(p.FirstName + " " + p.LastName + ": " + p.Age);
			}

			PrintDiv();
		}

		static void TakeSample()
		{
			Console.WriteLine("Пример с Take");
			List<Person> people = SampleHelper.CreatePersons();
			//.Skip(10) - пропустить первые 10 результата
			//.Take(10) - после 10 пропущенных взять 10 элементов
			IEnumerable<Person> result = people.Where(r => r.Age < 16).Skip(10).Take(10);
			var res = people.FirstOrDefault(r => r.FirstName == "Иван");

			if(res != null)
            {
                Console.WriteLine(res.FirstName);
            }

			if(people.Any(r => r.Age < 16))
                Console.WriteLine("В массиве есть хотябы один человек имеющий возраст меньше 16и лет");
			PrintDiv();
		}

		static void PrintDiv()
		{
			Console.WriteLine("-----------------------------------------------");
		}
	}
}
