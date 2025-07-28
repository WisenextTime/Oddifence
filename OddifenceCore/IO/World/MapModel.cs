using System.Collections.Generic;
using OddifenceCore.World;

namespace OddifenceCore.IO.World;

public class MapModel
{
	public string Name { get; set; } = "";
	public string Description { get; set; } = "";
	public string Image { get; set; } = "";
	public int SizeX { get; set; } = 32;
	public int SizeY { get; set; } = 32;
	public List<MapItemModel> Items { get; set; } = [];
	public List<int> Tiles { get; set; } = [];

	public MapRule SpecialRules { get; set; } = new();
}