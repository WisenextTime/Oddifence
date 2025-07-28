using System.Text;

namespace OddifenceCore.Utility;

public static class PathParser
{
	public static string ToStandardPath(string path)
	{
		var builder = new StringBuilder();
		var parts = path.Split(':');
		foreach (var part in parts)
		{
			switch (part)
			{
				case "user":
					builder.Append(Vars.DataDirectory);
					break;
				default:
					builder.Append(part);
					break;
			}
		}
		return builder.ToString();
	}
}