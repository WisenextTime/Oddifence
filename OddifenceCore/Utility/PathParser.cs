using System.IO;

namespace OddifenceCore.Utility;

public static class PathParser
{
	/// <summary>
	/// To standardize the path-name for cross-platform
	/// </summary>
	/// <param name="path">The path name.</param>
	/// <returns>The standardizing path-name.</returns>
	public static string StandardizingPath(this string path)
	{
		var parts = path.Split('/','\\');
		return Path.Combine(parts);
	}
}