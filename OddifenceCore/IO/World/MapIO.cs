using Newtonsoft.Json;
using OddifenceCore.IO.File;

namespace OddifenceCore.IO.World;

public static class MapIO
{
	public static string SaveMap(MapModel map)
	{
		return JsonConvert.SerializeObject(map);
	}

	public static MapModel LoadMap(string text)
	{
		return JsonConvert.DeserializeObject<MapModel>(text);
	}
}