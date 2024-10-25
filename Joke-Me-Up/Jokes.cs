using System;
using System.IO;
using System.Collections.Generic;
namespace JokeMeUp
{
	public static class Jokes
	{
		private static List<string> _jokes = new List<string>();

		public static void init()
		{
			StreamReader reader = new StreamReader("shortjokes.csv");

			string line = reader.ReadLine();

			while (line != null && line.Length != 0)
			{
				line = reader.ReadLine();
				line = line.Substring(line.IndexOf(","));
				_jokes.Add(line);
			}
		}

		public static string GetJoke()
		{
			Random rand = new Random();
			return _jokes[rand.Next(0, _jokes.Count)];
		}
	}
}

