using System.IO;

namespace OddifenceCore.Utility;

public static class PathParser
{
	/// <summary>
	///     To standardize the path-name for cross-platform
	/// </summary>
	/// <param name="path">The path name.</param>
	/// <returns>The standardized path-name.</returns>
	public static string StandardizePath(this string path)
	{
		var parts = path.Split('/', '\\');
		return Path.Combine(parts);
	}
}