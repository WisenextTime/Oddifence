using System;

namespace OddifenceCore;

public static class Vars
{
	public static readonly int[] Version = [0, 1, 0];

	public static readonly string DataDirectory =
		Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Oddifence\";
}