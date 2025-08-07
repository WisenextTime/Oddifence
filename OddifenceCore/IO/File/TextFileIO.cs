using System;
using System.IO;
using System.Text;
using OddifenceCore.Utility;

namespace OddifenceCore.IO.File;

public static class TextFileIO
{
	/// <summary>
	///     To write the texts into the target file.
	/// </summary>
	/// <param name="text"></param>
	/// <param name="path">The target file path.</param>
	/// <exception cref="ArgumentException">The target path is null.</exception>
	public static void WriteToFile(string text, string path)
	{
		if (path.StandardizePath() is null) throw new ArgumentException("Path cannot be null.", nameof(path));
		var sourcePath = path.StandardizePath();
		var file = System.IO.File.Open(sourcePath, FileMode.Create);
		AddText(file, text);
		file.Flush();
		file.Dispose();
	}

	/// <summary>
	///     To read texts from target file.
	/// </summary>
	/// <param name="path">The target file path.</param>
	/// <exception cref="ArgumentException">The target path is null.</exception>
	/// <returns>The texts in target file.</returns>
	public static string ReadFromFile(string path)
	{
		if (path.StandardizePath() is null) throw new ArgumentException("Path cannot be null.", nameof(path));
		var sourcePath = path.StandardizePath();
		var file = System.IO.File.Open(sourcePath, FileMode.Open);
		var text = ReadText(file);
		file.Dispose();
		return text;
	}

	private static void AddText(FileStream fs, string value)
	{
		var info = new UTF8Encoding(true).GetBytes(value);
		fs.Write(info, 0, info.Length);
	}

	private static string ReadText(FileStream fs)
	{
		fs.Seek(0, SeekOrigin.Begin);
		using var reader = new StreamReader(fs, Encoding.UTF8, leaveOpen: true);
		return reader.ReadToEnd();
	}
}