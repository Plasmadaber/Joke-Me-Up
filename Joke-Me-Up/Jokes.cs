using System;
using System.IO;
using System.Collections.Generic;

/*
 * This Class is soley used to implement the ability to get a random joke
 */

namespace Joke_Me_Up
{
	public static class Jokes
	{
		private static List<string> _jokes = new List<string>();

		// Initalizes the _jokes list with all jokes from dad_jokes.csv
		public static void init()
		{
			StreamReader reader = new StreamReader("dad_jokes.csv");

			string line = reader.ReadLine();

			while (line != null && line.Length != 0)
			{
				line = reader.ReadLine();
				if (line != null) { line = line.Substring(line.IndexOf(",")+1).Replace("\"", ""); }
				int indexQuesMark = line.IndexOf("?");
				if (indexQuesMark != -1) { line = line.Substring(0, indexQuesMark + 1) + "\n\n" + line.Substring(indexQuesMark + 1); }
                _jokes.Add(line);
			}
		}

		// returns a random joke from _jokes
		public static string GetJoke()
		{
			Random rand = new Random();
			return _jokes[rand.Next(0, _jokes.Count)];
		}
	}
}

