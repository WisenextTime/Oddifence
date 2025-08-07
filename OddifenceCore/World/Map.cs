using System;
using System.Collections.Generic;
using System.Linq;

namespace OddifenceCore.World;

public class Map
{
	public string Description = "";
	public List<MapItem> Items;
	public string Name = "";
	public (uint Width, uint Height) Size;
	public List<string> Tiles;

	public Map(uint width, uint height)
	{
		if (width == 0 || height == 0) throw new AggregateException("Width and height cannot be 0");
		Size = (width, height);
		Tiles = Enumerable.Repeat("Void", (int)(width * height)).ToList();
	}
}