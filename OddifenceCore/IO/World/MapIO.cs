using System.Linq;
using OddifenceCore.IO.File;
using OddifenceCore.World;
using Tomlyn;

namespace OddifenceCore.IO.World;

public static class MapIO
{
	private static Map FromModel(MapModel model)
	{
		var map = new Map(model.SizeX, model.SizeY)
		{
			Name = model.Name,
			Description = model.Description,
			Image = model.Image,
			Tiles = model.Tiles.Select(t => (Map.Tile)t).ToList(),
			Items = model.Items.Select(FromModel).ToList(),
			SpecialRules = model.SpecialRules,
		};
		return map;
	}

	private static MapItem FromModel(MapItemModel model)
	{
		var mapItem = new MapItem
		{
			Content = model.Content,
			Position = (model.X, model.Y),
			Type = (MapItem.ItemType)model.Type
		};
		return mapItem;
	}

	private static Map FromText(string text)
	{
		var model = Toml.Parse(text).ToModel<MapModel>();
		return FromModel(model);
	}

	private static MapModel ToModel(Map map)
	{
		var model = new MapModel()
		{
			Name = map.Name,
			SizeX = map.Size.X,
			SizeY = map.Size.Y,
			Description = map.Description,
			Image = map.Image,
			Tiles = map.Tiles.Select(t => (int)t).ToList(),
			Items = map.Items.Select(ToModel).ToList(),
			SpecialRules = map.SpecialRules,
		};
		return model;
	}

	private static MapItemModel ToModel(MapItem mapItem)
	{
		var itemModel = new MapItemModel()
		{
			Content = mapItem.Content,
			X = mapItem.Position.X,
			Y = mapItem.Position.Y,
			Type = (int)mapItem.Type
		};
		return itemModel;
	}

	private static string ToText<T>(T model)
	{
		var text = Toml.FromModel(model);
		return text;
	}

	public static void SaveMap(Map map, string path)
	{
		var text = ToText(ToModel(map));
		TextFileIO.WriteToFile(text, path);
	}

	public static Map LoadMap(string path)
	{
		var text = TextFileIO.ReadFromFile(path);
		return FromText(text);
	}
}