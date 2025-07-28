using System.Collections.Generic;
using System.Linq;

namespace OddifenceCore.World;

public class Map(int width = 32, int height = 32)
{
	public enum Tile
	{
		Void,
		Road,
		Base
	}
	
	public string Name = "";
	public string Description = "";
	public string Image;//Maybe useless(?)
	public (int X, int Y) Size = (width, height);
	public List<Tile> Tiles = Enumerable.Repeat(Tile.Void, width * height).ToList();
	public List<MapItem> Items = [];
	/// <summary>
	/// <para>Rule</para>
	/// </summary>
	public MapRule SpecialRules = new();
}