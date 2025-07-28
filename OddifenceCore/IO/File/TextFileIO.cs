using System.IO;
using System.Text;
using OddifenceCore.Utility;

namespace OddifenceCore.IO.File;

public static class TextFileIO
{
	public static void WriteToFile(string text, string path)
	{
		if (PathParser.ToStandardPath(path) is null) return;
		var sourcePath = PathParser.ToStandardPath(path);
		var file = System.IO.File.Open(path, FileMode.Create);
		AddText(file, text);
		file.Flush();
		file.Dispose();
	}

	public static string ReadFromFile(string path)
	{
		if (PathParser.ToStandardPath(path) is null) return null;
		var sourcePath = PathParser.ToStandardPath(path);
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